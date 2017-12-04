// Stephen Aranda
// 12/4/2017
// ITSE 1430
using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using SqlMovieDatabase;

namespace MovieLib.Windows
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);
            

            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"].ConnectionString;
            _database = new SqlMovieDatabase.SqlMovieDatabase(connString);

            _gridMovies.AutoGenerateColumns = false;

            UpdateList();
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnMovieAdd( object sender, EventArgs e )
        {
            var child = new MovieDetailForm("Movie Details");
            
            if (child.ShowDialog(this) != DialogResult.OK)
                return;


            //Save movie                      
            try
            {
                _database.Add(child.Movie);
            } 
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }


            UpdateList();
        }
        

        private void OnMovieEdit( object sender, EventArgs e )
        {
            var child = GetSelectedMovie();
            
            if (child == null)
            {
                MessageBox.Show(this, "Movies not available.");
                return;
            };

            EditMovie(child);
        }

        private void EditMovie( Movie movie )
        {
            var child = new MovieDetailForm("Movie Details");
            child.Movie = movie;
            
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //Save Movie
            try
            {
                _database.Update(child.Movie);
            } catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            };
            UpdateList();
        }

        private void OnMovieDelete( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            DeleteMovie(movie);
        }

        private void DeleteMovie( Movie movie )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{movie.Title}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            //Delete product
            try
            {
                _database.Remove(movie.Id);
            } catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            };
            UpdateList();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var about = new AboutMovieLib();
            about.ShowDialog(this);
        }

        public delegate void ButtonClickCall( object sender, EventArgs e );

        private void CallButton( ButtonClickCall functionToCall )
        {
            functionToCall(this, EventArgs.Empty);
        }

        // Get the selected movie from the grid
        private Movie GetSelectedMovie()
        {
            
            if (_gridMovies.SelectedRows.Count > 0)
                return _gridMovies.SelectedRows[0].DataBoundItem as Movie;

            return null;
        }

        private void UpdateList()
        {
            
            try
            {
                _bsMovies.DataSource = _database.GetAll().ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Refresh Failed");
                _bsMovies.DataSource = null;
            };

        }

       
        private IMovieDatabase _database;
        

        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Movie;

            if (item != null)
                EditMovie(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            var movie = GetSelectedMovie();

            //Handle Enter and Delete key when pressed.
            if (e.KeyCode == Keys.Enter)
            {
                if (movie != null)
                    EditMovie(movie);
            } else if (e.KeyCode == Keys.Delete)
            {
                if (movie != null)
                    DeleteMovie(movie);
            } else
                return;

            e.SuppressKeyPress = true;
        }
    }
}

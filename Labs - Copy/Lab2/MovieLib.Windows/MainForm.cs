// Stephen Aranda
// 10/9/2017
// ITSE 1430
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLib.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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

            _movie = child.Movie;
        }

       

        private void OnMovieEdit( object sender, EventArgs e )
        {
            var child = new MovieDetailForm("Movie Details");
            child.Movie = _movie;
            if (_movie == null)
            {
                MessageBox.Show(this, "Movie has not yet been defined!");
                return;
            };
            if (child.ShowDialog(this) != DialogResult.OK)               
                return;
            

            _movie = child.Movie;
        }

        

        private void OnMovieDelete( object sender, EventArgs e )
        {
            if (_movie == null)
            {
                MessageBox.Show(this, "Movie has not yet been defined!");
                return;
            };
                

            if (MessageBox.Show(this, $"Are you sure you want to delete '{_movie.Title}'? ",
                               "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
               

            _movie = null;
        }

        private Movie _movie;

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

       
    }
}

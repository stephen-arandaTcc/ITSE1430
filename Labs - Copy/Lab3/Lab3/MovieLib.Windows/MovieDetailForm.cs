// Stephen Aranda
// 11/1/2017
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
    public partial class MovieDetailForm : Form
    {

        #region Construction

        public MovieDetailForm()
        {
            InitializeComponent();
        }

        public MovieDetailForm (string title) : this()
        {
            Text = title;
        }

        public MovieDetailForm (string title, Movie movie) : this(title)
        {
            Movie = movie;
        }
        #endregion

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            if (Movie != null)
            {
                _txtTitle.Text = Movie.Title;
                _txtDescription.Text = Movie.Description;
                _txtLength.Text = Movie.Length.ToString();
                _chkOwned.Checked = Movie.IsOwned;
            };

            ValidateChildren();
        }
        public Movie Movie { get; set; }

       

        private void OnCancel( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowError(string message, string title)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnSave( object sender, EventArgs e )
        {
            if(!ValidateChildren())
            {
                return;
            };

            var movie = new Movie();
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;

            movie.Length = GetLength(_txtLength);
            movie.IsOwned = _chkOwned.Checked;            

            Movie = movie;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private int GetLength( TextBox control )
        {
            if (Int32.TryParse(control.Text, out int length))
                return length;

                      
            return -1;
        }

        private void OnValidatingLength( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;

            if (GetLength(tb) < 0)
            {
                e.Cancel = true;
                _errors.SetError(_txtLength, "Length must be >= 0.");
            } else
                _errors.SetError(_txtLength, "");
        }

        private void OnValidatingTitle( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;
            if (String.IsNullOrEmpty(tb.Text))
                _errors.SetError(tb, "Title is required");
            else
                _errors.SetError(tb, "");
        }

        
    }
}

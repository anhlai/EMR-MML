using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextBoxMmlLoader
{
    public partial class TextBoxMmlLoaderForm : Form
    {
        public TextBoxMmlLoaderForm()
        {
            InitializeComponent();
        }

        private string mMml;
        private string mDescription;

        public string MML
        {
            get { return mMml; }
        }

        public string Description
        {
            get { return mDescription; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            mMml = textBoxMml.Text;
            mDescription = textBoxDescription.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}

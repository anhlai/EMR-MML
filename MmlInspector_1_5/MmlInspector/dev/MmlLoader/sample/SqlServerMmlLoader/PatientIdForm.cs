using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SqlServerMmlLoader
{
    public partial class PatientIdForm : Form
    {
        public PatientIdForm()
        {
            InitializeComponent();
        }

        private string mPatientId;

        public string PatientId
        {
            get { return mPatientId; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            mPatientId = textBoxPatientId.Text;

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

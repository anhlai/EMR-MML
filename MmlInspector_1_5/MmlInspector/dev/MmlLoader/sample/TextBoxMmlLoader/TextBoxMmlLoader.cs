using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBoxMmlLoader
{
    public class TextBoxMmlLoader : Yos731.MmlLoader.IMmlLoader
    {
        public bool Load(out string mml, out string description)
        {
            TextBoxMmlLoaderForm form = new TextBoxMmlLoaderForm();

            if (System.Windows.Forms.DialogResult.OK == form.ShowDialog())
            {
                mml = form.MML;
                description = form.Description;

                return true;
            }
            else
            {
                mml = null;
                description = null;

                return false;
            }
        }
    }
}

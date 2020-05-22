using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Adam6224
{
    /// <summary>
    /// Summary description for FormPrompt.
    /// </summary>
    public partial class FormPrompt : Form
    {
        public FormPrompt()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public void IncreaseBar(int i_iValue)
        {
            progressBar1.Value = i_iValue;
        }

    }
}
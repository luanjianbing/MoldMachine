﻿using System;

using System.Collections.Generic;
using System.Windows.Forms;

namespace APAX_Controller_WinCE_Sample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new Form_APAX_Controller());
        }
    }
}
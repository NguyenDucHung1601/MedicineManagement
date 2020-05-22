﻿using MedicineManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicineManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(new Form1());
            ControllerPrescription ctr = new ControllerPrescription();

            DataTable dt = ctr.Search(new Models.Prescription { });

        }
    }
}
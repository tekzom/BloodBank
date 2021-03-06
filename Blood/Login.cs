﻿using Blood.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood
{
    public partial class Login : Form
    {
        NurseTableAdapter n = new NurseTableAdapter();


        public void WM()
        {
            tu.ForeColor = SystemColors.GrayText;
            tu.Text = "User ID";
            this.tu.Leave += new System.EventHandler(this.uLeave);
            this.tu.Enter += new System.EventHandler(this.uEnter);

            tp.ForeColor = SystemColors.GrayText;
            tp.Text = "Password";
            this.tp.Leave += new System.EventHandler(this.pLeave);
            this.tp.Enter += new System.EventHandler(this.pEnter);
        }

        private void uLeave(object sender, EventArgs e)
        {
            if (tu.Text.Length == 0)
            {
                tu.Text = "User ID";
                tu.ForeColor = SystemColors.GrayText;
            }
        }
        private void uEnter(object sender, EventArgs e)
        {
            if (tu.Text == "User ID")
            {
                tu.Text = "";
                tu.ForeColor = Color.FromArgb(221, 75, 75);
            }
        }

        private void pLeave(object sender, EventArgs e)
        {
            if (tp.Text.Length == 0)
            {
                tp.Text = "Password";
                tp.ForeColor = SystemColors.GrayText;
            }
        }

        private void pEnter(object sender, EventArgs e)
        {
            if (tp.Text == "Password")
            {
                tp.Text = "";
                tp.ForeColor = Color.FromArgb(221, 75, 75); 
            }
        }

      
        Form1 F;
        public static string NurseName="";
        public Login(Form1 F)
        {
            InitializeComponent();
            WM();
            this.F = F;
        }


        private void BCon_Click_1(object sender, EventArgs e)
        {
            try
            {

                List<DataSet1.NurseRow> LN = new NurseTableAdapter().GetData().ToList<DataSet1.NurseRow>();

                foreach (DataSet1.NurseRow N in LN)
                {
                    if (N.id == int.Parse(tu.Text.ToString()) && N.password == tp.Text)
                    {
                        F.clear();
                        NurseName = N.firstname + " " + N.lastname;
                    }
                }
                Form1.Nurename = NurseName;



            }
            catch (Exception)
            {
                MessageBox.Show("user id or password incorrect");
                
            }
        }

        private void tp_TextChanged(object sender, EventArgs e)
        {

        }

        private void bshow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && tp.Text != "Password")
                tp.PasswordChar = '\0';
        }

        private void bshow_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && tp.Text != "Password")
                tp.PasswordChar = '*';
        }

        private void tp_TextChanged_1(object sender, EventArgs e)
        {
            if (tp.Text != "Password")
                tp.PasswordChar = '*';
            else
                tp.PasswordChar = '\0';
        }
    }
}

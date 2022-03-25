using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        public static string id = "";
        public static string pw = "";
        public OleDbConnection con;
        public login()//charrrotdsfsf
        {
            InitializeComponent();
            con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Users\\Mark Anthony\\WindowsFormsApp1\\WindowsFormsApp1\\LibSys.mdb");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Users\\Mark Anthony\\WindowsFormsApp1\\WindowsFormsApp1\\LibSys.mdb";
            string cmdText = "select Count(*) from users where ID=? and [Password]=?";
            using (OleDbConnection con = new OleDbConnection(constring))
            using (OleDbCommand cmd = new OleDbCommand(cmdText, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@p1", txtID.Text);
                cmd.Parameters.AddWithValue("@p2", txtPW.Text);
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    MessageBox.Show("Login Successful");
                    con.Close();
                    form lib = new form();
                    lib.Show();
                    this.Visible = false;

                }
                else
                {
                    MessageBox.Show("Invalid Credentials, Please Re-Enter");
                    con.Close();
                }
            }
        }
        public void fillstring()
        {
            id = txtID.Text;
            pw = txtPW.Text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register res = new register();
            this.Visible = false;
            res.Show();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}

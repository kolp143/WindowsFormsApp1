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
    public partial class register : Form
    {
        private OleDbConnection con;

        public register()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Users\\Mark Anthony\\WindowsFormsApp1\\WindowsFormsApp1\\LibSys.mdb");
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            login form = new login();
            this.Close();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                con.Open();
                OleDbCommand com = new OleDbCommand("Insert into users values ('" + txtSI.Text + "','" + txtFN.Text + "', '" + txtLN.Text + "', '" + txtPW.Text + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                login lib = new login();
                lib.Show();
                this.Visible = false;
                MessageBox.Show("Successfully SAVED!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);           
                con.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }


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
    public partial class form : Form
    {
        private OleDbConnection con;
        public form()
    
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\\3rdYear_1stSem\\IT-IMDBSYS31\\WindowsFormsApp1\\WindowsFormsApp1\\LibSys.mdb");
        }

        private void form_Load(object sender, EventArgs e)
        {
            loadDatagrid();
        }

        private void grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtno.Text = grid1.Rows[e.RowIndex].Cells["accession_number"].Value.ToString();
            txttitle.Text = grid1.Rows[e.RowIndex].Cells["title"].Value.ToString();
            txtauthor.Text = grid1.Rows[e.RowIndex].Cells["author"].Value.ToString();
        }
        private void loadDatagrid()
        {
            con.Open();
            OleDbCommand com = new OleDbCommand("Select * from book order by accession_number", con);
            com.ExecuteNonQuery();

            OleDbDataAdapter adap = new OleDbDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            grid1.DataSource = tab;

            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            {
                con.Open();
                OleDbCommand com = new OleDbCommand("Insert into book values ('" + txtno.Text + "', '" + txttitle.Text + "', '" + txtauthor.Text + "')", con);
                com.ExecuteNonQuery();
                MessageBox.Show("Successfully SAVED!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                loadDatagrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            con.Open();
            string no;
            no = txtno.Text;
            OleDbCommand com = new OleDbCommand("Update book SET title = '" + txttitle.Text + "', author ='" + txtauthor.Text + "' where accession_number='" + no + "'", con);
            com.ExecuteNonQuery();
            MessageBox.Show("Successfully UPDATED!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            loadDatagrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            string num = txtno.Text;
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                OleDbCommand com = new OleDbCommand("DELETE FROM book WHERE accession_number = '" + num + "' ", con);
                com.ExecuteNonQuery();
                MessageBox.Show("Successfully DELETED!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("CANCELLED!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();
            loadDatagrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand com = new OleDbCommand("SELECT * FROM book WHERE title LIKE '%" + txtSearch.Text + "%'", con);
            com.ExecuteNonQuery();

            OleDbDataAdapter adap = new OleDbDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            grid1.DataSource = tab;

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout Successful");
            login lib = new login();
            lib.Show();
            this.Visible = false;
        }
    }
    }


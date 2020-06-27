using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


namespace StockM
{
    public partial class Form1 : Form
    {
        Utility ut = new Utility();
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataAdapter da;
        

        
        public void ShowComboBox()
        {
            conn = ut.openDB();
            conn.Open();
            cmd = new OracleCommand("select * from HR.SANGD", conn);
            da = new OracleDataAdapter();
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);
            CB1.DataSource = table;
            CB1.DisplayMember = "TENSAN";
            CB1.ValueMember = "MASAN";
        }
        public void ShowData(string sql)
        {
            Utility.OpenConnection();
            DGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            DGV.DataSource = Utility.getDataTable(sql);
        }
        public Form1()
        {
            InitializeComponent();
            Utility.OpenConnection();
            DGV.DataSource = Utility.getDataTable("Select MAGD,NGAY,KLMUA,GTMUA,KLBAN,GTBAN,KLGTRONG,GTGDRONG,ROOM,DANGSH from HR.SANGIAODICH");
            DGV.Columns["Column2"].DefaultCellStyle.Format = "dd/MM/yyyy";
            DGV.Columns["Column3"].DefaultCellStyle.Format = "#,0";
            DGV.Columns["Column4"].DefaultCellStyle.Format = "#,0";
            DGV.Columns["Column5"].DefaultCellStyle.Format = "#,0";
            DGV.Columns["Column6"].DefaultCellStyle.Format = "#,0";
            DGV.Columns["Column7"].DefaultCellStyle.Format = "#,0";
            DGV.Columns["Column8"].DefaultCellStyle.Format = "#,0";
            DGV.Columns["Column9"].DefaultCellStyle.Format = "#,0";
            DGV.Columns["Column10"].DefaultCellStyle.Format = "0.0\\%";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowComboBox();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string a = CB1.Text;
            //string sql = "select * from HR.GIAODICH where MASAN = '" + CB1.SelectedValue + "'";
            //this.ShowData(sql);
        }

        private void CB1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sql = "Select MAGD,NGAY,KLMUA,GTMUA,KLBAN,GTBAN,KLGTRONG,GTGDRONG,ROOM,DANGSH from HR.SANGIAODICH where MASAN = '" + CB1.SelectedValue + "'";
            this.ShowData(sql);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            display();
        }

        private void btn111_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "Select MAGD,NGAY,KLMUA,GTMUA,KLBAN,GTBAN,KLGTRONG,GTGDRONG,ROOM,DANGSH from HR.SANGIAODICH ";
            this.ShowData(sql);
            DGV.Update();
            DGV.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // display();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if ( textBox2.Text.Length > 0)
            {
                string sql = "Select MAGD,NGAY,KLMUA,GTMUA,KLBAN,GTBAN,KLGTRONG,GTGDRONG,ROOM,DANGSH from HR.SANGIAODICH WHERE NGAY LIKE '" + textBox2.Text + "%'";
                this.ShowData(sql);
            }
        }
        void display()
        {
            conn = ut.openDB();
            conn.Open();

            DataTable table1 = new DataTable();
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                string sql = "Select MAGD,NGAY,KLMUA,GTMUA,KLBAN,GTBAN,KLGTRONG,GTGDRONG,ROOM,DANGSH from HR.SANGIAODICH WHERE MAGD LIKE '" + textBox1.Text + "%' AND NGAY LIKE '" + textBox2.Text + "%' ";
                this.ShowData(sql);
            }
        }
    }
}

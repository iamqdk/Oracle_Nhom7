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
    public partial class Form2 : Form
    {
        Utility ut = new Utility();
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataAdapter da;
        public Form2()
        {
            InitializeComponent();
            Utility.OpenConnection();
            DGV1.DataSource = Utility.getDataTable("Select TENSAN,GIOITHIEU from HR.SANGD");
        }
       
        public void ShowData(string sql)
        {
            Utility.OpenConnection();
            DGV1.DataSource = Utility.getDataTable(sql);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void CB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string a = CBB2.Text;
            //string sql = "select * from HR.SANGD where TENSAN = '" + a + "'";
            //this.ShowData(sql);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //this.ShowComboBox();
        }


    }
}

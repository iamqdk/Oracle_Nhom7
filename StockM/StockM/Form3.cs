using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockM
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.SANGIAODICH' table. You can move, or remove it, as needed.
            this.sANGIAODICHTableAdapter.Fill(this.dataSet1.SANGIAODICH);
            // TODO: This line of code loads data into the 'dataSet3.GIAODICHSAN' table. You can move, or remove it, as needed.
            //string sql = "select GTMUA from HR.GIAODICHSAN where MAGD = SHE ";
          
            //this.gIAODICHSANTableAdapter.Fill(this.dataSet3.GIAODICHSAN);
           
        }

        private void gIAODICHSANBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //
        }
    }
}

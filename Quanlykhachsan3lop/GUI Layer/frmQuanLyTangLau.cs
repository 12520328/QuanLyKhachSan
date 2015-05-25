using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;


namespace Quanlykhachsan3lop.Màn_Hình
{
    public partial class frmQuanLyTangLau : Form
    {
        DataTable dt = new DataTable();
        //TangLauDTO _tanglauDTO = new TangLauDTO();
        public frmQuanLyTangLau()
        {
            InitializeComponent();
            dt.Columns.Add("MaTangLau", typeof(int));
            dt.Columns.Add("TenTangLau", typeof(string));
        }

        private void DanhSachVatTu()
        {
            dt.Clear();
               
        }
    }
}

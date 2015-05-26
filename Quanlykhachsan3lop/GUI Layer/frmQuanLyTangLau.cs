using DevExpress.XtraGrid;
using Quanlykhachsan3lop.Business_Logic_Layer;
using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Quanlykhachsan3lop.Màn_Hình
{
    public partial class frmQuanLyTangLau : Form
    {
        DataTable dt = new DataTable();

        public frmQuanLyTangLau()
        {
            InitializeComponent();

            // Định nghĩa Datatable tương thích với GridView.
            dt.Columns.Add("MaTangLau", typeof(int));
            dt.Columns.Add("TenTangLau", typeof(string));

            // Tắt hiển thị các button trong user control không cần sử dụng
            ucMenu.btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ucMenu.btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void frmQuanLyTangLau_Load(object sender, EventArgs e)
        {
            TangLauBUS tangLauBUS = new TangLauBUS();
            dt = tangLauBUS.LayDanhSachTangLau();
            gridControl1.DataSource = dt;

            // Bắt sự kiện cho các button trong user control.
            ucMenu.btnChiDoc.ItemClick += ucMenu_ChiDoc_Clicked;
            ucMenu.btnXoa.ItemClick += ucMenu_Xoa_Clicked;
        }
        private void ucMenu_ChiDoc_Clicked(object sender, EventArgs e)
        {
            if (gridView1.OptionsBehavior.ReadOnly == true)
            {
                ucMenu.btnChiDoc.Caption = "ĐANG Ở CHẾ ĐỘ CHỈNH SỬA";
                gridView1.OptionsBehavior.ReadOnly = false;
            }
            else
            {
                ucMenu.btnChiDoc.Caption = "ĐANG Ở CHẾ ĐỘ CHỈ ĐỌC";
                gridView1.OptionsBehavior.ReadOnly = true;
            }
        }

        private void ucMenu_Xoa_Clicked(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        // Bắt sự kiện BeforeLeaveRow để thêm nột hàng mới vào bảng dữ liệu.
        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (!gridView1.IsNewItemRow(e.RowHandle)) return;

            gridView1.EndInit();
            DataRow newDr = gridView1.GetDataRow(gridView1.DataRowCount - 1);
            TangLauDTO tangLauDTO = new TangLauDTO();
            tangLauDTO.TenTangLau = (string)newDr["TenTangLau"];
            TangLauBUS tangLauBUS = new TangLauBUS();
            tangLauBUS.ThemTangLau(tangLauDTO);
            newDr["MaTangLau"] = tangLauBUS.LayMaTangLauCuoiBang();
        }

        // Bắt sự kiện RowUpdate để thực hiện chỉnh sửa một hàng.
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.RowHandle == GridControl.NewItemRowHandle) return;

            DialogResult dg = MessageBox.Show("Bạn có chắc muốn sửa dòng này không ? ", "Sửa dữ liệu", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.Cancel)
            {
                return;
            }

            DataRow dr = gridView1.GetDataRow(e.RowHandle);
            TangLauDTO tlDto = new TangLauDTO();
            tlDto.MaTangLau = (int)dr["MaTangLau"];
            tlDto.TenTangLau = (string)dr["TenTangLau"];
            TangLauBUS tlBus = new TangLauBUS();
            tlBus.SuaTangLau(tlDto);
        }

        // Bắt sự kiện RowDeleting để khằng định lại việc xóa một hàng khỏi bảng.
        private void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn xóa dòng này không ? ", "Xóa dữ liệu", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            DataRow dr = gridView1.GetDataRow(e.RowHandle);
            TangLauDTO tlDto = new TangLauDTO();
            tlDto.MaTangLau = (int)dr["MaTangLau"];
            tlDto.TenTangLau = (string)dr["TenTangLau"];
            TangLauBUS tlBus = new TangLauBUS();
            tlBus.XoaTangLau(tlDto);
        }
    }
}

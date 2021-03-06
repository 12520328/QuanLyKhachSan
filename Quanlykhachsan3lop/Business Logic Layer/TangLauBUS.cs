﻿using Quanlykhachsan3lop.Data_Access_Layer;
using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Business_Logic_Layer
{
    class TangLauBUS
    {
        private TangLauDAO tangLauDAO;

        public TangLauDAO TangLauDAO
        {
            get { return tangLauDAO; }
            set { tangLauDAO = value; }
        }

        public TangLauBUS()
        {
            TangLauDAO = new TangLauDAO();
        }

        // Lấy danh sách tầng lầu.
        public DataTable LayDanhSachTangLau()
        {
            return tangLauDAO.LayDanhSachTangLau();
        }

        //Thêm một tầng lầu vào cơ sở dữ liệu.
        public void ThemTangLau(TangLauDTO tangLauDTO)
        {
            tangLauDAO.ThemTangLau(tangLauDTO);
        }

        // Xóa một tầng lầu khỏi cơ sở dữ liệu.
        public void XoaTangLau(TangLauDTO tangLauDTO)
        {
            tangLauDAO.XoaTangLau(tangLauDTO);
        }

        // Sửa thông tin một tầng lầu.
        public void SuaTangLau(TangLauDTO tangLauDTO)
        {
            tangLauDAO.SuaTangLau(tangLauDTO);
        }

        // Lấy MaTangLau cuối cùng trong bảng.
        public object LayMaTangLauCuoiBang()
        {
            return TangLauDAO.LayMaTangLauCuoiBang();
        }
    }
}

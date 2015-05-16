using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;


namespace DAO
{
    public class TangLauDAO
    {
        HotelDataContext _hotelDataContext = new HotelDataContext();

        //Đếm tất cả các phần tử có trong bảng
        public int SoLuongTangLau()
        {
            var query = (from count in _hotelDataContext.TangLaus select count).Distinct().Count();
            return query;
        }

        //Lấy danh sách tầng lầu
        public IList<TangLauDTO> DanhSachTangLau()
        {
            var query = (from tanglau in _hotelDataContext.TangLaus
                         orderby tanglau.MaTangLau descending
                         select new TangLauDTO
                         {
                             MaTangLau = tanglau.MaTangLau,
                             TenTangLau = tanglau.TenTangLau,     
                         }).Distinct<TangLauDTO>();

            return query.ToList<TangLauDTO>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class TangLauDTO
    {
        #region "Variables"
        private int _maTangLau;      
        private string _tenTangLau;       
        #endregion

        #region "Properties"
        public int MaTangLau
        {
            get { return _maTangLau; }
            set { _maTangLau = value; }
        }
        public string TenTangLau
        {
            get { return _tenTangLau; }
            set { _tenTangLau = value; }
        }
        #endregion
    }
}

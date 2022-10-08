using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPanel.Models.Views
{
    public class CAU_HINH_BAI_THI_VIEW : CAU_HINH_BAI_THI
    {
        private string _SO_CAU_DUNG;

        ATCLEntities entities = new ATCLEntities();

        public string SO_CAU_DUNG
        {
            get
            {
                var objSoCauDung = entities.UNG_VIEN_TRA_LOI.Where(x => x.TT_KET_QUA == true).Count();
                return objSoCauDung.ToString();
            }
            set
            {
                _SO_CAU_DUNG = value;
            }
        }
    }
}
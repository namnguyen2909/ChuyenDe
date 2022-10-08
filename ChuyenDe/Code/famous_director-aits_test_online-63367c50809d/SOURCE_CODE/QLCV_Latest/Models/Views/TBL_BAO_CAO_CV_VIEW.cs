using System;
using System.Linq;
using CPanel.Models;
using System.Configuration;
using CPanel.Commons;
namespace CPanel.Models.Views
{
    public class TBL_BAO_CAO_CV_VIEW : TBL_BAO_CAO_CV
    {

        private string _LOAI_CONG_VIEC;        
        ATCLEntities entities = new ATCLEntities();
        string strLoaiCongViec = ConfigurationManager.AppSettings["MA_DM_LOAI_CONG_VIEC"];

        public string LOAI_CONG_VIEC
        {
            get
            {
                var obj = entities.TBL_DANH_MUC.Where(x => x.ID == ID_LOAI_CONG_VIEC).FirstOrDefault();


                if (obj != null)
                {
                    return obj.TEN;
                }
                return "";

            }
            set
            {
                _LOAI_CONG_VIEC = value;
            }
        }


      
    }
}
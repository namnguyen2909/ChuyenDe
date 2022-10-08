using System;
using System.Linq;
using CPanel.Models;
using System.Configuration;
using CPanel.Commons;
namespace CPanel.Models.Views
{
    public class TBL_TIMESHEET_VIEW : TBL_TIMESHEET
    {

        private string _NOI_DUNG_CONG_VIEC;
        private string _TONG_THOI_GIAN;
        private string _TEN_NGUOI_BC;
        private string _STR_NGAY_BAO_CAO;
        
        ATCLEntities entities = new ATCLEntities();
        string strMaDanhMuc = ConfigurationManager.AppSettings["MA_DM_KET_QUA_CONG_VIEC"];

        public string TONG_THOI_GIAN
        {
            get
            {
                var lstObjs = entities.TBL_BAO_CAO_CV.Where(x => x.ID_TIMESHEET == ID).ToList();

                if ((lstObjs != null) && (lstObjs.Count >0))
                {
                    double dbTG = (double)entities.TBL_BAO_CAO_CV.Where(x => x.ID_TIMESHEET == ID).Sum(y => y.TONG_THOI_GIAN);
                    return dbTG.ToString();
                }
                return "";
            }
            set
            {
                _TONG_THOI_GIAN = value;
            }
        }

        public string STR_NGAY_BAO_CAO
        {
            get
            {
                if (NGAY_BAO_CAO != null)
                {
                    return ((DateTime)NGAY_BAO_CAO).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                }
                else
                {
                    return null;
                }

            }
            set
            {
                _STR_NGAY_BAO_CAO = value;
            }
        }

        public string NOI_DUNG_CONG_VIEC
        {
            get
            {
                var lstObjs = entities.TBL_BAO_CAO_CV.Where(x => x.ID_TIMESHEET == ID).ToList();
               
                string strResult = "", strTemp = "";
                if ((lstObjs != null) && (lstObjs.Count >0))
                {
                    foreach (var item in lstObjs)
                    {
                        strTemp = String.Format("- {0} ({1} giờ)", item.TEN_CONG_VIEC, item.TONG_THOI_GIAN.ToString());                        
                        strResult = String.IsNullOrEmpty (strResult) ? strTemp : strResult + "<br/>" + strTemp;
                    }
                }
                return strResult;

            }
            set
            {
                _NOI_DUNG_CONG_VIEC = value;
            }
        }






        public string TEN_NGUOI_BC
        {
            get
            {
                TBL_NGUOI_DUNG obj = entities.TBL_NGUOI_DUNG.Where(x => x.Id == ID_NGUOI_TAO).FirstOrDefault();
                if (obj != null)
                {
                    return obj.FullName;
                }
                else
                {
                    return null;
                }

            }
            set
            {
                _TEN_NGUOI_BC = value;
            }
        }          
    }
}
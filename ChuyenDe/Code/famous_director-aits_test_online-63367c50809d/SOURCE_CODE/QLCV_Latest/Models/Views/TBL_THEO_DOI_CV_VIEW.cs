using System;
using System.Linq;
using CPanel.Models;
using System.Configuration;
using CPanel.Commons;
namespace CPanel.Models.Views
{
    public class TBL_THEO_DOI_CV_VIEW : TBL_THEO_DOI_CV
    {

        private string _TEN_HE_THONG;
        private string _TEN_HOP_DONG;
        private string _TEN_NGUOI_CHU_TRI;
        private string _STR_NGAY_BAT_DAU;
        private string _STR_NGAY_KET_THUC;
        private string _KET_QUA_CV;

        ATCLEntities entities = new ATCLEntities();
        string strMaDanhMuc = ConfigurationManager.AppSettings["MA_DM_KET_QUA_CONG_VIEC"];

        public string STR_NGAY_BAT_DAU
        {
            get
            {
                if (NGAY_BAT_DAU != null)
                {
                    return ((DateTime)NGAY_BAT_DAU).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                }
                else
                {
                    return null;
                }

            }
            set
            {
                _STR_NGAY_BAT_DAU = value;
            }
        }

        public string TEN_HE_THONG
        {
            get
            {
                TBL_HE_THONG obj = entities.TBL_HE_THONG.Where(x => x.ID == ID_HE_THONG).FirstOrDefault();
                if (obj != null)
                {
                    return obj.TEN;
                }
                else
                {
                    return null;
                }

            }
            set
            {
                _TEN_HE_THONG = value;
            }
        }

        public string TEN_HOP_DONG
        {
            get
            {
                TBL_HOP_DONG obj = entities.TBL_HOP_DONG.Where(x => x.ID == ID_HOP_DONG).FirstOrDefault();
                if (obj != null)
                {
                    return obj.TEN;
                }
                else
                {
                    return null;
                }

            }
            set
            {
                _TEN_HOP_DONG = value;
            }
        }


        public string KET_QUA_CV
        {
            get
            {
                if (ID_KET_QUA_CV != null)
                {
                    TBL_DANH_MUC obj = entities.TBL_DANH_MUC.Where(x => x.ID == ID_KET_QUA_CV).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj.TEN;
                    }                    
                }                
                
                return null;
                
            }
            set
            {
                _KET_QUA_CV = value;
            }
        }

        public string STR_NGAY_KET_THUC
        {
            get
            {
                if (NGAY_KET_THUC != null)
                {
                    return ((DateTime)NGAY_KET_THUC).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                }
                else
                {
                    return null;
                }

            }
            set
            {
                _STR_NGAY_KET_THUC = value;
            }
        }

        

        

        public string TEN_NGUOI_CHU_TRI
        {
            get
            {
                TBL_NGUOI_DUNG obj = entities.TBL_NGUOI_DUNG.Where(x => x.Id == ID_NGUOI_CHU_TRI).FirstOrDefault();
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
                _TEN_NGUOI_CHU_TRI = value;
            }
        }          
    }
}
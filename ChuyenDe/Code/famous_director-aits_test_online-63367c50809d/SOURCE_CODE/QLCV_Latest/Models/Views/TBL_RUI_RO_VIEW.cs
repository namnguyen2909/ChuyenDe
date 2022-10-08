using System;
using System.Linq;
using CPanel.Models;
using System.Configuration;
using CPanel.Commons;
namespace CPanel.Models.Views
{
    public class TBL_RUI_RO_VIEW : TBL_RUI_RO
    {   
        private string _TEN_NGUOI_CHU_TRI;
        private string _STR_NGAY_BAT_DAU;
        private string _STR_NGAY_KET_THUC;
        private string _STR_NGAY_PHAT_SINH;
        private string _KET_QUA;

        ATCLEntities entities = new ATCLEntities();

        public string STR_NGAY_PHAT_SINH
        {
            get
            {
                if (NGAY_PHAT_SINH != null)
                {
                    return ((DateTime)NGAY_PHAT_SINH).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                }
                else
                {
                    return _STR_NGAY_PHAT_SINH;
                }

            }
            set
            {
                _STR_NGAY_PHAT_SINH = value;
            }
        }

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
                    return _STR_NGAY_BAT_DAU;
                }

            }
            set
            {
                _STR_NGAY_BAT_DAU = value;
            }
        }

        
        


        public string KET_QUA
        {
            get
            {
                if (ID_KET_QUA != null)
                {
                    TBL_DANH_MUC obj = entities.TBL_DANH_MUC.Where(x => x.ID == ID_KET_QUA).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj.TEN;
                    }                    
                }

                return _KET_QUA;
                
            }
            set
            {
                _KET_QUA = value;
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
                    return _STR_NGAY_KET_THUC;
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
                    return _TEN_NGUOI_CHU_TRI;
                }

            }
            set
            {
                _TEN_NGUOI_CHU_TRI = value;
            }
        }          
    }
}
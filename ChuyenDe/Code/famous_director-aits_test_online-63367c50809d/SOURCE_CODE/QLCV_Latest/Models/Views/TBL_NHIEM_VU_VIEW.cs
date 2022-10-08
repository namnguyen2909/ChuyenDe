using System;
using System.Linq;
using CPanel.Models;
using System.Configuration;
using CPanel.Commons;
namespace CPanel.Models.Views
{
    public class TBL_NHIEM_VU_VIEW : TBL_NHIEM_VU
    {   
        private string _TEN_NGUOI_CHU_TRI;
        private string _STR_NGAY_BAT_DAU_DK;
        private string _STR_NGAY_KET_THUC_DK;
        private string _KET_QUA_NV;

        ATCLEntities entities = new ATCLEntities();
        
        public string STR_NGAY_BAT_DAU_DK
        {
            get
            {
                if (NGAY_BAT_DAU_DK != null)
                {
                    return ((DateTime)NGAY_BAT_DAU_DK).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                }
                else
                {
                    return _STR_NGAY_BAT_DAU_DK;
                }

            }
            set
            {
                _STR_NGAY_BAT_DAU_DK = value;
            }
        }

        
        


        public string KET_QUA_NV
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

                return _KET_QUA_NV;
                
            }
            set
            {
                _KET_QUA_NV = value;
            }
        }

        public string STR_NGAY_KET_THUC_DK
        {
            get
            {
                if (NGAY_KET_THUC_DK != null)
                {
                    return ((DateTime)NGAY_KET_THUC_DK).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                }
                else
                {
                    return _STR_NGAY_KET_THUC_DK;
                }

            }
            set
            {
                _STR_NGAY_KET_THUC_DK = value;
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
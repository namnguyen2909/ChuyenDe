using System;
using System.Linq;
using CPanel.Models;
using System.Configuration;
using CPanel.Commons;
namespace CPanel.Models.Views
{
    public class TBL_HE_THONG_VIEW : TBL_HE_THONG
    {   
        private string _TEN_PM;
        private string _STR_NGAY_BAT_DAU_LAM;
        private string _STR_NGAY_NGHIEM_THU_TT;
        private string _LOAI_TRIEN_KHAI_DA;
        private string _TIEN_DO;
        private string _PHAM_VI_DA;
        private string _TRANG_THAI_DA;

        ATCLEntities entities = new ATCLEntities();

        public string STR_NGAY_BAT_DAU_LAM
        {
            get
            {
                if (NGAY_BAT_DAU_LAM != null)
                {
                    return ((DateTime)NGAY_BAT_DAU_LAM).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                }
                else
                {
                    return null;
                }

            }
            set
            {
                _STR_NGAY_BAT_DAU_LAM = value;
            }
        }

        public string TRANG_THAI_DA
        {
            get
            {
                if (ID_TRANG_THAI_DA != null)
                {
                    TBL_DANH_MUC obj = entities.TBL_DANH_MUC.Where(x => x.ID == ID_TRANG_THAI_DA).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj.TEN;
                    }
                }

                return _TRANG_THAI_DA;

            }
            set
            {
                _TRANG_THAI_DA = value;
            }
        }

        public string PHAM_VI_DA
        {
            get
            {
                if (ID_PHAM_VI_DA != null)
                {
                    TBL_DANH_MUC obj = entities.TBL_DANH_MUC.Where(x => x.ID == ID_PHAM_VI_DA).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj.TEN;
                    }
                }

                return _PHAM_VI_DA;

            }
            set
            {
                _PHAM_VI_DA = value;
            }
        }

        public string TIEN_DO
        {
            get
            {
                if (ID_TIEN_DO != null)
                {
                    TBL_DANH_MUC obj = entities.TBL_DANH_MUC.Where(x => x.ID == ID_TIEN_DO).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj.TEN;
                    }
                }

                return _TIEN_DO;

            }
            set
            {
                _TIEN_DO = value;
            }
        }

                
        public string LOAI_TRIEN_KHAI_DA
        {
            get
            {
                if (ID_LOAI_TRIEN_KHAI_DA != null)
                {
                    TBL_DANH_MUC obj = entities.TBL_DANH_MUC.Where(x => x.ID == ID_LOAI_TRIEN_KHAI_DA).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj.TEN;
                    }                    
                }

                return _LOAI_TRIEN_KHAI_DA;
                
            }
            set
            {
                _LOAI_TRIEN_KHAI_DA = value;
            }
        }

        public string STR_NGAY_NGHIEM_THU_TT
        {
            get
            {
                if (NGAY_NGHIEM_THU_TT != null)
                {
                    return ((DateTime)NGAY_NGHIEM_THU_TT).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                }
                else
                {
                    return null;
                }

            }
            set
            {
                _STR_NGAY_NGHIEM_THU_TT = value;
            }
        }

        

        

        public string TEN_PM
        {
            get
            {
                TBL_NGUOI_DUNG obj = entities.TBL_NGUOI_DUNG.Where(x => x.Id == ID_PM).FirstOrDefault();
                if (obj != null)
                {
                    return obj.FullName;
                }
                else
                {
                    return _TEN_PM;
                }

            }
            set
            {
                _TEN_PM = value;
            }
        }          
    }
}
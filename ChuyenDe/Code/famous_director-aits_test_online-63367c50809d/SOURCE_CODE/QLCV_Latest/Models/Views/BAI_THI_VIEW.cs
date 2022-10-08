using System;
using System.Linq;
using CPanel.Models;
using System.Configuration;
using CPanel.Commons;

namespace CPanel.Models.Views
{
    public class BAI_THI_VIEW : BAI_THI
    {
        private string _TEN_CHU_DE_BAI_THI;
        private string _TEN_MUC_DO_BAI_THI;
        private string _STR_NGAY_TAO;
        private string _STR_GIO_TAO;

        ATCLEntities entities = new ATCLEntities();

        public string STR_NGAY_TAO
        {
            get
            {
                if (NGAY_TAO != null)
                {
                    return ((DateTime)NGAY_TAO).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _STR_NGAY_TAO = value;
            }
        }

        public string STR_GIO_TAO
        {
            get
            {
                if (NGAY_TAO != null)
                {
                    return ((DateTime)NGAY_TAO).ToString(Commons.DateTimeType.TIME_FORMAT_HH_MM);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _STR_GIO_TAO = value;
            }
        }

        public string TEN_CHU_DE_BAI_THI
        {
            get
            {
                CHU_DE_BAI_THI obj = entities.CHU_DE_BAI_THI.Where(x => x.ID == ID_CHU_DE_BAI_THI).FirstOrDefault();
                if (obj != null)
                {
                    return obj.TEN_CHU_DE;
                }
                else
                {
                    return _TEN_CHU_DE_BAI_THI;
                }
            }
            set
            {
                _TEN_CHU_DE_BAI_THI = value;
            }
        }

        public string TEN_MUC_DO_BAI_THI
        {
            get
            {
                MUC_DO_BAI_THI obj = entities.MUC_DO_BAI_THI.Where(x => x.ID == ID_MUC_DO_BAI_THI).FirstOrDefault();
                if (obj != null)
                {
                    return obj.TEN_MUC_DO;
                }
                else
                {
                    return _TEN_MUC_DO_BAI_THI;
                }
            }
            set
            {
                _TEN_MUC_DO_BAI_THI = value;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPanel.Models.Views
{
    public class UNG_VIEN_VIEW : UNG_VIEN
    {
        private string _VI_TRI;
        private string _STR_NGAY_SINH;

        ATCLEntities entities = new ATCLEntities();

        public string STR_NGAY_SINH
        {
            get
            {
                if (NGAY_SINH != null)
                {
                    return ((DateTime)NGAY_SINH).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                }
                else
                {
                    return _STR_NGAY_SINH;
                }

            }
            set
            {
                _STR_NGAY_SINH = value;
            }
        }

        public string VI_TRI
        {
            get
            {
                if (ID_CHU_DE_BAI_THI != null)
                {
                    CHU_DE_BAI_THI obj = entities.CHU_DE_BAI_THI.Where(x => x.ID == ID_CHU_DE_BAI_THI).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj.TEN_CHU_DE;
                    }
                }

                return _VI_TRI;

            }
            set
            {
                _VI_TRI = value;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPanel.Models.Views
{
    public class CAU_HOI_MUC_DO_VIEW : CAU_HOI_MUC_DO
    {
        private string _MUC_DO;

        ATCLEntities entities = new ATCLEntities();

        public string MUC_DO
        {
            get
            {
                if (ID_MUC_DO_CAU_HOI != null)
                {
                    MUC_DO_CAU_HOI obj = entities.MUC_DO_CAU_HOI.Where(x => x.ID == ID_MUC_DO_CAU_HOI).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj.MO_TA;
                    }
                }
                return _MUC_DO;
            }
            set
            {
                _MUC_DO = value;
            }
        }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CPanel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAU_HOI
    {
        public CAU_HOI()
        {
            this.BAI_THI_CAU_HOI = new HashSet<BAI_THI_CAU_HOI>();
            this.CAU_HOI_MUC_DO = new HashSet<CAU_HOI_MUC_DO>();
            this.DAP_AN = new HashSet<DAP_AN>();
        }
    
        public string NOI_DUNG_CAU_HOI { get; set; }
        public Nullable<int> ID_LOAI_CAU_HOI { get; set; }
        public Nullable<int> ID_BAI_THI { get; set; }
        public Nullable<int> ID_CHU_DE_BAI_THI { get; set; }
        public Nullable<System.DateTime> NGAY_TAO { get; set; }
        public Nullable<int> ID_NGUOI_TAO { get; set; }
        public Nullable<System.DateTime> NGAY_SUA { get; set; }
        public Nullable<int> ID_NGUOI_SUA { get; set; }
        public int ID { get; set; }
        public Nullable<bool> TT_XOA { get; set; }
    
        public virtual ICollection<BAI_THI_CAU_HOI> BAI_THI_CAU_HOI { get; set; }
        public virtual CHU_DE_BAI_THI CHU_DE_BAI_THI { get; set; }
        public virtual LOAI_CAU_HOI LOAI_CAU_HOI { get; set; }
        public virtual ICollection<CAU_HOI_MUC_DO> CAU_HOI_MUC_DO { get; set; }
        public virtual ICollection<DAP_AN> DAP_AN { get; set; }
    }
}

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
    
    public partial class BAI_THI
    {
        public BAI_THI()
        {
            this.BAI_THI_CAU_HOI = new HashSet<BAI_THI_CAU_HOI>();
            this.BAI_THI_UNG_VIEN = new HashSet<BAI_THI_UNG_VIEN>();
            this.CAU_HINH_BAI_THI = new HashSet<CAU_HINH_BAI_THI>();
        }
    
        public Nullable<int> ID_CHU_DE_BAI_THI { get; set; }
        public Nullable<int> ID_MUC_DO_BAI_THI { get; set; }
        public Nullable<System.DateTime> NGAY_TAO { get; set; }
        public Nullable<int> ID_NGUOI_TAO { get; set; }
        public Nullable<System.DateTime> NGAY_SUA { get; set; }
        public Nullable<int> ID_NGUOI_SUA { get; set; }
        public int ID { get; set; }
        public Nullable<int> ID_LOAI_CAU_HOI { get; set; }
        public Nullable<bool> TT_XOA { get; set; }
        public string TEN_BAI_THI { get; set; }
        public Nullable<int> THOI_GIAN { get; set; }
    
        public virtual ICollection<BAI_THI_CAU_HOI> BAI_THI_CAU_HOI { get; set; }
        public virtual CHU_DE_BAI_THI CHU_DE_BAI_THI { get; set; }
        public virtual MUC_DO_BAI_THI MUC_DO_BAI_THI { get; set; }
        public virtual ICollection<BAI_THI_UNG_VIEN> BAI_THI_UNG_VIEN { get; set; }
        public virtual ICollection<CAU_HINH_BAI_THI> CAU_HINH_BAI_THI { get; set; }
    }
}

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
    
    public partial class CAU_HOI_MUC_DO
    {
        public int ID { get; set; }
        public Nullable<int> ID_CAU_HOI { get; set; }
        public Nullable<int> ID_MUC_DO_CAU_HOI { get; set; }
        public Nullable<System.DateTime> NGAY_TAO { get; set; }
        public Nullable<int> ID_NGUOI_TAO { get; set; }
        public Nullable<System.DateTime> NGAY_SUA { get; set; }
        public Nullable<int> ID_NGUOI_SUA { get; set; }
        public Nullable<bool> TT_XOA { get; set; }
    
        public virtual CAU_HOI CAU_HOI { get; set; }
        public virtual MUC_DO_CAU_HOI MUC_DO_CAU_HOI { get; set; }
    }
}

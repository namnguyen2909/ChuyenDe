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
    
    public partial class TBL_TIMESHEET
    {
        public TBL_TIMESHEET()
        {
            this.TBL_BAO_CAO_CV = new HashSet<TBL_BAO_CAO_CV>();
        }
    
        public int ID { get; set; }
        public string KHO_KHAN_KIEN_NGHI { get; set; }
        public string SANG_KIEN { get; set; }
        public Nullable<double> TONG_THOI_GIAN { get; set; }
        public Nullable<System.DateTime> NGAY_BAO_CAO { get; set; }
        public Nullable<int> STT { get; set; }
        public Nullable<bool> TT_XOA { get; set; }
        public Nullable<int> ID_NGUOI_TAO { get; set; }
        public Nullable<System.DateTime> NGAY_TAO { get; set; }
        public Nullable<int> ID_NGUOI_SUA { get; set; }
        public Nullable<System.DateTime> NGAY_SUA { get; set; }
        public string GHI_CHU { get; set; }
    
        public virtual ICollection<TBL_BAO_CAO_CV> TBL_BAO_CAO_CV { get; set; }
    }
}

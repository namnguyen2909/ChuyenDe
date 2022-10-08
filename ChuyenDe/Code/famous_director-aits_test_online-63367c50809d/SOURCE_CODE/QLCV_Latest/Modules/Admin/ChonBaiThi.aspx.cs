using CPanel.Models;
using CPanel.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel.Modules.Admin
{
    public partial class ChonBaiThi : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Commons.ATCL_Commons.getChuDe(drpLoai, entities);
                Commons.ATCL_Commons.getMucDoBaiThi(drpMucDo, entities);

            }
        }

        protected void grvUngVien_DataBinding(object sender, EventArgs e)
        {
            int intChuDeID = Convert.ToInt32(drpLoai.SelectedValue);
            var lstUngVien = entities.UNG_VIEN.Where(x => (x.ID_CHU_DE_BAI_THI == intChuDeID) && (x.TT_XOA == false))
                .Select(y => new UNG_VIEN_VIEW()
                {
                    ID = y.ID,
                    HO_TEN = y.HO_TEN,
                    NGAY_SINH = y.NGAY_SINH,
                    SO_DIEN_THOAI = y.SO_DIEN_THOAI,
                    EMAIL = y.EMAIL,
                    ID_CHU_DE_BAI_THI = y.ID_CHU_DE_BAI_THI,
                    ID_BAI_THI = y.ID_BAI_THI,
                    TT_XOA = y.TT_XOA,
                    MA_UNG_VIEN = y.MA_UNG_VIEN
                }).ToList();
            grvUngVien.DataSource = lstUngVien;
        }

        protected void drpLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpLoai.SelectedValue))
            {
                grvUngVien.DataBind();
            }
        }

        protected void drpMucDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpMucDo.SelectedValue))
            {
                Commons.ATCL_Commons.getBaiThi(drpBaiThi, Convert.ToInt32(drpLoai.SelectedValue), Convert.ToInt32(drpMucDo.SelectedValue), entities);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UNG_VIEN ungvien = new UNG_VIEN();
            BAI_THI_UNG_VIEN baithiungvien = new BAI_THI_UNG_VIEN();
            var lstUngvien = grvUngVien.GetSelectedFieldValues(grvUngVien.KeyFieldName);
            int intBaiThiID = Convert.ToInt32(drpBaiThi.SelectedValue);
            if ((lstUngvien != null) && (lstUngvien.Count > 0))
            {
                foreach (int i in lstUngvien)
                {
                    ungvien = entities.UNG_VIEN.Where(x => x.ID == i).FirstOrDefault();
                    baithiungvien.ID_UNG_VIEN = ungvien.ID;
                    baithiungvien.ID_BAI_THI = intBaiThiID;
                    baithiungvien.SO_DIEN_THOAI = ungvien.SO_DIEN_THOAI;
                    baithiungvien.NGAY_SINH = ungvien.NGAY_SINH;
                    baithiungvien.EMAIL = ungvien.EMAIL;
                    baithiungvien.VI_TRI_TUYEN_DUNG = entities.CHU_DE_BAI_THI.Where(x => x.ID == ungvien.ID_CHU_DE_BAI_THI).Select(x => x.TEN_CHU_DE).FirstOrDefault();
                    entities.BAI_THI_UNG_VIEN.Add(baithiungvien);
                    entities.SaveChanges();
                }
                Response.Redirect(Commons.TitleConst.getTitleConst("XemUngVien.aspx"));
            }
            else
            {
                Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("Bạn chưa chọn ứng viên"), Page);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("XemUngVien.aspx"));
        }
    }
}
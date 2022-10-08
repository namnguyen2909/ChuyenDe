using CPanel.Commons;
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
    public partial class DanhSachBaiThiCauHoi_List : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Set Captions for GridView
                Commons.TitleConst.setTitleConst_ASPxGridView(grvBaiThi);
                getChuDeBaiThi();
                getMucDoBaiThi();
                //getTenBaiThi();
                
            }
            getObjects();
        }

        protected void grvObjects_DataBinding(object sender, EventArgs e)
        {

        }

        /**
         * Get Date of Open Reports
         */
        protected void getObjects()
        {
            //bool blViewAll_KetQuaBT = false;

            bool blChuDeBaiThi = false;
            int intChuDeBaiThi = 0;

            if (drpChuDeBaiThi.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))
            {
                blChuDeBaiThi = true;
            }
            else
            {
                intChuDeBaiThi = Convert.ToInt32(drpChuDeBaiThi.SelectedValue);
            }

            bool blMucDoBaiThi = false, blTenBaiThi = false;
            int intMucDoBaiThi = 0, intTenBaiThi = 0;
            

            if (drpMucDoBaiThi.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))
            {
                blMucDoBaiThi = true;
            }
            else
            {
                intMucDoBaiThi = Convert.ToInt32(drpMucDoBaiThi.SelectedValue);
            }

            if (String.IsNullOrEmpty(txtTenBaiThi.Text))
            {
                blTenBaiThi = true;
            }
            //else
            //{
            //    strTenBaiThi = txtTenBaiThi.Text;
            //}    

            //if (drpTenBaiThi.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))
            //{
            //    blTenBaiThi = true;
            //}
            //else
            //{
            //    intTenBaiThi = Convert.ToInt32(drpTenBaiThi.SelectedValue);
            //}


            //var lstOpenReports = entities.BAI_THI.Where(x => (x.TT_XOA == false)
            //                    ).Select(y => new BAI_THI_VIEW()
            //                    {
            //                        ID = y.ID,
            //                        TEN_BAI_THI = y.TEN_BAI_THI,
            //                        ID_CHU_DE_BAI_THI = y.ID_CHU_DE_BAI_THI,
            //                        ID_MUC_DO_BAI_THI = y.ID_MUC_DO_BAI_THI,
            //                        THOI_GIAN = y.THOI_GIAN,
            //                        NGAY_TAO = y.NGAY_TAO
            //                    }).ToList();



            var lstOpenReports = (from BT in entities.BAI_THI
                                  join CDBT in entities.CHU_DE_BAI_THI on BT.ID_CHU_DE_BAI_THI equals CDBT.ID
                                  join MDBT in entities.MUC_DO_BAI_THI on BT.ID_MUC_DO_BAI_THI equals MDBT.ID
                                  where ((blChuDeBaiThi ? true : BT.ID_CHU_DE_BAI_THI == intChuDeBaiThi)
                                     && (blMucDoBaiThi ? true : MDBT.ID == intMucDoBaiThi)
                                     && (blTenBaiThi ? true : BT.TEN_BAI_THI.ToUpper().Contains(txtTenBaiThi.Text.ToUpper())))
                                  select new BAI_THI_VIEW()
                                  {
                                   ID = BT.ID,
                                   TEN_BAI_THI = BT.TEN_BAI_THI,
                                   ID_CHU_DE_BAI_THI = BT.ID_CHU_DE_BAI_THI,
                                   ID_MUC_DO_BAI_THI = BT.ID_MUC_DO_BAI_THI,
                                   THOI_GIAN = BT.THOI_GIAN,
                                   TT_XOA = BT.TT_XOA,
                                   NGAY_TAO = BT.NGAY_TAO
                                  }).Where(x => x.TT_XOA == false).OrderByDescending(z => z.NGAY_TAO).ToList();


            grvBaiThi.DataSource = lstOpenReports;
            grvBaiThi.DataBind();
        }

        /**
         * View Pop up window
         */
        protected void btnViewObject_Click(object sender, EventArgs e)
        {
            SessionForChuDeBaiThi objSessionForChuDeBaiThi = new SessionForChuDeBaiThi();
            objSessionForChuDeBaiThi.SESSION_OBJECT_ID = txtObjectID.Text;
            Session[Commons.ConstValues.SESSION_CHUDEBAITHI] = objSessionForChuDeBaiThi;
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_TAO_DE_BAI_THI"));
        }
        protected int getObjectID()
        {
            return Convert.ToInt32(txtObjectID.Text);
        }
        protected void btlDeleteObject_Click(object sender, EventArgs e)
        {
            showMessage(Commons.TitleConst.getTitleConst("MSG_BAN_CO_CHAC_CHAN_XOA_KHONG"));

            //Open Popup
            btnOK_DeleteObject.Visible = true;
            DIV_MESSAGE.Visible = true;
        }
        protected void showMessage(string strMessage)
        {
            DIV_MESSAGE.Visible = true;
            ltMessageContent.Text = strMessage;
        }
        protected void btnOK_DeleteObject_Click(object sender, EventArgs e)
        {
            int intObjectID = Convert.ToInt32(txtObjectID.Text);

            //Delete records in table "BAI_THI_CAU_HOI"
            //var objIdBaiThiCauHoi = entities.BAI_THI_CAU_HOI.Where(x => x.ID_BAI_THI == intObjectID).ToList();
            //if ((objIdBaiThiCauHoi != null) && (objIdBaiThiCauHoi.Count > 0))
            //{
            //    foreach (var item in objIdBaiThiCauHoi)
            //    {
            //        entities.BAI_THI_CAU_HOI.Remove(item);
            //        entities.SaveChanges();
            //    }
            //}

            //Delete records in table "CAU_HINH_BAI_THI"
            //var objIdBaiThiCauHinh = entities.CAU_HINH_BAI_THI.Where(x => x.ID_BAI_THI == intObjectID).ToList();
            //if ((objIdBaiThiCauHinh != null) && (objIdBaiThiCauHinh.Count > 0))
            //{
            //    foreach (var item in objIdBaiThiCauHinh)
            //    {
            //        entities.CAU_HINH_BAI_THI.Remove(item);
            //        entities.SaveChanges();
            //    }
            //}

            //Delete records in table "BAI_THI"
            var objId = entities.BAI_THI.Where(x => x.ID == intObjectID).FirstOrDefault();
            objId.TT_XOA = true;
            entities.SaveChanges();
            //refresh Gridview
            getObjects();

            //Close Popup
            DIV_MESSAGE.Visible = false;
            btnOK_DeleteObject.Visible = false;
        }
        protected void btlClosePopUp_Message_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE.Visible = false;
        }

        protected void btnCreate_Click( object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_TAO_BAI_THI"));
        }

        protected void getChuDeBaiThi()
        {
            drpChuDeBaiThi.DataSource = entities.CHU_DE_BAI_THI.Where(x => x.TT_XOA == false).ToList();
            drpChuDeBaiThi.DataValueField = "Id";
            drpChuDeBaiThi.DataTextField = "TEN_CHU_DE";
            drpChuDeBaiThi.DataBind();

            drpChuDeBaiThi.Items.Insert(0, new ListItem("Chọn chủ đề bài thi", Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpChuDeBaiThi.SelectedIndex = 0;
        }

        protected void getMucDoBaiThi()
        {
            drpMucDoBaiThi.DataSource = entities.MUC_DO_BAI_THI.Where(x => x.TT_XOA == false).ToList();
            drpMucDoBaiThi.DataValueField = "Id";
            drpMucDoBaiThi.DataTextField = "TEN_MUC_DO";
            drpMucDoBaiThi.DataBind();

            drpMucDoBaiThi.Items.Insert(0, new ListItem("Chọn mức độ bài thi", Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpMucDoBaiThi.SelectedIndex = 0;
        }

        //protected void getTenBaiThi()
        //{
        //    drpTenBaiThi.DataSource = entities.BAI_THI.Where(x => x.TT_XOA == false).ToList();
        //    drpTenBaiThi.DataValueField = "Id";
        //    drpTenBaiThi.DataTextField = "TEN_BAI_THI";
        //    drpTenBaiThi.DataBind();

        //    drpTenBaiThi.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
        //    drpTenBaiThi.SelectedIndex = 0;
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getObjects();
        }   
    }
}
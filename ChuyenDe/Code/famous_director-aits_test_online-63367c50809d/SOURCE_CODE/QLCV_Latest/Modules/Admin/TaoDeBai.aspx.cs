using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPanel.Commons;
using CPanel.Models;

namespace CPanel.Modules.Admin
{
    public partial class TaoDeBai : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        public double seconds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ////get Session
                //if (!String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_OBJECT_ID]))
                //{
                //    txtObjectID.Text = Session[ATCL_Consts.SESSION_OBJECT_ID].ToString();
                //    Session[ATCL_Consts.SESSION_OBJECT_ID] = null;
                //}



                string strObjID = Session[ATCL_Consts.SESSION_OBJECT_ID].ToString();
                if (!String.IsNullOrEmpty(strObjID))
                {
                    txtObjectID.Text = strObjID;
                    int intObjID = Convert.ToInt32(strObjID);
                    Session[ATCL_Consts.SESSION_OBJECT_ID] = null;

                    List<DAP_AN> lstAnswer;
                    var lstLoad = entities.BAI_THI_CAU_HOI.Where(x => x.ID_BAI_THI == intObjID).ToList();

                    if ((lstLoad != null) && (lstLoad.Count > 0))
                    {
                        int i = 0;
                        int SoCau = 1;

                        //Lay danh sach cau hoi TN
                        foreach (var item in lstLoad)
                        {
                            ////var lstCauTN = entities.CAU_HOI.Where(x => x.ID_LOAI_CAU_HOI == 1).ToList();
                            ltQuestion.Text = ltQuestion.Text + "<div class='cau_hoi_css'>";
                            ltQuestion.Text = ltQuestion.Text + string.Format(@"
                                <p>Câu {0}: <b> {1}</p></b>  
                                ", SoCau, item.CAU_HOI.NOI_DUNG_CAU_HOI);
                            //Lay danh sach dap an cau hoi trac nghiem
                            lstAnswer = entities.CAU_HOI.Join(entities.DAP_AN, CH => CH.ID, DA => DA.ID_CAU_HOI, (CH, DA) => new { CH, DA }).Where(x => (x.CH.ID == x.DA.ID_CAU_HOI) && (x.DA.ID_CAU_HOI == item.ID_CAU_HOI) && (x.CH.ID_LOAI_CAU_HOI == 1)).Select(y => y.DA).ToList();
                            if ((lstAnswer != null) && (lstAnswer.Count > 0))
                            {
                                foreach (var item1 in lstAnswer)
                                {
                                    ltQuestion.Text = ltQuestion.Text + string.Format(@"
                                <div class='dap_an_TN_css'><p><input type='checkbox'/>{0}</p></div>
                                        ", item1.NOI_DUNG_DAP_AN);
                                }
                            }
                            else
                            {
                                ltQuestion.Text = ltQuestion.Text + string.Format(@"
                                <div class='dap_an_TL_css'><p><input type='text'/></p></div>");
                            }
                            ltQuestion.Text = ltQuestion.Text + "</div>";//The dong "CAU HOI"
                            i++;
                            SoCau++;
                        }
                    }
                }

                

            }


            //Lay chu de bai thi
            //int intChuDeBaiThi;
            //SessionForChuDeBaiThi objSessionForChuDeBaiThi = (SessionForChuDeBaiThi)Session[Commons.ConstValues.SESSION_CHUDEBAITHI];

            //if ((objSessionForChuDeBaiThi != null) && (!String.IsNullOrEmpty(objSessionForChuDeBaiThi.ID_CHU_DE_BAI_THI)))
            //{
            //    intChuDeBaiThi = Convert.ToInt32(objSessionForChuDeBaiThi.ID_CHU_DE_BAI_THI);
            //    Session[Commons.ConstValues.SESSION_CHUDEBAITHI] = null;

            //    var objChuDeBT = entities.CHU_DE_BAI_THI.Find(intChuDeBaiThi);
            //    if (objChuDeBT != null)
            //        lblLoaiBT.Text = objChuDeBT.TEN_CHU_DE;

                //var objThoiGianThi = entities.BAI_THI.Find(intChuDeBaiThi);
                //if (objThoiGianThi != null)
                //    lblThoiGianThi.Text = Convert.ToString(objThoiGianThi.THOI_GIAN);
            }

        //Lay muc do bai thi
        //int mucdobaithi;
        //SessionForMucDoBaiThi objSessionForMucDoBaiThi = (SessionForMucDoBaiThi)Session[Commons.ConstValues.SESSION_MUCDOBAITHI];
        //if ((objSessionForMucDoBaiThi != null) && (!String.IsNullOrEmpty(objSessionForMucDoBaiThi.ID_MUC_DO_BAI_THI)))
        //{
        //    mucdobaithi = Convert.ToInt32(objSessionForMucDoBaiThi.ID_MUC_DO_BAI_THI);
        //    Session[Commons.ConstValues.SESSION_MUCDOBAITHI] = null;

        //    var objMucDoBT = entities.MUC_DO_BAI_THI.Find(mucdobaithi);
        //    if (objMucDoBT != null)
        //    {
        //        lblMucDo.Text = objMucDoBT.TEN_MUC_DO;

        //    }
        //}

        ////Lay Ten Bai Thi

        //SessionForTenBaiThi objSessionForTenBaiThi = (SessionForTenBaiThi)Session[Commons.ConstValues.SESSION_TENBAITHI];
        //if ((objSessionForTenBaiThi != null) && (!String.IsNullOrEmpty(objSessionForTenBaiThi.TEN_BAI_THI)))
        //{
        //    lblTenBaiThi.Text = objSessionForTenBaiThi.TEN_BAI_THI;
        //}

        //DateTime thoigianthi;

        //SessionForThoiGianThi objSessionForThoiGianThi = (SessionForThoiGianThi)Session[Commons.ConstValues.SESSION_THOIGIANTHI];
        //if ((objSessionForThoiGianThi != null) && (!String.IsNullOrEmpty(objSessionForThoiGianThi.THOI_GIAN)))
        //{
        //    thoigianthi = Convert.ToDateTime(objSessionForThoiGianThi.THOI_GIAN);
        //    Session[Commons.ConstValues.SESSION_THOIGIANTHI] = null;

        //    var objThoiGianThi = entities.BAI_THI.Find(thoigianthi);
        //    if (objThoiGianThi != null)
        //    {
        //        lblThoiGianThi.Text = Convert.ToString(objThoiGianThi.THOI_GIAN);
        //        //DateTime abc = Convert.ToDateTime(objThoiGianThi);
        //    }
        //    //seconds = (abc - GetStartTime()).TotalSeconds;
        //}

        //load Cau Hoi
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_DANH_SACH_BAI_THI_CAU_HOI_LIST"));
        }
    }
        
}
    //private DateTime GetStartTime()
    //{
    //    return DateTime.MinValue;

    //}
    //private DateTime GetEndTime()
    //{
    //    return new DateTime();

    //}





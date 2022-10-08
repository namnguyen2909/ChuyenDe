using CPanel.Commons;
using CPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel.Modules.UngVien
{
    public partial class LamBaiThi_View : System.Web.UI.Page
    {
        ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_OBJECT_ID]))
                {
                    txtObjectID.Text = Session[ATCL_Consts.SESSION_OBJECT_ID].ToString();
                    Session[ATCL_Consts.SESSION_OBJECT_ID] = null;
                }
                int intBaiThiUngVienID = Convert.ToInt32(txtObjectID.Text);
                int intBaiThiID = Convert.ToInt32(entities.BAI_THI_UNG_VIEN.Where(x => x.ID == intBaiThiUngVienID).Select(x => x.ID_BAI_THI).FirstOrDefault());
                int intUVID = (int)Commons.CheckUserInfo.GetUserId();

                List<DAP_AN> lstAnswer;
                var lstLoad = entities.BAI_THI_CAU_HOI.Where(x => x.ID_BAI_THI == intBaiThiID).ToList();

                if ((lstLoad != null) && (lstLoad.Count > 0))
                {
                    int i = 0;
                    int SoCau = 1;
                    UNG_VIEN_TRA_LOI objUVTL;
                    string strCheckedCSS = "";
                    //Lay danh sach cau hoi
                    foreach (var item in lstLoad)
                    {
                        ltQuestion.Text = ltQuestion.Text + "<div class='cau_hoi_css'>";
                        ltQuestion.Text = ltQuestion.Text + string.Format(@"
                                <p>Câu {0}: <b> {1}</p></b>  
                                ", SoCau, item.CAU_HOI.NOI_DUNG_CAU_HOI);


                        //Lay danh sach Dap an
                        lstAnswer = entities.CAU_HOI.Join(entities.DAP_AN, CH => CH.ID, DA => DA.ID_CAU_HOI, (CH, DA) => new { CH, DA }).Where(x => (x.CH.ID == x.DA.ID_CAU_HOI) && (x.DA.ID_CAU_HOI == item.ID_CAU_HOI)).Select(y => y.DA).ToList();
                        if ((lstAnswer != null) && (lstAnswer.Count > 0))
                        {
                            objUVTL = entities.UNG_VIEN_TRA_LOI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_UNG_VIEN == intUVID) && (x.ID_CAU_HOI == item.ID_CAU_HOI)).FirstOrDefault();
                            
                            foreach (var item1 in lstAnswer)
                            {
                                if (objUVTL != null)
                                {
                                    if (objUVTL.ID_DAP_AN.Contains(item1.ID.ToString()))
                                        strCheckedCSS = "checked__css";
                                    else
                                        strCheckedCSS = "";
                                }
                                    

                                ltQuestion.Text = ltQuestion.Text + string.Format(@"
                                <div class='dap_an_css'><p><input id='cbAnswer' type='checkbox' onclick='return false;' class='{0}' name='cbAnswer' value='{1}|{2}|{3}'/>{4}</p></div>
                                        ", strCheckedCSS, item.ID_BAI_THI, item1.ID_CAU_HOI, item1.ID, item1.NOI_DUNG_DAP_AN);//Format: vaue = ID_BAI_THI|ID_CAU_HOI|ID_DAP_AN
                            }
                        }
                        else
                        {
                            UNG_VIEN_TRA_LOI UVTL = entities.UNG_VIEN_TRA_LOI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_UNG_VIEN == intUVID) && (x.ID_CAU_HOI == item.ID_CAU_HOI)).FirstOrDefault();
                            ltQuestion.Text = ltQuestion.Text + string.Format(@"
                           <div class='dap_an_TL_css'><textarea style='width:100%;' rows='5' readonly='readonly'>{0}</textarea></div>", UVTL.NOI_DUNG_TRA_LOI);
                            //< p >< input type = 'text' value = '{0}' width = '100%' height = '90px' readonly /></ p >
                        }

                        ltQuestion.Text = ltQuestion.Text + "</div>";//The dong "CAU HOI"
                        i++;
                        SoCau++;
                    }

                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("UVReviewBT_List.aspx"));
        }
    }
}
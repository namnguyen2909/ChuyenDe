using CPanel.Commons;
using CPanel.Models;
using CPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel.Modules.QuanLyBaiThi
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Commons.ATCL_Commons.getChuDe(drpMenus, entities);
                Commons.ATCL_Commons.getMucDoBaiThi(DropDownList1, entities);
                getMucDoBaiThi();
                getObjects();
            }
        }

        public void getObjects()
        {
            if (!String.IsNullOrEmpty(txtObjectID.Text))
            {
                int intObjectID = Convert.ToInt32(txtObjectID.Text);
                var obj = entities.BAI_THI.Where(x => x.ID == intObjectID).FirstOrDefault();
                if (obj != null)
                {
                    if (obj.ID != null)
                        drpMenus.SelectedValue = obj.ID.ToString();
                }
            }
        }
        public void getMucDoBaiThi()
        {
            if (!String.IsNullOrEmpty(txtObjectID.Text))
            {
                int intObjectID = Convert.ToInt32(txtObjectID.Text);
                var obj = entities.MUC_DO_BAI_THI.Where(x => x.ID == intObjectID).FirstOrDefault();
                if (obj != null)
                {
                    if (obj.ID != null)
                        DropDownList1.SelectedValue = obj.ID.ToString();
                }
            }
        }

        protected string saveObject()
        {
            try
            {
                BAI_THI obj = new BAI_THI();
                MUC_DO_BAI_THI objMD = new MUC_DO_BAI_THI();

                int intChuDeBaiThiID = Convert.ToInt32(drpMenus.SelectedValue);
                int SoLuongCauHoiDeTN = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 1 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 1).Count();
                int SoLuongCauHoiTrungBinhTN = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 1 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 2).Count();
                int SoLuongCauHoiKhoTN = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 1 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 3).Count();

                int SoLuongCauHoiDeTL = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 2 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 1).Count();
                int SoLuongCauHoiTrungBinhTL = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 2 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 2).Count();
                int SoLuongCauHoiKhoTL = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 2 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 3).Count();


                if (String.IsNullOrEmpty(txtObjectID.Text)) //Create new item
                {
                    obj.NGAY_TAO = DateTime.Now;
                    obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    obj.TT_XOA = false;

                    entities.BAI_THI.Add(obj);
                }
                else //Edit the item
                {
                    int intObjID = Convert.ToInt32(txtObjectID.Text);
                    obj = entities.BAI_THI.Find(intObjID);
                }

                obj.TEN_BAI_THI = txtTenBaiThi.Text;
                obj.THOI_GIAN = Convert.ToInt32(txtThoiGianThi.Text);

                CAU_HINH_BAI_THI objTN = new CAU_HINH_BAI_THI();
                if (String.IsNullOrEmpty(txtObjectID.Text)) //Create new item
                {
                    objTN.NGAY_TAO = DateTime.Now;
                    objTN.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    objTN.TT_XOA = false;

                    entities.CAU_HINH_BAI_THI.Add(objTN);
                }
                else //Edit the item
                {
                    int intObjID = Convert.ToInt32(txtObjectID.Text);
                    objTN = entities.CAU_HINH_BAI_THI.Find(intObjID);
                }

                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpMenus.SelectedValue))
                {
                    obj.ID_CHU_DE_BAI_THI = Convert.ToInt32(drpMenus.SelectedValue);
                }

                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(DropDownList1.SelectedValue))
                {
                    obj.ID_MUC_DO_BAI_THI = Convert.ToInt32(DropDownList1.SelectedValue);
                }

                objTN.ID_BAI_THI = obj.ID;
                objTN.SO_LUONG_CAU_DE = Convert.ToInt32(String.IsNullOrEmpty(txtSoLuongCauHoiDeTN.Text) ? "0" : txtSoLuongCauHoiDeTN.Text);
                objTN.SO_LUONG_CAU_TB = Convert.ToInt32(String.IsNullOrEmpty(txtSoLuongCauHoiTrungBinhTN.Text) ? "0" : txtSoLuongCauHoiTrungBinhTN.Text);
                objTN.SO_LUONG_CAU_KHO = Convert.ToInt32(String.IsNullOrEmpty(txtSoLuongCauHoiKhoTN.Text) ? "0" : txtSoLuongCauHoiKhoTN.Text);

                if (!(String.IsNullOrEmpty((txtSoLuongCauHoiDeTN.Text))) || !(String.IsNullOrEmpty((txtSoLuongCauHoiTrungBinhTN.Text))) || !(String.IsNullOrEmpty((txtSoLuongCauHoiKhoTN.Text))))
                {
                    objTN.ID_LOAI_CAU_HOI = 1;
                }
                else
                {
                    objTN.ID_LOAI_CAU_HOI = 1;
                }
                CAU_HINH_BAI_THI objTL = new CAU_HINH_BAI_THI();
                if (String.IsNullOrEmpty(txtObjectID.Text)) //Create new item
                {
                    objTL.NGAY_TAO = DateTime.Now;
                    objTL.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    objTL.TT_XOA = false;

                    entities.CAU_HINH_BAI_THI.Add(objTL);
                }
                else //Edit the item
                {
                    int intObjID = Convert.ToInt32(txtObjectID.Text);
                    objTL = entities.CAU_HINH_BAI_THI.Find(intObjID);
                }

                objTL.ID_BAI_THI = obj.ID;
                objTL.SO_LUONG_CAU_DE = Convert.ToInt32(String.IsNullOrEmpty(txtSoLuongCauHoiDeTL.Text) ? "0" : txtSoLuongCauHoiDeTL.Text);
                objTL.SO_LUONG_CAU_TB = Convert.ToInt32(String.IsNullOrEmpty(txtSoLuongCauHoiTrungBinhTL.Text) ? "0" : txtSoLuongCauHoiTrungBinhTL.Text);
                objTL.SO_LUONG_CAU_KHO = Convert.ToInt32(String.IsNullOrEmpty(txtSoLuongCauHoiKhoTL.Text) ? "0" : txtSoLuongCauHoiKhoTL.Text);

                if (!(String.IsNullOrEmpty((txtSoLuongCauHoiDeTL.Text))) || !(String.IsNullOrEmpty((txtSoLuongCauHoiTrungBinhTL.Text)))|| !(String.IsNullOrEmpty((txtSoLuongCauHoiKhoTL.Text))))
                {
                    objTL.ID_LOAI_CAU_HOI = 2;
                }
                else
                {
                    objTL.ID_LOAI_CAU_HOI = 2;
                }
                entities.SaveChanges();

                //goi ham update
                update_CauHoi_BaiThi(obj.ID, (int)obj.ID_CHU_DE_BAI_THI);

                return obj.ID.ToString();//ID cua bai

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        protected void update_CauHoi_BaiThi(int intBaiThi, int intChuDeBaiThiID)
        {
            
            //Tim kiem cau hinh bai thi

            //load cau hoi
            var lstCHBT = entities.CAU_HINH_BAI_THI.Where(x => x.ID_BAI_THI == intBaiThi).ToList();


            //----------------------------------------------------
            
            if ((lstCHBT != null) && (lstCHBT.Count > 0))
            {

                foreach (var item in lstCHBT)
                {
                    updateCauHoi(intBaiThi, intChuDeBaiThiID, item, (int)item.ID_LOAI_CAU_HOI);
                }
            }
            
        }

        public void updateCauHoi(int intBaiThi, int intChuDeBaiThiID, CAU_HINH_BAI_THI item, int LOAI_CAU_HOI)
        {
            int LOAI_CAU_HOI_DE = 1;
            int LOAI_CAU_HOI_TB = 2;
            int LOAI_CAU_HOI_KHO = 3;
            int intSoLuongDe;
            int intSoLuongTrungBinh;
            int intSoLuongKho;
            List<int> lstCauHoiID = new List<int>();

            //Lay cau hoi trac nghiem de
            intSoLuongDe = Convert.ToInt32(item.SO_LUONG_CAU_DE);
            if (intSoLuongDe > 0)
            {
                var lstCauHoiDe = entities.CAU_HOI.Join(entities.CAU_HOI_MUC_DO, CH => CH.ID, CHMD => CHMD.ID_CAU_HOI, (CH, CHMD) => new { CH, CHMD }).Where(x => (x.CH.ID_CHU_DE_BAI_THI == intChuDeBaiThiID) && (x.CHMD.ID_MUC_DO_CAU_HOI == LOAI_CAU_HOI_DE) && (x.CH.ID_LOAI_CAU_HOI == LOAI_CAU_HOI) && (!lstCauHoiID.Contains(x.CH.ID))).Take(intSoLuongDe).ToList();

                if ((lstCauHoiDe != null) && (lstCauHoiDe.Count > 0))
                {
                    foreach (var itemCHDe in lstCauHoiDe)
                    {
                        //Cap nhat vao bang bai thi cau hoi
                        BAI_THI_CAU_HOI objBTCH = new BAI_THI_CAU_HOI();
                        objBTCH.ID_BAI_THI = intBaiThi;
                        objBTCH.ID_CAU_HOI = itemCHDe.CH.ID;
                        entities.BAI_THI_CAU_HOI.Add(objBTCH);
                        entities.SaveChanges();

                        //Cap nhat vao danh sach cau hoi da chon
                        lstCauHoiID.Add((int)objBTCH.ID_CAU_HOI);
                    }
                }
            }

            //Lay cau hoi trac nghiem trung binh
            intSoLuongTrungBinh = Convert.ToInt32(item.SO_LUONG_CAU_TB);
            if (intSoLuongTrungBinh > 0)
            {
                var lstCauHoiTrungBinh = entities.CAU_HOI.Join(entities.CAU_HOI_MUC_DO, CH => CH.ID, CHMD => CHMD.ID_CAU_HOI, (CH, CHMD) => new { CH, CHMD }).Where(x => (x.CH.ID_CHU_DE_BAI_THI == intChuDeBaiThiID) && (x.CHMD.ID_MUC_DO_CAU_HOI == LOAI_CAU_HOI_TB) && (x.CH.ID_LOAI_CAU_HOI == LOAI_CAU_HOI)
                                            && (!lstCauHoiID.Contains(x.CH.ID))).Take(intSoLuongTrungBinh).ToList();

                if ((lstCauHoiTrungBinh != null) && (lstCauHoiTrungBinh.Count > 0))
                {
                    foreach (var itemCHTB in lstCauHoiTrungBinh)
                    {
                        //Cap nhap vao bang bai thi cau hoi
                        BAI_THI_CAU_HOI objBTCH = new BAI_THI_CAU_HOI();
                        objBTCH.ID_BAI_THI = intBaiThi;
                        objBTCH.ID_CAU_HOI = itemCHTB.CH.ID;
                        entities.BAI_THI_CAU_HOI.Add(objBTCH);
                        entities.SaveChanges();

                        //Cap nhat vao danh sach cau hoi da chon
                        lstCauHoiID.Add((int)objBTCH.ID_CAU_HOI);
                    }
                }
            }

            //Lay cau hoi trac nghiem kho
            intSoLuongKho = Convert.ToInt32(item.SO_LUONG_CAU_KHO);
            if (intSoLuongKho > 0)
            {
                //var lstCauHoiKho = entities.CAU_HOI.Where(x => (x.ID_CHU_DE_BAI_THI == intChuDeBaiThiID) && (x.ID_LOAI_CAU_HOI == LOAI_CAU_HOI_KHO)).Take(intSoLuongKho).ToList();

                var lstCauHoiKho = entities.CAU_HOI.Join(entities.CAU_HOI_MUC_DO, CH => CH.ID, CHMD => CHMD.ID_CAU_HOI, (CH, CHMD) => new { CH, CHMD }).Where(x => (x.CH.ID_CHU_DE_BAI_THI == intChuDeBaiThiID) && (x.CHMD.ID_MUC_DO_CAU_HOI == LOAI_CAU_HOI_KHO) && (x.CH.ID_LOAI_CAU_HOI == LOAI_CAU_HOI) && (!lstCauHoiID.Contains(x.CH.ID))).Take(intSoLuongKho).ToList();

                if ((lstCauHoiKho != null) && (lstCauHoiKho.Count > 0))
                {
                    foreach (var itemCHK in lstCauHoiKho)
                    {
                        //Cap nhap vao bang bai thi cau hoi
                        BAI_THI_CAU_HOI objBTCH = new BAI_THI_CAU_HOI();
                        objBTCH.ID_BAI_THI = intBaiThi;
                        objBTCH.ID_CAU_HOI = itemCHK.CH.ID;
                        entities.BAI_THI_CAU_HOI.Add(objBTCH);
                        entities.SaveChanges();

                        //Cap nhat vao danh sach cau hoi da chon
                        lstCauHoiID.Add((int)objBTCH.ID_CAU_HOI);
                    }
                }
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            int intChuDeBaiThiID = Convert.ToInt32(drpMenus.SelectedValue);
            int SoLuongCauHoiDeTN = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 1 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 1).Count();
            int SoLuongCauHoiTrungBinhTN = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 1 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 2).Count();
            int SoLuongCauHoiKhoTN = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 1 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 3).Count();

            int SoLuongCauHoiDeTL = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 2 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 1).Count();
            int SoLuongCauHoiTrungBinhTL = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 2 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 2).Count();
            int SoLuongCauHoiKhoTL = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 2 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 3).Count();

            if (String.IsNullOrEmpty(txtSoLuongCauHoiDeTN.Text))
            {
                txtSoLuongCauHoiDeTN.Text = "0";
            }
            if (String.IsNullOrEmpty(txtSoLuongCauHoiTrungBinhTN.Text))
            {
                txtSoLuongCauHoiTrungBinhTN.Text = "0";
            }
            if (String.IsNullOrEmpty(txtSoLuongCauHoiKhoTN.Text))
            {
                txtSoLuongCauHoiKhoTN.Text = "0";
            }
            if (String.IsNullOrEmpty(txtSoLuongCauHoiDeTL.Text))
            {
                txtSoLuongCauHoiDeTL.Text = "0";
            }
            if (String.IsNullOrEmpty(txtSoLuongCauHoiTrungBinhTL.Text))
            {
                txtSoLuongCauHoiTrungBinhTL.Text = "0";
            }
            if (String.IsNullOrEmpty(txtSoLuongCauHoiKhoTL.Text))
            {
                txtSoLuongCauHoiKhoTL.Text = "0";
            }
            if (txtSoLuongCauHoiDeTN.Text.Contains('-') || txtSoLuongCauHoiTrungBinhTN.Text.Contains('-') || txtSoLuongCauHoiKhoTN.Text.Contains('-')
                || txtSoLuongCauHoiDeTL.Text.Contains('-') || txtSoLuongCauHoiTrungBinhTL.Text.Contains('-') || txtSoLuongCauHoiKhoTL.Text.Contains('-'))
            {
                Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("Số lượng câu hỏi phải lớn hơn 0"), Page);
            }
            else if (txtSoLuongCauHoiDeTN.Text.Contains('.') || txtSoLuongCauHoiTrungBinhTN.Text.Contains('.') || txtSoLuongCauHoiKhoTN.Text.Contains('.')
                    || txtSoLuongCauHoiDeTL.Text.Contains('.') || txtSoLuongCauHoiTrungBinhTL.Text.Contains('.') || txtSoLuongCauHoiKhoTL.Text.Contains('.'))
            {
                Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("Bạn phải nhập số nguyên"), Page);
            }
            else
            {
                if (Convert.ToDouble(txtSoLuongCauHoiDeTN.Text) > SoLuongCauHoiDeTN)
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("Số lượng câu hỏi Trắc nghiệm dễ phải nhỏ hơn hoặc bằng " + SoLuongCauHoiDeTN), Page);
                }
                else if (Convert.ToDouble(txtSoLuongCauHoiTrungBinhTN.Text) > SoLuongCauHoiTrungBinhTN)
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("Số lượng câu hỏi Trắc nghiệm trung bình phải nhỏ hơn hoặc bằng " + SoLuongCauHoiTrungBinhTN), Page);
                }
                else if (Convert.ToDouble(txtSoLuongCauHoiKhoTN.Text) > SoLuongCauHoiKhoTN)
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("Số lượng câu hỏi Trắc nghiệm khó phải nhỏ hơn hoặc bằng " + SoLuongCauHoiKhoTN), Page);
                }
                else if (Convert.ToDouble(txtSoLuongCauHoiDeTL.Text) > SoLuongCauHoiDeTL)
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("Số lượng câu hỏi Tự luận dễ phải nhỏ hơn hoặc bằng " + SoLuongCauHoiDeTL), Page);
                }
                else if (Convert.ToDouble(txtSoLuongCauHoiTrungBinhTL.Text) > SoLuongCauHoiTrungBinhTL)
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("Số lượng câu hỏi Tự luận trung bình phải nhỏ hơn hoặc bằng " + SoLuongCauHoiTrungBinhTL), Page);
                }
                else if (Convert.ToDouble(txtSoLuongCauHoiKhoTL.Text) > SoLuongCauHoiKhoTL)
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("Số lượng câu hỏi Tự luận khó phải nhỏ hơn hoặc bằng " + SoLuongCauHoiKhoTL), Page);
                }
                else
                {
                    string strBaiThiID = saveObject();
                    setSessionForChuDeBaiThi(strBaiThiID);
                    Response.Redirect(Commons.TitleConst.getTitleConst("TaoDeBaiThi.aspx"));
                }
            }
        }
        protected void setSessionForChuDeBaiThi(string strBaiThiID)
        {
            SessionForChuDeBaiThi objSessionForChuDeBaiThi = new SessionForChuDeBaiThi();
            objSessionForChuDeBaiThi.ID_CHU_DE_BAI_THI = drpMenus.SelectedValue;
            objSessionForChuDeBaiThi.SESSION_OBJECT_ID = strBaiThiID;
            objSessionForChuDeBaiThi.ID_MUC_DO_BAI_THI = DropDownList1.SelectedValue;
            objSessionForChuDeBaiThi.THOI_GIAN = txtThoiGianThi.Text;
            objSessionForChuDeBaiThi.TEN_BAI_THI = txtTenBaiThi.Text;
            Session[Commons.ConstValues.SESSION_CHUDEBAITHI] = objSessionForChuDeBaiThi;
        }

        protected void CheckTongSoCauHoi()
        {
            int intChuDeBaiThiID = Convert.ToInt32(drpMenus.SelectedValue);
            int SoLuongCauHoiDeTN = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 1 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 1).Count();
            int SoLuongCauHoiTrungBinhTN = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 1 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 2).Count();
            int SoLuongCauHoiKhoTN = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 1 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 3).Count();

            int SoLuongCauHoiDeTL = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 2 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 1).Count();
            int SoLuongCauHoiTrungBinhTL = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 2 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 2).Count();
            int SoLuongCauHoiKhoTL = entities.CAU_HOI_MUC_DO.Where(x => x.CAU_HOI.ID_LOAI_CAU_HOI == 2 && x.CAU_HOI.ID_CHU_DE_BAI_THI == intChuDeBaiThiID && x.CAU_HOI.TT_XOA == false && x.ID_MUC_DO_CAU_HOI == 3).Count();
            
            if (SoLuongCauHoiDeTN == 0)
            {
                lbDeTN.Text = "Hiện chưa có câu nào";
                txtSoLuongCauHoiDeTN.ReadOnly = true;
            }
            else
            {
                lbDeTN.Text = "";
                txtSoLuongCauHoiDeTN.ReadOnly = false;
            }

            if (SoLuongCauHoiTrungBinhTN == 0)
            {
                lbTrungBinhTN.Text = "Hiện chưa có câu nào";
                txtSoLuongCauHoiTrungBinhTN.ReadOnly = true;
            }
            else
            {
                lbTrungBinhTN.Text = "";
                txtSoLuongCauHoiTrungBinhTN.ReadOnly = false;
            }

            if (SoLuongCauHoiKhoTN == 0)
            {
                lbKhoTN.Text = "Hiện chưa có câu nào";
                txtSoLuongCauHoiKhoTN.ReadOnly = true;
            }
            else
            {
                lbKhoTN.Text = "";
                txtSoLuongCauHoiKhoTN.ReadOnly = false;
            }

            if (SoLuongCauHoiDeTL == 0)
            {
                lbDeTL.Text = "Hiện chưa có câu nào";
                txtSoLuongCauHoiDeTL.ReadOnly = true;
            }
            else
            {
                lbDeTL.Text = "";
                txtSoLuongCauHoiDeTL.ReadOnly = false;
            }

            if (SoLuongCauHoiTrungBinhTL == 0)
            {
                lbTrungBinhTL.Text = "Hiện chưa có câu nào";
                txtSoLuongCauHoiTrungBinhTL.ReadOnly = true;
            }
            else
            {
                lbTrungBinhTL.Text = "";
                txtSoLuongCauHoiTrungBinhTL.ReadOnly = false;
            }

            if (SoLuongCauHoiKhoTL == 0)
            {
                lbKhoTL.Text = "Hiện chưa có câu nào";
                txtSoLuongCauHoiKhoTL.ReadOnly = true;
            }
            else
            {
                lbKhoTL.Text = "";
                txtSoLuongCauHoiKhoTL.ReadOnly = false;
            }
        }

        protected void drpMenus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckTongSoCauHoi();
        }
        //protected void setSessionForMucDoBaiThi()
        //{
        //    SessionForMucDoBaiThi objSessionForMucDoBaiThi = new SessionForMucDoBaiThi();
        //    objSessionForMucDoBaiThi.ID_MUC_DO_BAI_THI = DropDownList1.SelectedValue;
        //    Session[Commons.ConstValues.SESSION_MUCDOBAITHI] = objSessionForMucDoBaiThi;
        //}
        //protected void setSessionForThoiGianThi()
        //{
        //    SessionForThoiGianThi objSessionForThoiGianThi = new SessionForThoiGianThi();
        //    objSessionForThoiGianThi.THOI_GIAN = txtThoiGianThi.Text;
        //    Session[Commons.ConstValues.SESSION_THOIGIANTHI] = objSessionForThoiGianThi;
        //}
        //protected void setSessionForTenBaiThi()
        //{
        //    SessionForTenBaiThi objSessionForTenBaiThi = new SessionForTenBaiThi();
        //    objSessionForTenBaiThi.TEN_BAI_THI = txtTenBaiThi.Text;
        //    Session[Commons.ConstValues.SESSION_TENBAITHI] = objSessionForTenBaiThi;
        //}
    }
}
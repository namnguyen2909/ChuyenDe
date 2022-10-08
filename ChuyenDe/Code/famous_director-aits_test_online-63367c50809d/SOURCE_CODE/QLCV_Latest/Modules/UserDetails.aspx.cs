using DevExpress.Web;
using CPanel.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPanel.Models;

namespace CPanel.Modules.Admin
{

    public partial class UserDetails : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack)
            {
                //Set Captions for GridView
                Commons.TitleConst.setTitleConst_ASPxGridView(grvObj);

                //get Group list
                grvObj.DataBind();

                //Get User's info
                string strUserID = Request.QueryString["userID"];
                if (!String.IsNullOrEmpty(strUserID))
                {
                    txtUserID.Text = strUserID;

                    int intUserID = Convert.ToInt32(strUserID);
                    var objSearchUser = entities.TBL_NGUOI_DUNG.Where(x => x.Id == intUserID).FirstOrDefault();
                    if (objSearchUser != null)
                    {
                        getOutputs(objSearchUser);

                        //Unchecked & Checked
                        var lstGroupID = entities.TBL_NGUOI_DUNG_PHONG_BAN.Where(x => x.UserID == objSearchUser.Id).Select(x => x.DepartmentID).ToList();
                        if ((lstGroupID != null) && (lstGroupID.Count >0))
                        {
                            grvObj.Selection.UnselectAll();
                            foreach (int i in lstGroupID)
                            {
                                grvObj.Selection.SetSelectionByKey(i, true);
                            }
                        }
                        
                    }


                }


                
            }
        }
        private void setInputs( TBL_NGUOI_DUNG objUserLogin)
        {            
            objUserLogin.UserName = txtUsername.Text;            
            objUserLogin.FullName = txtFullName.Text;
            objUserLogin.Email = txtEmail.Text;
            if (!String.IsNullOrEmpty(txtPassword_1.Text))
            {
                objUserLogin.Password = Formats.GetMD5(txtPassword_1.Text);
            }            
            objUserLogin.isEnabled = (bool)(cbActiveSatus.Checked ? true : false);
        }

        protected void grvRights_DataBinding(object sender, EventArgs e)
        {

        }

        private void getOutputs(TBL_NGUOI_DUNG objUserLogin)
        {
            txtUsername.Text = objUserLogin.UserName;
            txtFullName.Text = objUserLogin.FullName;
            txtEmail.Text = objUserLogin.Email;
            
            if (objUserLogin.isEnabled == true)
            {
                cbActiveSatus.Checked = true;
            }
            else
            {
                cbActiveSatus.Checked = false;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                TBL_NGUOI_DUNG objSearchUser = new TBL_NGUOI_DUNG();
                bool blPassword = true;

                if (String.IsNullOrEmpty(txtUsername.Text))
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay("You must type User name", Page);
                    return;
                }

                if (String.IsNullOrEmpty(txtFullName.Text))
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay("You must type Full name", Page);
                    return;
                }

                if (String.IsNullOrEmpty(txtUserID.Text)) //Create New
                {
                    entities.TBL_NGUOI_DUNG.Add(objSearchUser);
                    //Check Password
                    if (String.IsNullOrEmpty(txtPassword_1.Text) || String.IsNullOrEmpty(txtPassword_2.Text))
                    {
                        Commons.ValidationFuncs.errorMessage_TimeDelay("You must type the password", Page);                        
                        return;
                    }

                }
                else //Update
                {
                    int intUserID = Convert.ToInt32(txtUserID.Text);
                    objSearchUser = entities.TBL_NGUOI_DUNG.Where(x => x.Id == intUserID).FirstOrDefault();                    
                }

                //check Password                
                if (!String.IsNullOrEmpty(txtPassword_1.Text))
                {
                    if (!txtPassword_1.Text.Equals(txtPassword_2.Text))
                        blPassword = false;
                } 
                else if (!String.IsNullOrEmpty(txtPassword_2.Text))
                {
                    if (!txtPassword_2.Text.Equals(txtPassword_1.Text))
                        blPassword = false;
                }
                if (!blPassword)
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay("Password is incorrect", Page);                                            
                    return;
                }

                setInputs(objSearchUser);                        
                entities.SaveChanges(); 
                
                //Save into JOS_GROUPS_USERS tbl
                var lstGrvObj = grvObj.GetSelectedFieldValues(grvObj.KeyFieldName);
                
                if ((lstGrvObj != null) && (lstGrvObj.Count > 0)) //Disable
                {
                    //delete all records in JOS_GROUPS_USERS tbl with User's ID
                    var lstDelete = entities.TBL_NGUOI_DUNG_PHONG_BAN.Where(x => x.UserID == objSearchUser.Id).ToList();
                    foreach (var itemDel in lstDelete)
                    {
                        entities.TBL_NGUOI_DUNG_PHONG_BAN.Remove(itemDel);
                        entities.SaveChanges();
                    }

                    //Insert into JOS_GROUPS_USERS
                    foreach (int item in lstGrvObj)
                    {
                        TBL_NGUOI_DUNG_PHONG_BAN objGroupUser = new TBL_NGUOI_DUNG_PHONG_BAN();
                        objGroupUser.DepartmentID = item;
                        objGroupUser.UserID = objSearchUser.Id;
                        entities.TBL_NGUOI_DUNG_PHONG_BAN.Add(objGroupUser);
                        entities.SaveChanges();
                    }
                }
                
                backURL();
            }
            catch (Exception ex)
            {
                lbMessage.Text = ex.Message;
            }
                
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            backURL();
        }
        private void backURL()
        {
            Response.Redirect(Commons.ConstURL.URL_USER_VIEW);
        }

        //private void saveInToGroupUsers()
        //{
        //    int intUserID = -999;//Any Value
        //    var objSearchUser = entities.USERLOGINs.Where(x => x.USERNAME.IndexOf(txtUsername.Text) >= 0).FirstOrDefault();
        //    if (objSearchUser != null)
        //    {
        //        intUserID = objSearchUser.ID;
        //    }
        //    var lstRights = grvRights.GetSelectedFieldValues(grvRights.KeyFieldName);


        //    if (intUserID > 0)
        //    {
        //        // Xóa user khỏi tbl GROUP_USERs
        //        var lstGroupUser = entities.GROUPS_USER.Where(x => x.IDUSER == intUserID).ToList();
        //        if (lstGroupUser != null)
        //        {
        //            foreach (var item in lstGroupUser)
        //            {
        //                entities.GROUPS_USER.Remove(item);
        //                entities.SaveChanges();
        //            }
        //        }

        //        // Thêm user vào GROUP_USERS
        //        foreach (int i in lstRights)
        //        {
        //            GROUPS_USER obj = new GROUPS_USER();
        //            if (entities.GROUPS_USER.Count() > 0) obj.ID = entities.GROUPS_USER.Max(x => x.ID) + 1;
        //            else obj.ID = 1;
        //            obj.IDGROUPS = i;
        //            obj.IDUSER = intUserID;
        //            obj.CREATED = obj.LASTMODIFY = DateTime.Now;
        //            obj.CREATEDBY = obj.MODIFYBY = CheckUserInfo.GetUserId();
        //            entities.GROUPS_USER.Add(obj);
        //            entities.SaveChanges();
        //        }
        //    }


        //}

        protected void btnReject_Click(object sender, EventArgs e)
        {
            //try
            //{                               
            //    if (!String.IsNullOrEmpty(txtUsername.Text))
            //    {
            //        var objSearchUser = entities.USERLOGINs.Where(x => x.USERNAME.IndexOf(txtUsername.Text) >= 0).FirstOrDefault();
            //        if (objSearchUser != null)
            //        {
            //            setInputs(objSearchUser);
                        
            //            //Set status = "REJECTED" (=-1)
            //            objSearchUser.IS_ACTIVE = -1;

            //            entities.SaveChanges();
            //            lbMessage.Text = "Reject successfully";
            //        }
            //        backURL();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lbMessage.Text = ex.Message;
            //}
        }

        protected void grvObj_DataBinding(object sender, EventArgs e)
        {
            var lstObjs = entities.TBL_PHONG_BAN.Where(x => ((bool)x.isDeleted == false) && ((bool)x.isVisible)).ToList();
            grvObj.DataSource = lstObjs;
        }
   }
}
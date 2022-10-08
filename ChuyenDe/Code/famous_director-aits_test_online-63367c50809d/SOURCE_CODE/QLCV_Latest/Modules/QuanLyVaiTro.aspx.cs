using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPanel.Commons;
using System.Web.Services;
using CPanel.Models;

namespace CPanel.Modules
{
    public partial class QuanLyVaiTro : System.Web.UI.Page
    {
        ATCLEntities entities = new ATCLEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Set Captions for GridView
            Commons.TitleConst.setTitleConst_ASPxGridView(grvLib);

            if (!IsPostBack)
            {                
                grvLib.DataBind();
            }

        }
        
        protected void grvLib_DataBinding(object sender, EventArgs e)
        {
           
            var lstVaitro = entities.TBL_QUYEN.ToList();
            grvLib.DataSource = lstVaitro;            
        }

        protected void grvLib_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                var objMenu = entities.TBL_QUYEN.Find(e.Keys[0]);
                if (objMenu != null)
                {
                    entities.TBL_QUYEN.Remove(objMenu);
                    entities.SaveChanges();
                    
                    //Display Message Box
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("MSG_DELETE_SUCCESFULLY"), Page);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                // ghi log
            }
            finally
            {
                e.Cancel = true;
            }
        }

        protected void grvLib_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)// cho nút submit của edit
        {
            try
            {
                var objVaitro = entities.TBL_QUYEN.Find(Convert.ToInt32(e.Keys[0]));
                
                if (objVaitro != null)
                {
                    objVaitro.NAME = Convert.ToString(e.NewValues["NAME"]);
                    objVaitro.DESCRIPTION = Convert.ToString(e.NewValues["DESCRIPTION"]);
                }
                
                //Validation and update into DB
                if (validation(objVaitro))
                {
                    entities.SaveChanges();
                    grvLib.CancelEdit(); //This line closes the line Editor.
                    grvLib.Focus();
                    //Display Message Box
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("MSG_UPDATE_SUCCESFULLY"), Page);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
                // ghi log
            }
            finally
            {
                e.Cancel = true;

            }
        }

        /**
         * DESCRIPTION: This funtion check fomat before updating into DB
         * INPUTS: Menu is the object need updated into DB
         * OUTPUTS: TRUE if data is valid; FALSE if data is invalid
         * WRITTEN BY: TUYENDV
         **/
        protected bool validation(TBL_QUYEN objMenu)
        {
            //Check whether TITLE is empty
            if (String.IsNullOrEmpty(objMenu.NAME))
            {
                Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("MSG_TEN_VAI_TRO"), Page);
                return false;
            }

            return true;
        }

        protected void grvLib_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try {
                TBL_QUYEN objVaitro = new TBL_QUYEN();

                objVaitro.NAME = Convert.ToString(e.NewValues["NAME"]);

                objVaitro.DESCRIPTION = Convert.ToString(e.NewValues["DESCRIPTION"]);

                if (validation(objVaitro))
                {
                    entities.TBL_QUYEN.Add(objVaitro);
                    entities.SaveChanges();
                    grvLib.CancelEdit(); //This line closes the line Editor.
                    grvLib.Focus();
                    //Display Message Box
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("MSG_INSERT_SUCCESFULLY"), Page);
                }
                
            }
            catch (Exception ex)
            {
                //errorMsg.Text = "Lỗi: " + ex.Message + ex.InnerException + ex.StackTrace;
                // ghi log
                throw ex;
            }
            finally
            {
                e.Cancel = true;
                
            }
        }

        protected void redirectURL()
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_MENUS"));
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CPanel.Models.Menu objMenu = new CPanel.Models.Menu();

        //        if (entities.Menus.Count() > 0) 
        //            objMenu.id = entities.jos_menu.Max(x => x.id) + 1;
        //        else objMenu.id = 1;

        //        if (!String.IsNullOrEmpty(txtTieude.Text))
        //        {
        //            objMenu.name = txtTieude.Text;
        //            string str = drpMenus.SelectedValue;
        //            if (!drpMenus.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))
        //                objMenu.parent = Convert.ToInt32(drpMenus.SelectedValue);
        //        }
        //        else
        //        {
        //            Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("ERROR_TITLE_THIEU"), Page);
        //            return;
        //        }
        //        entities.jos_menu.Add(objMenu);
        //        entities.SaveChanges();

        //        //Save System Log
        //        Commons.CommonFunctionsAndProcedures.saveSystemLog (String.Format(Commons.TitleConst.getTitleConst("LOG_MENU_CREATE"), objMenu.name));

        //        redirectURL();
        //    }
        //    catch (Exception ex)
        //    {
        //        //errorMsg.Text = "Lỗi: " + ex.Message + ex.InnerException + ex.StackTrace;
        //        // ghi log
        //        throw ex;
        //    }
        //}

    }
}
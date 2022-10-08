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
    public partial class QuanLyNhomQuyen : System.Web.UI.Page
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


        protected void getListOfRights(int intRightLevel, string strIDRight, List<CPanel.Models.TBL_QUYEN> lstResultOfRights)
        {
            int intIDRight = 0; bool blNumber = false;
            if (!String.IsNullOrEmpty(strIDRight))
            {
                intIDRight = Convert.ToInt32(strIDRight);
                blNumber = true;
            }
            else //Begin --> reset DropDownlist
            {
                lstResultOfRights.Clear();
            }

            var lstRight = entities.TBL_QUYEN.Where(x => ((blNumber && x.ID_PARENT == intIDRight) || (blNumber == false && x.ID_PARENT == 0)))
                                                   .ToList();


            if (lstRight != null)
            {
                foreach (var item in lstRight)
                {
                    string strLine = "";
                    strLine = strLine.PadLeft(intRightLevel * 6, (char)Commons.TitleConst.getTitleConst("TITLE_ICON").ElementAt(0));
                    CPanel.Models.TBL_QUYEN objMenu = new CPanel.Models.TBL_QUYEN();
                    objMenu.ID = item.ID;
                    objMenu.ID_PARENT = item.ID_PARENT;                    

                    if (intRightLevel == 0) //Begining Level
                    {
                        objMenu.NAME = strLine + item.NAME;
                    }
                    else objMenu.NAME = strLine + item.NAME;
                    lstResultOfRights.Add(objMenu);
                    getListOfRights(intRightLevel + 1, item.ID.ToString(), lstResultOfRights);
                }
            }
        }

        
        protected void grvLib_DataBinding(object sender, EventArgs e)
        {

            List<CPanel.Models.TBL_QUYEN> lstVaitro = new List<CPanel.Models.TBL_QUYEN>();

            getListOfRights(0, null, lstVaitro);
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
        protected bool validation(TBL_QUYEN objQuyen)
        {
            //Check whether TITLE is empty
            if (String.IsNullOrEmpty(objQuyen.NAME))
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

    }
}
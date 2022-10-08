<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectReports.aspx.cs" Inherits="CPanel.SelectReports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=CPanel.Commons.TitleConst.getTitleConst("TITLE_PAGE_ATCL") %></title>
    <script src="/Templates/js/jquery-1.10.2.min.js"></script>
    <link href="/Templates/css/atcl_style.css" rel="stylesheet" />    
    <link href="/Templates/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Templates/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="/Templates/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
        <div id="DIV_MESSAGE" visible="false" runat="server">
            <div  class="pop_up_background_css"></div>
            <div class="pop_up_info_css pop_up_message_css" runat="server">
                <asp:Button ID="Button1" OnClick="btlClosePopUp_Click" Text="X" CssClass="btn btn-danger close_css" runat="server" />
                <a class="a_report_css" href="javascript:funAnonymous()"><%=CPanel.Commons.TitleConst.getTitleConst("BAO_CAO_NAC_DANH") %></a>
                <a class="a_report_css" href="javascript:funIdentification()"><%=CPanel.Commons.TitleConst.getTitleConst("BAO_CAO_DANG_NHAP") %></a>                
            </div>
        </div>

        <div class="panel panel-primary text-center form_css login-form">
            <div class="panel-heading">
                <h3 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("TITLE_PAGE_ATCL") %></h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <a class="a_report_css" href="javascript:selectReports('<%=ConfigurationManager.AppSettings["CODE_OPEN_REPORTS"]%>')">
                        <%=CPanel.Commons.TitleConst.getTitleConst("TITLE_BC_MO") %>
                    </a>

                    <a class="a_report_css" href="javascript:selectReports('<%=ConfigurationManager.AppSettings["CODE_GUARD_REPORTS"]%>')">
                        <%=CPanel.Commons.TitleConst.getTitleConst("TITLE_BC_CA_CUA_DOI_TRUC_BAN") %>
                    </a>

                    <a class="a_report_css" href="javascript:selectReports('<%=ConfigurationManager.AppSettings["CODE_TARGET_REPORTS"]%>')">
                        <%=CPanel.Commons.TitleConst.getTitleConst("TITLE_BC_MUC_TIEU_DK_MUC_TIEU") %>
                    </a>                    



                    <a class="a_report_css" href="javascript:selectReports('<%=ConfigurationManager.AppSettings["CODE_URGENT_REPORTS"]%>')">
                        <%=CPanel.Commons.TitleConst.getTitleConst("TITLE_BC_SU_CO_KHAN_NGUY") %>
                    </a>

                    <a class="a_report_css" href="javascript:selectReports('<%=ConfigurationManager.AppSettings["CODE_VIOLATE_REPORTS"]%>')">
                        <%=CPanel.Commons.TitleConst.getTitleConst("TITLE_BC_VU_VIEC") %>
                    </a>

                    <a class="a_report_css" href="javascript:selectReports('<%=ConfigurationManager.AppSettings["CODE_RISK_REPORTS"]%>')">
                        <%=CPanel.Commons.TitleConst.getTitleConst("TITLE_BC_RUI_RO") %>
                    </a>                    



                    <a class="a_report_css" href="javascript:selectReports('<%=ConfigurationManager.AppSettings["CODE_INVALID_REPORTS"]%>')">
                        <%=CPanel.Commons.TitleConst.getTitleConst("TITLE_BC_KHONG_PHU_HOP") %>
                    </a>

                    <a class="a_report_css" href="javascript:selectReports('<%=ConfigurationManager.AppSettings["CODE_EXPLOITATION_REPORTS"]%>')">
                        <%=CPanel.Commons.TitleConst.getTitleConst("TITLE_BC_PHUC_VU_KT_HANG_NGAY") %>
                    </a>

                    
                </div>
            </div>
        </div>
        
        <!-----------------------------------------BEGIN: hidden tag----------------------------------------------------->
        <div class="hidden_css">
            <asp:Button ID="btnAnonymous" runat="server" OnClick="btnAnonymous_Click" />
            <asp:Button ID="btnIdentification" runat="server" OnClick="btnIdentification_Click" />
            <asp:Button ID="btnDoActions" runat="server" OnClick="btnDoActions_Click" />
            <asp:TextBox runat="server" ID="txtUrlToRedirect"></asp:TextBox>
            <asp:TextBox runat="server" ID="txtReportCode"></asp:TextBox>
        </div>
        <!-----------------------------------------END: hidden tag----------------------------------------------------->
    
        <script>
            function selectReports(strReportCode) {
                $("#<%=txtReportCode.ClientID%>").val(strReportCode);            
                $("#<%=btnDoActions.UniqueID%>").trigger("click");            
            }

            function funAnonymous() {
                $("#<%=btnAnonymous.UniqueID%>").trigger("click");
            }

            function funIdentification() {
                $("#<%=btnIdentification.UniqueID%>").trigger("click");
            }
        </script>
        <script src="/Templates/js/bootstrap.js"></script>    
        <script src="/Templates/js/atcl_lib.js"></script>

    </form>
    
</body>
</html>

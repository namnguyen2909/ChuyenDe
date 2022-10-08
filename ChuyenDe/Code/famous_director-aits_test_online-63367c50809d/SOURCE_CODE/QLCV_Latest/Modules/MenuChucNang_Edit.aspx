<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MenuChucNang_Edit.aspx.cs" Inherits="CPanel.Modules.MenuChucNang_Edit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main_contain_css main_contain_css_1">
        <div class="control_css" style="margin-bottom: -25px">            
            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-default" OnClick="btnCancel_Click"></asp:Button>
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-warning" OnClick="btnSave_Click">                
            </asp:Button>            
        </div>
        <div class="page-header"><h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("MENU_DETAILS") %></h1></div>        

        

        <div class="bg_100pecents_css">
            <div class="col-xs-6">
                <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("TITLE") %></label>
                <asp:TextBox ID="txtTieude" CssClass="form-control element_tab_css" runat="server"></asp:TextBox>
            </div>

            <div class="col-xs-6">
                <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("MENU_PARENT") %></label>
                <asp:DropDownList ID="drpMenus" AutoPostBack="false" CssClass="form-control element_tab_css" runat ="server"></asp:DropDownList>
            </div>
        </div>
        
        <div class="bg_100pecents_css">
            <div class="col-xs-6">
                <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("MENU_TYPE") %></label>
                <asp:DropDownList ID="drpMenuType" CssClass="form-control element_tab_css" runat="server"></asp:DropDownList>
            </div>

            <div class="col-xs-6">
                <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("MENU_STT") %></label>
                <asp:TextBox ID="txtSTT" CssClass="form-control element_tab_css" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="bg_100pecents_css">
        

            <div class="col-xs-6">
                <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("MENU_URL") %></label>
                <asp:TextBox ID="txtURL" CssClass="form-control element_tab_css" runat="server"></asp:TextBox>
            </div>
        </div>

        
        <div class="col-xs-6">
            <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("PUBLISHED") %></label>
            <asp:CheckBox ID="cbPublishedStatus" runat="server" />
        </div>

        
        
        <asp:TextBox ID="txtMenuID" runat="server" CssClass="invisible_css"></asp:TextBox>        
    </div> 
    
    
    <!--Set button title-->
    <script>
        $("#<%=btnCancel.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_CANCEL")%>');
        $("#<%=btnSave.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_SUBMIT")%>');        
    </script>    

</asp:Content>

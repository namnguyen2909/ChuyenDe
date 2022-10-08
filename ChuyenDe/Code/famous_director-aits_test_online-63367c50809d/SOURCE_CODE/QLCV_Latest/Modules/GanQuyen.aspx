<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="GanQuyen.aspx.cs" Inherits="CPanel.Modules.GanQuyen" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main_contain_css main_contain_css_1">        
        <div class="page-header"><h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("Danh sách quyền") %>   </h1></div>
        
            <div class="bg_100pecents_css bg_button_css">            
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-warning" OnClick="btnSave_Click"></asp:Button>            
            </div>
       
        
        <div class="col-md-6">
            <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("RULE") %><span class="mandatory__css">(*)</span></label>
            <asp:DropDownList ID="drpDS_Quyen" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpDS_Quyen_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>                        
        </div>        
        
        <div class="col-md-12">
            <div class="col-md-6">
                <div class="page-header"><h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("LIST_OF_RULE") %></h1></div>
                <div id="treeViewTKSO_DIV" runat="server">          
                    <dx:ASPxTreeView ID="radTreeView_Rules" AllowCheckNodes="true" runat="server"></dx:ASPxTreeView>
                </div>
            </div>
            <div class="col-md-6">
                <div class="page-header"><h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("LIST_OF_MENU") %></h1></div>
                <div id="Div1" runat="server">            
                    <dx:ASPxTreeView ID="radTreeView_Menus" AllowCheckNodes="true" runat="server"></dx:ASPxTreeView>                    
                </div>
            </div>
         </div>
        

        
    </div>
    
    <!--Set button title-->
    <script>        
        $("#<%=btnSave.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_SUBMIT")%>');
    </script>    
</asp:Content>

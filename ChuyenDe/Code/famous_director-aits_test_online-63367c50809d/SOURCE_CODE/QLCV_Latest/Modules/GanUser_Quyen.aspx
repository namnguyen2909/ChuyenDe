<%@ Page Title="Quản lý nhóm" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="GanUser_Quyen.aspx.cs" Inherits="CPanel.Modules.GanUser_Quyen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main_contain_css main_contain_css_1">
        <div class="bg_100pecents_css bg_button_css" style="margin-bottom:-25px">
            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-default" OnClick="btnCancel_Click"></asp:Button>
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-warning" OnClick="btnSave_Click"></asp:Button>
        </div>

        <div class="page-header">
            <h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("Gán quyền") %></h1>
        </div>
        <div class="col-md-12">
            <div class="col-md-6">
                <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("USER_STATUS") %></label>
                <asp:DropDownList ID="drpAccountStatus" AutoPostBack="true" OnSelectedIndexChanged="drpAccountStatus_SelectedIndexChanged" CssClass="form-control element_tab_css" TabIndex="2" runat="server">
                </asp:DropDownList>
            </div>

            <div class="col-md-6">
                <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("RULE") %><span class="mandatory__css">(*)</span></label>
                <asp:DropDownList ID="drpDS_Quyen" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpDS_Quyen_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>                        
            </div>

            <div class="col-md-6" style="margin-bottom: 20px;">
                <label class="control-label line_lb_css">Đơn vị</label>
                <asp:DropDownList ID="drpDepartments" AutoPostBack="true" OnSelectedIndexChanged="drpDepartments_SelectedIndexChanged" CssClass="form-control element_tab_css" TabIndex="2" runat="server">
                </asp:DropDownList>
            </div>       
        </div>

        
        <div class="page-header"><h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("USER_LIST") %></h1></div>
        

        <div class="panel-body">
            <dx:aspxgridview id="grvUsers" width="100%" runat="server" keyfieldname="Id" ondatabinding="grvUsers_DataBinding" settings-showfilterrow="false"
                settings-showfilterrowmenu="true" settings-showgrouppanel="false" autogeneratecolumns="False" clientinstancename="grvUsers">
                <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />                
                <Columns>                    
                    <dx:GridViewCommandColumn ShowSelectCheckbox="true" VisibleIndex="0" HeaderStyle-HorizontalAlign="Center">
                        <HeaderTemplate>
                            <dx:ASPxCheckBox ID="SelectAllCheckBox" runat="server"
                                ClientSideEvents-CheckedChanged="function(s, e) { grvUsers.SelectAllRowsOnPage(s.GetChecked()); }" />
                        </HeaderTemplate>
                    </dx:GridViewCommandColumn>

                    <dx:GridViewDataColumn Caption="Tên đăng nhập" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="0">
                        <DataItemTemplate>                                                
                            <%# Eval("UserName") %>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                        
                    <dx:GridViewDataTextColumn FieldName="Email" Caption="Email" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />                        
                
                    <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Trạng thái" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" VisibleIndex="3">
                        <DataItemTemplate>                                                
                            <%# ((bool)Eval("isEnabled") == false ? "<div class='active_icon_css'></div>" : "")%>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                                          
                </Columns>
                <SettingsPager PageSize="50">
                    <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                </SettingsPager>
            </dx:aspxgridview>
        </div>
        
    </div>

    <!--Set button title-->
    <script>
        $("#<%=btnCancel.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_CANCEL")%>');
        $("#<%=btnSave.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_SUBMIT")%>');
    </script>

</asp:Content>

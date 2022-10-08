<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="TimeSheet_List.aspx.cs" Inherits="CPanel.Modules.TimeSheet_List" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">        

    <div class="main_contain_css main_contain_css_1">
            <div class="page-header"><h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("TITLE_BAO_CAO_CONG_VIEC") %></h1></div>        

            <div class="control_css">            
                <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-warning" OnClick="btnCreate_Click" ></asp:Button>        
            </div>

            <div class="bg_100pecents_css margin_css">
                <div class="col-xs-6">
                    <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("KET_QUA_CV") %></label>
                    <asp:DropDownList ID="drpKetQuaCV" AutoPostBack="true" Visible="false" CssClass="form-control" TabIndex="2" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
    
           
        <dx:ASPxGridView ID="grvObjects" Width="100%" runat="server" KeyFieldName="Id" OnDataBinding="grvObjects_DataBinding" 
                    Settings-ShowGroupPanel="false" AutoGenerateColumns="False" ClientInstanceName="grvObjects">
            <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />  

            <Columns>      
                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="NOI_DUNG_CONG_VIEC" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        <%# Eval("NOI_DUNG_CONG_VIEC") %>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn FieldName="TONG_THOI_GIAN" Caption="THOI_LUONG" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="KHO_KHAN_KIEN_NGHI" Caption="KHO_KHAN_KIEN_NGHI" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="SANG_KIEN" Caption="SANG_KIEN" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="STR_NGAY_BAO_CAO" Caption="NGAY_BAO_CAO" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="TEN_NGUOI_BC" Caption="TEN_NGUOI_BC" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                
                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="HANH_DONG" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="3">
                    <DataItemTemplate>                                              
                        <a href="javascript:viewObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("XEM")%></a>
                        <a href="javascript:deleteObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("XOA")%></a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
            </Columns>
            <SettingsPager PageSize="20">
                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
            </SettingsPager>
            <Settings ShowFilterRow="true"/>                
        </dx:ASPxGridView>

        <!-------------------------------BEGIN: display Message Box-------------------------------------------------------->
        <div id="DIV_MESSAGE" visible="false" runat="server">
            <div  class="pop_up_background_css pop_up_background_message_css"></div>
            <div class="pop_up_info_css pop_up_message_css" runat="server">
                <asp:Button ID="btlClosePopUp_Message" OnClick="btlClosePopUp_Message_Click" Text="X" CssClass="btn btn-danger close_css" runat="server" />
                <span class="message_box_css"><asp:Literal ID="ltMessageContent" runat="server"></asp:Literal></span>
                <asp:Button ID="btnOK_DeleteObject" OnClick="btnOK_DeleteObject_Click" class="btn btn-warning row_css" Text="OK" Visible="false"  runat="server" />
            </div>
        </div>
        <!-------------------------------END: display Message Box-------------------------------------------------------->
        
        <!--BEGIN: hidden tag-->
        <div class="hidden_css">
            <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtFileID" runat="server"></asp:TextBox>

            <asp:Button ID="btnViewFile" Text="View File" runat="server" />
            <asp:Button ID="btnViewObject" OnClick="btnViewObject_Click" runat="server" /> 
            <asp:Button ID="btlDeleteObject" OnClick="btlDeleteObject_Click"   runat="server" />       
        </div>
        <!--END: hidden tag-->
    
        <script>
            //***********************************BEGIN: Set button title***************************************           
            $("#<%=btnCreate.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_CREATE")%>');
            //***********************************END: Set button title*****************************************

            function viewObject(intID) {
                $("#<%=txtObjectID.ClientID%>").val(intID);
                __doPostBack("<%= btnViewObject.UniqueID %>", "OnClick");
            }

            function viewFile(intID)
            {
                $("#<%=txtFileID.ClientID%>").val(intID);
                __doPostBack("<%= btnViewFile.UniqueID %>", "OnClick");
            }

            function deleteObject(intID) {
                $("#<%=txtObjectID.ClientID%>").val(intID);
                __doPostBack("<%= btlDeleteObject.UniqueID %>", "OnClick");
            }
        </script>
    </div>
</asp:Content>

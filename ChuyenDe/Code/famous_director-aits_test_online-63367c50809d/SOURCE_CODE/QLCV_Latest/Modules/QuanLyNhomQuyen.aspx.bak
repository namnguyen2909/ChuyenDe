<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="QuanLyNhomQuyen.aspx.cs" Inherits="CPanel.Modules.QuanLyNhomQuyen" %>

<%@ Register Assembly="DevExpress.Web.v17.2" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main_contain_css main_contain_css_1">        

        <div class="page-header"><h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("RULE_MANAGEMENT") %></h1></div>
        
        <dx:ASPxGridView ID="grvLib" Width="100%" runat="server" KeyFieldName="ID" OnDataBinding="grvLib_DataBinding" on
                OnRowDeleting="grvLib_RowDeleting" OnRowUpdating="grvLib_RowUpdating" AutoGenerateColumns="False"
                EnableRowsCache="False" OnRowInserting="grvLib_RowInserting" EnableCallBacks="false" SettingsEditing-Mode="Inline" SettingsPager-Mode="ShowAllRecords">
                
                <ClientSideEvents RowDblClick="function(s, e) {s.StartEditRow(e.visibleIndex);}" />  
                <ClientSideEvents CustomButtonClick="function(s, e) {if (e.buttonID == 'btnDelete')	deleteConfirm_ASPxGridView_ByAnyFields(s, e, 'name');}" /> 

                <Columns>
                    <dx:GridViewCommandColumn CellStyle-CssClass="bt_action__css" ButtonType="Image" VisibleIndex="6" Caption="ACTION" HeaderStyle-HorizontalAlign="Center">
                        
                        
                        
                        
                        
                        <CustomButtons>                                                
                            <dx:GridViewCommandColumnCustomButton Image-SpriteProperties-CssClass="bt_delete_css" Text="Xóa" ID="btnDelete">
                            </dx:GridViewCommandColumnCustomButton>                                                
                        </CustomButtons>
                    
                        
                    </dx:GridViewCommandColumn>                
                    <dx:GridViewDataTextColumn FieldName="NAME" Caption="Tên quyền" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                    <dx:GridViewDataTextColumn FieldName="DESCRIPTION" Caption="Mô tả" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="3" />                            
                </Columns>
            </dx:ASPxGridView>        
    
        <!-- ModalPopupExtender --> 
    
        
    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="HeThong_List.aspx.cs" Inherits="CPanel.Modules.HeThong_List" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">        

    <div class="main_contain_css main_contain_css_1">
            <div class="page-header"><h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("TITLE_PAGE_THEO_DOI_CONG_VIEC") %></h1></div>        

            <div class="control_css">            
                <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-warning" OnClick="btnCreate_Click" Visible="true" ></asp:Button>        
            </div>

            <div class="bg_100pecents_css margin_css">
                <div class="col-xs-6">
                    <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("KET_QUA_CV") %></label>
                    <asp:DropDownList ID="drpKetQuaCV" Visible="false" AutoPostBack="true" CssClass="form-control" TabIndex="2" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
    
           
        <dx:ASPxGridView ID="grvObjects" Width="100%" runat="server" KeyFieldName="Id" OnDataBinding="grvObjects_DataBinding" 
                    Settings-ShowGroupPanel="false" AutoGenerateColumns="False" ClientInstanceName="grvObjects">
            <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />  

            <Columns>      
                                                                                     
                <dx:GridViewDataTextColumn FieldName="TEN" Settings-AllowAutoFilter="True" Caption="TEN_HE_THONG" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="MO_TA" Caption="MO_TA" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="TEN_HOP_DONG" Caption="PLHĐ" Width="50px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="TEN_NGUOI_CHU_TRI" Caption="NGUOI_CHU_TRI" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="ID_NGUOI_PHOI_HOP" Caption="NGUOI_PHOI_HOP" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" Visible="false" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="STR_NGAY_BAT_DAU" Caption="NGAY_BAT_DAU" Width="100px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="STR_NGAY_KET_THUC" Caption="NGAY_KET_THUC" Width="100px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="KET_QUA_CV" Caption="KET_QUA_CV" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="GHI_CHU" Caption="GHI_CHU" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                
                

                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="HANH_DONG" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="3">
                    <DataItemTemplate>                                              
                        <a href="javascript:viewObject('<%# Eval("ID") %>')">XEM</a>
                        <a href="javascript:deleteObject('<%# Eval("ID") %>')">XOA</a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
            </Columns>
            <SettingsPager PageSize="20">
                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
            </SettingsPager>
            <Settings ShowFilterRow="true" AutoFilterCondition="Contains"/>                
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
            <asp:Button ID="btlDeleteObject" OnClick="btlDeleteObject_Click"   runat="server" />

            
            <asp:Button ID="btnViewObject" OnClick="btnViewObject_Click" runat="server" />        
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

            function deleteObject(intID) {
                $("#<%=txtObjectID.ClientID%>").val(intID);
                __doPostBack("<%= btlDeleteObject.UniqueID %>", "OnClick");
            }

        </script>
    </div>
</asp:Content>

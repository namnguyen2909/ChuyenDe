<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="RuiRo_List.aspx.cs" Inherits="CPanel.Modules.RuiRo_List" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">        

    <div class="main_contain_css main_contain_css_1">
        <asp:Label ID="lbMenus" runat="server"></asp:Label>

        <div class="page-header"><h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("TITLE_PAGE_THEO_DOI_RUI_RO") %></h1></div>        

        <div class="control_css">            
            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-default" OnClick="btnCancel_Click"></asp:Button>
            <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-warning" OnClick="btnCreate_Click" Visible="true" ></asp:Button>        
        </div>

            
    
           
        <dx:ASPxGridView ID="grvObjects" Width="100%" runat="server" KeyFieldName="Id" OnDataBinding="grvObjects_DataBinding" 
                    Settings-ShowGroupPanel="false" AutoGenerateColumns="False" ClientInstanceName="grvObjects">
            <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />  

            <Columns>      
                                                                                     
                <dx:GridViewDataTextColumn FieldName="MA_RUI_RO" PropertiesTextEdit-EncodeHtml="false" Settings-AllowAutoFilter="True" Caption="MA_RUI_RO" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="NOI_DUNG" PropertiesTextEdit-EncodeHtml="false" Caption="NOI_DUNG_MODULE" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="MO_TA" PropertiesTextEdit-EncodeHtml="false" Caption="MO_TA" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" Visible="false" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="STR_NGAY_PHAT_SINH" PropertiesTextEdit-EncodeHtml="false" Caption="NGAY_PHAT_SINH" Width="100px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewBandColumn Caption="TRACH_NHIEM_XU_LY" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" >
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="TT_TRACH_NHIEM_KH" PropertiesTextEdit-EncodeHtml="false" Caption="KH" Width="20px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                            <dx:GridViewDataTextColumn FieldName="TT_TRACH_NHIEM_AITS" PropertiesTextEdit-EncodeHtml="false" Caption="AITS" Width="20px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                            <dx:GridViewDataTextColumn FieldName="TT_TRACH_NHIEM_DT" PropertiesTextEdit-EncodeHtml="false" Caption="ĐT" Width="20px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                        </Columns>
                    </dx:GridViewBandColumn>
                <dx:GridViewDataTextColumn FieldName="GIAI_PHAP" PropertiesTextEdit-EncodeHtml="false" Caption="GIAI_PHAP" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="TEN_NGUOI_CHU_TRI" PropertiesTextEdit-EncodeHtml="false" Caption="NGUOI_CHU_TRI" Width="100px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                
                <dx:GridViewDataTextColumn FieldName="STR_NGAY_BAT_DAU" PropertiesTextEdit-EncodeHtml="false" Caption="NGAY_BAT_DAU" Width="100px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="STR_NGAY_KET_THUC" PropertiesTextEdit-EncodeHtml="false" Caption="NGAY_KET_THUC" Width="100px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="KET_QUA" PropertiesTextEdit-EncodeHtml="false" Caption="KET_QUA_CV" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="KIEN_NGHI" PropertiesTextEdit-EncodeHtml="false" Caption="KIEN_NGHI" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                
                <dx:GridViewDataTextColumn FieldName="GHI_CHU" PropertiesTextEdit-EncodeHtml="false" Caption="GHI_CHU" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                
                

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
            <asp:TextBox ID="txtHeThongID" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtFileID" runat="server"></asp:TextBox>
            <asp:Button ID="btlDeleteObject" OnClick="btlDeleteObject_Click"   runat="server" />

            
            <asp:Button ID="btnViewObject" OnClick="btnViewObject_Click" runat="server" />
                  
        </div>
        <!--END: hidden tag-->
    
        <script>
            //***********************************BEGIN: Set button title***************************************  
            $("#<%=btnCancel.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_CANCEL")%>');
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

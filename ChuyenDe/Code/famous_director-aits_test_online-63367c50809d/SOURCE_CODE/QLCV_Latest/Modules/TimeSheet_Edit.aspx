<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="TimeSheet_Edit.aspx.cs" enableEventValidation="false" Inherits="CPanel.Modules.TimeSheet_Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="main_contain_css main_contain_css_1">
            <div class="page-header"><h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("BAO_CAO_CONG_VIEC") %></h1></div>        

            <div class="control_css">            
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" CssClass="btn btn-default"></asp:Button>
                <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-info" OnClick="btnCreate_Click"></asp:Button>                
                <input type="button" class="btn btn-warning btn_Validation_Save_TimeSheet_CSS"  />
            </div>

            
            <div class="bg_100pecents_css row_css">
                <dx:ASPxGridView ID="grvObjects" Width="100%" runat="server" KeyFieldName="Id" OnDataBinding="grvObjects_DataBinding" 
                        Settings-ShowGroupPanel="false" AutoGenerateColumns="False" ClientInstanceName="grvObjects">
                <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />  

                    <Columns>      
                             
                        <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="TEN_CONG_VIEC" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="2">
                            <DataItemTemplate>                                              
                                <%# Eval("TEN_CONG_VIEC") %>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>                                                                                        
                
                        <dx:GridViewDataTextColumn FieldName="LOAI_CONG_VIEC" Caption="LOAI_CONG_VIEC" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                            <dx:GridViewDataTextColumn FieldName="MO_TA" Caption="MO_TA" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                            <dx:GridViewDataTextColumn FieldName="TONG_THOI_GIAN" Caption="TONG_THOI_GIAN" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                
            
                        <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="HANH_DONG" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="3">
                            <DataItemTemplate>                                              
                                <a href="javascript:viewObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("XEM")%></a>
                                <a href="javascript:deleteObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("XOA")%></a>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                    </Columns>
                    <SettingsPager PageSize="20">
                        <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                    </SettingsPager>
                    <Settings ShowFilterRow="false"/>                
                </dx:ASPxGridView>
            </div>

            <div class="bg_100pecents_css row_css">
                <div class="col-xs-4">
                    <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("NGAY_BAO_CAO") %></label>                            
                    <dx:ASPxDateEdit runat="server" ID ="dtNgayBaoCao" EditFormat="Custom" CssClass="form-control readonly_css"></dx:ASPxDateEdit>                    
                </div>
            </div>
            

            


            
        
            <div class="bg_100pecents_css row_css">
                <div class="col-xs-12">
                    <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("KHO_KHAN_KIEN_NGHI") %></label>
                    <asp:TextBox ID="txtKhoKhanKN" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="10" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="bg_100pecents_css row_css">
                <div class="col-xs-12">
                    <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("SANG_KIEN") %></label>
                    <asp:TextBox ID="txtSangKien" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="10" runat="server"></asp:TextBox>
                </div>
            </div>


        <!-----------------------------------------BEGIN: POP UP WINDOW----------------------------------------------------->
        <div id="DIV_BACKGROUND_POP_UP" visible="false" runat="server">
            <div  class="pop_up_background_css"></div>
            <div id="DIV_INFO_POP_UP" class="pop_up_info_css">
                <asp:Button ID="Button1" OnClick="btlClosePopUp_Click" Text="X" runat="server" CssClass="btn btn-danger close_css" />
                
                <!-------------------------------BEGIN: info------------------------------------->
                <div class="bg_100pecents_css">
                    <div class="col-xs-12">
                        <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("TEN_CONG_VIEC") %></label>
                        <asp:TextBox ID="txtTenCongViec_1" MaxLength="200" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>                    
                    </div>
                </div>
                
                <div class="bg_100pecents_css row_css">
                    <div class="col-xs-6">
                        <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("LOAI_CONG_VIEC") %></label>
                        <asp:DropDownList ID="drpLoaiCongViec_1" AutoPostBack="false" CssClass="form-control element_tab_css" runat ="server"></asp:DropDownList>                    
                    </div> 

                    <div class="col-xs-6">
                        <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("THOI_LUONG") %></label>
                        <asp:TextBox ID="txtThoiGIan_1" CssClass="form-control element_tab_css" runat="server"></asp:TextBox>                    
                    </div>
                </div>

                <div class="bg_100pecents_css row_css">
                        <div class="col-xs-12">
                        <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("MO_TA_CHI_TIET") %></label>
                        <asp:TextBox ID="txtMoTaChiTiet_1" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="8" runat="server"></asp:TextBox>                    
                    </div>
                </div>
                <div class="control_css row_css button_css_1">
                    <input type="button" class="btn btn-warning btn_Validation_Save_CSS"  />            
                </div>
                <!-------------------------------END: info------------------------------------->
            </div>
        </div>
        <!-----------------------------------------END: POP UP WINDOW----------------------------------------------------->


            
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
                    <asp:TextBox ID="txtTimeSheetID" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
                    <asp:Button ID="btnViewObject" OnClick="btnViewObject_Click"  runat="server" />
                    <asp:Button ID="btlDeleteObject" OnClick="btlDeleteObject_Click"   runat="server" />
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click">  </asp:Button>
                    <asp:Button ID="btnSaveTimeSheet" runat="server" OnClick="btnSaveTimeSheet_Click">  </asp:Button>
                </div>
            <!--END: hidden tag-->
        </div> 
        
                
        <script>
            //***********************************BEGIN: Set button title***************************************
            $("#<%=btnCancel.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_CANCEL")%>');
            $("#<%=btnCreate.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_TAO_CONG_VIEC")%>');
            $(".btn_Validation_Save_CSS").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_SUBMIT")%>');        
            $(".btn_Validation_Save_TimeSheet_CSS").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_SUBMIT")%>');        
            //***********************************END: Set button title*****************************************

            function viewObject(intID) {
                $("#<%=txtObjectID.ClientID%>").val(intID);
                __doPostBack("<%= btnViewObject.UniqueID %>", "OnClick");
            }

            function deleteObject(intID) {
                $("#<%=txtObjectID.ClientID%>").val(intID);
                __doPostBack("<%= btlDeleteObject.UniqueID %>", "OnClick");
            }

            $(".btn_Validation_Save_CSS").click(function () {                

                if (validateForm()) {                    
                    __doPostBack("<%=btnSave.UniqueID%>", "OnClick");
                }
            });

            $(".btn_Validation_Save_TimeSheet_CSS").click(function () {
                __doPostBack("<%=btnSaveTimeSheet.UniqueID%>", "OnClick");
            });
        </script>            
</asp:Content>

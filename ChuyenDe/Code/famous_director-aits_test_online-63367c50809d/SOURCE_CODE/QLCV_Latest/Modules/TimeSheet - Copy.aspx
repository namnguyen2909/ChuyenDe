<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="TimeSheet.aspx.cs" enableEventValidation="false" Inherits="CPanel.Modules.TimeSheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="main_contain_css main_contain_css_1">
            <div class="page-header"><h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("BAO_CAO_CONG_VIEC") %></h1></div>        

            <div class="control_css">            
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-default"></asp:Button>
                <input type="button" class="btn btn-warning btn_Validation_Save_CSS"  />
            </div>

            <div class="bg_100pecents_css">
                <div class="col-xs-3">
                    <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("TEN_CONG_VIEC") %></label>
                    <asp:TextBox ID="txtTenCongViec_1" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>                    
                </div>
                
                <div class="col-xs-3">
                    <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("LOAI_CONG_VIEC") %></label>
                    <asp:DropDownList ID="drpLoaiCongViec_1" AutoPostBack="false" CssClass="form-control element_tab_css" runat ="server"></asp:DropDownList>                    
                </div> 

                <div class="col-xs-4">
                    <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("MO_TA_CHI_TIET") %></label>
                    <asp:TextBox ID="txtMoTaChiTiet_1" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>                    
                </div>

                <div class="col-xs-2">
                    <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("THOI_LUONG") %></label>
                    <asp:TextBox ID="txtThoiGIan_1" CssClass="form-control element_tab_css" runat="server"></asp:TextBox>                    
                </div>
            </div>

            <div class="bg_100pecents_css">
                <div class="col-xs-3">
                    <asp:TextBox ID="txtTenCongViec_2" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>                    
                </div>
                
                <div class="col-xs-3">
                    <asp:DropDownList ID="drpLoaiCongViec_2" AutoPostBack="false" CssClass="form-control element_tab_css" runat ="server"></asp:DropDownList>                    
                </div> 

                <div class="col-xs-4">
                    <asp:TextBox ID="txtMoTaChiTiet_2" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>                    
                </div>

                <div class="col-xs-2">
                    <asp:TextBox ID="txtThoiGIan_2" CssClass="form-control element_tab_css" runat="server"></asp:TextBox>                    
                </div>
            </div>

            <div class="bg_100pecents_css">
                <div class="col-xs-3">                    
                    <asp:TextBox ID="txtTenCongViec_3" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>                    
                </div>
                
                <div class="col-xs-3">
                    <asp:DropDownList ID="drpLoaiCongViec_3" AutoPostBack="false" CssClass="form-control element_tab_css" runat ="server"></asp:DropDownList>                    
                </div> 

                <div class="col-xs-4">
                    <asp:TextBox ID="txtMoTaChiTiet_3" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>                    
                </div>

                <div class="col-xs-2">
                    <asp:TextBox ID="txtThoiGIan_3" CssClass="form-control element_tab_css" runat="server"></asp:TextBox>                    
                </div>
            </div>

            <div class="bg_100pecents_css">
                <div class="col-xs-3">                    
                    <asp:TextBox ID="txtTenCongViec_4" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>                
                </div>
                
                <div class="col-xs-3">
                    <asp:DropDownList ID="drpLoaiCongViec_4" AutoPostBack="false" CssClass="form-control element_tab_css" runat ="server"></asp:DropDownList>                    
                </div> 

                <div class="col-xs-4">
                    <asp:TextBox ID="txtMoTaChiTiet_4" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>                    
                </div>

                <div class="col-xs-2">
                    <asp:TextBox ID="txtThoiGIan_4" CssClass="form-control element_tab_css" runat="server"></asp:TextBox>                    
                </div>
            </div>


            <div class="bg_100pecents_css">
                <div class="col-xs-3">                    
                    <asp:TextBox ID="txtTenCongViec_5" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>                    
                </div>
                
                <div class="col-xs-3">
                    <asp:DropDownList ID="drpLoaiCongViec_5" AutoPostBack="false" CssClass="form-control element_tab_css" runat ="server"></asp:DropDownList>                    
                </div> 

                <div class="col-xs-4">                    
                    <asp:TextBox ID="txtMoTaChiTiet_5" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>                    
                </div>

                <div class="col-xs-2">                    
                    <asp:TextBox ID="txtThoiGIan_5" CssClass="form-control element_tab_css" runat="server"></asp:TextBox>                    
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

            <div class="bg_100pecents_css row_css">
                <div class="col-xs-4">
                    <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("NGAY_BAO_CAO") %></label>                            
                    <dx:ASPxDateEdit runat="server" ID ="dtNgayBaoCao" EditFormat="Custom" CssClass="form-control readonly_css"></dx:ASPxDateEdit>                    
                </div>
            </div>
            
            <!-------------------------------BEGIN: display Message Box-------------------------------------------------------->
            <div id="DIV_MESSAGE" visible="false" runat="server">
                <div  class="pop_up_background_css"></div>
                <div class="pop_up_info_css pop_up_message_css" runat="server">
                    <asp:Button ID="btlClosePopUp" OnClick="btlClosePopUp_Click" Text="X" CssClass="btn btn-danger close_css" runat="server" />
                    <span class="message_box_css"><asp:Literal ID="ltMessageContent" runat="server"></asp:Literal></span>
                </div>
            </div>            
            <!-------------------------------END: display Message Box-------------------------------------------------------->

            <!--BEGIN: hidden tag-->
                <div class="hidden_css">
                    <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click">  </asp:Button>
                </div>
            <!--END: hidden tag-->
        </div> 
        
                
        <script>
            //***********************************BEGIN: Set button title***************************************
            $("#<%=btnCancel.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_CANCEL")%>');
            $(".btn_Validation_Save_CSS").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_SUBMIT")%>');        
            //***********************************END: Set button title*****************************************

            $(".btn_Validation_Save_CSS").click(function () {                

                if (validateForm()) {                    
                    __doPostBack("<%=btnSave.UniqueID%>", "OnClick");
                }
            });
        </script>            
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="TaoBaiThi.aspx.cs" EnableEventValidation="false" Inherits="CPanel.Modules.QuanLyBaiThi.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="control_css">
        <%--<asp:Button ID="Button1" Text="Next" OnClick="btnOK_Click" runat="server" CssClass="btn btn-warning btn_Validation_Save_CSS"></asp:Button>--%>
        <input type="button" class="btn btn-warning btn_Validation_Save_CSS" />
    </div>

    <div class="page-header">
        <h1 class="panel-title">Tạo mới bài thi</h1>
    </div>
    <div class="bg_100pecents_css">
        <div class="col-md-12">
            <label class="control-label line_lb_css">Tên bài thi<span class="mandatory__css">(*)</span></label>
            <asp:TextBox ID="txtTenBaiThi" CssClass="form-control element_tab_css required_css" runat="server"></asp:TextBox>
            <span class="validation_css" id="<%=txtTenBaiThi.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("MSG_NHAP_TEN_BAI_THI") %></span>
        </div>

        <div class="col-md-6">
            <label class="control-label line_lb_css">Chủ đề bài thi<span class="mandatory__css">(*)</span></label>
            <asp:DropDownList ID="drpMenus" AutoPostBack="true" OnSelectedIndexChanged="drpMenus_SelectedIndexChanged" CssClass="form-control element_tab_css center-block required_css" runat="server"></asp:DropDownList>
            <span class="validation_css" style="margin-top: 10px;" id="<%=drpMenus.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("MSG_CHON_CHU_DE_BAI_THI") %></span>
        </div>

        <div class="col-md-3">
            <label class="control-label line_lb_css">Mức độ bài thi<span class="mandatory__css">(*)</span></label>
            <asp:DropDownList ID="DropDownList1" AutoPostBack="false" CssClass="form-control element_tab_css center-block required_css" runat="server"></asp:DropDownList>
            <span class="validation_css" style="margin-top: 10px;" id="<%=DropDownList1.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("MSG_CHON_MUC_DO_BAI_THI") %></span>
        </div>

        <div class="col-md-3">
            <label class="control-label line_lb_css">Thời gian thi (phút) <span class="mandatory__css">(*)</span></label>
            <asp:TextBox ID="txtThoiGianThi" runat="server" CssClass="form-control element_tab_css required_css"></asp:TextBox>
            <span class="validation_css" id="<%=txtThoiGianThi.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("MSG_NHAP_TIME_BAI_THI") %></span>
        </div>



        <div class="col-xs-12">
            <div id="debai-text">
                <label>Cấu hình bài thi</label>
            </div>
        </div>

        <div class="col-xs-6">
            <div class="col-xs-12" id="tracnghiem">
                <label class="txt_bt_css">TRẮC NGHIỆM</label>
            </div>

            <div class="col-xs-5" id="socauhoide1">
                <label>Số câu hỏi dễ:</label>
            </div>
            <div style="width: 100%; margin-left: 15px; float:left; color: red;">
                <asp:Label ID="lbDeTN" runat="server"></asp:Label>
            </div>      
            <div class="col-xs-7" id="txt_socauhoide1">
                <asp:TextBox ID="txtSoLuongCauHoiDeTN" runat="server" TextMode="Number" MaxLength="5" CssClass="form-control element_tab_css" placeholder="Nhập số lượng"></asp:TextBox>
            </div>

            <div class="col-xs-5 clearfix" id="socauhoibthg1">
                <label>Số câu hỏi trung bình:</label>
            </div>
            <div style="width: 100%; margin-left: 15px; float: left; color: red;">
                <asp:Label ID="lbTrungBinhTN" runat="server"></asp:Label>
            </div>      
            <div class="col-xs-7" id="txt_socauhoibthg1">
                <asp:TextBox ID="txtSoLuongCauHoiTrungBinhTN" runat="server" TextMode="Number" MaxLength="5" CssClass="form-control element_tab_css" placeholder="Nhập số lượng"></asp:TextBox>
            </div>

            <div class="col-xs-5 clearfix" id="socauhoikho1">
                <label>Số câu hỏi khó: </label>
            </div>
            <div style="width: 100%; float: left; margin-left: 15px; color: red;">
                <asp:Label ID="lbKhoTN" runat="server"></asp:Label>
            </div>      
            <div class="col-xs-7" id="txt_socauhoikho1">
                <asp:TextBox ID="txtSoLuongCauHoiKhoTN" runat="server" TextMode="Number" MaxLength="5" CssClass="form-control element_tab_css" placeholder="Nhập số lượng"></asp:TextBox>
            </div>

        </div>

        <div class="col-xs-6">
            <div class="col-xs-12" id="tuluan">
                <label class="txt_bt_css">TỰ LUẬN</label>
            </div>

            <div class="col-xs-5" id="socauhoide2">
                <label>Số câu hỏi dễ:</label>
            </div>
            <div style="width: 100%; float: left; color: red; margin-left: 15px;">
                <asp:Label ID="lbDeTL" runat="server"></asp:Label>
            </div>      
            <div class="col-xs-7" id="txt_socauhoide2">
                <asp:TextBox ID="txtSoLuongCauHoiDeTL" TextMode="Number" MaxLength="5" runat="server" CssClass="form-control element_tab_css" placeholder="Nhập số lượng"></asp:TextBox>
            </div>

            <div class="col-xs-5 clearfix" id="socauhoibthg2">
                <label>Số câu hỏi trung bình: </label>
            </div>
            <div style="width: 100%; float: left; color: red; margin-left: 15px;">
                <asp:Label ID="lbTrungBinhTL" runat="server"></asp:Label>
            </div>      
            <div class="col-xs-7" id="txt_socauhoibthg2">
                <asp:TextBox ID="txtSoLuongCauHoiTrungBinhTL" TextMode="Number" MaxLength="5" runat="server" CssClass="form-control element_tab_css" placeholder="Nhập số lượng"></asp:TextBox>
            </div>

            <div class="col-xs-5 clearfix" id="socauhoikho2">
                <label>Số câu hỏi khó: </label>
            </div>
            <div style="width: 100%; float: left; color: red; margin-left: 15px;">
                <asp:Label ID="lbKhoTL" runat="server"></asp:Label>
            </div>      
            <div class="col-xs-7" id="txt_socauhoikho2">
                <asp:TextBox ID="txtSoLuongCauHoiKhoTL" runat="server" TextMode="Number"  CssClass="form-control element_tab_css" placeholder="Nhập số lượng"></asp:TextBox>
            </div>
        </div>
    </div>


    <!-------------------------------BEGIN: display Message Box-------------------------------------------------------->
    <div id="DIV_MESSAGE" visible="false" runat="server">
        <div class="pop_up_background_css"></div>
        <div class="pop_up_info_css pop_up_message_css" runat="server">
            <asp:Button ID="btlClosePopUp" Text="X" CssClass="btn btn-danger close_css" runat="server" />
            <span class="message_box_css">
                <asp:Literal ID="ltMessageContent" runat="server"></asp:Literal></span>
        </div>
    </div>
    <!-------------------------------END: display Message Box-------------------------------------------------------->

    <!--BEGIN: hidden tag-->
    <div class="hidden_css">
        <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtParentObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtHeThongID" runat="server"></asp:TextBox>
        <asp:Button ID="btnSave" runat="server" OnClick="btnOK_Click"></asp:Button>
    </div>
    <!--END: hidden tag-->
    <script>
        $(".btn_Validation_Save_CSS").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_SUBMIT")%>');

        $(".btn_Validation_Save_CSS").click(function () {
            

			if (validateForm()) {
                __doPostBack("<%=btnSave.UniqueID%>", "OnClick");
            }

        });
    </script>
</asp:Content>

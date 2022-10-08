<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="TaoCauHoiTN.aspx.cs" Inherits="CPanel.Modules.Admin.TaoCauHoiTN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="control_css">
        <asp:Button ID="btnBack" Text="Quay lại" CssClass="btn btn-success center_css" OnClick="btnBack_Click" runat="server"></asp:Button>
        <input id="btnSave" type="button" class="btn btn-warning btn_Validation_Save_CSS" title="Save"/>
    </div>
    <div class="page-header">
        <h1 class="panel-title">Thêm câu hỏi trắc nghiệm</h1>
    </div>
    <div style="width: 100%; float: left; color: red;">
        <asp:Label ID="lbMessage" runat="server"></asp:Label>
    </div>

    <div class="col-xs-6">
        <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Chủ đề câu hỏi *") %></label>
        <asp:DropDownList ID="drpChuDe" AutoPostBack="false" CssClass="form-control element_tab_css required_css" runat="server"></asp:DropDownList>
        <span class="validation_css" id="<%=drpChuDe.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("MSG_CHON_CHU_DE_CAU_HOI") %></span>
    </div>

    <div class="col-xs-6">
        <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Mức độ *") %></label>
        <span class="validation_css" id="<%=txtDanhSachMucDo.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("MSG_CHON_MUC_DO") %></span>
        <div style="width: 100%; float: left; color: red;">
            <asp:Label ID="lbChude" runat="server"></asp:Label>
        </div>
        <asp:CheckBox ID="cbDe" CssClass="classCheckBox" runat="server" Style="text-align: center; margin-right: 60px" Text="Dễ"></asp:CheckBox>
        
        <asp:CheckBox ID="cbTB" CssClass="classCheckBox" runat="server" Style="text-align: center; margin-right: 40px" Text="Trung bình"></asp:CheckBox>
        
        <asp:CheckBox ID="cbKho" CssClass="classCheckBox" runat="server" Style="text-align: center" Text="Khó"></asp:CheckBox>
    </div>

    <div class="col-xs-12">
        <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Nội dung câu hỏi *") %></label>
        <asp:TextBox ID="txtNoiDung" TextMode="MultiLine" CssClass="form-control element_tab_css required_css" Rows="10" runat="server"></asp:TextBox>
        <span class="validation_css" id="<%=txtNoiDung.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("MSG_NHAP_NOI_DUNG") %></span>
    </div>

    <div class="col-xs-12">
        <label id="lblDapAn" class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Đáp án *") %></label>
        <span class="validation_css" id="<%=txtDSDapAn.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("MSG_NHAP_DAP_AN") %></span>
        <div style="width: 100%; float: left; color: red;">
            <asp:Label ID="lbDapan" runat="server"></asp:Label>
        </div>
    </div>

    <!------------------------------------------Đáp án 1---------------------------------------------------------->
    <div class="col-xs-12">
        <div class="col-xs-6">
            <div class="col-xs-1">
                <asp:CheckBox ID="cbDapAn1" CssClass="classCheckBox" runat="server"></asp:CheckBox>
            </div>
            <div class="col-xs-11">
                <asp:TextBox ID="txtDA1" CssClass="form-control element_tab_css classTextBox required_css" TextMode="MultiLine" runat="server"></asp:TextBox>
                <span class="validation_css" id="<%=txtDA1.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("Nhập đáp án") %></span>
            </div>
        </div>

        <!------------------------------------------Đáp án 2---------------------------------------------------------->
        <div class="col-xs-6">
            <div class="col-xs-1">
                <asp:CheckBox ID="cbDapAn2" CssClass="classCheckBox" runat="server"></asp:CheckBox>
            </div>

            <div class="col-xs-11">
                <asp:TextBox ID="txtDA2" CssClass="form-control element_tab_css classTextBox required_css" TextMode="MultiLine" runat="server"></asp:TextBox>
                <span class="validation_css" id="<%=txtDA2.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("Nhập đáp án") %></span>
            </div>
        </div>
    </div>

    <!------------------------------------------Đáp án 3---------------------------------------------------------->
    <div class="col-xs-12" style="margin-top: 20px">
        <div class="col-xs-6">
            <div class="col-xs-1">
                <asp:CheckBox ID="cbDapAn3" CssClass="classCheckBox" runat="server"></asp:CheckBox>
            </div>

            <div class="col-xs-11">
                <asp:TextBox ID="txtDA3" CssClass="form-control element_tab_css classTextBox required_css" TextMode="MultiLine" runat="server"></asp:TextBox>
                <span class="validation_css" id="<%=txtDA3.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("Nhập đáp án") %></span>
            </div>
        </div>

        <!------------------------------------------Đáp án 4---------------------------------------------------------->
        <div class="col-xs-6">
            <div class="col-xs-1">
                <asp:CheckBox ID="cbDapAn4" CssClass="classCheckBox" runat="server"></asp:CheckBox>
            </div>

            <div class="col-xs-11">
                <asp:TextBox ID="txtDA4" CssClass="form-control element_tab_css classTextBox required_css" TextMode="MultiLine" runat="server"></asp:TextBox>
                <span class="validation_css" id="<%=txtDA4.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("Nhập đáp án") %></span>
            </div>
        </div>
    </div>




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
        <asp:TextBox ID="txtDanhSachMucDo" CssClass="required_css" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtDSDapAn" CssClass="required_css" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtParentObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtHeThongID" runat="server"></asp:TextBox>
        <asp:Button ID="btnSave1" OnClick="btnSave_Click" runat="server"></asp:Button>
    </div>

    <script>
        $(".btn_Validation_Save_CSS").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_SUBMIT")%>');
        $(".btn_Validation_Save_CSS").click(function () {

            //Kiem tra muc do
            strMucDo = "";
            $('input[type=checkbox]').each(function () {
                if ($(this).prop("checked") == true) {
                    strMucDo = "Y";
                }
            });
            $("#<%=txtDanhSachMucDo.ClientID%>").val(strMucDo);

            //Kiem tra dap an
            strDapAn = "";
            $('input[type=checkbox]').each(function () {
                if ($(this).prop("checked") == true) {
                    strDapAn = "Y";
                }
            });
            $("#<%=txtDSDapAn.ClientID%>").val(strDapAn);

            //Validate
            if (validateForm()) {
                __doPostBack("<%=btnSave1.UniqueID%>", "OnClick");
            }

        });   
    </script>
</asp:Content>

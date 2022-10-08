<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="TaoCauHoiTL.aspx.cs" Inherits="CPanel.Modules.Admin.TaoCauHoiTL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="control_css">            
        <asp:Button ID="btnBack" Text="Quay lại" OnClick="btnBack_Click" CssClass="btn btn-success center_css" runat="server"></asp:Button>
        <input id="btnSave" type="button" class="btn btn-warning btn_Validation_Save_CSS" title="Save"/>
    </div>

    <div class="page-header">
        <h1 class="panel-title">Thêm câu hỏi tự luận</h1>
    </div>
    <div style="width: 100%; float: left; color: red;">
        <asp:Label ID="lbMessage" runat="server"></asp:Label>
    </div>

    <div class="col-md-6">
        <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Chủ đề câu hỏi *") %></label>
        <asp:DropDownList ID="drpChuDeTL" AutoPostBack="false" CssClass="form-control element_tab_css required_css" runat="server"></asp:DropDownList>
        <span class="validation_css" id="<%=drpChuDeTL.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("MSG_CHON_CHU_DE_CAU_HOI") %></span>
    </div>

    <div class="col-xs-6">
        <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Mức độ *") %></label>
        <span class="validation_css" id="<%=txtDanhSachMucDo.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("MSG_CHON_MUC_DO") %></span>
        <asp:CheckBox ID="cbDeTL" runat="server" Text="Dễ"></asp:CheckBox>
        <asp:CheckBox ID="cbTbTL" runat="server" Text="Trung bình"></asp:CheckBox>
        <asp:CheckBox ID="cbKhoTL" runat="server" Text="Khó"></asp:CheckBox>
    </div>

    <div class="col-xs-12">
        <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Nội dung câu hỏi *") %></label>
        <asp:TextBox ID="txtNoiDungTL" TextMode="MultiLine" CssClass="form-control element_tab_css required_css" Rows="10" runat="server"></asp:TextBox>
        <span class="validation_css" id="<%=txtNoiDungTL.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("MSG_NHAP_NOI_DUNG") %></span>
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
        <asp:TextBox ID="txtDanhSachMucDo" CssClass="form-control element_tab_css required_css" runat="server"></asp:TextBox>
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

            //Validate
            if (validateForm()) {
                __doPostBack("<%=btnSave1.UniqueID%>", "OnClick");
            }

        });
    </script>
</asp:Content>

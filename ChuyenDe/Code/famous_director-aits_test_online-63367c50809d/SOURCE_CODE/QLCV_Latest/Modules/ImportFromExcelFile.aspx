<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="ImportFromExcelFile.aspx.cs" Inherits="CPanel.Modules.ImportFromExcelFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main_contain_css main_contain_css_1">
        <div style="width: 100%; float: left; color: red;">
            <asp:Label ID="lbMessage" runat="server"></asp:Label>
        </div>

        <div class="page-header">
            <h1 class="panel-title">Import Dữ liệu</h1>
        </div>

        <div class="control_css">
            <asp:Button ID="BtImport_TaiKhoanSo" runat="server" Text="Import into DB" OnClick="BtImport_SoTaiKhoan_Click" CssClass="btn btn-warning" />
        </div>

        <asp:FileUpload ID="FileUpload_SoTaiKhoan" runat="server" CssClass="form-control element_tab_css" />

        
        </div>
        Don Gia San Luong:
        <asp:CheckBox ID="cbDonGiaSanLuong" runat="server" /><br />
        1-QUYEN-RULE:
        <asp:CheckBox ID="cbQuyenRule" runat="server" /><br />
        2-QUYEN-USER:
        <asp:CheckBox ID="cbQuyenUser" runat="server" /><br />

        <%--<div class="page-header">
            <h1 class="panel-title">Import Câu hỏi</h1>
        </div>

    <div class="control_css">
            <asp:Button ID="btnImport_test_online" runat="server" Text="Import test_online excel" OnClick="BtImport_test_online_Click" CssClass="btn btn-warning" />
        </div>
        <asp:FileUpload ID="FileUpload_test_online" runat="server" CssClass="form-control element_tab_css" />


        <div class="col-xs-6 col-space-right-css">
            <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("LOAI_CAU_HOI") %></label>
            <asp:DropDownList ID="drpLoaiCH" CssClass="form-control element_tab_css" runat="server" AutoPostBack="false">
                <asp:ListItem Value="trac_nghiem">Trắc nghiệm</asp:ListItem>
                <asp:ListItem Value="tu_luan">Tự luận</asp:ListItem>
                <asp:ListItem Value="chu_de_bai_thi">Chủ đề bài thi</asp:ListItem>
            </asp:DropDownList>

    </div>--%>
</asp:Content>

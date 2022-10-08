<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AdminReviewBT.aspx.cs" Inherits="CPanel.Modules.Admin.AdminReviewBT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-xs-12">
        <div class="col-xs-6">
            <label style="font-weight:bold; font-size:20px; margin-top:10px">Số câu trắc nghiệm: </label>
            <asp:Label ID="lblSoCauTracNghiem" style="font-size:20px" runat="server"></asp:Label>
        </div>

        <div class="col-xs-6">
            <label style="font-weight:bold; font-size:20px; margin-top:10px">Số câu tự luận: </label>
            <asp:Label ID="lblSoCauTuLuan" style="font-size:20px" runat="server"></asp:Label>
        </div>
    </div>

    <div class="col-xs-12 text-center" style="margin-top:10px">
        <label style="font-weight:bold; font-size:20px">ĐỀ BÀI</label> 
    </div>

    <%--Hien thi bai thi ung vien--%>
    <div class="">
            <asp:Literal runat="server" ID="ltQuestion" />
        </div>

    <label>Nội dung đánh giá</label>
    <asp:TextBox ID="txtNoiDungDanhGia" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="10" runat="server"></asp:TextBox>

    <div class="col-xs-12">
        <asp:RadioButtonList ID="rblKetQuaDanhGia" runat="server">
            <asp:ListItem Text="ĐẠT"/>
            <asp:ListItem Text="KHÔNG ĐẠT"/>
        </asp:RadioButtonList> 
    </div>

    <div class="col-xs-12">
        <div class="col-xs-6">
            <asp:Button ID="btnSave" Text="Save" OnClick="btnSave_Click" Font-Size="16px" runat="server"
            style="
            background-image: linear-gradient(to right, #0cebeb 0%, #20e3b2  51%, #0cebeb  100%);
            margin-left:500px;
            margin-top:20px;
            padding: 5px 10px;
            text-align: center;
            text-transform: uppercase;
            transition: 0.5s;
            background-size: 200% auto;
            color: white;            
            box-shadow: 0 0 20px #eee;
            border-radius: 10px;
            display: block;"></asp:Button>
        </div>
        <div class="col-xs-6">
            <asp:Button ID="btnBack" OnClick="btnBack_Click" Text="Back" Font-Size="16px" runat="server"
            style="
            background-image: linear-gradient(to right, #0cebeb 0%, #20e3b2  51%, #0cebeb  100%);
            margin-top:20px;
            padding: 5px 10px;
            text-align: center;
            text-transform: uppercase;
            transition: 0.5s;
            background-size: 200% auto;
            color: white;            
            box-shadow: 0 0 20px #eee;
            border-radius: 10px;
            display: block;"></asp:Button>
        </div>
    </div>
    
    <%--<input type="button" class="btn btn-warning btn_Validation_Save_CSS"  />--%>
    <!--BEGIN: hidden tag-->
    <div class="hidden_css">
        <asp:TextBox ID="txtCheckBoxValue" runat="server"></asp:TextBox> 
        <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtDiemTN" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtCauTL" runat="server"></asp:TextBox>
        <%--<asp:Button runat="server" ID="btnSave" CssClass="btn btn-warning" OnClick="btnSave_Click" Text="Save" />--%>
    </div>
    <!--END: hidden tag-->
    <script>
            //***********************************BEGIN: Set button title***************************************  

         <%--$(".btn_Validation_Save_CSS").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_SUBMIT")%>');--%>        
        //***********************************END: Set button title*****************************************

        //$(".btn_Validation_Save_CSS").click(function () {

        //    updateKQ();                 
        //     __doPostBack("<=btnSave.UniqueID%>", "OnClick");

        //});
        //$('#cbAnswer').click(function (e) {
        //    if (e.target.checked) {
        //        localStorage.checked = true;
        //    } else {
        //        localStorage.checked = false;
        //    }
        //})

        //$(document).ready(function () {

        //    document.querySelector('#cbAnswer').checked = localStorage.checked

        //});

        $(".checked__css").prop("checked", "true");

    </script>
</asp:Content>

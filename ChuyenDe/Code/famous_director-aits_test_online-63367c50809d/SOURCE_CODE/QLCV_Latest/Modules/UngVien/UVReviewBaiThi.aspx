<%@ Page Title="" Language="C#" MasterPageFile="~/Main_UV.master" AutoEventWireup="true" CodeBehind="UVReviewBaiThi.aspx.cs" Inherits="CPanel.Modules.UngVien.UVReviewBaiThi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-xs-12">
        <label style="font-size:20px; margin-top:10%; margin-bottom:5%; margin-left:30%">CHÚC MỪNG BẠN ĐÃ HOÀN THÀNH BÀI THI</label>
    </div>

    <div class="col-xs-12">
        <div class="col-xs-6" style="margin-left:45%">
            <asp:Button ID="btnBack" Text="Back"
                OnClick="btnBack_Click"
                CssClass="btn btn-success center_css"
                Style="margin-top: 20px; margin-right: 300px; background-image: linear-gradient(to right, #00c6ff 0%, #0072ff  51%, #00c6ff  100%); padding: 10px 20px; text-transform: uppercase; transition: 0.5s; background-size: 200% auto; color: white; box-shadow: 0 0 20px #eee; border-radius: 10px; display: block;"
                Width="100px" Font-Size="Small" runat="server"></asp:Button>
        </div>
    </div>
    <style>
        .banner_1_css{
            display:none;
        }
    </style>
</asp:Content>

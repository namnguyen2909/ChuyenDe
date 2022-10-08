<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="TaoDeBai.aspx.cs" Inherits="CPanel.Modules.Admin.TaoDeBai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header" style="text-align: center; ">
        <label class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("TEN_BAI_THI") %></label>
        <asp:Label ID="lblTenBaiThi" runat="server" CssClass="tenbaithi_css" />
    </div>

    <div class="col-xs-12">
        <div class="col-xs-6 text-center">
            <label style="font-size:16px">Chủ đề bài thi: </label>
            <asp:Label ID="lblLoaiBT" style ="font-size:16px;font-weight:bold" runat="server"></asp:Label>
        </div>

        <div class="col-xs-6 text-center">
            <label style="font-size:16px">Mức độ:</label>
            <asp:Label ID="lblMucDo"  style ="font-size:16px;font-weight:bold" runat="server"></asp:Label>
        </div>
    </div>
    
    <%--------------Test time đếm ngược-------------------%>
   
    <%--<div id="timelabel" style ="font-size:16px;font-weight:bold"></div>

 
        <script type="text/javascript">
            var leave =<%=seconds %>;
            CounterTimer();
            var interv = setInterval(CounterTimer, 1000);
            function CounterTimer() {
                var day = Math.floor(leave / (60 * 60 * 24))
                var hour = Math.floor(leave / 3600) - (day * 24)
                var minute = Math.floor(leave / 60) - (day * 24 * 60) - (hour * 60)
                var second = Math.floor(leave) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60)
                hour = hour < 10 ? "0" + hour : hour;
                minute = minute < 10 ? "0" + minute : minute;
                second = second < 10 ? "0" + second : second;
                var remain =  hour + ":" + minute + ":" + second;
                leave = leave - 1;
                document.getElementById("timelabel").innerHTML = remain;
            }
        </script>--%>
   
    <%----------------------------Hiển thị time-------------------------------%>
    <%--<div class ="col-xs-12">
        <asp:Label id="lblThoiGianThi" style ="font-size:16px;font-weight:bold" runat="server"></asp:Label>
    </div>--%>
    <%------------------------------end------------------------------------%>
    <div class="text-center" style="font-weight: bold; font-size: 25px; color:red">
        <label style="margin-top:40px">ĐỀ BÀI</label>
    </div>
        <div class="">
            <asp:Literal runat="server" ID="ltQuestion" />
        </div>
         <div class="col-xs-12">
            <asp:Button ID="Button1" Text="Save"
               
                CssClass="btn btn-success center_css"
                style="margin-top:20px;
                       margin-left:885px;
                background-image: linear-gradient(to right, #cb2d3e 0%, #ef473a  51%, #cb2d3e  100%);
                padding: 10px 20px;
                text-transform: uppercase;
                transition: 0.5s;
                background-size: 200% auto;
                color: white;            
                box-shadow: 0 0 20px #eee;
                border-radius: 10px;
                display: block;" 
                Width="100px" Height="40px" Font-Size=16px runat="server">
            </asp:Button>
        </div>

    <div class="hidden_css">
        <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtParentObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtHeThongID" runat="server"></asp:TextBox>
        <asp:Button ID="btnSave" OnClick="btnSave_Click"  runat="server"></asp:Button>
    </div>
</asp:Content>

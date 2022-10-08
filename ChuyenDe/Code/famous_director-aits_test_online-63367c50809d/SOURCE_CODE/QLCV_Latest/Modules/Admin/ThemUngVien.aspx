<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ThemUngVien.aspx.cs" Inherits="CPanel.Modules.Admin.ThemUngVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-xs-12" style="margin-left: 100px">

        <div class="col-xs-3">
        </div>
        <div class="col-xs-3">
            <label style="text-align: end; font-size: 16px">Họ và tên<span class="mandatory__css">(*)</span></label>
            <span class="validation_css" id="<%=txtHoTen.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("Bạn chưa nhập họ tên") %></span>
            <asp:TextBox ID="txtHoTen" CssClass="form-control center-block required_css" Width="200px" Style="margin: 0px 50px 20px 0px" runat="server"></asp:TextBox>
        </div>

        <div class="col-xs-3">
            <label style="font-size: 16px">Email<span class="mandatory__css">(*)</span></label>
            <div style="width: 100%; float: left; color: red;">
                <asp:Label ID="lbEmail" runat="server"></asp:Label>
            </div>
             <span class="validation_css" id="<%=txtEmail.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("Bạn chưa nhập email") %></span>
            <asp:TextBox ID="txtEmail" TextMode="Email" Height="" CssClass="form-control element_tab_css required_css" Width="350px" runat="server"></asp:TextBox>
        </div>

    </div>

    <div class="col-xs-12" style="margin-left: 100px">

        <div class="col-xs-3">
        </div>

        <div class="col-xs-3">
            <label style="font-size: 16px">Số điện thoại<span class="mandatory__css">(*)</span></label>
            <span class="validation_css" id="<%=txtSDT.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("Bạn chưa nhập số điện thoại") %></span>
            <div style="width: 100%; float: left; color: red;">
            <asp:Label ID="lbSdt" runat="server"></asp:Label>
            </div>
            <asp:TextBox ID="txtSDT" TextMode="Phone" CssClass="form-control element_tab_css required_css" Width="150px" runat="server"></asp:TextBox>
        </div>


        <div class="col-xs-3">
            <label style="font-size: 16px">Vị trí tuyển dụng<span class="mandatory__css">(*)</span></label>
            <span class="validation_css" id="<%=drpViTri.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("Bạn chưa chọn Vị trí ứng tuyển") %></span>
            <asp:DropDownList ID="drpViTri" AutoPostBack="true" OnSelectedIndexChanged="drpViTri_SelectedIndexChanged" CssClass="form-control center-block required_css" Width="350px" Style="margin: 0px 50px 20px 0px" runat="server"></asp:DropDownList>
        </div>

    </div>

    <div class="col-xs-12" style="margin-left: 100px">
        <div class="col-xs-3">
        </div>

        <div class="col-xs-3">
            <label style="font-size: 16px">Ngày sinh<span class="mandatory__css">(*)</span></label>
            <%--<asp:TextBox ID="dtNgaySinh" TextMode="Date" CssClass="form-control element_tab_css" Width="150px" runat="server"></asp:TextBox>--%>
            
            <dx:ASPxDateEdit runat="server" DateOnError="Undo" ID="dtNgaySinh" Width="150px" EditFormat="Custom" CssClass="form-control readonly_css"></dx:ASPxDateEdit>
            <div style="width: 100%; float: left; color: red;">
                <asp:Label ID="lbNgaySinh" runat="server"></asp:Label>
            </div>
        </div>



        <div class="col-xs-3">
            <label style="font-size: 16px">Mã ứng viên: </label>
            <asp:Label ID="lblMaUV" runat="server"></asp:Label>
        </div>

    </div>

    <div class="col-xs-12">
        <div class="col-xs-6">

            <input type="button" class="btn btn-warning btn_Validation_Save_CSS" CssClass="btn btn-success center_css"
                Style="margin-top: 20px; margin-left: 470px; background-image: linear-gradient(to right, #cb2d3e 0%, #ef473a  51%, #cb2d3e  100%); padding: 10px 20px; text-transform: uppercase; transition: 0.5s; background-size: 200% auto; color: white; box-shadow: 0 0 20px #eee; border-radius: 10px; display: block;"
                Width="150px" Height="40px" Font-Size="16px" runat="server" />

        </div>

        <div class="col-xs-6">
            <asp:Button ID="btnBack" Text="Quay lại" OnClick="btnBack_Click"
                CssClass="btn btn-success center_css"
                Style="margin-top: 20px; margin-right: 200px; background-image: linear-gradient(to right, #00c6ff 0%, #0072ff  51%, #00c6ff  100%); padding: 10px 20px; text-transform: uppercase; transition: 0.5s; background-size: 200% auto; color: white; box-shadow: 0 0 20px #eee; border-radius: 10px; display: block;"
                Width="100px" Font-Size="Small" runat="server"></asp:Button>
        </div>
    </div>

    <div id="DIV_MESSAGE" visible="false" runat="server">
        <div class="pop_up_background_css"></div>
        <div class="pop_up_info_css pop_up_message_css" runat="server">
            <asp:Button ID="btlClosePopUp" OnClick="btlClosePopUp_Click" Text="X" CssClass="btn btn-danger close_css" runat="server" />
            <span class="message_box_css">
                <asp:Literal ID="ltMessageContent" runat="server"></asp:Literal></span>
        </div>
    </div>

    <div class="hidden_css">
        <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtParentObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtHeThongID" runat="server"></asp:TextBox>
        <asp:Button ID="btnSave1" runat="server" OnClick="btnSaveUV_Click"></asp:Button>
    </div>

    <script>
        $(".btn_Validation_Save_CSS").val('<%=CPanel.Commons.TitleConst.getTitleConst("Lưu")%>');

        $(".btn_Validation_Save_CSS").click(function () {
            

			if (validateForm()) {
                __doPostBack("<%=btnSave1.UniqueID%>", "OnClick");
            }

        });
    </script>
</asp:Content>

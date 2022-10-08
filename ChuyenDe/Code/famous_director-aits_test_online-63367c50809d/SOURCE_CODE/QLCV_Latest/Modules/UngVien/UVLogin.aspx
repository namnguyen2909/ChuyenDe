<%@ Page Language="C#" MasterPageFile="~/RootAITS.master" AutoEventWireup="true" CodeBehind="UVLogin.aspx.cs" Inherits="CPanel.Modules.UngVien.UVLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <link href="../../Content/css/login_register.css" rel="stylesheet" />

    <!-- begin header -->
    <div class="header">
        <section class="top-bar">
            <div class="container">
                <nav class="navbar navbar-custom">
                    <div class="container-fluid">
                        <div class="navbar-header" style="margin-right:-20%">
                            <button type="button" class="navbar-toggle" data-toggle="collapse"
                                data-target="#myNavbar">
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <div class="top-bar_logo">
                                <a href="/index.aspx">
                                    <img class="top-logo" src="/Content/images/logo.png"
                                        alt="logo-aits"></a>
                            </div>
                        </div>
                        <div class="collapse navbar-collapse" id="myNavbar">
                            <ul class="nav navbar-nav navbar-right">
                                <li class="active"><a href="#">Trang chủ</a></li>
                                <li class=""><a href="#">Việc làm aits</a></li>
                                <%--<li class="dropdown">
                                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">Việc làm Aits
                                        <span class="caret"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="#">Page 1-1</a></li>
                                        <li><a href="#">Page 1-2</a></li>
                                        <li><a href="#">Page 1-3</a></li>
                                    </ul>
                                </li>--%>
                                <li><a href="#">Về công ty</a></li>
                                <li><a href="#">Liên hệ</a></li>
                                <li>
                                    <button class="btn btn_dang-ky">Đăng ký</button>
                                </li>
                                <%--<li>
                                    <button class="btn btn_dang-nhap">Đăng nhập</button>
                                </li>--%>
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
        </section>
    </div>
    <!-- END Header -->

    <!-----------------------------------BEGIN: Main content-------------------------------------->

    <div class="main-content">

        <div class="container dang_nhap_ung_tuyen">
            <div class="row">
                <div class="col-sm-5 all_text_css">
                    <div class="dang_ky-title">
                        <p>Đăng nhập ứng tuyển ngay</p>
                    </div>

                    <div class="dang_nhap-group_input">
                        <div class="alert-danger" style="line-height:30px; font-size:20px">
                            <asp:Literal ID="lbNotice" runat="server"></asp:Literal>
                        </div>
                        <div class="dang_ky-text_field">
                            <div>
                                <label for="">Tên đăng nhập</label>
                            </div>
                            <asp:TextBox runat="server" ClientIDMode="Static" CssClass="input" ID="txtUserName" placeholder="Nhập tên đăng nhập" required="true" />
                        </div>
                        <div class="dang_ky-text_field">
                            <div>
                                <label for="">Mật khẩu</label>
                            </div>
                            <asp:TextBox runat="server" ClientIDMode="Static" TextMode="Password" CssClass="input" ID="txtPassword" placeholder="Nhập mật khẩu" required />
                        </div>

                        <div class="dang_ky-text_field">
                            <div>
                                <asp:Button runat="server" ID="btn_Login" CssClass="btn-dang_nhap" OnClick="btn_Login_Click" Text="Đăng nhập" />
                            
                            </div>
                            <%--<div class="dang_ky_nhanh"><a href="#">Hoặc đăng ký nhanh</a></div>--%>
                        </div>
                        <%--<div class="dang_ky-text_field">
                            <div class="button-dang_nhap">
                                <button class="btn-facebook">
                                    <img src="/Content/images/iconly/facebook.png"
                                        alt="facebook_icon"></button>
                                <button class="btn-google">
                                    <img src="/Content/images/iconly/google.png"
                                        alt="google_icon"></button>
                            </div>
                        </div>--%>
                    </div>
                </div>
                <div class="col-sm-7">
                    <div class="logo_image">
                        <img src="/Content/images/logo_big.png" alt="logo_big">
                    </div>
                    <div class="office_image">
                        <img src="/Content/images/at_the_office.png" alt="at_the_office" width="100%">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End Main content -->

    <!--BEGIN: hidden tag-->
    <%--<div class="hidden_css">
        <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtParentObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtHeThongID" runat="server"></asp:TextBox>
        <asp:Button ID="btnSave" runat="server"></asp:Button>
    </div>--%>

    <script>
        $(function () {
            $('#btn_Login').click(function () {
                if ($('#txtUserName').val() == '') {
                    alert('Chưa có tên đăng nhập');
                    $("#txtUserName").focus();
                    return false;
                }
                if ($('#txtPassword').val() == '') {
                    alert('Chưa có mật khẩu');
                    $("#txtPassword").focus();
                    return false;
                }
            });
        });
    </script>
</asp:Content>

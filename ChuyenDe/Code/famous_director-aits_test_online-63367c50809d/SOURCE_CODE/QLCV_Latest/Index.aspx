<%@ Page Title="" Language="C#" MasterPageFile="~/RootAITS.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CPanel.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <!-- begin header -->
    <div class="header">
        <section class="top-bar">
            <div class="container">
                <nav class="navbar navbar-custom">
                    <div class="container-fluid">
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle" data-toggle="collapse"
                                data-target="#myNavbar">
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <div class="top-bar_logo">
                                <a href="/index.aspx">
                                    <img class="top-logo" src="/Content/images/logo.png" alt="logo-aits" /></a>

                            </div>
                        </div>
                        <div class="collapse navbar-collapse" id="myNavbar">
                            <ul class="nav navbar-nav navbar-right">
                                <li class="active"><a href="/index.aspx">Trang chủ</a></li>
                                <li class="active"><a href="#">Việc làm aits</a></li>
                                <!-- <li class="dropdown">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">Việc làm Aits
                                    <span class="caret"></span></a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">Page 1-1</a></li>
                                    <li><a href="#">Page 1-2</a></li>
                                    <li><a href="#">Page 1-3</a></li>
                                </ul>
                            </li> -->
                                <li><a href="#">Về công ty</a></li>
                                <li><a href="#">Liên hệ</a></li>
                                <li>
                                    <asp:Button ID="btnSignUp" ClientIDMode="Static" Text="Đăng ký" CssClass="btn btn_dang-ky" runat="server" />
                                </li>
                                <li>
                                    <asp:Button ID="btnSignIn" OnClick="btn_dang_nhap_click" ClientIDMode="Static" Text="Đăng nhập" CssClass="btn btn_dang-nhap" runat="server" />
                                </li>

                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
        </section>
    </div>
    <!-- END Header -->
    <!-- Banner slideshow -->
    <div class="banner">
        <!-----------------------------------BEGIN: Images of Banner-------------------------------------->
        <div class="hundred_percent_css banner_1_css">
            <div class="banner_css">
                <div id="jssor_1">
                    <div data-u="slides" class="slide_css">
                        <div>
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-7 banner_text">
                                        <h1>Cùng <span>AITS </span>kiến tạo tương lai</h1>
                                        <h3>Khám phá công việc và phát triển con người</h3>
                                        <br />
                                        <p>
                                            AITS - môi trường chuyên nghiệp, năng động, sáng tạo luôn chào đón
                                        bạn - Những ứng viên
                                        mong
                                        muốn
                                        làm việc trong lĩnh vực công nghệ.
                                        </p>
                                        <button type="button" class="btn-primary btn_ung-tuyen">
                                            Ứng tuyển ngay
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <img data-u="image" src="/Content/images/girl_image.png" alt="Image1" />
                        </div>
                        <div>
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-7 banner_text">
                                        <h1>Cùng <span>AITS </span>kiến tạo tương lai</h1>
                                        <h3>Khám phá công việc và phát triển con người</h3>
                                        <br />
                                        <p>
                                            AITS - môi trường chuyên nghiệp, năng động, sáng tạo luôn chào đón
                                        bạn - Những ứng viên
                                        mong
                                        muốn
                                        làm việc trong lĩnh vực công nghệ.
                                        </p>
                                        <button type="button" class="btn-primary btn_ung-tuyen">
                                            Ứng tuyển ngay
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <img data-u="image" src="/Content/images/girl_image.png" alt="Image1" />
                        </div>
                        <!--<div>
                            <img data-u="image"
                                src="/Content/images/girl_image.png"
                                alt="Iamge3" />
                        </div>-->
                    </div>
                    <!-- Bullet Navigator -->
                    <div data-u="navigator" class="jssorb032" data-autocenter="1" data-scale="0.5"
                        data-scale-bottom="0.75">
                        <div data-u="prototype" class="i" style="width: 16px; height: 16px;">
                            <svg viewbox="0 0 16000 16000"
                                style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;">
                                <circle class="b" cx="8000" cy="8000" r="5800"></circle>
                            </svg>
                        </div>
                    </div>
                    <!-- Arrow Navigator -->
                    <div data-u="arrowleft" class="jssora051" style="width: 65px; height: 65px; top: 0px; left: 25px;"
                        data-autocenter="2" data-scale="0.75" data-scale-left="0.75">
                        <svg viewbox="0 0 16000 16000"
                            style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;">
                            <polyline class="a" points="11040,1920 4960,8000 11040,14080 "></polyline>
                        </svg>
                    </div>
                    <div data-u="arrowright" class="jssora051"
                        style="width: 65px; height: 65px; top: 0px; right: 25px;" data-autocenter="2" data-scale="0.75"
                        data-scale-right="0.75">
                        <svg viewbox="0 0 16000 16000"
                            style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;">
                            <polyline class="a" points="4960,1920 11040,8000 4960,14080 "></polyline>
                        </svg>
                    </div>
                </div>

            </div>
        </div>
    </div>


    <!--------------------END: for Slideshow----------------------------->
    <div class="section main-content">
        <div class="div-color"></div>
    </div>
</asp:Content>

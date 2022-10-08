<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="CPanel.SignIn" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title><%=CPanel.Commons.TitleConst.getTitleConst("TITLE_PAGE_ATCL") %></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="/Templates/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Templates/css/login.css" rel="stylesheet" />
    <script src="/Templates/js/jquery.min.js"></script>
    <script src="/Templates/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        // <![CDATA[
        function GetRefreshButton() {
            return document.getElementById("refreshButton");
        }
        function OnCaptchaBeginCallback(s, e) {
            var refreshButton = GetRefreshButton();
            refreshButton.src = "Templates/images/refreshButton.gif";
        }
        function OnCaptchaEndCallback(s, e) {
            var refreshButton = GetRefreshButton();
            refreshButton.src = "Templates/images/refreshButton.gif";
            document.getElementById("tbCode").value = "";
            if (typeof (lblCorrectCodeMessage) != "undefined")
                lblCorrectCodeMessage.SetVisible(false);
            if (typeof (lblIncorrectCodeMessage) != "undefined")
                lblIncorrectCodeMessage.SetVisible(false);
        }
        // ]]> 
        $(document).ready(function () {
            $(".popup").hide();
            $(".close").click(function (e) {
                closePopup();
            });
        });
        function openPopup() {
            $(".popup").show();
            $(".popup").fadeIn(300);
            $('body').append('<div id="over">');
            $('#over').fadeIn(300);

        }
        function closePopup() {
            $(".popup").hide();
            $('#over, .popup').fadeOut(300, function () {
                $('#over').remove();
            });
        }
    </script>
    <style type="text/css">
        
			#over {
			    display: none;
			    background: #000;
			    position: fixed;
			    left: 0;
			    top: 0;
			    width: 100%;
			    height: 100%;
			    opacity: 0.8;
			    z-index: 999;
			}
        	.error {
				padding: 15px;
				margin-bottom: 20px;
				border: 1px solid transparent;
				border-radius: 4px;
				color: #a94442;
				background-color: #f2dede;
				border-color: #ebccd1;
			}
			.popup{
				left: 50%; 
                top: 50%;
                display:none;
    			overflow:hidden;
    			position:absolute;
                transform: translateX(-50%) translateY(-50%);
                position: absolute;
                box-shadow: 0 1px 1px rgba(0,0,0,.05);
                margin-bottom: 20px;
                background-color: #fff;
                border: 1px solid transparent;
                border-color: #ddd;
                border-radius: 4px;
                z-index:99999;
            }
            #channel{
            	color: #38659C;
            	font-size: 20px;
            	margin: 15px 20px;
               	font-family: cursive;
            }
            .titleXX{
            	color: #38659C;
            	text-shadow: 0px 0px 1px #38659C;
                width: 100%;
                margin-top:0px;
                background-color: #ffffff00;
                border-color: #ddd;
                padding: 10px 15px;
                border-bottom: 1px solid transparent;
                border-top-left-radius: 3px;
                border-top-right-radius: 3px;
                box-shadow: 0px 0px 5px 0px black;
            }
            #openPop{
            	margin-top:10px;
                cursor: pointer;
                color: #38659C;
            }
            a.close{
                text-decoration: none;
                float: right;
            }
        
    </style>


</head>
<body style="background: #fff; background-size: auto; min-height: 100%; min-width: 100%; width: auto; height: auto; margin: 0; position: absolute;">
    <img src="Templates/images/illustration.jpg" style="object-fit:cover; width:calc(100% - 450px); height:100%; position:absolute; z-index:-1; right:450px" />
    <div class="login-form">
        <form id="form1" runat="server">
            <div>
                <div class="login">
                    <div>
                        <img src="Templates/images/logo_fpt.png" width="137px" /> &nbsp
                    </div>
                    <div class="title">
                        <h3 style="color: #000;"><%=CPanel.Commons.TitleConst.getTitleConst("TITLE_PAGE_ATCL") %></h3>
                    </div>
                    <div class="alert-danger">
                        <asp:Literal ID="lbNotice" runat="server"></asp:Literal>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtUserName" ClientIDMode="Static" CssClass="form-control" runat="server" value=""></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtPassword" ClientIDMode="Static" CssClass="form-control" runat="server" TextMode="Password" value=""></asp:TextBox>
                    </div>
                    <%--capcha--%>
                    <div style="display:none" class="input-group col-md-10 col-md-offset-1">
                        <label class="headerB"></label>
                        <table class="mainTable">
                            <tr>
                                <td style="font-size: 0;">
                                    <img id="refreshButton" src="Templates/images/refreshButton.gif" alt="Show another code" title=""
                                        class="refreshButton" onclick="captcha.Refresh();" />
                                    <div class="captchaDiv">
                                        

                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="labelCell">
                                    <label for="tbCode">Type the code for Captcha</label>
                                </td>
                            </tr>
                            <tr>
                                <td class="textBoxCell">
                                    <input type="text" id="tbCode" name="tbCode" autocomplete="off" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%--endcapcha--%>
                    <asp:Button ID="btnSingnIn" ClientIDMode="Static" CssClass="btn btn-primary" Text="Sign In" OnClick="btnSignIn_Click" runat="server" />
                    <asp:Button ID="btnReset" ClientIDMode="Static" CssClass="btn btn-danger" Text="Reset" OnClick="btnReset_Click" runat="server" />
                    <div style="display:none" id="openPop" onclick="openPopup()">Can't access your account></div>
                </div>
            </div>
        </form>
    </div>
    <script>
        $(function () {
            $('#btnSignIn').click(function () {
                if ($('#txtUsername').val() == '') {
                    alert('Chưa có tên đăng nhập');
                    $("#txtUsername").focus();
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

</body>
</html>

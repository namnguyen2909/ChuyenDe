<%@ Page Title="" Language="C#" MasterPageFile="~/Main_UV.master" AutoEventWireup="true" CodeBehind="LamBaiThi.aspx.cs" Inherits="CPanel.Modules.UngVien.LamBaiThi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-xs-12 text-center" style="margin-top:10px">
        <label style="font-weight:bold; font-size:20px">ĐỀ BÀI</label> 
    </div>

    <div class="col-xs-12" style="text-align:end">
        <%--<label style="font-size:16px">Thời gian: </label>
        <asp:Label ID="lblTime" runat="server"></asp:Label>--%>
        <asp:ScriptManager runat="server" ID="ScriptManager1" />
        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000">
        </asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <span id="CodeAsk">Thời gian: </span>
                <asp:Label ID="LabelTimer" runat="server" Text="1"></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--Hien thi bai thi ung vien--%>
    <div class="" style="margin-left:90px">
            <asp:Literal runat="server" ID="ltQuestion"></asp:Literal>
        </div>

    <div class="col-xs-12">
        <asp:Button ID="btnNopBai" CssClass="btn btn_NopBai_css btn-warning" OnClick="btnNopBai_Click" Text="Nộp bài" Font-Size="16px" runat="server"
            style="
            background-image: linear-gradient(to right, #0cebeb 0%, #20e3b2  51%, #0cebeb  100%);
            margin-left:900px;
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

    <%--<input type="button" class="btn btn-warning btn_Validation_Save_CSS"  />--%>
    <!--BEGIN: hidden tag-->
    <div class="hidden_css" style="display:none">
        <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtCheckBoxValue" runat="server"></asp:TextBox>  
        <asp:TextBox ID="txtTraLoiTL" runat="server"></asp:TextBox> 
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

        $(".btn_NopBai_css").click(function () {

            updateKQ();
            __doPostBack("<%=btnNopBai.UniqueID%>", "OnClick");

        });

        $("input[type='checkbox']").click(function () {

            updateKQ();


        });

        function updateKQ() {

            /*if (validateForm()) {*/
                strCheckBoxValue = "";
                $('input[type=checkbox]').each(function () {

                    if ($(this).prop("checked") == true) {
                        if (strCheckBoxValue == "")
                            strCheckBoxValue = $(this).val();
                        else
                            strCheckBoxValue = strCheckBoxValue + "*" + $(this).val();
                    }
                })
                //alert(strCheckBoxValue);
                $("#<%=txtCheckBoxValue.ClientID%>").val(strCheckBoxValue);
            /*}*/
        }

    </script>
    <style>
        .banner_1_css{
            display:none;
        }
    </style>
</asp:Content>

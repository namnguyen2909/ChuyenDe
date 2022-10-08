<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ChonBaiThi.aspx.cs" Inherits="CPanel.Modules.Admin.ChonBaiThi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main_contain_css main_contain_css_1">
        <%--<div class="control_css">
            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default" OnClick="btnBack_Click"></asp:Button>
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-warning" OnClick="btnSave_Click"></asp:Button>
        </div>--%>
        <div class="control_css">
      
            <input id="btnSave" type="button" class="btn btn-warning btn_Validation_Save_CSS" title="Save" />
            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default" OnClick="btnBack_Click"></asp:Button>

            <div class="hidden_css">
                <asp:Button ID="btnSave1" OnClick="btnSave_Click" runat="server"></asp:Button>
            </div>
        </div>
        <div class="page-header">
            <h1 class="panel-title" style="margin-top:20px"><%=CPanel.Commons.TitleConst.getTitleConst("Chọn bài thi cho ứng viên") %></h1>
        </div>
        <div class="col-xs-12">
            <div class="col-xs-4 text-center" id="loaibaithi">
                <label>Loại bài thi<span class="mandatory__css">(*)</span></label>
            </div>

            <div class="col-xs-4 text-center" id="mucdobaithi">
                <label>Mức độ bài thi<span class="mandatory__css">(*)</span></label>
            </div>

            <div class="col-xs-4 text-center" id="baithi">
                <label>Bài thi<span class="mandatory__css">(*)</span></label>
            </div>
        </div>

        <div class="col-xs-12">
            <div class="col-xs-4">
                <asp:DropDownList ID="drpLoai" OnSelectedIndexChanged="drpLoai_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control center-block required_css" Width="200px" runat="server"></asp:DropDownList>
                <span class="validation_css" style="margin-left:70px" id="<%=drpLoai.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("Bạn chưa chọn Loại bài thi") %></span>
            </div>

            <div class="col-xs-4">
                <asp:DropDownList ID="drpMucDo" OnSelectedIndexChanged="drpMucDo_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control center-block required_css" Width="200px" runat="server"></asp:DropDownList>
                <span class="validation_css" style="margin-left:80px" id="<%=drpMucDo.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("Bạn chưa chọn Mức độ") %></span>
            </div>

            <div class="col-xs-4" style="margin-bottom: 20px">
                <asp:DropDownList ID="drpBaiThi" CssClass="form-control center-block required_css" Width="200px" runat="server"></asp:DropDownList>
                <span class="validation_css" style="margin-left:90px" id="<%=drpBaiThi.ClientID %>_errorMsg"><%=CPanel.Commons.TitleConst.getTitleConst("Bạn chưa chọn Bài thi") %></span>
            </div>
        </div>
    </div>


    <dx:ASPxGridView ID="grvUngVien" OnDataBinding="grvUngVien_DataBinding" Width="100%" Style="margin-left: auto; margin-right: auto" runat="server" KeyFieldName="ID"
        Settings-ShowGroupPanel="false" Settings-ShowFilterRow="false"
        Settings-ShowFilterRowMenu="false" ClientInstanceName="grvUngVien" AutoGenerateColumns="False">



        <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />

        <Columns>
            <dx:GridViewDataTextColumn FieldName="STT" Caption="STT" Settings-AllowSort="False" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" Width="4%">
                <DataItemTemplate>
                    <%# Container.ItemIndex + 1 %>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MA_UNG_VIEN" Caption="Mã ứng viên" Settings-AllowSort="False" Width="30px" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="HO_TEN" Caption="Họ tên" Settings-AllowSort="False" Width="100px" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="VI_TRI" Caption="Vị trí ứng tuyển" Settings-AllowSort="False" Width="200px" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewCommandColumn Width="20px" ShowSelectCheckbox="true" VisibleIndex="0" HeaderStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <dx:ASPxCheckBox ID="SelectAllCheckBox" runat="server"
                        ClientSideEvents-CheckedChanged="function(s, e) { grvUngVien.SelectAllRowsOnPage(s.GetChecked()); }" />
                </HeaderTemplate>
            </dx:GridViewCommandColumn>


        </Columns>
        <SettingsPager PageSize="20">
            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
        </SettingsPager>
    </dx:ASPxGridView>


    <script>
        $(".btn_Validation_Save_CSS").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_SUBMIT")%>');
        $(".btn_Validation_Save_CSS").click(function () {
            //Validate
            if (validateForm()) {
                __doPostBack("<%=btnSave1.UniqueID%>", "OnClick");
            }
        });
        $("#<%=btnBack.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("Quay lại")%>');
        <%--$("#<%=btnSave.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("Save")%>');--%>
    </script>
</asp:Content>

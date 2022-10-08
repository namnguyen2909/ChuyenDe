<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="DsUvDaThi.aspx.cs" Inherits="CPanel.Modules.QuanLyBaiThi.DsUvDaThi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-xs-1" id="btn_guimail">
        <asp:Button runat="server" ID="btnChonNguoiGui" OnClick="btnChonNguoiGui_Click" Text="chọn người đánh giá" Style="background-image: linear-gradient(to right, #314755 0%, #26a0da  51%, #314755  100%); margin: 0px 0px 35px 40px; width: 220px; height: 45px; padding: 10px 15px; text-align: center; text-transform: uppercase; transition: 0.5s; background-size: 200% auto; color: white; box-shadow: 0 0 20px #eee; border-radius: 10px; display: block;" />
    </div>

    <!-------------------------------BEGIN: display Message Box-------------------------------------------------------->
    <div id="DIV_MESSAGE_NGUOI_DANH_GIA" visible="false" runat="server">
        <div class="pop_up_background_css pop_up_background_message_css"></div>
        <div class="pop_up_info_css pop_up_message_css" runat="server">
            <asp:Button ID="btlClosePopUp_NguoiDanhGia" OnClick="btlClosePopUp_NguoiDanhGia_Click" Text="X" CssClass="btn btn-danger close_css" runat="server" />
            <div class="col-xs-12">
                <label>Phòng ban</label>
                <asp:DropDownList ID="drpPhongban" OnSelectedIndexChanged="drpPhongban_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control element_tab_css center-block" Style="width: 200px" runat="server"></asp:DropDownList>
                <label>Người nhận mail</label>
                <%--                    <asp:DropDownList ID="drpNguoidanhgia" AutoPostBack="false" CssClass="form-control element_tab_css center-block" Width="200px" runat ="server"></asp:DropDownList>--%>
                <dx:ASPxGridView ID="grvNguoinhan" OnDataBinding="grvNguoinhan_DataBinding" Width="100%" runat="server" KeyFieldName="ID"
                    Settings-ShowGroupPanel="false" AutoGenerateColumns="False" ClientInstanceName="grvNguoinhan">
                    <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />

                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="STT" Caption="STT" Settings-AllowSort="False" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" Width="4%">
                            <DataItemTemplate>
                                <%# Container.ItemIndex + 1 %>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn Width="20px" ShowSelectCheckbox="true" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <dx:ASPxCheckBox ID="SelectAllCheckBox" runat="server"
                                    ClientSideEvents-CheckedChanged="function(s, e) { grvObjects.SelectAllRowsOnPage(s.GetChecked()); }" />
                            </HeaderTemplate>
                        </dx:GridViewCommandColumn>
                        <%--<dx:GridViewDataTextColumn FieldName= "STT" Settings-AllowAutoFilter="True" Caption="STT" Width="50px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />--%>
                        <dx:GridViewDataTextColumn FieldName="HO_TEN" Settings-AllowAutoFilter="True" Caption="Tên người đánh giá" Width="100px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                        <dx:GridViewDataTextColumn FieldName="EMAIL" Caption="Email" Width="200px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                        <dx:GridViewDataTextColumn FieldName="CHUC_VU" Caption="Chức vụ" Width="150px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                        <%-- <dx:GridViewDataTextColumn FieldName="EMAIL" Caption="Email" Width="200px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="ID_BAI_THI" Caption="Mã bài thi" Width="80px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />--%>
                        <%--<dx:GridViewDataTextColumn FieldName="DIEM_TN" Caption="Điểm trắc nghiệm" Width="80px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="SO_CAU_TL" Caption="Số câu tự luận" Width="80px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="TRANG_THAI" Caption="Trạng thái" Width="150px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />--%>
                    </Columns>
                </dx:ASPxGridView>
            </div>
            <asp:Button ID="btnGuiEMail" OnClick="btnSend_Click" class="btn btn-warning row_css" Text="Gửi Email" runat="server" />
        </div>
    </div>
    <!-------------------------------END: display Message Box-------------------------------------------------------->



    <dx:ASPxGridView ID="grvObjects" Width="100%" runat="server" KeyFieldName="ID" OnDataBinding="grvObj_DataBinding"
        Settings-ShowGroupPanel="false" AutoGenerateColumns="False" ClientInstanceName="grvObjects">
        <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />

        <Columns>
            <dx:GridViewDataTextColumn FieldName="STT" Caption="STT" Settings-AllowSort="False" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" Width="4%">
                <DataItemTemplate>
                    <%# Container.ItemIndex + 1 %>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewCommandColumn Width="20px" ShowSelectCheckbox="true" VisibleIndex="0" HeaderStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <dx:ASPxCheckBox ID="SelectAllCheckBox" runat="server"
                        ClientSideEvents-CheckedChanged="function(s, e) { grvObjects.SelectAllRowsOnPage(s.GetChecked()); }" />
                </HeaderTemplate>
            </dx:GridViewCommandColumn>
            <%--<dx:GridViewDataTextColumn FieldName= "STT" Settings-AllowAutoFilter="True" Caption="STT" Width="50px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />--%>
            <dx:GridViewDataTextColumn FieldName="UNG_VIEN.MA_UNG_VIEN" Settings-AllowAutoFilter="True" Caption="Mã ứng viên" Width="100px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="UNG_VIEN.HO_TEN" Caption="Tên ứng viên" Width="200px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <%--<dx:GridViewDataTextColumn FieldName="SO_DIEN_THOAI" Caption="SĐT" Width="150px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="EMAIL" Caption="Email" Width="200px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />--%>
            <dx:GridViewDataTextColumn FieldName="BAI_THI.TEN_BAI_THI" Caption="Tên bài thi" Width="200px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="VI_TRI_TUYEN_DUNG" Caption="Vị trí ứng tuyển" Width="200px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="DIEM_TRAC_NGHIEM" Caption="Điểm trắc nghiệm" Width="80px" Settings-AllowSort="False" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="SO_CAU_TU_LUAN" Caption="Số câu tự luận" Width="80px" Settings-AllowSort="False" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="KET_QUA_DANH_GIA" Caption="Kết quả" Width="80px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="NGUOI_DANH_GIA.HO_TEN" Caption="Người đánh giá" Width="200px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataTextColumn FieldName="TRANG_THAI_GUI_MAIL" Caption="Trạng thái" Width="150px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" VisibleIndex="2" />
            <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Width="150px" Caption="Hành động" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" VisibleIndex="3">
                <DataItemTemplate>
                    <a href="javascript:viewObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("Đánh giá")%></a>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
        </Columns>
        <SettingsPager PageSize="20">
            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
        </SettingsPager>
        <Settings ShowFilterRow="false" AutoFilterCondition="Contains" />
    </dx:ASPxGridView>

    <!-------------------------------BEGIN: display Message Box-------------------------------------------------------->
    <div id="DIV_MESSAGE" visible="false" runat="server">
        <div class="pop_up_background_css pop_up_background_message_css"></div>
        <div class="pop_up_info_css pop_up_message_css" runat="server">
            <asp:Button ID="btlClosePopUp_Message" Text="X" CssClass="btn btn-danger close_css" runat="server" />
            <span class="message_box_css">
                <asp:Literal ID="ltMessageContent" runat="server"></asp:Literal></span>
        </div>
    </div>
    <!-------------------------------END: display Message Box-------------------------------------------------------->

    <!--BEGIN: hidden tag-->
    <div class="hidden_css">
        <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtFileID" runat="server"></asp:TextBox>
        <asp:Button ID="btlDeleteObject" runat="server"></asp:Button>
        <asp:Button ID="btnViewObject" OnClick="btnViewObject_Click" runat="server"></asp:Button>
    </div>
    <!--END: hidden tag-->

    <script>
        function viewObject(intID) {
            $("#<%=txtObjectID.ClientID%>").val(intID);
            __doPostBack("<%= btnViewObject.UniqueID %>", "OnClick");
        }
    </script>

    <style>
        #chonthang {
            margin-bottom: 50px;
        }
        /*#btn_guimail{
            margin-left:50px;
        }*/
    </style>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ChonLoaiCauHoi.aspx.cs" Inherits="CPanel.Modules.QuanLyBaiThi.ChonLoaiCauHoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-xs-12">
        <%--<asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn btn-success" Text="Save"></asp:Button>--%>
        <div class="control_css">
            <asp:Button ID="btnImport" runat="server" CssClass="btn btn-warning" OnClick="btnImport_Click" Text="Import" Visible="true"></asp:Button>
            <button type="button" class="btn btn-warning" data-toggle="modal" data-target="#myModal"><%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_CREATE")%></button>
            <asp:Button ID="btnBack" Text="Back" OnClick="btnBack_Click" Visible="false" CssClass="btn btn-success center_css" runat="server"></asp:Button>
        </div>

        <div class="page-header">
            <h1 class="panel-title">DANH SÁCH CÂU HỎI</h1>
        </div>

        <div class="col-md-12 search_info_css">
            <div class="col-md-4">
                <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Chủ đề câu hỏi") %></label>
                <asp:DropDownList ID="drpChuDeCauHoi" AutoPostBack="true" OnSelectedIndexChanged="drpChuDeCauHoi_SelectedIndexChanged" CssClass="form-control element_tab_css center-block" runat="server"></asp:DropDownList>
            </div>

            <div class="col-md-4">
                <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Mức độ câu hỏi") %></label>
                <asp:DropDownList ID="drpMucDoCauHoi" AutoPostBack="true" Style="margin-right: 50px" OnSelectedIndexChanged="drpMucDoCauHoi_SelectedIndexChanged" CssClass="form-control element_tab_css center-block" runat="server"></asp:DropDownList>
            </div>


            <div class="col-md-4">
                <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Loại câu hỏi") %></label>
                <asp:DropDownList ID="drpLoaiCauHoi" AutoPostBack="true" Style="margin-right: 130px" OnSelectedIndexChanged="drpLoaiCauHoi_SelectedIndexChanged" CssClass="form-control element_tab_css center-block" runat="server"></asp:DropDownList>
            </div>
        </div>

        <!-------------BEGIN: Display Gridview----------------->
        <dx:ASPxGridView ID="grvCauHoi" Width="100%" Style="margin-left: auto; margin-right: auto" runat="server" KeyFieldName="Id"
            Settings-ShowGroupPanel="false" AutoGenerateColumns="False" ClientInstanceName="grvCauHoi">
            <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />

            <Columns>
                <dx:GridViewDataTextColumn FieldName="STT" Caption="STT" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" Width="4%">
                    <DataItemTemplate>
                        <%# Container.ItemIndex + 1 %>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NOI_DUNG_CAU_HOI" Caption="Nội dung" Width="35%" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="KIEU_CAU_HOI" Caption="Loại câu hỏi" Width="15%" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="KIEU_MUC_DO" Caption="Mức độ" Width="20%" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="KIEU_CHU_DE" Caption="Chủ đề câu hỏi" Width="20%" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Lựa chọn" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" VisibleIndex="3">
                    <DataItemTemplate>
                        <a href="javascript:viewObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("Sửa")%></a>
                        <a href="javascript:deleteObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("XOA")%></a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
            </Columns>
            <SettingsPager PageSize="20">
                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
            </SettingsPager>
            <Settings ShowFilterRow="false" AutoFilterCondition="Contains" />
        </dx:ASPxGridView>
        <!-------------END: Display Gridview----------------->
    </div>

    <div id="DIV_MESSAGE" visible="false" runat="server">
        <div class="pop_up_background_css pop_up_background_message_css"></div>
        <div class="pop_up_info_css pop_up_message_css" runat="server">
            <asp:Button ID="btlClosePopUp_Message" OnClick="btlClosePopUp_Message_Click" Text="X" CssClass="btn btn-danger close_css" runat="server" />
            <span class="message_box_css">
                <asp:Literal ID="ltMessageContent" runat="server"></asp:Literal></span>
            <asp:Button ID="btnOK_DeleteObject" OnClick="btnOK_DeleteObject_Click" class="btn btn-warning row_css" Text="OK" Visible="false" runat="server" />
        </div>
    </div>

    <!------------------------popup chon loai cau hoi------------>
    <div class="modal fade" id="myModal">
        <div class="modal-dialog modal-dialog-centered ">

            <!-- Modal content-->
            <div class="modal-content" style="width: 600px; height: 300px">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" id="txt_title" style="text-align: center; font-weight: bold; font-size: 18px">Thêm câu hỏi</h4>
                </div>
                <div class="modal-body" id="modal_body" style="width: 600px; height: 150px">
                    <div class="col-xs-12" style="text-align: center; margin-top: 5px">
                        <asp:Button ID="btnTracNghiem" CssClass="btn btn-success" OnClick="btnTracNghiem_Click" Style="margin-right: 5px" Text="Trắc nghiệm" runat="server"></asp:Button>
                        <asp:Button ID="btnTuLuan" CssClass="btn btn-success" OnClick="btnTuLuan_Click" Style="margin-right: 5px" Text="Tự luận" runat="server"></asp:Button>
                    </div>
                </div>
                <%--<div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Save</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>--%>
            </div>
        </div>
    </div>
    <!------------------------END: popup chon loai cau hoi------------>


    <!-------------------------------BEGIN: display Message Box-------------------------------------------------------->
    <div id="DIV_MESSAGE_IMPORT" visible="false" runat="server">
        <div class="pop_up_background_css pop_up_background_message_css"></div>
        <div class="pop_up_info_css pop_up_message_css" runat="server">
            <asp:Button ID="btlClosePopUp_Import" OnClick="btlClosePopUp_Import_Click" Text="X" CssClass="btn btn-danger close_css" runat="server" />
            <div class="col-xs-12">
                <div class="page-header">
                    <h1 class="panel-title">Import Câu hỏi</h1>
                </div>
                <div style="width: 100%; float: left; color: red;">
                    <asp:Label ID="lbMessage" runat="server"></asp:Label>
                </div>

                <asp:FileUpload ID="FileUpload_test_online" runat="server" CssClass="form-control element_tab_css" />

                <div class="col-xs-6 col-space-right-css" style="margin-left: -15px">
                    <label class="control-label">Loại câu hỏi</label>
                    <asp:DropDownList ID="drpLoaiCH" CssClass="form-control element_tab_css" runat="server" AutoPostBack="false">
                        <asp:ListItem Value="trac_nghiem">Trắc nghiệm</asp:ListItem>
                        <asp:ListItem Value="tu_luan">Tự luận</asp:ListItem>
                        <asp:ListItem Value="chu_de_bai_thi">Chủ đề bài thi</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <asp:Button ID="btnSaveImport" OnClick="BtImport_test_online_Click" class="btn btn-warning row_css" Text="Save" runat="server" />
        </div>
    </div>
    <!-------------------------------END: display Message Box-------------------------------------------------------->

    <div class="hidden_css">
        <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtHeThongID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtFileID" runat="server"></asp:TextBox>
        <asp:Button ID="btlDeleteObject" OnClick="btlDeleteObject_Click" runat="server" />
        <asp:Button ID="btnViewObject" OnClick="btnViewObject_Click" runat="server" />
    </div>

    <script>
        function viewObject(intID) {

            $("#<%=txtObjectID.ClientID%>").val(intID);

            __doPostBack("<%= btnViewObject.UniqueID %>", "OnClick");

        }

        function deleteObject(intID) {
            $("#<%=txtObjectID.ClientID%>").val(intID);
            __doPostBack("<%= btlDeleteObject.UniqueID %>", "OnClick");
        }

    </script>

</asp:Content>

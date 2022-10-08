<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="HopDuAn_Edit.aspx.cs" EnableEventValidation="false" Inherits="CPanel.Modules.HopDuAn_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>
		.margin_bottom10{
			margin-bottom:10px;
		}
	</style>
	<div class="main_contain_css main_contain_css_1">
		<div class="page-header">
			<h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("TITLE_UPDATE_HOP_DU_AN") %></h1>
		</div>

		<div class="control_css">
			<asp:Button ID="btnCancel" runat="server" CssClass="btn btn-default" OnClick="btnCancel_Click"></asp:Button>
			<input type="button" class="btn btn-warning btn_Validation_Save_CSS" />
		</div>
		<div class="bg_100pecents_css">
			<div class="col-xs-12">
				<div class="col-xs-2">
					<label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("STR_NGAY_HOP") %></label>
				</div>

				<div class="col-xs-4 margin_bottom10">
					<dx:ASPxDateEdit runat="server" ID="dtNgayHop" EditFormat="Custom" CssClass="form-control readonly_css"></dx:ASPxDateEdit>
				</div>

			</div>

			<div class="col-xs-12">
				<div class="col-xs-2">
					<label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("STR_GIO_HOP") %></label>
				</div>

				<div class="col-xs-4 margin_bottom10">
					<dx:ASPxTimeEdit ID="tsGioHop" runat="server"
						DisplayFormatString="HH:mm" EditFormat="Custom" EditFormatString="HH:mm" CssClass="form-control readonly_css">
					</dx:ASPxTimeEdit>
				</div>

			</div>
			<div class="col-xs-12">
				<div class="col-xs-2">
					<label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("DIA_DIEM") %></label>
				</div>

				<div class="col-xs-4">
					<asp:TextBox ID="txtDiaDiem" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>
				</div>
			</div>
			<div class="col-xs-12">
				<div class="col-xs-2">
					<label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("STR_KIEU_HOP") %></label>
				</div>

				<div class="col-xs-4 margin_bottom10">
					<asp:DropDownList ID="drpKieuHop" AutoPostBack="false" Enabled="true" CssClass="form-control element_tab_css" runat="server"></asp:DropDownList>
				</div>
			</div>
			<div class="col-xs-12">
				<div class="col-xs-2">
					<label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("STR_HINH_THUC_HOP") %></label>
				</div>

				<div class="col-xs-4 margin_bottom10">
					<asp:DropDownList ID="drpHinhThuc" AutoPostBack="false" Enabled="true" CssClass="form-control element_tab_css" runat="server"></asp:DropDownList>
				</div>
			</div>
			<div class="col-xs-12">
				<div class="col-xs-2">
					<label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("NOI_DUNG_HOP") %></label>
				</div>

				<div class="col-xs-4">
					<asp:TextBox ID="txtNoiDung" CssClass="form-control element_tab_css" Rows="1" runat="server"></asp:TextBox>
				</div>
			</div>
			<div class="col-xs-12">
				<div class="col-xs-2">
					<label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("STR_KET_QUA_HOP") %></label>
				</div>

				<div class="col-xs-4">
					<asp:FileUpload ID="FileUpload_KetQua" runat="server" CssClass="form-control element_tab_css" />
				</div>
			</div>
			<div class="col-xs-12">
				<div class="col-xs-2">
					<label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("GHI_CHU") %></label>
				</div>

				<div class="col-xs-6">
					<asp:TextBox ID="txtGhiChu" TextMode="MultiLine" CssClass="form-control element_tab_css" Rows="3" runat="server"></asp:TextBox>
				</div>
			</div>

		</div>
	</div>
	<div class="col-xs-8"></div>
	<!-------------------------------BEGIN: display Message Box-------------------------------------------------------->
	<div id="DIV_MESSAGE" visible="false" runat="server">
		<div class="pop_up_background_css"></div>
		<div class="pop_up_info_css pop_up_message_css" runat="server">
			<asp:Button ID="btlClosePopUp" OnClick="btlClosePopUp_Click" Text="X" CssClass="btn btn-danger close_css" runat="server" />
			<span class="message_box_css">
				<asp:Literal ID="ltMessageContent" runat="server"></asp:Literal></span>
		</div>
	</div>
	<!-------------------------------END: display Message Box-------------------------------------------------------->

	<!--BEGIN: hidden tag-->
	<div class="hidden_css">
		<asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
		<asp:TextBox ID="txtHeThongID" runat="server"></asp:TextBox>
		<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click"></asp:Button>


	</div>
	<!--END: hidden tag-->


	<script>
		//***********************************BEGIN: Set button title***************************************
		$("#<%=btnCancel.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_CANCEL")%>');
		$(".btn_Validation_Save_CSS").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_SUBMIT")%>');
		//***********************************END: Set button title*****************************************

		$(".btn_Validation_Save_CSS").click(function () {
			if (validateForm()) {

				__doPostBack("<%=btnSave.UniqueID%>", "OnClick");
			}
		});
	</script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="DanhSachBaiThiCauHoi_List.aspx.cs" Inherits="CPanel.Modules.Admin.DanhSachBaiThiCauHoi_List" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main_contain_css main_contain_css_1">
        <div class="control_css">            
            <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-warning" OnClick="btnCreate_Click" Visible="true" ></asp:Button>        
        </div>

        <div class="page-header">
            <h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("DANH_SACH_BAI_THI") %></h1>
        </div>
                
         <div class="col-md-12 search_info_css">
            <div class="col-md-4">
                <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Chủ đề bài thi") %></label>
                <asp:DropDownList ID="drpChuDeBaiThi"  CssClass="form-control element_tab_css center-block" runat ="server"></asp:DropDownList>
            </div>

           
            <div class="col-md-3">
                <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Mức độ bài thi") %></label>
                <asp:DropDownList ID="drpMucDoBaiThi" CssClass="form-control element_tab_css center-block" runat ="server"></asp:DropDownList>
            </div>

            
            <div class="col-md-3">
                <label class="control-label line_lb_css"><%=CPanel.Commons.TitleConst.getTitleConst("Tên bài thi") %></label>
                <%--<asp:DropDownList ID="drpTenBaiThi" AutoPostBack="true" style="margin-right:130px" OnSelectedIndexChanged="drpTenBaiThi_SelectedIndexChanged" CssClass="form-control element_tab_css center-block" runat ="server"></asp:DropDownList>--%>
                <asp:TextBox ID="txtTenBaiThi" CssClass="form-control element_tab_css" placeholder ="Nhập tên bài thi" runat="server"></asp:TextBox>
            </div>
             <div class="col-md-2" style ="margin-top:37px; display:inline-block;">
                 <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-default"   Text="Tìm kiếm" OnClick="btnSearch_Click" Visible="true" ></asp:Button>
            </div>
        </div>
       <%-- OnTextChanged="txtTenBaiThi_TextChanged"--%>
        <dx:ASPxGridView runat="server" ID="grvBaiThi" Width="100%" KeyFieldName="Id" OnDataBinding="grvObjects_DataBinding" Settings-ShowGroupPanel="false" AllowFocusedRow="true">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="STT" Caption="STT" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" Width="4%" CellStyle-HorizontalAlign="Center">
                    <DataItemTemplate>
                        <%# Container.ItemIndex + 1 %>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TEN_BAI_THI" Settings-AllowSort="False" Caption="TEN_BAI_THI" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="TEN_CHU_DE_BAI_THI" Settings-AllowSort="False" Caption="CHU_DE" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="TEN_MUC_DO_BAI_THI" Settings-AllowSort="False" Caption="MUC_DO" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" CellStyle-HorizontalAlign="Center"/>
                <dx:GridViewDataTextColumn FieldName="THOI_GIAN" Settings-AllowSort="False" Caption="TIME" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" CellStyle-HorizontalAlign="Center" />
                <dx:GridViewDataTextColumn FieldName="NGAY_TAO" Settings-AllowSort="False" Caption="Thời gian tạo"
                    HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" CellStyle-HorizontalAlign="Center" />

                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="HANH_DONG_BT" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" VisibleIndex="3">
                    <DataItemTemplate>
                        <a href="javascript:viewObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("XEM")%></a>
                        &ensp;
                        <a href="javascript:deleteObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("XOA")%></a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
            </Columns>
            <SettingsPager PageSize="20">
                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
            </SettingsPager>
            <Settings ShowFilterRow="false" AutoFilterCondition="Contains" />
        </dx:ASPxGridView>
        <!-------------------------------BEGIN: display MessageBox--------------------------------------------->
        <div id="DIV_MESSAGE" visible="false" runat="server">
            <div class="pop_up_background_css pop_up_background_message_css"></div>
            <div class="pop_up_info_css pop_up_message_css" runat="server">
                <asp:Button ID="btlClosePopUp_Message" OnClick="btlClosePopUp_Message_Click" Text="X" CssClass="btn btn-danger close_css" runat="server" />
                <span class="message_box_css">
                    <asp:Literal ID="ltMessageContent" runat="server"></asp:Literal></span>
                <asp:Button ID="btnOK_DeleteObject" OnClick="btnOK_DeleteObject_Click" class="btn btn-warning row_css" Text="OK" Visible="false" runat="server" />
            </div>
        </div>
        <!-------------------------------END: display Message Box----------------------------------------------->
        <!--BEGIN: hidden tag-->
        <div class="hidden_css">
            <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtFileID" runat="server"></asp:TextBox>
            <asp:Button ID="btlDeleteObject" OnClick="btlDeleteObject_Click" runat="server" />


            <asp:Button ID="btnViewObject" OnClick="btnViewObject_Click" runat="server" />
        </div>
        <!--END: hidden tag-->
        <script>
            //***********************************BEGIN: Set button title***************************************          
            $("#<%=btnCreate.ClientID%>").val('<%=CPanel.Commons.TitleConst.getTitleConst("BUTTON_CREATE")%>');

            //***********************************END: Set button title*****************************************

            function viewObject(intID) {
                $("#<%=txtObjectID.ClientID%>").val(intID);
                __doPostBack("<%= btnViewObject.UniqueID %>", "OnClick");
            }

            function deleteObject(intID) {
                $("#<%=txtObjectID.ClientID%>").val(intID);
                __doPostBack("<%= btlDeleteObject.UniqueID %>", "OnClick");
            }

        </script>
    </div>
</asp:Content>

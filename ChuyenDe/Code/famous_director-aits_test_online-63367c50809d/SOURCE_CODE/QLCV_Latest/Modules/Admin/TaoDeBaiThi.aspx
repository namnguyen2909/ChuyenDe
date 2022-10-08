<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="TaoDeBaiThi.aspx.cs" Inherits="CPanel.Modules.Admin.TaoDeBaiThi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="control_css">
        <%--<input type="button" class="btn btn-warning btn_ADD_CSS" data-toggle="modal" data-target="#myModal" />--%>
        <asp:Button CssClass="btn btn-warning" Text="Thêm Mới" ID="btnAddCauHoi" runat="server" OnClick="btnAddCauHoi_Click" />
    </div>
    <div class="page-header" style="text-align: center; ">
        <label class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("TEN_BAI_THI") %></label>
        <asp:Label ID="lblTenBaiThi" runat="server" CssClass="tenbaithi_css" />
    </div>

    <div class="col-xs-12">
        <div class="col-xs-4 text-center">
            <label style="font-size:16px">Chủ đề bài thi: </label>
            <asp:Label ID="lblLoaiBT" style ="font-size: 16px; font-weight: bold" runat="server"></asp:Label>
        </div>

        <div class="col-xs-4 text-center">
            <label style="font-size:16px">Mức độ:</label>
            <asp:Label ID="lblMucDo"  style ="font-size: 16px; font-weight: bold" runat="server"></asp:Label>
        </div>
        <div class="col-xs-4">
            <label style="font-size: 16px;">Thời gian:</label>
            <asp:Label ID="lblThoiGian" style="font-size: 16px; font-weight: bold" runat="server" />
        </div>
    </div>
    <div>
        <dx:ASPxGridView ID="grvObjects" Width="100%" runat="server" KeyFieldName="Id" OnDataBinding="grvObjects_DataBinding" Settings-ShowGroupPanel="false" AutoGenerateColumns="False" ClientInstanceName="grvObjects">
        <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />  
        <Columns>         
            <%--<dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="STT" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="2">
                <DataItemTemplate>                                              
                    <%# Eval("STT") %>
                </DataItemTemplate>
            </dx:GridViewDataColumn>--%>

            <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Câu hỏi" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="2">
                <DataItemTemplate>                                              
                    <%# Eval("CAU_HOI") %>
                </DataItemTemplate>
            </dx:GridViewDataColumn>                                                                                        
            <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Đáp án" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="2">
                <DataItemTemplate>                                              
                    <%# Eval("DAP_AN") %>
                </DataItemTemplate>
            </dx:GridViewDataColumn>

            <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Hành động" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="3">
                <DataItemTemplate>
                    <a href="javascript:deleteObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("XOA")%></a>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
        </Columns>
        <SettingsPager PageSize="20">
            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
        </SettingsPager>
        <Settings ShowFilterRow="true" AutoFilterCondition="Contains"/>                
        </dx:ASPxGridView>
    </div>
         <div class="col-xs-12">
            <asp:Button ID="Button1" OnClick="btnBack_Click" Text="Back"
               
                CssClass="btn btn-success center_css"
                style="margin-top:20px;
                       margin-left:885px;
                background-image: linear-gradient(to right, #cb2d3e 0%, #ef473a  51%, #cb2d3e  100%);
                padding: 10px 20px;
                text-transform: uppercase;
                transition: 0.5s;
                background-size: 200% auto;
                color: white;            
                box-shadow: 0 0 20px #eee;
                border-radius: 10px;
                display: block;" 
                Width="100px" Height="40px" Font-Size=16px runat="server">
            </asp:Button>
        </div>
    <%--Popup chọn câu hỏi--%>
    <div id="DIV_CAU_HOI" visible="false" runat="server">
        <div class="pop_up_background_css pop_up_background_message_css"></div>
        <div class="pop_up_info_css pop_up_message_css" style="height:auto; margin-top:-280px;">
            <asp:Button ID="btlClosePopUp" OnClick="btlClosePopUp_Click" Text="X" CssClass="btn btn-danger close_css" runat="server" />
            <div class="col-xs-12">
                <label>Chủ đề câu hỏi:</label>
                <asp:DropDownList ID="drpChuDeCauHoi" OnSelectedIndexChanged="drpChuDeCauHoi_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control element_tab_css center-block" Style="width: auto" runat="server"></asp:DropDownList>
                <br />
                 <dx:ASPxGridView runat="server" ID="grvCauHoi" OnDataBinding="grvCauHoi_DataBinding" Width="100%" KeyFieldName="ID" Settings-ShowGroupPanel="false" AutoGenerateColumns="False" ClientInstanceName="grvCauHoi">
                    <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />
                        <Columns>
                            <dx:GridViewCommandColumn Width="20px" ShowSelectCheckbox="true" VisibleIndex="0" HeaderStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <dx:ASPxCheckBox ID="SelectAllCheckBox" runat="server" ClientSideEvents-CheckedChanged="function(s, e) { grvCauHoi.SelectAllRowsOnPage(s.GetChecked()); }"/>
                                </HeaderTemplate>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="NOI_DUNG_CAU_HOI" Settings-AllowAutoFilter="True" Caption="Câu hỏi" Width="100px" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" CellStyle-HorizontalAlign="Left" />
                        </Columns>
                 </dx:ASPxGridView>
            </div>
            <asp:Button ID="btnSave" OnClick="btnSave_Click" class="btn btn-warning row_css" Text="Save" runat="server" />
        </div>
    </div>
    <!-------------------------------BEGIN: display Message Box-------------------------------------------------------->
        <div id="DIV_MESSAGE" visible="false" runat="server">
            <div  class="pop_up_background_css pop_up_background_message_css"></div>
            <div class="pop_up_info_css pop_up_message_css" runat="server">
                <asp:Button ID="btlClosePopUp_Message" OnClick="btlClosePopUp_Message_Click" Text="X" CssClass="btn btn-danger close_css" runat="server" />
                <span class="message_box_css"><asp:Literal ID="ltMessageContent" runat="server"></asp:Literal></span>
                <asp:Button ID="btnOK_DeleteObject" OnClick="btnOK_DeleteObject_Click" class="btn btn-warning row_css" Text="OK" Visible="false"  runat="server" />
            </div>
        </div>    
        <!-------------------------------END: display Message Box------------------------------------------------------>
    <div class="hidden_css">
        <asp:TextBox ID="txtCauHoiID" runat="server" />
        <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtParentObjectID" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtHeThongID" runat="server"></asp:TextBox>
        <asp:Button ID="btlDeleteObject" OnClick="btlDeleteObject_Click" runat="server" />
    </div>
    <script>
        <%--$(".btn_ADD_CSS").val('<%=CPanel.Commons.TitleConst.getTitleConst("CHON_CAU_HOI")%>');--%>

        function deleteObject(intid) {
            $("#<%=txtCauHoiID.ClientID%>").val(intid);
            __doPostBack("<%= btlDeleteObject.UniqueID %>", "onclick");
        }
    </script>
</asp:Content>

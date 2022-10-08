<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="DuAn_List.aspx.cs" Inherits="CPanel.Modules.DuAn_List" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">        

    <div class="main_contain_css main_contain_css_1">
            <div class="page-header"><h1 class="panel-title"><%=CPanel.Commons.TitleConst.getTitleConst("TITLE_PAGE_QUAN_LY_DU_AN") %></h1></div>        

            <div class="control_css">            
                <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-warning" OnClick="btnCreate_Click" ></asp:Button>        
            </div>

            <div class="bg_100pecents_css margin_css">
                <div class="col-xs-6">
                    <label class="control-label"><%=CPanel.Commons.TitleConst.getTitleConst("KET_QUA_CV") %></label>
                    <asp:DropDownList ID="drpKetQuaCV" AutoPostBack="true" Visible="false" CssClass="form-control" TabIndex="2" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
    
           
        <dx:ASPxGridView ID="grvObjects" Width="100%" runat="server" KeyFieldName="Id" OnDataBinding="grvObjects_DataBinding" 
                    Settings-ShowGroupPanel="false" AutoGenerateColumns="False" ClientInstanceName="grvObjects">
            <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />  

            <Columns>      
                <dx:GridViewDataTextColumn FieldName="MA_HE_THONG" Caption="MA" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0" />
                
                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="TEN_DU_AN" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        <%# Eval("TEN") %><br />
                        <i>(<%# Eval("MO_TA") %>)</i>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                
                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Loại DA" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        DA chưa có HĐ
                    </DataItemTemplate>
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Phạm vi DA" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        DA AITS
                    </DataItemTemplate>
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Kiểu DA" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        Tự triển khai
                    </DataItemTemplate>
                </dx:GridViewDataColumn>

                <dx:GridViewDataTextColumn FieldName="STR_NGAY_BAT_DAU_LAM" Caption="NGAY_BAT_DAU_LAM" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0" />
                <dx:GridViewDataTextColumn FieldName="STR_NGAY_NGHIEM_THU_TT" Caption="NGAY_NGHIEM_THU_TT" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0" />
                
                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Số ngày triển khai" HeaderStyle-Wrap="True" Width="40px" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        90
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Tổ trưởng" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        Duong Van Tuyen
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Thư ký" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        Do Quynh Trang
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Số Task hoàn thành" HeaderStyle-Wrap="True" Width="40px" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        9/50
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Số Task quá hạn" HeaderStyle-Wrap="True" Width="40px" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        10/50
                    </DataItemTemplate>
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Số lượng Rủi ro" HeaderStyle-Wrap="True" Width="40px" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        3
                    </DataItemTemplate>
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Kết quả" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        18%
                    </DataItemTemplate>
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="Tình trạng" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="0">
                    <DataItemTemplate>                                              
                        <span style="background-color: red">Quá hạn</span>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>

                <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Caption="HANH_DONG" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" VisibleIndex="3">
                    <DataItemTemplate>                                              
                        <a href="javascript:viewObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("XEM")%></a>
                        <a href="javascript:deleteObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("XOA")%></a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
            </Columns>
            <SettingsPager PageSize="50">
                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
            </SettingsPager>
            <Settings ShowFilterRow="false"/>                
        </dx:ASPxGridView>

        <!-------------------------------BEGIN: display Message Box-------------------------------------------------------->
        <div id="DIV_MESSAGE" visible="false" runat="server">
            <div  class="pop_up_background_css pop_up_background_message_css"></div>
            <div class="pop_up_info_css pop_up_message_css" runat="server">
                <asp:Button ID="btlClosePopUp_Message" OnClick="btlClosePopUp_Message_Click" Text="X" CssClass="btn btn-danger close_css" runat="server" />
                <span class="message_box_css"><asp:Literal ID="ltMessageContent" runat="server"></asp:Literal></span>
                <asp:Button ID="btnOK_DeleteObject" OnClick="btnOK_DeleteObject_Click" class="btn btn-warning row_css" Text="OK" Visible="false"  runat="server" />
            </div>
        </div>
        <!-------------------------------END: display Message Box-------------------------------------------------------->
        
        <!--BEGIN: hidden tag-->
        <div class="hidden_css">
            <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtFileID" runat="server"></asp:TextBox>

            <asp:Button ID="btnViewFile" Text="View File" runat="server" />
            <asp:Button ID="btnViewObject" OnClick="btnViewObject_Click" runat="server" /> 
            <asp:Button ID="btlDeleteObject" OnClick="btlDeleteObject_Click"   runat="server" />       
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

            function viewFile(intID)
            {
                $("#<%=txtFileID.ClientID%>").val(intID);
                __doPostBack("<%= btnViewFile.UniqueID %>", "OnClick");
            }

            function deleteObject(intID) {
                $("#<%=txtObjectID.ClientID%>").val(intID);
                __doPostBack("<%= btlDeleteObject.UniqueID %>", "OnClick");
            }
        </script>
    </div>
</asp:Content>

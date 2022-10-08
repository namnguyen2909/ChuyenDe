<%@ Page Title="" Language="C#" MasterPageFile="~/Main_UV.master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="UVReviewBT_List.aspx.cs" Inherits="CPanel.Modules.UngVien.UVReviewBT_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="tab-content">
        <div id="XemUV" class="tab-pane fade in active">
            <div class="col-xs-12">
                    <div class="col-xs-1" style="margin-left: 89%; margin-bottom: 10px">
                        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" CssClass="btn btn-primary" Text="Quay lại"
                            Style="margin-bottom: -30px; background-image: linear-gradient(to right, #00c6ff 0%, #0072ff  51%, #00c6ff  100%); padding: 5px 12px; text-transform: uppercase; transition: 0.5s; background-size: 200% auto; color: white; box-shadow: 0 0 20px #eee; border-radius: 10px; display: block;"></asp:Button>
                    </div>
                </div>
            <div class="page-header" style="margin-top:5%;">
                <h1 class="panel-title">DANH SÁCH BÀI THI ỨNG VIÊN</h1>
            </div>
            <div class="container">
                <div style="width: 100%; color: red;">
                    <asp:Label ID="lbMessage" runat="server"></asp:Label>
                </div>
                <dx:ASPxGridView ID="grvBaiThi" OnDataBinding="grvBaiThi_DataBinding" Width="50%" Style="margin-left: auto; margin-top:2%; margin-right: auto; width:100%" runat="server" KeyFieldName="ID"
                    Settings-ShowGroupPanel="false" AutoGenerateColumns="False" ClientInstanceName="grvBaiThi">
                    <SettingsBehavior AllowSelectByRowClick="true" AllowFocusedRow="true" />

                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="STT" Caption="STT" Settings-AllowSort="False" CellStyle-BackColor="White" CellStyle-ForeColor="Black" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" Width="4%">
                            <DataItemTemplate>
                                <%# Container.ItemIndex + 1 %>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="BAI_THI.TEN_BAI_THI" Caption="Mã bài thi" CellStyle-BackColor="White" CellStyle-ForeColor="Black" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Left" Width="20%" VisibleIndex="2" />
                        <dx:GridViewDataTextColumn FieldName="NGAY_GUI_MAIL" Caption="Ngày nhận" Width="15%" CellStyle-BackColor="White" CellStyle-ForeColor="Black" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" VisibleIndex="2" />
                        <dx:GridViewDataTextColumn FieldName="NGAY_HOAN_THANH_BAI_THI" Caption="Ngày hoàn thành" CellStyle-BackColor="White" CellStyle-ForeColor="Black" Settings-AllowSort="False" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" Visible="true" Width="15%" VisibleIndex="2" />


                        <dx:GridViewDataColumn Settings-AutoFilterCondition="Contains" Width="10%" Caption="Lựa chọn" CellStyle-BackColor="White" CellStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" VisibleIndex="3">
                            <DataItemTemplate>
                                <a href="javascript:viewObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("XEM")%></a>
                                <a href="javascript:testObject('<%# Eval("ID") %>')"><%=CPanel.Commons.TitleConst.getTitleConst("Làm")%></a>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                    </Columns>
                    <SettingsPager PageSize="20">
                        <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                    </SettingsPager>
                </dx:ASPxGridView>

                
            </div>
            </div>
        </div>

        <!--BEGIN: hidden tag-->
        <div class="hidden_css"style="display:none">
            <asp:TextBox ID="txtObjectID" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtParentObjectID" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtHeThongID" runat="server"></asp:TextBox>
            <asp:Button ID="btnViewObject" OnClick="btnViewObject_Click" runat="server" />
            <asp:Button ID="btnTestObject" OnClick="btnTestObject_Click" runat="server" />
            <%--<asp:Button ID="btnSave" runat="server"></asp:Button>--%>
        </div>

        <style>
            @media only screen and (min-width: 1200px) {
                #abc {
                    margin-left: 910px;
                }
            }

            @media only screen and (min-width: 992px) and (max-width: 1200px) {
                #abc {
                    margin-left: 470px;
                }
            }

            @media only screen and (min-width: 768px) and (max-width: 992px) {
                #abc {
                    margin-left: 350px;
                }
            }

            @media only screen and (min-width: 576px) and (max-width: 768px) {
                #abc {
                    margin-left: 270px;
                }
            }

            @media only screen and (max-width: 576px) {
                #abc {
                    margin-left: 220px;
                }
            }
            
        .banner_1_css{
            display:none;
        }
        </style>
        <script>
            //***********************************BEGIN: Set button title***************************************   

            function viewObject(intID) {
                $("#<%=txtObjectID.ClientID%>").val(intID);
                 __doPostBack("<%= btnViewObject.UniqueID %>", "OnClick");
            }

            //***********************************END: Set button title*****************************************

            function testObject(intID) {
                $("#<%=txtObjectID.ClientID%>").val(intID);
                 __doPostBack("<%= btnTestObject.UniqueID %>", "OnClick");
            }
        </script>
</asp:Content>

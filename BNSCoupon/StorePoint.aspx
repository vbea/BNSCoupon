<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="StorePoint.aspx.cs" Inherits="BNSCoupon.StorePoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    积分商城
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    <div class="chi_div">
        <a href="BNSCoupon.aspx">账号列表</a>-积分商城
            <table style="width: 50%; height: 30px; border-collapse: collapse;">
                <tr>
                    <td colspan="2">当前账号：<asp:Label ID="labAccount" runat="server" CssClass="store_id"></asp:Label></td>
                    <td colspan="2">账户余额：<asp:Label ID="labRemaining" runat="server" CssClass="store_id"></asp:Label></td>
                </tr>
            </table>
        <asp:LinkButton ID="likHidden" runat="server" ClientIDMode="Static" OnClick="likHidden_Click"></asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <link href="js/asyncbox/skins/ZCMS/asyncbox.css" rel="stylesheet" />
    <script src="js/asyncbox/AsyncBox.v1.4.5.js"></script>
    <script type="text/javascript">
        function openBuy(id, account) {
            asyncbox.open({
                id: 'dialogBuy',
                url: 'ShopPoint.aspx',
                width: 500,
                height: 500,
                data: { "commodity": id, "account": account },
                title: '积分购买商品'
            });
            /*var dialog = new Dialog("dialog" + id);
            dialog.Width = 450;
            dialog.Height = 400;
            dialog.Title = "购买商品";
            dialog.URL = "Shop.aspx?commodity=" + id + "&account=" + account;
            dialog.ShowButtonRow = false;
            dialog.show();*/
        }
        function closeMoy(id) {
            asyncbox.close(id);
            __doPostBack('ctl00$conTitle$likHidden', '');
        }
    </script>
    <div class="chi_div">
        <div style="width: 100%;">
            <table style="width: 95%;">
                <tr style="width: 100%;">
                    <td style="width: 80%; vertical-align: top;">
                        <asp:Table ID="tabCommodity" runat="server" Width="100%">
                        </asp:Table>
                        <asp:Label ID="labNodata" runat="server" Text="没有查询到商品" Style="width: 60%; text-align: center; display: inline-block; color: #F75733;" Visible="false"></asp:Label>
                    </td>
                    <td style="width: 20%; vertical-align: top; border-left: 2px solid #F75733; padding-left: 5px; padding-right: 5px;">
                        <div class="store_id" style="text-align: left; font-weight: normal;">购买记录：<asp:LinkButton ID="lnkAllLog" runat="server" OnClick="lnkAllLog_Click">查看所有记录</asp:LinkButton></div>
                        <asp:GridView ID="gvOrderList" runat="server" AutoGenerateColumns="False" Style="width: 98%; border-style: none;" ShowHeader="False" BorderStyle="None">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table style="width: 100%; padding: 5px 10px 5px 10px; background-color: #F1F1F1; border-style: none;">
                                            <tr>
                                                <td style="font-size: 12px; color: #808080;" colspan="2"><%# Convert.ToDateTime(Eval("dates")).ToString("yyyy-MM-dd HH:mm:ss") %></td>
                                            </tr>
                                            <tr>
                                                <td style="font-size: 15px;" colspan="2"><%# Eval("cname")%><span class="store_id">×<%# Eval("ccount") %></span></td>
                                            </tr>
                                            <tr style="font-size: 14px;">
                                                <td>单价:<%# Eval("cunit") %></td>
                                                <td>总价:<%# Eval("point") %></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align:center; color:#666666; padding-top:100px;">暂无本月购买记录</div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

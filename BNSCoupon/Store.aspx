<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="BNSCoupon.Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    商城
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    <div class="chi_div">
        <a href="BNSCoupon.aspx">账号列表</a>-商城
            <table style="width: 50%; height: 30px; border-collapse: collapse;">
                <tr style="width: 100%; height: 30px; border-collapse: collapse;">
                    <td style="width: 20%; height: 30px;">商品搜索：</td>
                    <td style="width: 15%; text-align: right; height: 30px;">按照分类：</td>
                    <td style="width: 20%; height: 30px;">
                        <asp:DropDownList ID="ddlCategory" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                            <asp:ListItem Value="0"> 请选择...</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%; text-align: right; height: 30px;">按照关键字：</td>
                    <td style="width: 20%; height: 100%; border-collapse: collapse; border: 0px;">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="search" onkeydown="if(event.keyCode==13) {document.all.btnSearch.focus(); document.all.btnSearch.click();}"></asp:TextBox>
                    </td>
                    <td style="height: 100%; text-align: left; border-collapse: collapse; margin-left: -2px;">
                        <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="search_btn" OnClick="btnSearch_Click" ClientIDMode="Static" />
                    </td>
                    <td style="height: 100%; text-align: left; border-collapse: collapse; padding-left:5px;">
                       <asp:Button ID="btnBymon" runat="server" Text="购买金币" OnClientClick="openBuym();" CssClass="search_btn" UseSubmitBehavior="False"/>
                        <asp:LinkButton ID="likHidden" runat="server" ClientIDMode="Static" OnClick="likHidden_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">当前账号：<asp:Label ID="labAccount" runat="server" CssClass="store_id"></asp:Label></td>
                    <td colspan="2">账户余额：<asp:Label ID="labRemaining" runat="server" CssClass="store_id"></asp:Label></td>
                    <td><asp:HiddenField ID="hidShowStore" runat="server" />
                    </td>
                </tr>
            </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <link href="js/asyncbox/skins/ZCMS/asyncbox.css" rel="stylesheet" />
    <script src="js/asyncbox/AsyncBox.v1.4.5.js"></script>
    <script type="text/javascript">
        function openBuy(id, account) {
            asyncbox.open({
                id: 'dialogBuy',
                url: 'Shop.aspx',
                width: 500,
                height: 500,
                data: { "commodity": id, "account": account },
                title: '购买商品'
            });
            /*var dialog = new Dialog("dialog" + id);
            dialog.Width = 450;
            dialog.Height = 400;
            dialog.Title = "购买商品";
            dialog.URL = "Shop.aspx?commodity=" + id + "&account=" + account;
            dialog.ShowButtonRow = false;
            dialog.show();*/
        }
        function openBuym(account) {
            asyncbox.open({
                id: 'dialogBuym',
                url: 'Money.aspx',
                width: 450,
                height: 400,
                data: { "account": account },
                title: '购买金币'
            });
            /*var dialog = new Dialog("money_" + account);
            dialog.Width = 450;
            dialog.Height = 400;
            dialog.Title = "购买金币";
            dialog.URL = "Money.aspx?account=" + account;
            dialog.ShowButtonRow = false;
            dialog.show();*/
            return false;
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
                                                <td>总价:<%# Eval("price") %></td>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Record.aspx.cs" Inherits="BNSCoupon.Record" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Literal runat="server" ID="litTitle">购买记录</asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    <div class="chi_div">
        <table width="90%">
            <tr>
                <td style="width:30%;">
                    <asp:HyperLink ID="hlkStore" runat="server">商城</asp:HyperLink>-<asp:Literal runat="server" ID="labTitle"></asp:Literal>
                    <asp:DropDownList ID="ddlDatadiff" runat="server" Style="margin-left: 10px;" OnSelectedIndexChanged="ddlDatadiff_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="0">本月记录</asp:ListItem>
                        <asp:ListItem Value="1">上月记录</asp:ListItem>
                        <asp:ListItem Value="2">近三个月记录</asp:ListItem>
                        <asp:ListItem Value="3">三个月前记录</asp:ListItem>
                        <asp:ListItem Value="4">所有记录</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width:30%;">
                    查询到<asp:Literal ID="litRecordCount" runat="server"></asp:Literal>条记录</td>
                <td style="width:35%; text-align:right; padding-right:0px;">
                    <asp:Literal ID="litPager" runat="server">1/1</asp:Literal></td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <div class="chi_div">
        <div style="width: 90%;">
            <asp:GridView ID="gvOrderList" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" GridLines="None" CssClass="grid_b" AllowPaging="True" OnPageIndexChanging="gvOrderList_PageIndexChanging" PageSize="20">
                <AlternatingRowStyle BackColor="#E7F7FF" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="width: 5%; text-align: center;">ID</td>
                                    <td style="width: 8%; text-align: center;">商品编号</td>
                                    <td style="width: 30%; text-align: center;">商品名称</td>
                                    <td style="width: 10%; text-align: center;">单价</td>
                                    <td style="width: 10%; text-align: center;">数量</td>
                                    <td style="width: 15%; text-align: center;">总价</td>
                                    <td style="width: 20%; text-align: center;">购买日期</td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="width: 5%; text-align: center;"><%# Eval("id") %></td>
                                    <td style="width: 8%; text-align: center;"><%# Eval("cid") %></td>
                                    <td style="width: 30%; text-align: center;"><%# Eval("cname") %></td>
                                    <td style="width: 10%; text-align: center;"><%# Eval("cunit") %></td>
                                    <td style="width: 10%; text-align: center;"><%# Eval("ccount") %></td>
                                    <td style="width: 15%; text-align: center;"><%# Eval("price") %></td>
                                    <td style="width: 20%; text-align: center;"><%# Convert.ToDateTime(Eval("dates")).ToString("yyyy年MM月dd日 HH:mm:ss") %></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div style="width: 100%; text-align: center;">没有查询到数据</div>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#F75733" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#F75733" Font-Bold="True" ForeColor="White" />
                <PagerStyle CssClass="grid_page" HorizontalAlign="Center" />
                <RowStyle BackColor="white" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

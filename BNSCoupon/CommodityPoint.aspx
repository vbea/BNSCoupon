<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="CommodityPoint.aspx.cs" Inherits="BNSCoupon.CommodityPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    积分商城管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    <div class="chi_div">商品列表</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <div class="chi_div">
        <asp:GridView ID="gdCommodity" CellPadding="4" GridLines="None" runat="server" CssClass="grid_b" AutoGenerateColumns="False" Width="70%" AllowPaging="True" OnPageIndexChanging="gdCommodity_PageIndexChanging" OnRowDataBound="gdCommodity_RowDataBound" PageSize="15">
            <AlternatingRowStyle BackColor="#E7F7EF" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="100%">
                            <tr>
                                <td style="width: 10%; text-align: center;">商品编号</td>
                                <td style="width: 20%; text-align: center;">商品名</td>
                                <td style="width: 10%; text-align: center;">积分</td>
                                <td style="width: 15%; text-align: center;">最大购买量</td>
                                <td style="width: 20%; text-align: center;">说明</td>
                                <td style="width: 10%; text-align: center;">已上架</td>
                                <td style="width: 15%; text-align: center;">操作</td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td style="width: 10%; text-align: center;"><%# Eval("id") %></td>
                                <td style="width: 20%; text-align: center;"><%# Eval("name") %></td>
                                <td style="width: 10%; text-align: center;"><%# Eval("point") %></td>
                                <td style="width: 15%; text-align: center;"><%# Eval("maxs") %></td>
                                <td style="width: 20%; text-align: center;"><%# Eval("mark") %></td>
                                <td style="width: 10%; text-align: center;"><%# Eval("valid") %></td>
                                <td style="width: 15%; text-align: center;">
                                    <a href='<%# "Pointhouse.aspx?action=edt&id="+ Eval("id")%>'>修改</a>
                                    <asp:LinkButton ID="linkDelete" runat="server" CommandName='<%# Eval("id") %>' OnClientClick="return confirm('确定要删除该商品吗？');" OnClick="linkDelete_Click">删除</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div style="width: 100%; text-align: center;">当前没有商品数据，请添加！</div>
            </EmptyDataTemplate>
            <FooterStyle BackColor="#F75733" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#F75733" Font-Bold="True" ForeColor="White" />
            <PagerStyle CssClass="grid_page" HorizontalAlign="Center" />
            <RowStyle BackColor="white" />
        </asp:GridView>
        <table width="80%">
            <tr>
                <td><a href="Pointhouse.aspx?action=add">添加商品</a></td>
            </tr>
        </table>
    </div>
</asp:Content>

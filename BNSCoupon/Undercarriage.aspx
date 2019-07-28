<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Undercarriage.aspx.cs" Inherits="BNSCoupon.Undercarriage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    商品仓库
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
     <div class="chi_div"><a href="Commodity.aspx">商品列表</a>-商品仓库</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <div class="chi_div">
        <asp:GridView ID="gdCommodity" CellPadding="4" GridLines="None" runat="server" CssClass="grid_b" AutoGenerateColumns="False" Width="90%" OnRowDataBound="gdCommodity_RowDataBound" AllowPaging="True" PageSize="15" OnPageIndexChanging="gdCommodity_PageIndexChanging">
            <AlternatingRowStyle BackColor="#E7F7EF" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="100%">
                            <tr>
                                <td style="width: 10%; text-align: center;">商品编号</td>
                                <td style="width: 20%; text-align: center;">商品名</td>
                                <td style="width: 12%; text-align: center;">商品分类</td>
                                <td style="width: 10%; text-align: center;">单价</td>
                                <td style="width: 15%; text-align: center;">最大购买量</td>
                                <td style="width: 20%; text-align: center;">说明</td>
                                <td style="width: 13%; text-align: center;">操作</td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td style="width: 10%; text-align: center;"><%# Eval("id") %></td>
                                <td style="width: 20%; text-align: center;"><%# Eval("name") %></td>
                                <td style="width: 12%; text-align: center;"><%# Eval("catename") %></td>
                                <td style="width: 10%; text-align: center;"><%# Eval("price") %></td>
                                <td style="width: 15%; text-align: center;"><%# Eval("maxs") %></td>
                                <td style="width: 20%; text-align: center;"><%# Eval("mark") %></td>
                                <td style="width: 13%; text-align: center;">
                                    <asp:LinkButton ID="linkRestore" runat="server" CommandName='<%# Eval("id") %>' OnClick="linkRestore_Click" >重新上架</asp:LinkButton>
                                    <asp:LinkButton ID="linkDelete" runat="server" CommandName='<%# Eval("id") %>' OnClientClick="return confirm('确定要删除该商品吗？删除后将不可恢复');" OnClick="linkDelete_Click">删除</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div style="width: 100%; text-align: center;">所有商品均已上架！</div>
            </EmptyDataTemplate>
            <FooterStyle BackColor="#F75733" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#F75733" Font-Bold="True" ForeColor="White" />
            <PagerStyle CssClass="grid_page" HorizontalAlign="Center" />
            <RowStyle BackColor="white" />
        </asp:GridView>
    </div>
</asp:Content>

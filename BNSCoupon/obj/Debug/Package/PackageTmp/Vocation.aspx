<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Vocation.aspx.cs" Inherits="BNSCoupon.Vocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    职业管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    <div class="chi_div">职业管理</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <div class="chi_div">
        <asp:GridView ID="gvVocation" runat="server" Width="60%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="grid_b" OnRowDataBound="gvVocation_RowDataBound">
            <AlternatingRowStyle BackColor="#E7F7FF" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="100%">
                            <tr>
                                <td style="width: 15%; text-align: center;">ID</td>
                                <td style="width: 25%; text-align: center;">种族</td>
                                <td style="width: 30%; text-align: center;">职业名称</td>
                                <td style="width: 20%; text-align: center;">包含性别</td>
                                <td style="width: 10%; text-align: center;">操作</td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td style="width: 15%; text-align: center;"><%# Eval("id") %></td>
                                <td style="width: 25%; text-align: center;"><%# Eval("race") %></td>
                                <td style="width: 30%; text-align: center;"><%# Eval("vocation") %></td>
                                <td style="width: 20%; text-align: center;"><%# showGender(Eval("sex").ToString()) %></td>
                                <td style="width: 10%; text-align: center;">
                                    <a href='<%# "VocationEdit.aspx?id=" +  Eval("id") + "&action=edt"%>'>修改</a>
                                    <a href='<%# "VocationEdit.aspx?id=" +  Eval("id") + "&action=del"%>' onclick="return confirm('确定要删除吗？');">删除</a>
                                </td>
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
            <RowStyle BackColor="white" />
        </asp:GridView><br />
        <asp:Button ID="btnAdd" runat="server" Text="添加新职业" OnClick="btnAdd_Click" Width="100px" UseSubmitBehavior="false" />
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="BNSCoupon.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    账号管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    <div class="chi_div">账号列表</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <div class="chi_div">
        <div style="width: 100%;">
            <asp:GridView ID="gvAccountList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="90%" CssClass="grid_b" OnRowDataBound="gvAccountList_RowDataBound">
                <AlternatingRowStyle BackColor="#E7F7EF" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="width: 4%; text-align: center;">ID</td>
                                    <td style="width: 10%; text-align: center;">QQ号</td>
                                    <td style="width: 10%; text-align: center;">密码</td>
                                    <td style="width: 12%; text-align: center;">昵称</td>
                                    <td style="width: 5%; text-align: center;">性别</td>
                                    <td style="width: 5%; text-align: center;">种族</td>
                                    <td style="width: 7%; text-align: center;">职业</td>
                                    <td style="width: 12%; text-align: center;">注册时间</td>
                                    <td style="width: 5%; text-align: center;">等级</td>
                                    <td style="width: 5%; text-align: center;">星级</td>
                                    <td style="width: 15%; text-align: center;">说明</td>
                                    <td style="width: 10%; text-align: center;">操作</td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="width: 4%; text-align: center;"><%# Eval("id") %></td>
                                    <td style="width: 10%; text-align: center;"><%# Eval("qq") %></td>
                                    <td style="width: 10%; text-align: center;"><%# Eval("psd") %></td>
                                    <td style="width: 12%; text-align: center;"><%# Eval("name") %></td>
                                    <td style="width: 5%; text-align: center;"><%# Eval("gender") %></td>
                                    <td style="width: 5%; text-align: center;"><%# Eval("race") %></td>
                                    <td style="width: 7%; text-align: center;"><%# Eval("vocation") %></td>
                                    <td style="width: 12%; text-align: center;"><%# ((DateTime)Eval("redate")).ToString("yyyy年MM月dd日") %></td>
                                    <td style="width: 5%; text-align: center;"><%# Eval("level") %></td>
                                    <td style="width: 5%; text-align: center;"><%# Eval("stard") %></td>
                                    <td style="width: 15%; text-align: center;"><%# Eval("remark") %></td>
                                    <td style="width: 10%; text-align: center;">
                                        <asp:HyperLink ID="hlnkAmend" runat="server" NavigateUrl='<%# "~/AccountEdit.aspx?action=edt&id=" + Eval("id") %>'>修改</asp:HyperLink>
                                        <asp:LinkButton ID="lnkDelete" runat="server" Text="删除" CommandName='<%# Eval("id") %>' OnClientClick="return confirm('确定要删除吗？删除后可在回收站中找回');" OnClick="lnkDelete_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div style="width: 100%; text-align: center;">当前没有数据，请添加！</div>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#F75733" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#F75733" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="white" />
            </asp:GridView>
        </div>
        <div style="width: 100%;">
            <table width="90%">
                <tr>
                    <td align="left">
                        <asp:Button ID="btnAddaccount" runat="server" Text="添加账号" OnClick="btnAddaccount_Click" UseSubmitBehavior="false" CssClass="btn_action"/>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnRecycleBin" runat="server" Text="回收站" OnClick="btnRecycleBin_Click" UseSubmitBehavior="false" CssClass="btn_action"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Preference.aspx.cs" Inherits="BNSCoupon.Preference" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">角色统计信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    <div class="chi_div">角色统计分析</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <div class="chi_div">
        <table width="80%">
            <tr>
                <td style="width:50%;" valign="top" class="store_id">※ 职业分布信息
                </td>
                <td style="width:50%;" valign="top" class="store_id">※ 种族分布信息
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border-bottom:1px solid #F75733;"></td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Table ID="tabVocation" runat="server" Width="100%" CssClass="pre_table"></asp:Table>
                </td>
                <td valign="top">
                    <asp:Table ID="tabRace" runat="server" Width="100%" CssClass="pre_table"></asp:Table>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="labWidth" runat="server" Text="" Width="70%"></asp:Label>
                </td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>

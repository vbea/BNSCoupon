<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="VocationEdit.aspx.cs" Inherits="BNSCoupon.VocationEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    编辑职业
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    <div class="chi_div">
        <a href="Vocation.aspx">职业列表</a>-<asp:Literal ID="litTitle" runat="server" Text="添加职业"></asp:Literal>
        <br />
        <div style="width: 60%;">
            <table style="width:50%">
                <tr>
                    <td>种族:</td>
                    <td>
                        <asp:RadioButtonList ID="rblRace" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Selected="True">人族</asp:ListItem>
                            <asp:ListItem>龙族</asp:ListItem>
                            <asp:ListItem>灵族</asp:ListItem>
                            <asp:ListItem>天族</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>职业:</td>
                    <td>
                        <asp:TextBox ID="txtVocation" runat="server" Width="210px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>包含性别:</td>
                    <td>
                        <asp:CheckBoxList ID="cblGenders" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:HiddenField ID="hidAction" runat="server" />
                        <asp:Button ID="btnSave" runat="server" Text="保存" Height="30px" Width="100px" OnClick="btnSave_Click" UseSubmitBehavior="false" CssClass="btn_action"/></td>
                </tr>
            </table>
            <br />
        </div>
    </div>
</asp:Content>

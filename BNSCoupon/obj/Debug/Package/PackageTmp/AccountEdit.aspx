<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="AccountEdit.aspx.cs" Inherits="BNSCoupon.AccountEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">编辑账号
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="conTitle" runat="server">
    <div class="chi_div">
        <a href="Account.aspx">账号列表</a>-<asp:Literal ID="litTitle" runat="server" Text="添加账号"></asp:Literal>
        <div style="width:100%; padding-top:5px;">
            <table class="table_ss">
                <tr>
                    <td>QQ号:</td>
                    <td>
                        <asp:TextBox ID="txtQQ" runat="server" CssClass="input_trans"></asp:TextBox>
                    </td>
                    <td style="border-style:none; color:red;">*</td>
                </tr>
                <tr>
                    <td>密码或提示:</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="input_trans"></asp:TextBox>
                    </td>
                    <td style="border-style:none; color:red;"></td>
                </tr>
                <tr>
                    <td>昵称:</td>
                    <td>
                        <asp:TextBox ID="txtNickName" runat="server" CssClass="input_trans"></asp:TextBox>
                    </td>
                    <td style="border-style:none; color:red;">*</td>
                </tr>
                <tr>
                    <td>性别:</td>
                    <td>
                        <asp:RadioButtonList ID="rblGenders" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="rblGenders_SelectedIndexChanged"></asp:RadioButtonList>
                    </td>
                    <td style="border-style:none; color:red;">*</td>
                </tr>
                <tr>
                    <td style="height: 24px">职业:</td>
                    <td style="height: 24px">
                        <asp:DropDownList ID="ddlVocation" runat="server" Width="100%"></asp:DropDownList>
                    </td>
                    <td style="border-style:none; color:red;">*</td>
                </tr>
                <tr>
                    <td>注册时间:</td>
                    <td>
                        <asp:TextBox ID="txtRedate" runat="server" CssClass="input_trans" AutoPostBack="True" OnKeyPress="if(event.keyCode=13) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
                        <script src="js/selectdate.js" type="text/javascript"></script>
                    </td>
                    <td style="border-style:none; color:red;">*</td>
                </tr>
                <tr>
                    <td>等级:</td>
                    <td>
                        <asp:TextBox ID="txtLevel" runat="server" CssClass="input_trans" Width="40px" style="text-align:center" MaxLength="3" OnKeyPress="if((event.keyCode>=48)&&(event.keyCode <=57)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>级
                        <asp:TextBox ID="txtStard" runat="server" CssClass="input_trans" Width="40px" style="text-align:center" MaxLength="3" OnKeyPress="if((event.keyCode>=48)&&(event.keyCode <=57)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>星
                    </td>
                    <td style="border-style:none; color:red;">*</td>
                </tr>
                <tr>
                    <td>说明:</td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="input_trans"></asp:TextBox>
                    </td>
                    <td style="border-style:none;"></td>
                </tr>
            </table>
            <asp:HiddenField ID="hidAction" runat="server" />
        </div><br />
        <asp:Button ID="btnSave" runat="server" Text="保存" Height="30px" Width="100px" OnClick="btnSave_Click" UseSubmitBehavior="false"/>
    </div>
</asp:Content>

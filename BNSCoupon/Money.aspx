<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Money.aspx.cs" Inherits="BNSCoupon.Money" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单确认</title>
    <link type="text/css" rel="stylesheet" href="css/common.css" />
    <script type="text/javascript" src="js/Dialog.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 95%; padding: 0px 10px 5px 10px;">
            <table style="width:100%; color:#F55733;">
                <tr>
                    <td style="width:20%; text-align:left;">确认订单</td>
                    <td style="width:80%; text-align:right;">
                        <asp:Literal ID="litHello" runat="server"></asp:Literal></td>
                </tr>
            </table>
            <br />
            <table class="table_sh">
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">当前账号：
                    </td>
                    <td style="text-align: left; width: 50%; color: #000000;">
                        <asp:Label ID="labAccount" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">账户余额：
                    </td>
                    <td>
                        <asp:Label ID="labRemaining" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">商品名称：</td>
                    <td>购买金币</td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">比例(金币:点券)：</td>
                    <td>1:<asp:TextBox ID="txtUnit" runat="server" style="width: 40px; text-align: center; background-color: transparent; border-style: none;" AutoPostBack="True" OnTextChanged="txtCount_TextChanged"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">金币数量：</td>
                    <td>
                        <asp:ImageButton ID="btnReduce" runat="server" ImageUrl="~/images/130.png" OnClick="btnReduce_Click" />
                        <asp:TextBox ID="txtCount" runat="server" style="width: 20px; text-align: center; background-color: transparent; border-style: none;" AutoPostBack="True" OnTextChanged="txtCount_TextChanged" MaxLength="5">1</asp:TextBox>
                        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/images/129.png" OnClick="btnAdd_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">总价：</td>
                    <td><asp:TextBox ID="txtPrice" runat="server" style="width: 100px; background-color: transparent; border-style: none;" AutoPostBack="True" OnTextChanged="txtUnit_TextChanged"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">购买后余额：</td>
                    <td>
                        <asp:Label ID="labBalance" runat="server"></asp:Label></td>
                </tr>
            </table>
            <div style="width: 95%; text-align: center; padding: 10px;">
                <asp:Button ID="btnBuy" runat="server" Text="购买" CssClass="store_buy" Width="40%" OnClientClick="return confirm('确定要购买该商品？')" OnClick="btnBuy_Click" />
            </div>
        </div>
    </form>
</body>
</html>

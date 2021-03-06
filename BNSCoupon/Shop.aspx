﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="BNSCoupon.Shop" %>

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
                    <td style="text-align: right; width: 30%; color: #F55733;">购买商品：</td>
                    <td>
                        <asp:Label ID="labCommodity" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">商品编号：</td>
                    <td>
                        <asp:Label ID="labConmmoid" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">商品分类：</td>
                    <td>
                        <asp:Label ID="labCategory" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">商品介绍：</td>
                    <td>
                        <asp:Label ID="labRemark" runat="server"></asp:Label></td>
                </tr>
                <tr runat="server" id="trConst">
                    <td style="text-align: right; color: #F55733;">原价：</td>
                    <td class="auto-style2">
                        <asp:Label ID="labCostprice" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: right; color: #F55733;">单价：</td>
                    <td class="auto-style2">
                        <asp:Label ID="labUnitprice" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">最大购买数量：</td>
                    <td>
                        <asp:Label ID="labMaxs" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">购买数量：</td>
                    <td>
                        <asp:ImageButton ID="btnReduce" runat="server" ImageUrl="~/images/130.png" OnClick="btnReduce_Click" />
                        <asp:TextBox ID="txtCount" runat="server" Style="width: 25px; text-align: center; background-color: transparent; border-style: none;" AutoPostBack="True" OnTextChanged="txtCount_TextChanged" MaxLength="3">1</asp:TextBox>
                        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/images/129.png" OnClick="btnAdd_Click" />
                        &nbsp;<asp:LinkButton ID="linkMax" runat="server" OnClick="linkMax_Click">最大</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">超额购买：</td>
                    <td>
                        <asp:TextBox ID="txtActurl" runat="server" Style="width:100px; background-color: transparent; border-style: none;" AutoPostBack="True" OnTextChanged="txtActurl_TextChanged" MaxLength="4">1</asp:TextBox>
                    </td>
                </tr>
                <tr id="trMore" runat="server" visible="false">
                    <td colspan="2" style="text-align:center;">
                        <span style="color: #F55733;">提示：</span><asp:Label ID="labShoptype" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">总价：</td>
                    <td>
                        <asp:Label ID="labPrice" runat="server"></asp:Label>
                        <asp:HiddenField ID="hidHasPoint" runat="server" />
                    </td>
                </tr>
                <asp:Panel ID="palPoint" runat="server" Visible="true"><tr>
                    <td style="text-align: right; width: 30%; color: #F55733;">可获积分：</td>
                    <td>
                        <asp:Label ID="labPoint" runat="server"></asp:Label>
                        <asp:HiddenField ID="hidPoint" runat="server" />
                    </td>
                </tr></asp:Panel>
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

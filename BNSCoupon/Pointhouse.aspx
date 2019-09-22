<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Pointhouse.aspx.cs" Inherits="BNSCoupon.Pointhouse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">商品仓库-新增商品
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    <div class="chi_div">
        <a href="CommodityPoint.aspx">商品列表</a>-<asp:Literal ID="litTitle" runat="server" Text="添加商品"></asp:Literal>
        <div style="width:100%; padding-top:5px;">
            <table class="table_ss">
                <tr>
                    <td>商品名:</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="input_trans"></asp:TextBox>
                    </td>
                    <td style="border-style:none; color:red;">*</td>
                </tr>
                <tr>
                    <td>购买积分:</td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="input_trans" MaxLength="10"></asp:TextBox>
                    </td>
                    <td style="border-style:none; color:red;">*</td>
                </tr>
                <tr>
                    <td>最大购买量:</td>
                    <td>
                        <asp:TextBox ID="txtMaxs" runat="server" CssClass="input_trans" MaxLength="3" OnKeyPress="if((event.keyCode>=48)&&(event.keyCode <=57)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
                    </td>
                    <td style="border-style:none; color:red;">*</td>
                </tr>
                <tr>
                    <td>说明:</td>
                    <td>
                        <asp:TextBox ID="txtMark" runat="server" CssClass="input_trans"></asp:TextBox>
                    </td>
                    <td style="border-style:none;"></td>
                </tr>
            </table>
            <asp:HiddenField ID="hidAction" runat="server" />
        </div><br />
        <asp:Button ID="btnSave" runat="server" Text="保存" Height="30px" Width="100px" OnClick="btnSave_Click" UseSubmitBehavior="false" CssClass="btn_action"/>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Coupons.aspx.cs" Inherits="BNSCoupon.Coupons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">点券补登系统
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
    <div class="chi_div">
        <div style="float:left;">点券管理系统</div>
        <div style="text-align:right; padding-right:12%; color:#F75733;">当前点券合计：<asp:Literal ID="litCoupon" runat="server"></asp:Literal></div>
    </div>
    <style type="text/css">
        .checked{
            background-color:#88B04B !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <div class="chi_div">
        <asp:GridView ID="gvDetailList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="92%" CssClass="grid_b" OnRowDataBound="gvDetailList_RowDataBound">
            <AlternatingRowStyle BackColor="#E7F7EF" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="100%">
                            <tr>
                                <td style="width: 4%; text-align: center;">ID</td>
                                <td style="width: 10%; text-align: center;">账号</td>
                                <td style="width: 15%; text-align: center;">昵称</td>
                                <td style="width: 6%; text-align: center;">性别</td>
                                <td style="width: 8%; text-align: center;">种族</td>
                                <td style="width: 8%; text-align: center;">职业</td>
                                <td style="width: 6%; text-align: center;">等级</td>
                                <td style="width: 6%; text-align: center;">星级</td>
                                <td style="width: 12%; text-align: center;">上次登记时间</td>
                                <td style="width: 12%; text-align: center;">剩余点券</td>
                                <td style="width: 13%; text-align: center;">操作</td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td style="width: 4%; text-align: center;"><%# Eval("id") %></td>
                                <td style="width: 10%; text-align: center;"><%# Eval("qq") %></td>
                                <td style="width: 15%; text-align: center;"><%# Eval("name") %></td>
                                <td style="width: 6%; text-align: center;"><%# Eval("gender") %></td>
                                <td style="width: 8%; text-align: center;"><%# Eval("race") %></td>
                                <td style="width: 8%; text-align: center;"><%# Eval("vocation") %></td>
                                <td style="width: 6%; text-align: center;"><%# Eval("level") %></td>
                                <td style="width: 6%; text-align: center;"><%# Eval("stard") %></td>
                                <td style="width: 12%; text-align: center;"><asp:Label runat="server" ID="labCheckDate" Text='<%# ((DateTime)Eval("checkdate")).ToString("yyyy年MM月dd日") %>'></asp:Label>
                                    <asp:Label runat="server" ID="labCheckTime" Text='<%# toShortTime(Eval("checktime")) %>'></asp:Label></td>
                                <td style="width: 12%; text-align: center;">
                                    <asp:Label ID="labCoupon" runat="server" Text='<%# Eval("coupon") %>'></asp:Label>
                                    <asp:TextBox ID="txtCoupons" runat="server" Width="50%" CssClass="input_trans" Visible="False" style="text-align:center;" OnKeyPress="if((event.keyCode>=48)&&(event.keyCode <=57)) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="10"></asp:TextBox>
                                    <%--if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;} 46为小数点--%>
                                </td>
                                <td style="width: 13%; text-align: center;">
                                    <asp:LinkButton ID="linkAddStand" runat="server" Text='<%# getButtonText() %>' OnClick="linkAddStand_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="linkAmendCoupon" runat="server" Text="修改" OnClick="linkAmendCoupon_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="linkSaveCoupon" runat="server" Text="保存" CommandName='<%# Eval("id") %>' OnClick="linkSaveCoupon_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="linkCancel" runat="server" Text="取消" OnClick="linkCancel_Click"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div style="width: 100%; text-align: center;">当前没有账号相关数据，请添加！</div>
            </EmptyDataTemplate>
            <FooterStyle BackColor="#F75733" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#F75733" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="white" />
        </asp:GridView>
        <asp:HiddenField ID="hidWhereCount" runat="server" Value="0"/>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="BNSCoupon.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    设置
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conTitle" runat="server">
     <div class="chi_div">设置</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <div class="chi_div">
        <div class="div_set">
            <table width="100%">
                <tr>
                    <td style="width: 20%;" valign="top">性别设置：<br />
                        <table class="table_h" width="50%">
                            <tr class="table_th">
                                <td style="width: 20%; text-align: center;">编号</td>
                                <td style="width: 50%; text-align: center;">性别</td>
                                <td style="width: 30%; text-align: center;">操作</td>
                            </tr>
                            <asp:Panel ID="panGender" runat="server"></asp:Panel>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtGenderId" runat="server" Width="100%" OnKeyPress="if((event.keyCode>=48)&&(event.keyCode <=57)) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="5"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGender" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkAddGender" runat="server" OnClick="lnkAddGender_Click">添加</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 22%;" valign="top">商品分类信息设置：<br />
                        <table class="table_h" width="45%">
                            <tr class="table_th">
                                <td style="width: 20%; text-align: center;">ID</td>
                                <td style="width: 45%; text-align: center;">分类名称</td>
                                <td style="width: 25%; text-align: center;">操作</td>
                            </tr>
                            <asp:Panel ID="panCategory" runat="server"></asp:Panel>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="txtCatename" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkAddCategory" runat="server" OnClick="lnkAddCategory_Click" >添加</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="div_set">
            条件设置：
            <asp:GridView ID="gdWhereList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="85%" CssClass="grid_b">
                <AlternatingRowStyle BackColor="#E7F7FF" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td style="width: 5%; text-align: center;">ID</td>
                                    <td style="width: 10%; text-align: center;">最低等级</td>
                                    <td style="width: 10%; text-align: center;">最低星级</td>
                                    <td style="width: 10%; text-align: center;">周期</td>
                                    <td style="width: 10%; text-align: center;">数量</td>
                                    <td style="width: 23%; text-align: center;">说明</td>
                                    <td style="width: 12%; text-align: center;">上次发放时间</td>
                                    <td style="width: 10%; text-align: center;">状态</td>
                                    <td style="width: 10%; text-align: center;">操作</td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td style="width: 5%; text-align: center;"><%# Eval("id") %></td>
                                    <td style="width: 10%; text-align: center;"><%# Eval("minlevel") %></td>
                                    <td style="width: 10%; text-align: center;"><%# Eval("minStard") %></td>
                                    <td style="width: 10%; text-align: center;"><%# Eval("cycle") %></td>
                                    <td style="width: 10%; text-align: center;"><%# Eval("coupon") %></td>
                                    <td style="width: 23%; text-align: center;"><%# Eval("remark") %></td>
                                    <td style="width: 12%; text-align: center;"><%# showDates(Eval("dates")) %></td>
                                    <td style="width: 10%; text-align: center;"><%# showState(Eval("isvalid")) %></td>
                                    <td style="width: 10%; text-align: center;">
                                        <asp:LinkButton ID="linkDeleteWhere" runat="server" CommandName='<%# Eval("id") %>' OnClientClick="return confirm('确定要删除吗？');" OnClick="linkDeleteWhere_Click">删除</asp:LinkButton>
                                        <asp:LinkButton ID="LinkDisable" runat="server" CommandName='<%# Eval("id") %>' Visible='<%# Convert.ToBoolean(Eval("isvalid")) %>' OnClick="LinkDisable_Click">禁用</asp:LinkButton>
                                        <asp:LinkButton ID="linkEnable" runat="server" CommandName='<%# Eval("id") %>' Visible='<%# !Convert.ToBoolean(Eval("isvalid")) %>' OnClick="linkEnable_Click">启用</asp:LinkButton>
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
            <asp:Label Style="margin-top: 5px; float: left;" ID="labMoreEnable" runat="server" Text="警告：启用多个条件，将只按照查询到的第一条记录计算，所以应避免同时启用多个条件。" ForeColor="Red"></asp:Label>
            <br />
            <asp:Panel ID="panAddWhere" runat="server">
                <table style="width: auto;" class="table_s">
                    <tr>
                        <td rowspan="4">条件：</td>
                        <td>最低等级:</td>
                        <td>
                            <asp:TextBox ID="txtMinLevel" runat="server" Width="97%" CssClass="input_trans" OnKeyPress="if((event.keyCode>=48)&&(event.keyCode <=57)) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>最低星级:</td>
                        <td>
                            <asp:TextBox ID="txtMinStard" runat="server" Width="97%" CssClass="input_trans" OnKeyPress="if((event.keyCode>=48)&&(event.keyCode <=57)) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>周期:</td>
                        <td>
                            <asp:DropDownList ID="ddlCycle" runat="server" Width="98%">
                                <asp:ListItem>每天</asp:ListItem>
                                <asp:ListItem>每周</asp:ListItem>
                                <asp:ListItem>每两周</asp:ListItem>
                                <asp:ListItem>每月</asp:ListItem>
                                <asp:ListItem>每年</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>数量:</td>
                        <td>
                            <asp:TextBox ID="txtCoupon" runat="server" Width="97%" CssClass="input_trans" OnKeyPress="if((event.keyCode>=48)&&(event.keyCode <=57)) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>说明：</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtWhereRemark" runat="server" Width="98%" CssClass="input_trans"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>操作：</td>
                        <td colspan="2" align="center">
                            <asp:LinkButton ID="lnkReset" runat="server" OnClick="lnkReset_Click">重置</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="linkAddWhere" runat="server" OnClick="linkAddWhere_Click">添加</asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

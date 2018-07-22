<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="BNSCoupon.aspx.cs" Inherits="BNSCoupon.BNSCoupon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">剑灵南天国账号点券记录系统</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="conTitle" runat="server">
    <link href="css/datepicker.css" rel="stylesheet" />
    <script src="js/datepicker_lang.js"></script>
    <script src="js/jquery.datepicker.js"></script>
     <script type="text/javascript">
         $(function () {
             $("#txtProvideDate").datepicker({ picker: "#picker"});//, applyrule: function () { return { enddate: new Date() } } });
         });
    </script>
    <div class="chi_div">
        <table style="border-collapse: collapse;">
            <tr style="border-collapse: collapse;">
                <td style="color:#F75733;">视图：</td>
                <td style="background-color: #F75733; border-collapse: collapse; padding: 1px;">
                    <asp:Button ID="btnGeneral" runat="server" Text="普通" OnClick="btnGeneral_Click" CssClass="btn_press" /></td>
                <td style="background-color: #F75733; border-collapse: collapse; padding: 1px;">
                    <asp:Button ID="btnDetail" runat="server" Text="详细" OnClick="btnDetail_Click" CssClass="btn_normal" />
                </td>
                <td style="color:#F75733; padding-left:10px;">选项：</td>
                <td>
                    <asp:CheckBox ID="chkFullAccount" runat="server" AutoPostBack="True" OnCheckedChanged="chkFullAccount_CheckedChanged" Text="显示完整账号" />
                </td>
                <td>
                    <asp:CheckBox ID="chkExpanstor" runat="server" AutoPostBack="True" OnCheckedChanged="chkExpanstor_CheckedChanged" Text="直接展示商品" Checked="True" />
                </td>
                <td style="color:#F75733; padding-left:10px;">排序：</td>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblOrder" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="rblOrder_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">默认</asp:ListItem>
                        <asp:ListItem Value="1">等级</asp:ListItem>
                        <asp:ListItem Value="2">点券</asp:ListItem>
                    </asp:RadioButtonList> 
                </td>
                <td>
                    <div style="border:1px dashed #F75733; padding:5px;">
                        <asp:RadioButtonList ID="rblOrderby" runat="server" OnSelectedIndexChanged="rblOrderby_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="0">升序</asp:ListItem>
                            <asp:ListItem Value="1">降序</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="chi_div">
        <div style="width: 100%;">
            <asp:MultiView ID="multiView" runat="server">
                <asp:View ID="viewGeneral" runat="server">
                    <asp:GridView ID="gvDataList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="70%" CssClass="grid_b" OnRowDataBound="gvDataList_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table width="100%"><tr><td style="width: 5%; text-align: center;">ID</td><td style="width: 12%; text-align: center;">账号</td><td style="width: 15%; text-align: center;">昵称</td><td style="width: 9%; text-align: center;">性别</td><td style="width: 10%; text-align: center;">种族</td><td style="width: 11%; text-align: center;">职业</td><td style="width: 11%; text-align: center;">等级</td><td style="width: 12%; text-align: center;">剩余点券</td><td style="width: 10%; text-align: center;">是否检查</td><td style="width: 5%; text-align: center;">商城</td></tr></table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="100%"><tr><td style="width: 5%; text-align: center;"><%# Eval("id") %></td><td style="width: 12%; text-align: center;"><%# showAccount(Eval("qq").ToString()) %></td><td style="width: 15%; text-align: center;"><%# Eval("name") %></td><td style="width: 9%; text-align: center;"><%# Eval("gender") %></td><td style="width: 10%; text-align: center;"><%# Eval("race") %></td><td style="width: 11%; text-align: center;"><%# Eval("vocation") %></td><td style="width: 11%; text-align: center;"><asp:Label ID="labViewLevels" runat="server" Text='<%# showLevel(Eval("level"),Eval("stard")) %>'></asp:Label></td><td style="width: 12%; text-align: center;"><%# Eval("coupon") %></td><td style="width: 10%; text-align: center;" title='<%# "上次检查时间: "+Convert.ToDateTime(Eval("checkdate")).ToString("yyyy年MM月dd日") %>'><%# isCheckd(Convert.ToDateTime(Eval("checkdate"))) %></td><td style="width: 5%; text-align: center;"><asp:HyperLink ID="hlnkGoo" runat="server" NavigateUrl='<%# "~/Store.aspx?id=" + Eval("id") %>' Visible='<%# showStore(Convert.ToInt32(Eval("coupon"))) %>'>去消费</asp:HyperLink></td></tr></table>
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
                </asp:View>
                <asp:View ID="viewDetail" runat="server">
                    <asp:GridView ID="gvDetailList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="92%" CssClass="grid_b" OnRowDataBound="gvDetailList_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField><HeaderTemplate><table width="100%"><tr><td style="width: 4%; text-align: center;">ID</td><td style="width: 10%; text-align: center;">账号</td><td style="width: 9%; text-align: center;">密码</td><td style="width: 11%; text-align: center;">昵称</td><td style="width: 4%; text-align: center;">性别</td><td style="width: 5%; text-align: center;">种族</td><td style="width: 5%; text-align: center;">职业</td><td style="width: 12%; text-align: center;">注册时间</td><td style="width: 5%; text-align: center;">等级</td><td style="width: 5%; text-align: center;">星级</td><td style="width: 8%; text-align: center;">剩余点券</td><td style="width: 12%; text-align: center;">说明</td><td style="width: 5%; text-align: center;">是否检查</td><td style="width: 5%; text-align: center;">商城</td></tr></table></HeaderTemplate><ItemTemplate><table width="100%"><tr><td style="width: 4%; text-align: center;"><%# Eval("id") %></td><td style="width: 10%; text-align: center;"><%# showAccount(Eval("qq").ToString()) %></td><td style="width: 9%; text-align: center;"><%# showAccount(Eval("psd").ToString()) %></td><td style="width: 11%; text-align: center;"><%# Eval("name") %></td><td style="width: 4%; text-align: center;"><%# Eval("gender") %></td><td style="width: 5%; text-align: center;"><%# Eval("race") %></td><td style="width: 5%; text-align: center;"><%# Eval("vocation") %></td><td style="width: 12%; text-align: center;"><%# ((DateTime)Eval("redate")).ToString("yyyy年MM月dd日") %></td><td style="width: 5%; text-align: center;"><asp:Label ID="labViewLevel" runat="server" Text='<%# Eval("level") %>'></asp:Label></td><td style="width: 5%; text-align: center;"><asp:Label ID="labViewStard" runat="server" Text='<%# Eval("stard") %>'></asp:Label></td><td style="width: 8%; text-align: center;"><%# Eval("coupon") %></td><td style="width: 12%; text-align: center;"><%# Eval("remark") %></td><td style="width: 5%; text-align: center;"  title='<%# "上次补登时间: "+Convert.ToDateTime(Eval("checkdate")).ToString("yyyy年MM月dd日") %>'><%# isCheckd(Convert.ToDateTime(Eval("checkdate"))) %></td><td style="width: 5%; text-align: center;"><asp:HyperLink ID="hlnkGoo" runat="server" NavigateUrl='<%# "~/Store.aspx?id=" + Eval("id") + "&s=" + chkExpanstor.Checked %>' Visible='<%# showStore(Convert.ToInt32(Eval("coupon"))) %>'>去消费</asp:HyperLink></td></tr></table></ItemTemplate></asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="width: 100%; text-align: center;">当前没有数据，请添加！</div>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#F75733" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#F75733" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="white" />
                    </asp:GridView>
                </asp:View>
            </asp:MultiView>
            <div class="div_x">
                <table class="table_x">
                    <tr>
                        <td>总账号数量：<asp:Literal ID="litCount" runat="server"></asp:Literal></td>
                        <td>满足条件的账号数量：<asp:Literal ID="litWhereCount" runat="server"></asp:Literal></td>
                        <td>点券合计：<font color="#CC0000"><asp:Literal ID="litCoupon" runat="server"></asp:Literal></font></td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="width: 100%">
            <asp:Panel ID="panWhere" runat="server">
                <table style="width: auto;">
                    <tr>
                        <td>[条件]</td>
                        <td class="store_id">最低等级:</td>
                        <td>
                            <asp:Label ID="labLevel" runat="server" Text=""></asp:Label>
                            <asp:Panel ID="panMinLevel" runat="server">
                            <asp:TextBox ID="txtMinLevel" runat="server" Width="40px" MaxLength="3" OnKeyPress="if((event.keyCode>=48)&&(event.keyCode <=57)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>级
                            <asp:TextBox ID="txtMinStard" runat="server" Width="40px" MaxLength="3" OnKeyPress="if((event.keyCode>=48)&&(event.keyCode <=57)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>星
                            </asp:Panel>
                        </td>
                        <td class="store_id">周期:</td>
                        <td>
                            <asp:Label ID="labCycle" runat="server" Text=""></asp:Label>
                            <asp:DropDownList ID="ddlCycle" runat="server">
                                <asp:ListItem>每天</asp:ListItem>
                                <asp:ListItem>每周</asp:ListItem>
                                <asp:ListItem>每两周</asp:ListItem>
                                <asp:ListItem>每月</asp:ListItem>
                                <asp:ListItem>每年</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="store_id">数量:</td>
                        <td>
                            <asp:Label ID="labCoupon" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="txtCoupon" runat="server" Width="59px" MaxLength="10" OnKeyPress="if((event.keyCode>=48)&&(event.keyCode <=57)) {event.returnValue=true;} else{event.returnValue=false;}"></asp:TextBox>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkAmend" runat="server" OnClick="lnkAmend_Click">修改</asp:LinkButton>
                            <asp:LinkButton ID="lnkCancel" runat="server" OnClick="lnkCancel_Click">取消</asp:LinkButton>
                            <asp:LinkButton ID="lnkSave" runat="server" OnClick="lnkSave_Click">保存</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="store_id">上次发放时间：</td>
                        <td colspan="4">
                            <asp:Label ID="labProvideDate" runat="server" Text="未提供"></asp:Label>
                            <asp:TextBox ID="txtProvideDate" runat="server" Width="65%" ClientIDMode="Static"></asp:TextBox>
                            <asp:Image runat="server" align="middle" class="picker" ID="picker" ImageUrl="/images/cal.gif" ClientIDMode="Static"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="store_id">说明：</td>
                        <td colspan="4">
                            <asp:Label ID="labWhereRemark" runat="server"></asp:Label>
                            <asp:TextBox ID="txtWhereRemark" runat="server" Width="100%" MaxLength="200"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HiddenField ID="hidWhereID" runat="server" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Literal ID="litNoWhere" runat="server" Visible="False" Text="当前没有设置条件，请在设置页中添加条件！"></asp:Literal>
        </div>
    </div>
</asp:Content>

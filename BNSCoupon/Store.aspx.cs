﻿using BNSLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BNSCoupon
{
    public partial class Store : System.Web.UI.Page
    {
        public static bool isRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
                Response.Redirect("BNSCoupon.aspx");
            if (!IsPostBack)
            {
                CouponBLL bll = new CouponBLL();
                getAccount(bll, Convert.ToInt32(Request.QueryString["id"]));
                getCategory(bll);
                getSetting(bll);
                gvOrderList.DataSource = bll.getOrderList(Convert.ToInt32(Request.QueryString["id"]));
                gvOrderList.DataBind();
                if (Convert.ToBoolean(hidShowStore.Value))
                    getData(bll, txtKeywords.Text);
            }
        }

        public void getAccount(CouponBLL bll, int id)
        {
            DataSet ds = bll.getAccountList(id);
            DataRowCollection rows = ds.Tables[0].Rows;
            btnBymon.OnClientClick = "return openBuym(" + id + ");";
            if (rows.Count > 0)
            {
                labAccount.Text = rows[0]["name"].ToString();
                labRemaining.Text = "ஐ" + rows[0]["coupon"];
                labPoint.Text = "￠" + rows[0]["point"];
                labPoint.NavigateUrl = "/StorePoint.aspx?id=" + rows[0]["id"];
            }
        }
         
        private void getData(CouponBLL bll, string key)
        {
            dataBind(bll.getCommodityList(key.Trim()));
        }

        private void getData(CouponBLL bll, int id)
        {
            dataBind(bll.getCommodityListByCategory(id));
        }

        private void dataBind(DataSet ds)
        {
            tabCommodity.Controls.Clear();
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                labNodata.Visible = false;
                int widthd = 5; //一行显示的商品数量
                int rows = (count / widthd > 0) ? (count % widthd > 0) ? count / widthd + 1 : count / widthd : 1;
                for (int r = 0; r < rows; r++)  //遍历行
                {
                    TableRow row = new TableRow();  //实例化一行
                    for (int i = 0; i < widthd; i++)
                    {
                        int ddd = r * widthd + i;  //当前数量
                        //如果当前行还没遍历完但数量已经到达总数，行数又为0，则添加空列
                        if (ddd + 1 > count)
                        {
                            if (r == 0)
                            {
                                addEmpty(row, widthd - (ddd));
                                break;
                            }
                            else
                                break;
                        }
                        DataRow rowd = ds.Tables[0].Rows[ddd]; //取数据
                        TableCell cell = new TableCell();
                        cell.CssClass = "store_cell";
                        //添加一列数据
                        cell.Controls.Add(createStore(rowd["id"].ToString(), rowd["name"].ToString(), rowd["catename"].ToString(), rowd["cost"].ToString(), rowd["price"].ToString(), rowd["maxs"].ToString(), rowd["mark"].ToString()));
                        row.Controls.Add(cell);
                    }
                    tabCommodity.Controls.Add(row);
                }
            }
            else
                labNodata.Visible = true;
        }

        private void addEmpty(TableRow row, int count)
        {
            for (int i = 0; i < count; i++)
            {
                TableCell cell = new TableCell();
                cell.CssClass = "store_cell";
                row.Controls.Add(cell);
            }
        }

        private void getCategory(CouponBLL bll)
        {
            DataSet ds = bll.getCategory();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ddlCategory.Items.Add(new ListItem(row["catename"].ToString(), row["id"].ToString()));
                }
            }
        }

        private Table createStore(string id, string name, string category,string cost, string price, string maxs, string mark)
        {
            Table table = new Table();
            table.CssClass = "store_table";
            if (mark.Length > 0)
                table.ToolTip = mark;
            #region ROW0
            TableRow th = new TableRow();
            TableCell th1 = new TableCell();
            th1.CssClass = "store_hid";
            TableCell th2 = new TableCell();
            th2.CssClass = "store_hin";
            TableCell th3 = new TableCell();
            th3.CssClass = "store_hin";
            th.Controls.Add(th1);
            th.Controls.Add(th2);
            th.Controls.Add(th3);
            table.Controls.Add(th);
            TableRow row0 = new TableRow();
            TableCell _cell0 = new TableCell();
            Label labid = new Label();
            labid.ID = "labStore" + id;
            labid.CssClass = "store_id";
            labid.Text = id + "：";
            TableCell _cell1 = new TableCell();
            _cell1.ColumnSpan = 2;
            Label labName = new Label();
            labName.ID = "labName" + id;
            labName.Text = name;
            _cell0.Controls.Add(labid);
            _cell1.Controls.Add(labName);
            row0.Controls.Add(_cell0);
            row0.Controls.Add(_cell1);
            table.Controls.Add(row0); 
            #endregion
            #region ROW1
            TableRow row1 = new TableRow();
            TableCell _cell2 = new TableCell();
            _cell2.ColumnSpan = 2;
            _cell2.CssClass = "store_category";
            _cell2.Text = "商品分类：" + category;
            TableCell _cell3 = new TableCell();
            _cell3.CssClass = "store_maxs";
            _cell3.Text = maxs;
            row1.Controls.Add(_cell2);
            row1.Controls.Add(_cell3);
            table.Controls.Add(row1); 
            #endregion
            #region ROW2
            TableRow row2 = new TableRow();
            TableCell cell1 = new TableCell();
            cell1.ColumnSpan = 2;
            cell1.CssClass = "store_pricerow";
            Label labcost = new Label();
            Label labprice = new Label();
            labcost.CssClass = "store_cost";
            labprice.CssClass = "store_price";
            if (!cost.Equals("0"))
                labcost.Text = " " + cost;
            labprice.Text = " ஐ" + price;
            cell1.Controls.Add(labcost);
            cell1.Controls.Add(labprice);
            TableCell cell2 = new TableCell();
            cell2.CssClass = "store_b";
            //Button btnBuy = new Button();
            //btnBuy.ID = "btnBuy" + id;
            //btnBuy.BorderStyle = BorderStyle.NotSet;
            //btnBuy.CommandName = id;
            //btnBuy.CssClass = "store_buy";
            //btnBuy.OnClientClick = "openBuy(" + id + ")";
            //btnBuy.UseSubmitBehavior = false;
            //btnBuy.Text = "立即购买";
            //cell2.Controls.Add(btnBuy);
            cell2.Text = "<input type='button' class='store_buy' value='立即购买' onclick='openBuy(" + id + "," + Request.QueryString["id"] + ");' />";
            //cell2.Text = "<input type='button' class='store_buy' value='立即购买' onclick='openBuym(" + Request.QueryString["id"] + ");' />";
            row2.Controls.Add(cell1);
            row2.Controls.Add(cell2);
            table.Controls.Add(row2); 
            #endregion
            return table;
        }

        private void getSetting(CouponBLL bll)
        {
            DataSet ds = bll.getSettings();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["keys"].ToString().Equals("showStore"))
                {
                    hidShowStore.Value = "" + Convert.ToBoolean(row["state"]);
                    break;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ddlCategory.SelectedIndex = 0;
            getData(new CouponBLL(), txtKeywords.Text);
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CouponBLL bll = new CouponBLL();
            if (!ddlCategory.SelectedValue.Equals("0"))
            {
                getData(bll, Convert.ToInt32(ddlCategory.SelectedValue));
                txtKeywords.Text = "";
            }
            else
            {
                getData(bll, "");
            }
        }

        protected void lnkAllLog_Click(object sender, EventArgs e)
        {
            Response.Redirect("Record.aspx?id=" + Request.QueryString["id"]);
        }

        protected void likHidden_Click(object sender, EventArgs e)
        {
            CouponBLL bll = new CouponBLL();
            getAccount(bll, Convert.ToInt32(Request.QueryString["id"]));
            gvOrderList.DataSource = bll.getOrderList(Convert.ToInt32(Request.QueryString["id"]));
            gvOrderList.DataBind();
            if (!ddlCategory.SelectedValue.Equals("0"))
            {
                getData(bll, Convert.ToInt32(ddlCategory.SelectedValue));
            }
            else
            {
                getData(bll, txtKeywords.Text);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BNSLogic;

namespace BNSCoupon
{
    public partial class Record : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
                Response.Redirect("BNSCoupon.aspx");
            if (!IsPostBack)
            {
                CouponBLL bll = new CouponBLL();
                getAccount(bll, int.Parse(Request.QueryString["id"]));
                gvOrderList.DataSource = getOrderList(bll, int.Parse(Request.QueryString["id"]));
                gvOrderList.DataBind();
                litPager.Text = (gvOrderList.PageCount > 1) ? ((gvOrderList.PageIndex + 1) + "/" + gvOrderList.PageCount) : "";
                hlkStore.NavigateUrl = "Store.aspx?id=" + Request.QueryString["id"];
            }
        }

        public void getAccount(CouponBLL bll, int id)
        {
            DataSet ds = bll.getAccountList(id);
            DataRow row = ds.Tables[0].Rows[0];
            labTitle.Text = litTitle.Text = "购买记录-" + row["name"];
        }

        public DataSet getOrderList(CouponBLL bll, int id)
        {
            DataSet ds;
            switch (ddlDatadiff.SelectedValue)
            {
                case "0"://本月
                    ds = bll.getOrderThisMonth(id);
                    break;
                case "1"://上月
                    ds = bll.getOrderLastMonth(id);
                    break;
                case "2"://近三个月
                    ds = bll.getOrderThreeMonth(id);
                    break;
                case "3"://三个月前
                    ds = bll.getOrderLastThreeMonth(id);
                    break;
                case "4"://全部记录
                    ds = bll.getOrderAll(id);
                    break;
                default:
                    ds = bll.getOrderThisMonth(id);
                    break;
            }
            litRecordCount.Text = "" + ds.Tables[0].Rows.Count;
            return ds;
        }

        protected void ddlDatadiff_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvOrderList.DataSource = getOrderList(new CouponBLL(), int.Parse(Request.QueryString["id"]));
            gvOrderList.DataBind();
            litPager.Text = (gvOrderList.PageCount > 1) ? ((gvOrderList.PageIndex + 1) + "/" + gvOrderList.PageCount) : "";
        }

        protected void gvOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrderList.PageIndex = e.NewPageIndex;
            gvOrderList.DataSource = getOrderList(new CouponBLL(), int.Parse(Request.QueryString["id"]));
            gvOrderList.DataBind();
            litPager.Text = (gvOrderList.PageIndex + 1) + "/" + gvOrderList.PageCount;
        }
    }
}
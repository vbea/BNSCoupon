using BNSLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BNSCoupon
{
    public partial class Undercarriage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bindData(new CouponBLL());
        }

        private void bindData(CouponBLL bll)
        {
            gdCommodity.DataSource = bll.getReCommodityList();
            gdCommodity.DataBind();

        }

        protected void linkRestore_Click(object sender, EventArgs e)
        {
            CouponBLL bll = new CouponBLL();
            if (bll.restoreCommodity(Convert.ToInt32(((LinkButton)sender).CommandName)))
                bindData(bll);
        }

        protected void linkDelete_Click(object sender, EventArgs e)
        {
            CouponBLL bll = new CouponBLL();
            if (bll.delCommodity(Convert.ToInt32(((LinkButton)sender).CommandName)))
                bindData(bll);
        }

        protected void gdCommodity_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#96EAF6';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
            }
        }

        protected void gdCommodity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdCommodity.PageIndex = e.NewPageIndex;
            bindData(new CouponBLL());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BNSLogic;

namespace BNSCoupon
{
    public partial class Commodity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bindData(new CouponBLL());
        }

        private void bindData(CouponBLL bll)
        {
            gdCommodity.DataSource = bll.getCommodityList();
            gdCommodity.DataBind();

        }

        protected void gdCommodity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdCommodity.PageIndex = e.NewPageIndex;
            bindData(new CouponBLL());
        }

        protected void gdCommodity_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#96eaf6';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
            }
        }

        protected void linkDelete_Click(object sender, EventArgs e)
        {
            CouponBLL bll = new CouponBLL();
            if (bll.recycleCommodity(Convert.ToInt32(((LinkButton)sender).CommandName)))
                bindData(bll);
        }
    }
}
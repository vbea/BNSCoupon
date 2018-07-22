using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BNSLogic;

namespace BNSCoupon
{
    public partial class RecycleBin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bindData(new CouponBLL());
        }

        private void bindData(CouponBLL bll)
        {
            gvAccountList.DataSource = bll.getRecycleAccountList();
            gvAccountList.DataBind();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            int id = Convert.ToInt32(link.CommandName);
            CouponBLL bll = new CouponBLL();
            if (bll.deleteAccount(id))
                bindData(bll);
        }

        protected void lnkRestore_Click(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            int id = Convert.ToInt32(link.CommandName);
            CouponBLL bll = new CouponBLL();
            if (bll.enableAccount(id))
                bindData(bll);
        }

        protected void gvAccountList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#44FF9C';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
            }
        }
    }
}
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
    public partial class Vocation : System.Web.UI.Page
    {
        protected string tables = "";
        protected DataSet dssex;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            CouponBLL bll = new CouponBLL();
            dssex = bll.getGenders();
            gvVocation.DataSource = bll.getVocationList();
            gvVocation.DataBind();
        }

        protected string showGender(string gender)
        {
            string detail = "";
            if (gender.Length > 0)
            {
                detail = gender;
                foreach (DataRow row in dssex.Tables[0].Rows)
                    detail = detail.Replace(row[1].ToString(), row[2].ToString());
            }
            return detail;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("VocationEdit.aspx?action=add");
        }

        protected void gvVocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#99DDFF';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
            }
        }
    }
}
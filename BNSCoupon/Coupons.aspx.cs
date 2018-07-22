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
    public partial class Coupons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CouponBLL bll = new CouponBLL();
                getWhere(bll);
                dataBound(bll);
            }
        }

        public void dataBound(CouponBLL bll)
        {
            DataSet ds = bll.getCouponList();
            gvDetailList.DataSource = ds;
            gvDetailList.DataBind();
            int couTotal = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                couTotal += Convert.ToInt32(row["coupon"]);
            }
            litCoupon.Text = "ஐ" + couTotal;
        }

        public void getWhere(CouponBLL bll)
        {
            DataSet ds = bll.getWhere();
            if (ds.Tables[0].Rows.Count > 0)
                hidWhereCount.Value = ds.Tables[0].Rows[0]["coupon"].ToString();
            else
                hidWhereCount.Value = "0";
        }

        public string getButtonText()
        {
            if (hidWhereCount.Value.Equals("0"))
                return "";
            else
                return "+" + hidWhereCount.Value;
        }

        protected void gvDetailList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                LinkButton lnkAmend = (LinkButton)e.Row.FindControl("linkAmendCoupon");
                LinkButton lnkSave = (LinkButton)e.Row.FindControl("linkSaveCoupon");
                LinkButton lnkAdd = (LinkButton)e.Row.FindControl("linkAddStand");
                LinkButton lnkCan = (LinkButton)e.Row.FindControl("linkCancel");
                Label labCheckDate = (Label)e.Row.FindControl("labCheckDate");
                if (!string.IsNullOrEmpty(labCheckDate.Text))
                {
                    if (isCheckd(DateTime.Parse(labCheckDate.Text)))
                    {
                        e.Row.Attributes.Add("class", "checked");
                        e.Row.Attributes.Remove("style");
                    }
                    else
                    {
                        e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#8BC1F9';");
                        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
                    }
                }
                lnkAmend.CommandName = lnkSave.CommandArgument = lnkAdd.CommandName = lnkCan.CommandName = e.Row.RowIndex + "";
                lnkSave.Visible = lnkAdd.Visible = lnkCan.Visible = false;
            }
        }

        protected void linkAddStand_Click(object sender, EventArgs e)
        {
            LinkButton lnkAdd = (LinkButton)sender;
            GridViewRow row = gvDetailList.Rows[Convert.ToInt32(lnkAdd.CommandName)];
            TextBox coupon = (TextBox)row.FindControl("txtCoupons");
            coupon.Text = "" + (Convert.ToInt32(coupon.Text) + Convert.ToInt32(hidWhereCount.Value));
        }

        protected void linkAmendCoupon_Click(object sender, EventArgs e)
        {
            LinkButton lnkAmend = (LinkButton)sender;
            GridViewRow row = gvDetailList.Rows[Convert.ToInt32(lnkAmend.CommandName)];
            Label labCoupon = (Label)row.FindControl("labCoupon");
            TextBox txtCoupon = (TextBox)row.FindControl("txtCoupons");
            txtCoupon.Text = labCoupon.Text;
            txtCoupon.Visible = true;
            labCoupon.Visible = false;
            ((LinkButton)row.FindControl("linkSaveCoupon")).Visible = true;
            ((LinkButton)row.FindControl("linkAddStand")).Visible = true;
            ((LinkButton)row.FindControl("linkCancel")).Visible = true;
            lnkAmend.Visible = false;
        }

        public string toShortTime(object obj)
        {
            if (obj != null)
                return DateTime.Parse(obj.ToString()).ToString("HH:mm:ss");
            return obj.ToString();
        }

        public bool isCheckd(DateTime dt)
        {
            if (DateTime.Now.Date == dt)
                return true;
            return false;
        }

        protected void linkSaveCoupon_Click(object sender, EventArgs e)
        {
            LinkButton lnkSave = (LinkButton)sender;
            GridViewRow row = gvDetailList.Rows[Convert.ToInt32(lnkSave.CommandArgument)];
            TextBox coupon = (TextBox)row.FindControl("txtCoupons");
            Label oldcou =  (Label)row.FindControl("labCoupon");
            Label chdate = (Label)row.FindControl("labCheckDate");
            if (coupon.Text.Trim().Equals(""))
                coupon.Text = "0";
            CouponBLL bll = new CouponBLL();
            if (!oldcou.Text.Equals(coupon.Text))
            {
                DateTime now = DateTime.Now;
                if (bll.setAccount(Convert.ToInt32(lnkSave.CommandName), Convert.ToInt32(coupon.Text), now))
                {
                    /*oldcou.Text = coupon.Text;
                    chdate.Text = now.ToString("yyyy年MM月dd日 HH:mm:ss");
                }
                else
                {*/
                    dataBound(bll);
                    //return;
                }
            }
            ((LinkButton)row.FindControl("linkAmendCoupon")).Visible = oldcou.Visible = true;
            coupon.Visible = lnkSave.Visible = ((LinkButton)row.FindControl("linkAddStand")).Visible = ((LinkButton)row.FindControl("linkCancel")).Visible = false;
        }

        protected void linkCancel_Click(object sender, EventArgs e)
        {
            LinkButton lnkCancel = (LinkButton)sender;
            GridViewRow row = gvDetailList.Rows[Convert.ToInt32(lnkCancel.CommandName)];
            lnkCancel.Visible = false;
            ((TextBox)row.FindControl("txtCoupons")).Visible = false;
            ((Label)row.FindControl("labCoupon")).Visible = true;
            ((LinkButton)row.FindControl("linkAddStand")).Visible = false;
            ((LinkButton)row.FindControl("linkSaveCoupon")).Visible = false;
            ((LinkButton)row.FindControl("linkAmendCoupon")).Visible = true;
        }
    }
}
using BNSLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BNSCoupon
{
    public partial class Money : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["account"] != null)
                {
                    CouponBLL bll = new CouponBLL();
                    getAccount(bll, Convert.ToInt32(Request.QueryString["account"]));
                }
            }
        }

        private void getAccount(CouponBLL bll, int id)
        {
            DataSet ds = bll.getAccountList(id);
            DataRowCollection rows = ds.Tables[0].Rows;
            if (rows.Count > 0)
            {
                labAccount.Text = rows[0]["qq"].ToString();
                labRemaining.Text = rows[0]["coupon"].ToString();
                litHello.Text = "Hi：" + rows[0]["name"];
            }
        }

        private void setButtonState(string reman, long total)
        {
            long price = Convert.ToInt64(reman);
            if (price >= total)
            {
                btnBuy.CssClass = "store_buy";
                btnBuy.OnClientClick = "return confirm('确定要购买该商品？')";
            }
            else
            {
                btnBuy.CssClass = "btn_disable";
                btnBuy.OnClientClick = "alert('余额不足，无法购买！'); return false;";
            }
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            CouponBLL bll = new CouponBLL();
            if (bll.deductCoupon(Convert.ToInt32(Request.QueryString["account"]), Convert.ToInt64(labBalance.Text)))
            {
                bll.addOrderLog(Convert.ToInt32(Request.QueryString["account"]), 4093, "购买金币(比例 1:" + txtUnit.Text + ")", (int)Convert.ToSingle(txtUnit.Text), Convert.ToInt32(txtCount.Text), Convert.ToInt32(txtPrice.Text), DateTime.Now);
                ClientScript.RegisterStartupScript(GetType(), "back", "top.closeMoy('dialogBuym');", true);
                //ClientScript.RegisterStartupScript(GetType(), "back", "Dialog.getInstance('money_" + Request.QueryString["account"] + "');", true);
                //Response.Redirect("Store.aspx?id=" + Request.QueryString["account"] + "&s=true");
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "err", "<script>alert('购买失败！');</script>");
        }

        protected void btnReduce_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToInt32(txtCount.Text) > 1)
            {
                txtCount.Text = (Convert.ToInt32(txtCount.Text) - 1).ToString();
                long s = Convert.ToInt64(labRemaining.Text);
                long t = (long)(Convert.ToSingle(txtUnit.Text) * Convert.ToSingle(txtCount.Text));
                txtPrice.Text = t.ToString();
                labBalance.Text = (s - t).ToString();
                setButtonState(labRemaining.Text, t);
            }
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (txtUnit.Text == "")
                txtUnit.Text = "0";
            txtCount.Text = (Convert.ToInt32(txtCount.Text) + 1).ToString();
            long s = Convert.ToInt64(labRemaining.Text);
            long t = (long)(Convert.ToSingle(txtUnit.Text) * Convert.ToSingle(txtCount.Text));
            txtPrice.Text = t.ToString();
            labBalance.Text = (s - t).ToString();
            setButtonState(labRemaining.Text, t);
        }

        protected void txtCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtCount.Text) == 0)
                    throw new FormatException();
            }
            catch (FormatException)
            {
                ClientScript.RegisterStartupScript(GetType(), "err", "<script>alert('请输入正确的值！');</script>");
                txtCount.Text = "1";
            }
            finally
            {
                try
                {
                    long s = Convert.ToInt64(labRemaining.Text);
                    long t = (long)(Convert.ToDouble(txtUnit.Text) * Convert.ToInt32(txtCount.Text));
                    txtPrice.Text = t.ToString();
                    labBalance.Text = (s - t).ToString();
                    setButtonState(labRemaining.Text, t);
                }
                catch
                {
                    txtUnit.Text = txtPrice.Text = "0";
                }
            }
        }

        protected void txtUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtCount.Text) == 0)
                    throw new FormatException();
            }
            catch (FormatException)
            {
                ClientScript.RegisterStartupScript(GetType(), "err", "<script>alert('请输入正确的值！');</script>");
                txtCount.Text = "1";
            }
            finally
            {
                try
                {
                    long s = Convert.ToInt64(labRemaining.Text);
                    double c = Convert.ToDouble(txtPrice.Text);
                    double t = c / Convert.ToDouble(txtCount.Text);
                    txtUnit.Text = t.ToString();
                    labBalance.Text = (s - c).ToString();
                    setButtonState(labRemaining.Text, (int)c);
                }
                catch
                {
                    txtUnit.Text = txtPrice.Text = "0";
                }
            }
        }
    }
}
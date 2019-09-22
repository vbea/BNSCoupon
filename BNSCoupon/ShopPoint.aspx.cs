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
    //Add on 20190922 by vbe
    public partial class ShopPoint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["commodity"] != null && Request.QueryString["account"] != null)
                {
                    CouponBLL bll = new CouponBLL();
                    getAccount(bll, Convert.ToInt32(Request.QueryString["account"]));
                    getCommodity(bll, Convert.ToInt32(Request.QueryString["commodity"]));
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
                labRemaining.Text = rows[0]["point"].ToString();
                litHello.Text = "Hi：" + rows[0]["name"];
            }
        }

        private void getCommodity(CouponBLL bll, int id)
        {
            DataSet ds = bll.getPointData(id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int max = Convert.ToInt32(row["maxs"]);
                int point  = Convert.ToInt32(row["point"]);
                labConmmoid.Text = row["id"].ToString();
                labCommodity.Text = row["name"].ToString();
                labRemark.Text = row["mark"].ToString();
                labPoint.Text = point.ToString();
                btnAdd.Enabled = btnReduce.Enabled = !(max == 0 || max == 1);
                labMaxs.Text = max.ToString();
                labPrice.Text = point.ToString();
                labBalance.Text = ""+(Convert.ToInt64(labRemaining.Text) - point);
                setButtonState(labRemaining.Text, labPrice.Text);
            }
        }

        private void setButtonState(string reman,string total)
        {
            long price = Convert.ToInt64(reman);
            long tottl = Convert.ToInt64(total);
            if (price >= tottl)
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
            if (bll.deductPoint(Convert.ToInt32(Request.QueryString["account"]), Convert.ToInt64(labBalance.Text)))
            {
                bll.addPointLog(Convert.ToInt32(Request.QueryString["account"]), Convert.ToInt32(labConmmoid.Text), labCommodity.Text, Convert.ToInt32(labPoint.Text), Convert.ToInt32(txtCount.Text), Convert.ToInt32(labPrice.Text), DateTime.Now);
                ClientScript.RegisterStartupScript(GetType(), "back", "top.closeMoy('dialogBuy');", true);
                //ClientScript.RegisterStartupScript(GetType(), "back", "<script>parent.document.getElementById(\"divClose\").click();</script>");
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
                long t = Convert.ToInt64(labPoint) * Convert.ToInt32(txtCount.Text);
                labPrice.Text = t.ToString();
                labBalance.Text = (s - t).ToString();
                setButtonState(labRemaining.Text, labPrice.Text);
            }
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToInt32(txtCount.Text) < Convert.ToInt32(labMaxs.Text))
            {
                txtCount.Text = (Convert.ToInt32(txtCount.Text) + 1).ToString();
                long s = Convert.ToInt64(labRemaining.Text);
                long t = Convert.ToInt64(labPoint.Text) * Convert.ToInt32(txtCount.Text);
                labPrice.Text = t.ToString();
                labBalance.Text = (s - t).ToString();
                setButtonState(labRemaining.Text, labPrice.Text);
            }
        }

        protected void txtCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtCount.Text) == 0)
                    throw new FormatException();
                if (Convert.ToInt32(labMaxs.Text) < Convert.ToInt32(txtCount.Text))
                {
                    ClientScript.RegisterStartupScript(GetType(), "err", "<script>alert('超过了可购买的最大物品数量！');</script>");
                    txtCount.Text = labMaxs.Text;
                }
            }
            catch (FormatException)
            {
                ClientScript.RegisterStartupScript(GetType(), "err", "<script>alert('请输入正确的数量！');</script>");
                txtCount.Text = "1";
            }
            finally
            {
                long s = Convert.ToInt64(labRemaining.Text);
                long t = Convert.ToInt64(labPoint.Text) * Convert.ToInt32(txtCount.Text);
                labPrice.Text = t.ToString();
                labBalance.Text = (s - t).ToString();
                setButtonState(labRemaining.Text, labPrice.Text);
            }
        }

        protected void linkMax_Click(object sender, EventArgs e)
        {
            txtCount.Text = labMaxs.Text;
            txtCount_TextChanged(sender, e);
        }
    }
}
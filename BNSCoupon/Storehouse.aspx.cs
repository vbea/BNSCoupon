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
    public partial class Storehouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CouponBLL bll = new CouponBLL();
                getCategory(bll);
                switch (Request.QueryString["action"])
                {
                    case "add":
                    {
                        hidAction.Value = "add";
                        break;
                    }
                    case "edt":
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            litTitle.Text = "修改商品信息";
                            hidAction.Value = "edt";
                            getCommodity(bll);
                        }
                        break;
                    }
                }
            }
        }

        private void getCommodity(CouponBLL bll)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataSet ds = bll.getCommodityList(id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txtName.Text = row["name"].ToString();
                ddlCategory.SelectedValue = row["category"].ToString();
                txtCost.Text = row["cost"].ToString();
                txtPrice.Text = row["price"].ToString();
                txtMaxs.Text = row["maxs"].ToString();
                txtMark.Text = row["mark"].ToString();
            }
        }

        private void getCategory(CouponBLL bll)
        {
            DataSet ds = bll.getCategory();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCategory.Items.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ddlCategory.Items.Add(new ListItem(row["catename"].ToString(), row["id"].ToString()));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length > 0 && txtPrice.Text.Trim().Length > 0 && txtMaxs.Text.Trim().Length > 0 && ddlCategory.SelectedIndex > -1)
            {
                try
                {
                    if (txtCost.Text.Trim().Length == 0)
                        txtCost.Text = "0";
                    CouponBLL bll = new CouponBLL();
                    if (hidAction.Value.Equals("add"))
                    {
                        if (bll.addCommodity(txtName.Text, int.Parse(ddlCategory.SelectedValue), Convert.ToInt32(txtCost.Text), Convert.ToInt32(txtPrice.Text.Trim()), Convert.ToInt32(txtMaxs.Text.Trim()), txtMark.Text))
                            Response.Redirect("Commodity.aspx");
                        else
                            throw new Exception();
                    }
                    else if (hidAction.Value.Equals("edt"))
                    {
                        if (bll.setCommodity(Convert.ToInt32(Request.QueryString["id"]), txtName.Text, int.Parse(ddlCategory.SelectedValue), Convert.ToInt32(txtCost.Text), Convert.ToInt32(txtPrice.Text.Trim()), Convert.ToInt32(txtMaxs.Text.Trim()), txtMark.Text))
                            Response.Redirect("Commodity.aspx");
                        else
                            throw new Exception();
                    }
                }
                catch (FormatException)
                {
                    ClientScript.RegisterStartupScript(GetType(), "trim", "<script>alert('输入数据类型不正确！')</script>");
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "trim", "<script>alert('操作失败！')</script>");
                }
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "trim", "<script>alert('请输入对应数据！(带*为必填项)')</script>");
        }
    }
}
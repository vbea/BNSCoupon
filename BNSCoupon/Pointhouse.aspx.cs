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
    public partial class Pointhouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CouponBLL bll = new CouponBLL();
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
            DataSet ds = bll.getPointData(id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txtName.Text = row["name"].ToString();
                txtPrice.Text = row["point"].ToString();
                txtMaxs.Text = row["maxs"].ToString();
                txtMark.Text = row["mark"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length > 0 && txtPrice.Text.Trim().Length > 0 && txtMaxs.Text.Trim().Length > 0)
            {
                try
                {
                    CouponBLL bll = new CouponBLL();
                    if (hidAction.Value.Equals("add"))
                    {
                        if (bll.addPointData(txtName.Text, Convert.ToInt32(txtPrice.Text.Trim()), Convert.ToInt32(txtMaxs.Text.Trim()), txtMark.Text))
                            Response.Redirect("CommodityPoint.aspx");
                        else
                            throw new Exception();
                    }
                    else if (hidAction.Value.Equals("edt"))
                    {
                        if (bll.updatePointData(Convert.ToInt32(Request.QueryString["id"]), txtName.Text, Convert.ToInt32(txtPrice.Text.Trim()), Convert.ToInt32(txtMaxs.Text.Trim()), txtMark.Text))
                            Response.Redirect("CommodityPoint.aspx");
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
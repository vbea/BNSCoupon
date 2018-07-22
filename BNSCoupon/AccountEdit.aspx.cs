using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using BNSLogic;

namespace BNSCoupon
{
    public partial class AccountEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtRedate.Attributes.Add("onclick", "setDay(this);");
                if (Request.QueryString["action"] != null)
                {
                    string s = Request.QueryString["action"];
                    CouponBLL bll = new CouponBLL();
                    if (Request.QueryString["id"] != null)
                    {
                        setGenders(bll);
                        switch (s)
                        {
                            case "add":
                                hidAction.Value = "add";
                                litTitle.Text = "添加账号";
                                setVocation(bll, rblGenders.SelectedValue);
                                break;
                            case "edt":
                                hidAction.Value = "edt";
                                getAccount(bll, Convert.ToInt32(Request.QueryString["id"]));
                                litTitle.Text = "修改账号信息";
                                txtQQ.Enabled = false;
                                txtQQ.BackColor = Color.White;
                                break;
                        }
                    }
                    else
                    {
                        if (s.Equals("add"))
                        {
                            setGenders(bll);
                            setVocation(bll, rblGenders.SelectedValue);
                            hidAction.Value = "add";
                        }
                    }
                }
            }
        }

        public void setGenders(CouponBLL bll)
        {
            DataSet ds = bll.getGenders();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                rblGenders.Items.Add(new ListItem(row[2].ToString(), row[1].ToString()));
            }
            rblGenders.SelectedIndex = 0;
        }

        private void setVocation(CouponBLL bll, string sex)
        {
            DataSet ds = bll.getVocationList(sex);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ddlVocation.Items.Add(new ListItem(row["race"].ToString() + " - " + row["vocation"], row["id"].ToString()));
            }
        }

        private void getAccount(CouponBLL bll,int id)
        {
            DataSet ds = bll.getAccountList(id);
            DataRow row = ds.Tables[0].Rows[0];
            txtQQ.Text = row["qq"].ToString();
            txtPassword.Text = row["psd"].ToString();
            txtNickName.Text = row["name"].ToString();
            rblGenders.SelectedValue = row["sex"].ToString();
            setVocation(bll, rblGenders.SelectedValue);
            ddlVocation.SelectedValue = row["vocation"].ToString();
            txtRedate.Text = Convert.ToDateTime(row["redate"]).ToString("yyyy-MM-dd");
            txtLevel.Text = row["level"].ToString();
            txtStard.Text = row["stard"].ToString();
            txtRemark.Text = row["remark"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtQQ.Text.Trim().Length > 0 && txtNickName.Text.Trim().Length > 0 && txtRedate.Text.Trim().Length > 0 && txtLevel.Text.Trim().Length > 0 && rblGenders.SelectedIndex > -1 && ddlVocation.SelectedIndex > -1)
            {
                if (txtStard.Text.Trim().Length <= 0)
                    txtStard.Text = "0";
                CouponBLL bll = new CouponBLL();
                if (hidAction.Value.Equals("edt"))
                {
                    bll.setAccount(Convert.ToInt32(Request.QueryString["id"]), txtPassword.Text, txtNickName.Text, Convert.ToInt32(rblGenders.SelectedValue), Convert.ToInt32(ddlVocation.SelectedValue), Convert.ToDateTime(txtRedate.Text), Convert.ToInt32(txtLevel.Text), Convert.ToInt32(txtStard.Text), txtRemark.Text);
                }
                else if (hidAction.Value.Equals("add"))
                {
                    bll.addAccount(txtQQ.Text, txtPassword.Text, txtNickName.Text, Convert.ToInt32(rblGenders.SelectedValue), Convert.ToInt32(ddlVocation.SelectedValue), Convert.ToDateTime(txtRedate.Text), Convert.ToInt32(txtLevel.Text), Convert.ToInt32(txtStard.Text), txtRemark.Text);
                }
                Response.Redirect("Account.aspx");
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "trim", "<script>alert('请输入对应数据！(带*为必填项)')</script>");
        }

        protected void rblGenders_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlVocation.Items.Clear();
            setVocation(new CouponBLL(), rblGenders.SelectedValue);
        }

    }
}
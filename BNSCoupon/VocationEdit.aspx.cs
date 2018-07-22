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
    public partial class VocationEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["action"] != null)
                {
                    string s = Request.QueryString["action"];
                    CouponBLL bll = new CouponBLL();
                    if (Request.QueryString["id"] != null)
                    {
                        switch (s)
                        {
                            case "add":
                                hidAction.Value = "add";
                                setGenders(bll);
                                break;
                            case "edt":
                                editVocation(bll, Request.QueryString["id"]);
                                break;
                            case "del":
                                deleteVocation(bll, Request.QueryString["id"]);
                                break;
                        }
                    }
                    else
                    {
                        if (s.Equals("add"))
                        {
                            hidAction.Value = "add";
                            setGenders(bll);
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
                cblGenders.Items.Add(new ListItem(row[2].ToString(), row[1].ToString()));
            }
        }

        public void setGenders(string value)
        {
            string[] values = value.Split(',');
            foreach (ListItem item in cblGenders.Items)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (item.Value.Equals(values[i]))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }

        public string getGenders()
        {
            string it = "";
            foreach (ListItem item in cblGenders.Items)
            {
                if (item.Selected)
                    it += item.Value + ",";
            }
            return it.Trim(',');
        }

        public void editVocation(CouponBLL bll, string id)
        {
            litTitle.Text = "编辑职业信息";
            hidAction.Value = "edt";
            setGenders(bll);
            DataRow row = bll.getVocationList(Convert.ToInt32(id)).Tables[0].Rows[0];
            rblRace.SelectedValue = row["race"].ToString();
            txtVocation.Text = row["vocation"].ToString();
            setGenders(row["sex"].ToString());
        }

        public void deleteVocation(CouponBLL bll,string id)
        {
            litTitle.Text = "删除职业";
            bll.deleteVocation(Convert.ToInt32(id));
            Response.Redirect("Vocation.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string s = getGenders();
            CouponBLL bll = new CouponBLL();
            if (!txtVocation.Text.Trim().Equals("") && s.Length > 0)
            {
                if (hidAction.Value.Equals("edt"))
                {
                    bll.setVocation(Convert.ToInt32(Request.QueryString["id"]), rblRace.SelectedValue, txtVocation.Text, s);
                }
                else if (hidAction.Value.Equals("add"))
                {
                    bll.addVocation(rblRace.SelectedValue, txtVocation.Text, s);
                }
                Response.Redirect("Vocation.aspx");
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "trim", "<script>alert('请输入对应数据！')</script>");
        }
    }
}
using BNSLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BNSCoupon
{
    public partial class Settings : System.Web.UI.Page
    {
        public string genders = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CouponBLL bll = new CouponBLL();
            showGenders(bll);
            showCategory(bll);
            showWhereList(bll);
        }

        private void showGenders(CouponBLL bll)
        {
            panGender.Controls.Clear();
            DataSet ds = bll.getGenders();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    TableRow _row = new TableRow();
                    TableCell _cell0 = new TableCell();
                    _cell0.Text = row[1].ToString();
                    TableCell _cell1 = new TableCell();
                    _cell1.Text = row[2].ToString();
                    TableCell _cell2 = new TableCell();
                    //StringBuilder stringBuilder = new System.Text.StringBuilder();
                    //StringWriter stringWriter = new System.IO.StringWriter(stringBuilder);
                    //HtmlTextWriter htmlTextWriter = new System.Web.UI.HtmlTextWriter(stringWriter);
                    //Panel pan = new Panel();
                    LinkButton link = new LinkButton();
                    link.Text = "删除";
                    link.ID = "lnkDel" + row[0];
                    link.CommandName = row[0].ToString();
                    //link.ForeColor = Color.Blue;
                    link.Click += btnDelete_Click;
                    link.OnClientClick = "return confirm('确定要删除吗？');";
                    //pan.Controls.Add(link);
                    //pan.RenderControl(htmlTextWriter);

                    //genders += "<tr><td>" + row[0] + "</td>\n"
                    //    + "<td>" + row[1] + "</td>\n"
                    //    + "<td>"+ stringBuilder.ToString() +"</td>\n</tr>\n";
                    _cell2.Controls.Add(link);
                    _row.Cells.Add(_cell0);
                    _row.Cells.Add(_cell1);
                    _row.Cells.Add(_cell2);
                    panGender.Controls.Add(_row);
                }
            }
        }

        private void showCategory(CouponBLL bll)
        {
            panCategory.Controls.Clear();
            DataSet ds = bll.getCategory();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    TableRow _row = new TableRow();
                    _row.ID = "rowCate" + row[0];
                    TableCell _cell0 = new TableCell();
                    _cell0.Text = row[0].ToString();
                    TableCell _cell1 = new TableCell();
                    TextBox text = new TextBox();
                    text.ID = "txtCategoryName" + row[0];
                    text.CssClass = "pan_input";
                    text.Visible = false;
                    Label labText = new Label();
                    labText.ID = "labCategoryName" + row[0];
                    labText.Text = row[1].ToString();
                    _cell1.Controls.Add(text);
                    _cell1.Controls.Add(labText);
                    TableCell _cell2 = new TableCell();
                    LinkButton link = new LinkButton();
                    LinkButton link1 = new LinkButton();
                    LinkButton link2 = new LinkButton();
                    link.Text = "修改 ";
                    link1.Text = "保存 ";
                    link2.Text = " 删除";
                    link.ID = "lnkUpdate" + row[0];
                    link1.ID = "lnkSave" + row[0];
                    link2.ID = "lnkDelt" + row[0];
                    link.CommandName = row[0].ToString();
                    link1.CommandName = row[0].ToString();
                    link2.CommandName = row[0].ToString();
                    link.Click += btnUpdate_Click;
                    link1.Click += btnCatesave_Click;
                    link2.Click += btnDelCate_Click;
                    link2.OnClientClick = "return confirm('确定要删除吗？');";
                    link1.Visible = false;
                    _cell2.Controls.Add(link);
                    _cell2.Controls.Add(link1);
                    _cell2.Controls.Add(link2);
                    _row.Cells.Add(_cell0);
                    _row.Cells.Add(_cell1);
                    _row.Cells.Add(_cell2);
                    panCategory.Controls.Add(_row);
                }
            }
        }

        private void showWhereList(CouponBLL bll)
        {
            DataSet ds = bll.getWhereList();
            if (ds != null)
            {
                gdWhereList.DataSource = ds;
                gdWhereList.DataBind();
            }
            panAddWhere.Visible = true;
            int en = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(row["isvalid"]) == 1)
                {
                    panAddWhere.Visible = false;
                    en++;
                }
            }
            labMoreEnable.Visible = (en > 1);
        }

        protected string showState(object s)
        {
            if (Convert.ToBoolean(s))
                return "<font color='green'>已启用</font>";
            else
                return "<font color='red'>已禁用</font>"; 
        }

        protected string showDates(object s)
        {
            if (s != DBNull.Value)
            {
                if (!string.IsNullOrEmpty(s.ToString()))
                    return ((DateTime)s).ToShortDateString();
            }
            return s + "";
        }

        private void resetWhere()
        {
            txtCoupon.Text = txtMinLevel.Text = txtMinStard.Text = txtWhereRemark.Text = string.Empty;
            ddlCycle.SelectedIndex = 0;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            int id = Convert.ToInt32(link.CommandName);
            CouponBLL bll = new CouponBLL();
            if (bll.deleteGender(id))
                showGenders(bll);
        }

        protected void lnkAddGender_Click(object sender, EventArgs e)
        {
            if (txtGenderId.Text.Trim().Length > 0 && txtGender.Text.Trim().Length > 0)
            {
                CouponBLL bll = new CouponBLL();
                int pid = Convert.ToInt32(txtGenderId.Text);
                if (bll.addGender(pid, txtGender.Text))
                    showGenders(bll);
                txtGender.Text = txtGenderId.Text = string.Empty;
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "varn", "<script>alert('请将数据填写完整！');</script>");
        }

        protected void linkAddWhere_Click(object sender, EventArgs e)
        {
            if (txtMinLevel.Text.Trim().Length > 0 && txtCoupon.Text.Trim().Length > 0)
            {
                if (txtMinStard.Text.Trim().Length <= 0)
                    txtMinStard.Text = "0";
                CouponBLL bll = new CouponBLL();
                if (bll.addWhere(txtMinLevel.Text.Trim(), txtMinStard.Text.Trim(), txtCoupon.Text.Trim(), ddlCycle.SelectedValue, txtWhereRemark.Text))
                    showWhereList(bll);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "varn", "<script>alert('请将数据填写完整！');</script>");
            }
        }

        protected void LinkDisable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((LinkButton)sender).CommandName);
            CouponBLL bll = new CouponBLL();
            if (bll.setWhere(id, 0))
                showWhereList(bll);
        }

        protected void linkEnable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((LinkButton)sender).CommandName);
            CouponBLL bll = new CouponBLL();
            if (bll.setWhere(id, 1))
                showWhereList(bll);
        }

        protected void lnkReset_Click(object sender, EventArgs e)
        {
            resetWhere();
        }

        protected void linkDeleteWhere_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((LinkButton)sender).CommandName);
            CouponBLL bll = new CouponBLL();
            if (bll.deleteWhere(id))
                showWhereList(bll);
        }

        protected void lnkAddCategory_Click(object sender, EventArgs e)
        {
            if (txtCatename.Text.Trim().Length > 0)
            {
                CouponBLL bll = new CouponBLL();
                if (bll.addCategory(txtCatename.Text.Trim()))
                    showCategory(bll);
                txtCatename.Text = string.Empty;
            }
            else
                ClientScript.RegisterStartupScript(GetType(), "varn", "<script>alert('请将数据填写完整！');</script>");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            LinkButton linkUpdate = (LinkButton)sender;
            TableRow row = (TableRow)panCategory.FindControl("rowCate" + linkUpdate.CommandName);
            LinkButton linkSave = (LinkButton)row.FindControl("lnkSave" + linkUpdate.CommandName);
            TextBox text = (TextBox)row.FindControl("txtCategoryName" + linkUpdate.CommandName);
            Label labText = (Label)row.FindControl("labCategoryName" + linkUpdate.CommandName);
            text.Text = labText.Text;
            text.Visible = linkSave.Visible = true;
            labText.Visible = linkUpdate.Visible = false;
        }

        protected void btnCatesave_Click(object sender, EventArgs e)
        {
            LinkButton linkSave = (LinkButton)sender;
            TableRow row = (TableRow)panCategory.FindControl("rowCate" + linkSave.CommandName);
            LinkButton linkUpdate = (LinkButton)row.FindControl("lnkUpdate" + linkSave.CommandName);
            TextBox text = (TextBox)row.FindControl("txtCategoryName" + linkSave.CommandName);
            Label labText = (Label)row.FindControl("labCategoryName" + linkSave.CommandName);
            if (labText.Text != text.Text)
            {
                CouponBLL bll = new CouponBLL();
                if (bll.updateCategory(int.Parse(linkSave.CommandName), text.Text.Trim()))
                {
                    labText.Text = text.Text;
                }
            }
            text.Visible = linkSave.Visible = false;
            labText.Visible = linkUpdate.Visible = true;
        }

        private void btnDelCate_Click(object sender, EventArgs e)
        {
            LinkButton linkDel = (LinkButton)sender;
            CouponBLL bll = new CouponBLL();
            if (bll.delCategory(int.Parse(linkDel.CommandName)))
                showCategory(bll);
        }
    }
}
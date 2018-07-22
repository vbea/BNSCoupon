using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BNSLogic;
using System.Globalization;

namespace BNSCoupon
{
    public partial class BNSCoupon : System.Web.UI.Page
    {
        public int w_count = 0;
        private const string status1 = "<font color='red'>No</font>";
        private const string status2 = "<font color='green'>Yes</font>";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CouponBLL bll = new CouponBLL();
                init(bll);
                showWhere(bll);
                dataBound(bll, false);
            }
        }

        private void init(CouponBLL bll)
        {
            DataSet ds = bll.getSettings();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                switch (row["keys"].ToString())
                {
                    case "showAccount":
                        chkFullAccount.Checked = Convert.ToBoolean(row["state"]);
                        break;
                    case "showStore":
                        chkExpanstor.Checked = Convert.ToBoolean(row["state"]);
                        break;
                    case "orderby":
                        rblOrder.SelectedValue = row["value"].ToString();
                        rblOrderby.SelectedValue = Convert.ToInt32(row["state"]).ToString();
                        break;
                }
            }
        }

        private void dataBound(CouponBLL bll, bool check)
        {
            w_count = 0;
            DataSet ds = getOrderList(bll);
            gvDataList.DataSource = ds;
            gvDataList.DataBind();
            gvDetailList.DataSource = ds;
            gvDetailList.DataBind();
            if (!check)
                changeView(0);
            litCount.Text = ds.Tables[0].Rows.Count.ToString();
            litWhereCount.Text = w_count.ToString();
            int couTotal = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                couTotal += Convert.ToInt32(row["coupon"]);
            }
            litCoupon.Text = "ஐ" + couTotal;
        }

        #region 逻辑方法
        //显示等级
        protected string showLevel(object level, object stard)
        {
            if (stard.ToString().Equals("0"))
                return level + "级";
            else
                return level + "级" + stard + "星";
        }
        //取出等级数字
        public int[] getLevel(string level)
        {
            int[] leveld = new int[2];
            if (level.IndexOf("级") > 0)
            {
                string[] levels = level.Split('级');
                leveld[0] = int.Parse(levels[0]);
                if (level.IndexOf("星") > 0)
                {
                    string[] stard = levels[1].Split('星');
                    leveld[1] = int.Parse(stard[0]);
                }
                else
                    leveld[1] = 0;
            }
            return leveld;
        }
 
        //显示条件信息页
        private void showWhere(CouponBLL _bll)
        {
            DataSet ds = _bll.getWhere();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow wheres = ds.Tables[0].Rows[0];
                txtCoupon.Visible = panMinLevel.Visible = ddlCycle.Visible = lnkSave.Visible = lnkCancel.Visible = txtWhereRemark.Visible = txtProvideDate.Visible = picker.Visible = false;
                labLevel.Visible = labCycle.Visible = labCoupon.Visible = lnkAmend.Visible = labWhereRemark.Visible = labProvideDate.Visible = true;
                txtMinLevel.Text = wheres["minlevel"].ToString();
                txtMinStard.Text = wheres["minStard"].ToString();
                labLevel.Text = showLevel(wheres["minlevel"], wheres["minStard"]);
                labCycle.Text = wheres["cycle"].ToString();
                labCoupon.Text = wheres["coupon"].ToString();
                if (wheres["dates"] != DBNull.Value)
                {
                    DateTime ffrq = Convert.ToDateTime(wheres["dates"]);
                    labProvideDate.Text = ffrq.ToString("yyyy年MM月dd日");
                    txtProvideDate.Text = ffrq.ToString("yyyy-MM-dd");
                }
                else
                    labProvideDate.Text = "从未发放";
                labWhereRemark.Text = wheres["remark"].ToString();
                hidWhereID.Value = wheres["id"].ToString();
            }
            else
            {
                panWhere.Visible = false;
                litNoWhere.Visible = true;
            }
        }
        //显示条件信息编辑页
        private void showWhereEdit()
        {
            txtCoupon.Visible = panMinLevel.Visible = ddlCycle.Visible = lnkSave.Visible = lnkCancel.Visible = txtWhereRemark.Visible = txtProvideDate.Visible = picker.Visible = true;
            labLevel.Visible = labCycle.Visible = labCoupon.Visible = lnkAmend.Visible = labWhereRemark.Visible = labProvideDate.Visible = false;
            ddlCycle.SelectedValue = labCycle.Text;
            txtCoupon.Text = labCoupon.Text;
            txtWhereRemark.Text = labWhereRemark.Text;
        }
        //是否达到条件
        private bool isPass(string level)
        {
            if (panWhere.Visible)
            {
                int[] a = getLevel(labLevel.Text);
                int[] b = getLevel(level);
                if (b[0] > a[0])
                    return true;
                else if (b[0] == a[0])
                {
                    if (b[1] >= a[1])
                        return true;
                }
            }
            return false;
        } 
        //是否检查
        public string isCheckd(DateTime dt)
        {
            DateTime now = DateTime.Now;
            string status = "";
            status = status1;
            switch (labCycle.Text)
            {
                case "每天":
                {
                    if (now.Year == dt.Year && now.DayOfYear == dt.DayOfYear)
                        status = status2;
                    break;
                }
                case "每周":
                {
                    if (now.Year == dt.Year && getWeek(now) == getWeek(dt))
                        status = status2;
                    break;
                }
                case "每两周":
                {
                    if (now.Year == dt.Year && getWeek(now) - getWeek(dt) < 1)
                        status = status2;
                    break;
                }
                case "每月":
                {
                    if (now.Year == dt.Year && now.Month == dt.Month)
                        status = status2;
                    break;
                }
                case "每年":
                {
                    if (now.Year == dt.Year)
                        status = status2;
                    break;
                }
            }
            return status;
        }
        //获取周数
        public int getWeek(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
       //账号信息处理
        protected string showAccount(string account)
        {
            if (chkFullAccount.Checked)
                return account;
            string show = "";
            if (account.Length > 7)
            {
                show += account.Substring(0, 2);
                show += showStar(account.Length - 4);
                show += account.Substring(account.Length - 2);
            }
            else if (account.Length <= 7 && account.Length > 4)
            {
                show += account.Substring(0, 1);
                show += showStar(account.Length - 2);
                show += account.Substring(account.Length - 1);
            }
            else if (account.Length <= 4)
            {
                show += account.Substring(0, 1);
                show += showStar(account.Length - 1);
            }
            return show;
        }
        //隐藏QQ号
        private string showStar(int i)
        {
            int j = 0;
            string s = "";
            while (j < i)
            {
                s += "*";
                j++;
            }
            return s;
        }
        //显示商城状态
        protected bool showStore(int coupon)
        {
            return coupon > 50;
        }

        //排序方法
        private DataSet getOrderList(CouponBLL bll)
        {
            string order = "asc";
            if (rblOrderby.SelectedValue.Equals("1"))
                order = "desc";
            switch (rblOrder.SelectedValue)
            {
                case "0":
                    return bll.getBNSListById(order);
                case "1":
                    return bll.getBNSListByLevel(order);
                case "2":
                    return bll.getBNSListByCoupon(order);
                default:
                    return bll.getBNSListById(order);
            }
        }
        /// <summary>
        /// 切换视图
        /// </summary>
        /// <param name="mode">0:普通视图 1:详细视图</param>
        private void changeView(int mode)
        {
            switch (mode)
            {
                case 0:
                {
                    multiView.SetActiveView(viewGeneral);
                    btnGeneral.CssClass = "btn_press";
                    btnDetail.CssClass = "btn_normal";
                    break;
                }
                case 1:
                {
                    multiView.SetActiveView(viewDetail);
                    btnGeneral.CssClass = "btn_normal";
                    btnDetail.CssClass = "btn_press";
                    break;
                }
                default:
                {
                    multiView.SetActiveView(viewGeneral);
                    btnGeneral.CssClass = "btn_press";
                    btnDetail.CssClass = "btn_normal";
                    break;
                }
            }
        }
        #endregion

        protected void btnGeneral_Click(object sender, EventArgs e)
        {
            changeView(0);
        }
        protected void btnDetail_Click(object sender, EventArgs e)
        {
            changeView(1);
        }

        protected void lnkAmend_Click(object sender, EventArgs e)
        {
            showWhereEdit();
        }

        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            showWhere(new CouponBLL());
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            if (txtCoupon.Text.Trim().Equals("") || txtMinLevel.Text.Trim().Equals("") || txtMinStard.Text.Trim().Equals(""))
            {
                ClientScript.RegisterStartupScript(GetType(), "varrn", "<script>alert('请将数据填写完整！');</script>");
            }
            else
            {
                CouponBLL bll = new CouponBLL();
                if (bll.setWhere(int.Parse(hidWhereID.Value), txtMinLevel.Text, txtMinStard.Text, txtCoupon.Text, ddlCycle.SelectedValue, txtProvideDate.Text, txtWhereRemark.Text))
                {
                    showWhere(bll);
                    dataBound(bll, true);
                }
                else
                    showWhere(bll);
            }
        }

        protected void gvDetailList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                if (isPass(showLevel(((Label)e.Row.FindControl("labViewLevel")).Text,((Label)e.Row.FindControl("labViewStard")).Text)))
                {
                    e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#E7F7FF';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
                    w_count++;
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#FFE7F7';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
                }
            }
        }

        protected void gvDataList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                if (isPass(((Label)e.Row.FindControl("labViewLevels")).Text))
                {
                    e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#E7F7FF';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#FFE7F7';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
                }
            }
        }

        protected void chkFullAccount_CheckedChanged(object sender, EventArgs e)
        {
            CouponBLL bll = new CouponBLL();
            dataBound(bll, true);
            bll.setShowAccount(chkFullAccount.Checked);
        }

        protected void rblOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            CouponBLL bll = new CouponBLL();
            dataBound(bll, true);
            bll.setOrderBy(Convert.ToInt32(rblOrder.SelectedValue), rblOrderby.SelectedValue.Equals("1"));
        }

        protected void chkExpanstor_CheckedChanged(object sender, EventArgs e)
        {
            CouponBLL bll = new CouponBLL();
            bll.setShowCommodity(chkExpanstor.Checked);
        }

        protected void rblOrderby_SelectedIndexChanged(object sender, EventArgs e)
        {
            CouponBLL bll = new CouponBLL();
            dataBound(bll, true);
            bll.setOrderBy(Convert.ToInt32(rblOrder.SelectedValue), rblOrderby.SelectedValue.Equals("1"));
        }

    }
}
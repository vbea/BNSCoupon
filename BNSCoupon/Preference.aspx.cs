using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BNSLogic;

namespace BNSCoupon
{
    public partial class Preference : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData(new CouponBLL());
            }
        }

        private void getData(CouponBLL bll)
        {
            DataSet ds1 = bll.getStatisticsList();
            DataSet ds2 = bll.getSingleVocation();
            binVocation(ds2, ds1);
        }

        private void binVocation(DataSet voc, DataSet acc)
        {
            int count = voc.Tables[0].Rows.Count;
            string[] vocation = new string[count];
            string[] race = {"人族", "龙族", "灵族", "天族" };
            int[] vocationcou = new int[count];
            int[] raceCou = new int[4];
            for (int i = 0; i < count; i++)
            {
                vocation[i] = voc.Tables[0].Rows[i]["vocation"].ToString();
            }
            foreach (DataRow row in acc.Tables[0].Rows)
            {
                for (int i = 0; i < count; i++)
                {
                    if (vocation[i].Equals(row["vocation"].ToString()))
                    {
                        vocationcou[i]++;
                        break;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (race[i].Equals(row["race"].ToString()))
                    {
                        raceCou[i]++;
                        break;
                    }
                }
            }
            addVocation(vocation, vocationcou);
            addRace(race, raceCou);
        }

        private void addVocation(string[] vocation, int[] count)
        {

            double unit = labWidth.Width.Value / count.Max();
            for (int i = 0; i < vocation.Length; i++)
                tabVocation.Rows.Add(addNewRow(vocation[i], count[i], (int)(unit * count[i] * 1.5)));
        }

        private void addRace(string[] race, int[] count)
        {
            double unit = labWidth.Width.Value / count.Max();
            for (int i = 0; i < race.Length; i++)
                tabRace.Rows.Add(addNewRow(race[i], count[i], (int)(unit * count[i] * 2)));
        }

        private TableRow addNewRow(string title, int count, int width)
        {
            width = width < 0 ? 0 : width;
            TableRow _row = new TableRow();
            TableCell cell1 = new TableCell();
            cell1.CssClass = "pre_min";
            cell1.Text = title;
            TableCell cell2 = new TableCell();
            TextBox text = new TextBox();
            Label label = new Label();
            text.CssClass = "pre_pillar";
            label.Text = " " + count;
            text.Enabled = false;
            text.Width = Unit.Pixel(width+2);
            cell2.Controls.Add(text);
            cell2.Controls.Add(label);
            _row.Cells.Add(cell1);
            _row.Cells.Add(cell2);
            return _row;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BNSCoupon
{
    public partial class Header : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["headed"] == null)
                Session["headed"] = "0";
            if (!IsPostBack)
                setHeadImg();
        }

        protected void imgExpand_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["headed"].ToString().Equals("0"))
                Session["headed"] = "1";
            else
                Session["headed"] = "0";
            setHeadImg();
        }

        public void setHeadImg()
        {
            switch (Session["headed"].ToString())
            {
                case "0":
                    imgExpand.ImageUrl = "/images/expand.png";
                    headImage.Style.Add(HtmlTextWriterStyle.Height, "auto");
                    break;
                case "1":
                    imgExpand.ImageUrl = "/images/shrink.png";
                    headImage.Style.Add(HtmlTextWriterStyle.Height, "0px");
                    break;
            }
        }
    }
}
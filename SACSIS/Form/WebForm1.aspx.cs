using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace SACSIS.Form
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string p = @"^\d+(\.)?\d*$";

            if (Regex.IsMatch("t234.3", p))
            {
                Response.Write("OK");
            }
            else
            {
                Response.Write("NO");
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TranslateService.Service1Client proxy = new TranslateService.Service1Client();
            string str=TextBox1.Text.ToString();
          string result=  proxy.Translated(str, "en", "zh-CHS");
          TextBox2.Text = result;
        }
    }
}

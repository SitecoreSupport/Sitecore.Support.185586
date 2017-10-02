using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.SecurityModel.Cryptography;
using Sitecore.SecurityModel.License;
using Sitecore.Text;
using Sitecore.Web;
using Sitecore.Web.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Sitecore.Support
{
    public class CustomDefaultLogin : Sitecore.sitecore.login.Default
    {
        protected System.Web.UI.WebControls.Literal ltrLogin;
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrLogin.Text = Sitecore.Globalization.Translate.Text("Please enter your login credentials.");
        }
    }
}

using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.Security.Authentication;
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

namespace Sitecore.Support.sitecore.login
{
    public class Default : Sitecore.sitecore.login.Default
    {
        private string fullUserName = string.Empty;
        private string startUrl = string.Empty;

        protected System.Web.UI.WebControls.Literal ltrLogin;
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrLogin.Text = Sitecore.Globalization.Translate.Text("Please enter your login credentials.");
        }

        protected override bool Login()
        {
            this.fullUserName = WebUtil.HandleFullUserName(this.UserName.Text);
            this.startUrl = WebUtil.GetQueryString("returnUrl");

            if (AuthenticationManager.Login(this.fullUserName, this.Password.Text, this.ShouldPersist()))
            {
                return true;
            }

            this.RenderError(Sitecore.Globalization.Translate.Text("Your login attempt was not successful. Please try again."));
            return false;
        }

        private void RenderError(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            this.FailureHolder.Visible = true;
            this.FailureText.Text = text;
        }

        private bool ShouldPersist()
        {
            return !Settings.Login.DisableRememberMe && this.RememberMe.Checked;
        }
    }
}

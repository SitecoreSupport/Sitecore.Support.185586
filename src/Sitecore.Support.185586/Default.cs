using Sitecore.Configuration;
using Sitecore.Globalization;
using Sitecore.Security.Authentication;
using System.Reflection;

namespace Sitecore.Support.sitecore.login
{
    public class Default : Sitecore.sitecore.login.Default
    {
        protected override bool Login()
        {
            if (AuthenticationManager.Login(typeof(Sitecore.sitecore.login.Default).GetField("fullUserName", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this).ToString(), base.Password.Text, this.ShouldPersist()))
            {
                return true;
            }
            this.RenderError(Translate.Text("Your login attempt was not successful. Please try again."));
            return false;

        }

        private bool ShouldPersist() =>
    (!Settings.Login.DisableRememberMe && base.RememberMe.Checked);

        private void RenderError(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                base.FailureHolder.Visible = true;
                base.FailureText.Text = text;
            }
        }
       
    }
}

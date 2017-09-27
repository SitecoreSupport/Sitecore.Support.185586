using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.LoggingIn;
using Sitecore.Security.Accounts;
using Sitecore.Security.Authentication;
using System;

namespace Sitecore.Support
{
    public class CustomCheckClientUser
    {
        /// <summary>
		/// Runs the processor.
		/// </summary>
		/// <param name="args">The arguments.</param>
		public void Process(LoggingInArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            User user = User.FromName(args.Username, false);
            if (AuthenticationManager.Login(args.Username.ToString(), args.Password.ToString()) && user.IsAdministrator)
            {
                return;
            }
            if (!AuthenticationManager.Login(args.Username.ToString(), args.Password.ToString()))
            {
                args.Success = false;
                args.AddMessage("Your login attempt was not successful. Please try again.");
                args.AbortPipeline();
                return;
            }
            if (user.IsInRole(Constants.SitecoreClientUsersRole))
            {
                return;
            }
            args.Success = false;
            args.AddMessage("You do not have access to the system. If you think this is wrong, please contact the system administrator.");
            args.AbortPipeline();
        }
    }
}
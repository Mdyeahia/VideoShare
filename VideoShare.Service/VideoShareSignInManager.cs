using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VideoShare.Entities;

namespace VideoShare.Service
{
    public class VideoShareSignInManager : SignInManager<VideoShareUser, string>
    {
        public VideoShareSignInManager(VideoShareUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(VideoShareUser user)
        {
            return user.GenerateUserIdentityAsync((VideoShareUserManager)UserManager);
        }

        public static VideoShareSignInManager Create(IdentityFactoryOptions<VideoShareSignInManager> options, IOwinContext context)
        {
            return new VideoShareSignInManager(context.GetUserManager<VideoShareUserManager>(), context.Authentication);
        }
    }
}

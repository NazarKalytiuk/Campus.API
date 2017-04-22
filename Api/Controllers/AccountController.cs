using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Domain.Infrastruscture.Interaction;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using RequestModels;
using Services.Contracts;

namespace Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private readonly IStudentService _studentService;
        private ApplicationUserManager _userManager;

        public AccountController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat,
            IStudentService studentService
        )
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
            _studentService = studentService;
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }


        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }


        // POST api/Account/ChangePassword
        //[Route("ChangePassword")]
        //public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
        //        model.NewPassword);

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        // POST api/Account/SetPassword
        //[Route("SetPassword")]
        //public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}


        // POST api/Account/Register
        //[AllowAnonymous]
        //[Route("Register")]
        //public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

        //    IdentityResult result = await UserManager.CreateAsync(user, model.Password);

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}
        // POST api/Account/RegisterStudent
        [AllowAnonymous]
        [Route("RegisterStudent")]
        public async Task<IHttpActionResult> RegisterStudent(RegisterStudentRequestModel model)
        {
            try
            {
                var student = await _studentService.CreateStudentAsync(model);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
                return InternalServerError();

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error);

                if (ModelState.IsValid)
                    return BadRequest();

                return BadRequest(ModelState);
            }

            return null;
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                    return null;

                var providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || string.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || string.IsNullOrEmpty(providerKeyClaim.Value))
                    return null;

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                    return null;

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static readonly RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");

                var strengthInBytes = strengthInBits / bitsPerByte;

                var data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        #endregion
    }
}
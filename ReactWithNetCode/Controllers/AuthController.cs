using BusinessFactory.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelFactory.Users;
using ReactWithNetCode.ActionFilter;
using Security.Security;
using System.Threading;

namespace ReactWithNetCode.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        IBALPortalUser objBALPortalUser;
        IBALDimMbr objBALDimMbr;
        public AuthController(IBALPortalUser _IBALPortalUser, IBALDimMbr _IBALDimMbr)
        {
            objBALPortalUser = _IBALPortalUser;
            objBALDimMbr = _IBALDimMbr;
        }

        [CustomActionFilter]
        [HttpPost]
        public IActionResult Login([FromBody]PortalUser _PortalUser)
        {
            var user = objBALPortalUser.GetLoginUser(_PortalUser);
            Thread.Sleep(2000);
            if (user == null) { return Ok(null); };
            var mamber = objBALDimMbr.GetMember(user.MbrId);
            var token = new JwtTokenBuilder()
                               .AddSecurityKey(JwtSecurityKey.Create("myowndemo-secret-key"))
                               .AddSubject(user.UserName)
                               .AddIssuer("MyOwnDemo.Security.Bearer")
                               .AddAudience("MyOwnDemo.Security.Bearer")
                               .AddClaim("MembershipId", "111")
                               .AddExpiry(60)
                               .Build();

            return Ok(new { token = token.Value, user = new { UserName = user.UserName, MamberId = user.MbrId, UserFirstName = user.UserFirstName, UserLastName = user.UserLastName, MamberType = mamber.MbrName } });
        }
    }
}
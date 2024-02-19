using System.Security.Claims;
using System.ComponentModel;

namespace SetCookie
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetLoggedInUserName(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.Name).Value.ToString();
        }

        public static string GetLoggedInRole(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst("RoleId").Value.ToString();
        }

        public static string GetLoggedInUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst("UserId").Value.ToString();
        }

        public static string GetLoggedInImgProfile(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst("ImgProfile").Value.ToString();
        }
    }
    
}
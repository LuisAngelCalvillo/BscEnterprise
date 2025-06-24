using Microsoft.AspNetCore.Authorization;

namespace UI.Authorization
{
    public class PermissionAuthorizeAttribute : AuthorizeAttribute
    {
        public PermissionAuthorizeAttribute(string permission)
        {
            Policy = $"Permission:{permission}";
        }
    }
}

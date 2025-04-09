using Abp.Authorization;
using FinallyProject.Authorization.Roles;
using FinallyProject.Authorization.Users;

namespace FinallyProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

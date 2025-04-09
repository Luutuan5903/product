using System.Collections.Generic;
using FinallyProject.Roles.Dto;

namespace FinallyProject.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}

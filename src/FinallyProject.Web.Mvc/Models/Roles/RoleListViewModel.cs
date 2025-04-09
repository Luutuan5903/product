using System.Collections.Generic;
using FinallyProject.Roles.Dto;

namespace FinallyProject.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}

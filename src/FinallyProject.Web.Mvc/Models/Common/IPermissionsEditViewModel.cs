using System.Collections.Generic;
using FinallyProject.Roles.Dto;

namespace FinallyProject.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}
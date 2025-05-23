﻿using System.Threading.Tasks;
using Abp.Application.Services;
using FinallyProject.Authorization.Accounts.Dto;

namespace FinallyProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

using LOL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Domain.Contracts.Services
{
    public interface IDictionariesService
    {
        Task<List<RoleModel>> GetAllRoles();
    }
}

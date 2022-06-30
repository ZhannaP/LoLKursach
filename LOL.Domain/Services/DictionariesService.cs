using AutoMapper;
using LOL.Core.UoWs;
using LOL.Domain.Contracts.Services;
using LOL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Domain.Services
{
    public class DictionariesService : IDictionariesService
    {
        private readonly ILOLUnitOfWork lolUnitOfWork;
        private readonly IMapper mapper;

        public DictionariesService(ILOLUnitOfWork lolUnitOfWork,
                                   IMapper mapper)
        {
            this.lolUnitOfWork = lolUnitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<RoleModel>> GetAllRoles()
        {
            var list = await lolUnitOfWork.RoleRepository.GetBaseAllAsync();
            return mapper.Map<List<RoleModel>>(list);
        }
    }
}

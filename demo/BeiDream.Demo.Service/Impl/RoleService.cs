﻿using System;
using BeiDream.Core.Domain.Uow;
using BeiDream.Core.Domain.Uow.Interception;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Domain.Services.Contracts;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Utils.Extensions;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Service.Impl
{

    public class RoleService : IRoleService
    {
        /// <summary>
        ///用户领域服务
        /// </summary>
        public IRoleDomainService RoleDomainService { get; set; }

        public RoleService(IRoleDomainService roleDomainService)
        {
            RoleDomainService = roleDomainService;
        }
        [NoUnitOfWork]
        public PagerList<RoleDto> Query(RoleQuery query)
        {
            return RoleDomainService.Query(query).Convert(ToDto);
        }
        private RoleDto ToDto(Role entity)
        {
            return new RoleDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description=entity.Description,
                IsAdmin = entity.IsAdmin,
                Enabled = entity.Enabled,
                DateCreated = entity.DateCreated.ToChineseDateTimeString(true),
                Version = entity.Version
            };
        }
        public void AddorUpdate(RoleDto dto)
        {
            RoleDomainService.AddorUpdate(ToEntity(dto));
        }
        private Role ToEntity(RoleDto dto)
        {
            return new Role()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                IsAdmin = dto.IsAdmin,
                Enabled = dto.Enabled,
                Version = dto.Version
            };
        }
        [NoUnitOfWork]
        public RoleDto Find(Guid id)
        {
           var role= RoleDomainService.Find(id);
            return ToDto(role);
        }

        public void Delete(Guid id)
        {
            RoleDomainService.Delete(id);
        }
    }
}
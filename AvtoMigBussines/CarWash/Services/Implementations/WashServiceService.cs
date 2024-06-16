﻿using AvtoMigBussines.Authenticate;
using AvtoMigBussines.CarWash.Models;
using AvtoMigBussines.CarWash.Repositories.Implementations;
using AvtoMigBussines.CarWash.Repositories.Interfaces;
using AvtoMigBussines.CarWash.Services.Interfaces;
using AvtoMigBussines.DTOModels;
using AvtoMigBussines.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace AvtoMigBussines.CarWash.Services.Implementations
{
    public class WashServiceService : IWashServiceService
    {
        private readonly IWashServiceRepository _washServiceRepository;
        private readonly UserManager<AspNetUser> userManager;
        public WashServiceService(IWashServiceRepository washServiceRepository, UserManager<AspNetUser> userManager)
        {
            _washServiceRepository = washServiceRepository;
            this.userManager = userManager;
        }
        public async Task<bool> CreateAsync(WashServiceDTO washServiceDTO, string aspNetUserId)
        {
            var user = await userManager.FindByIdAsync(aspNetUserId);
            if (await _washServiceRepository.ExistsWithName(washServiceDTO.WashOrderId, washServiceDTO.ServiceId))
            {
                throw new CustomException.WashOrderExistsException("Wash service with the same service already exists.");
            }
            var currentUser = await userManager.FindByIdAsync(aspNetUserId);
            var washService = new WashService()
            {
                WashOrderId = washServiceDTO.WashOrderId,
                ServiceId = washServiceDTO.ServiceId,
                Price = washServiceDTO.Price,
                OrganizationId = user.OrganizationId,
                AspNetUserId = aspNetUserId
            };

            await _washServiceRepository.AddAsync(washService);
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            await _washServiceRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<WashService>> GetAllAsync()
        {
            return await _washServiceRepository.GetAllAsync();
        }

        public async Task<IEnumerable<WashServiceDTO>> GetAllWashServicesOnOrder(int? orderId, string? aspNetUserId)
        {
            var washServices = await _washServiceRepository.GetAllWashServicesOnOrder(orderId);

            var washServiceDTOs = new List<WashServiceDTO>();

            foreach (var ws in washServices)
            {
                var washServiceDTO = new WashServiceDTO
                {
                    ServiceName = ws.Service.Name,
                    Price = ws.Price,
                    // другие свойства
                };

                washServiceDTOs.Add(washServiceDTO);
            }

            return washServiceDTOs;
        }



        public async Task<WashService> GetByIdAsync(int id)
        {
            return await _washServiceRepository.GetByIdAsync(id);
        }

        public async Task<int?> GetCountAllServices(int? orderId)
        {
            return await _washServiceRepository.GetCountAllServices(orderId);
        }

        public async Task<double?> GetSummAllServices(int? orderId)
        {
            return await _washServiceRepository.GetSummAllServices(orderId);
        }

        public Task UpdateAsync(WashService washService)
        {
            throw new NotImplementedException();
        }
    }
}

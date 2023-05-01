using AutoMapper;
using OlderTask.Domain.Entities;
using OrderTask.Business.Contracts.Feature;
using OrderTask.Business.Contracts.Persistence.IRepository;
using OrderTask.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalApp.Demo.Application.Services
{
    public class OrderDetailsAppService : IOrderDetailsAppService
    {
        private readonly IAsyncRepository<OrderDetail> _rep;
        private readonly IAsyncRepository<Order> _orederRep;
        private readonly IMapper mapper;
        public OrderDetailsAppService(IAsyncRepository<OrderDetail> rep, IMapper mapper, IAsyncRepository<Order> orederRep)
        {
            this._rep = rep;
            this.mapper = mapper;
            _orederRep = orederRep;
        }
        public async Task<OrderDetailsDto> AddAsync(OrderDetailsDto obj)
        {
            var entity = mapper.Map<OrderDetail>(obj);
            var data = await _rep.AddAsync(entity);
            return mapper.Map<OrderDetailsDto>(data);
        }
        public async Task<OrderDto> GetAllByOrderIdAsync(int id)
        {
            var data = await _orederRep.GetOrderWithDetails(id);
            return mapper.Map<OrderDto>(data);
        }
        public async Task<OrderDetailsDto> GetByIdAsync(int id)
        {
            var data = await _rep.GetByIdAsync(id);
            return mapper.Map<OrderDetailsDto>(data);
        }
        public async Task<OrderDetailsDto> UpdateAsync(OrderDetailsDto obj)
        {
            var entity = mapper.Map<OrderDetail>(obj);
            var data = await _rep.UpdateAsync(entity);
            return mapper.Map<OrderDetailsDto>(data);
        }
        public async Task<OrderDetailsDto> DeleteAsync(OrderDto obj)
        {
            var entity = mapper.Map<OrderDetail>(obj);
            var data = await _rep.DeleteAsync(entity);
            return mapper.Map<OrderDetailsDto>(data);
        }
        public async Task<OrderDetailsDto> DeleteByIdAsync(int id)
        {
            var data = await _rep.DeleteAsync(id);
            return mapper.Map<OrderDetailsDto>(data);
        }
    }
}

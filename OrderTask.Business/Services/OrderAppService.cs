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
    public class OrderAppService: IOrderAppService 
    {
        private readonly IAsyncRepository<Order> _rep;
        private readonly IMapper mapper;

        public OrderAppService(IAsyncRepository<Order> rep, IMapper mapper)
        {
            this._rep = rep;
            this.mapper = mapper;
        }
        public async Task<OrderDto> AddAsync(OrderDto obj)
        {
            var entity = mapper.Map<Order>(obj);
            var data = await _rep.AddAsync(entity);
            return mapper.Map<OrderDto>(data);
        }
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var data = await _rep.GetAllAsync();
            return mapper.Map<IEnumerable<OrderDto>>(data);
        }
        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var data = await _rep.GetByIdAsync(id);
            return mapper.Map<OrderDto>(data);
        }
        public async Task<OrderDto> UpdateAsync(OrderDto obj)
        {
            var entity = mapper.Map<Order>(obj);
            var data = await _rep.UpdateAsync(entity);
            return mapper.Map<OrderDto>(data);
        }
        public async Task<OrderDto> DeleteAsync(OrderDto obj)
        {
            var entity = mapper.Map<Order>(obj);
            var data = await _rep.DeleteAsync(entity);
            return mapper.Map<OrderDto>(data);
        }
        public async Task<OrderDto> DeleteByIdAsync(int id)
        {
            var data = await _rep.DeleteAsync(id);
            return mapper.Map<OrderDto>(data);
        }
    }
}

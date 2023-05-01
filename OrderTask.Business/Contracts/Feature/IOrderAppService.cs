using OrderTask.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTask.Business.Contracts.Feature
{
    public interface IOrderAppService
    {
        Task<OrderDto> AddAsync(OrderDto obj);
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(int id);
        Task<OrderDto> UpdateAsync(OrderDto obj);
        Task<OrderDto> DeleteByIdAsync(int id);

    }
}

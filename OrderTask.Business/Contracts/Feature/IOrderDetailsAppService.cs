using OrderTask.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTask.Business.Contracts.Feature
{
    public interface IOrderDetailsAppService
    {
        Task<OrderDetailsDto> AddAsync(OrderDetailsDto obj);
        Task<OrderDto> GetAllByOrderIdAsync(int id);
        Task<OrderDetailsDto> GetByIdAsync(int id);
        Task<OrderDetailsDto> UpdateAsync(OrderDetailsDto obj);
        Task<OrderDetailsDto> DeleteByIdAsync(int id);

    }
}

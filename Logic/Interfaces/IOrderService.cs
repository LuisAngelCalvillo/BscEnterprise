using DataAccess.Entities;
using Shared.DTOs;

namespace Logic.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseDataDto<List<OrderDto>>> GetAllOrdersAsync();
        Task<ResponseDto> InsertOrderAsync(InsertOrderDetailDto orderDetail);
        Task<ResponseDataDto<List<DetailOrderResponse>>> GetDetailOrder(int IdWorkOrder);
    }
}

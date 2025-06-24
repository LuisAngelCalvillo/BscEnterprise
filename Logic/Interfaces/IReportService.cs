using Shared.DTOs;

namespace Logic.Interfaces
{
    public interface IReportService
    {
        Task<ResponseDataDto<byte[]>> GetInformationForProductsReport();
    }
}

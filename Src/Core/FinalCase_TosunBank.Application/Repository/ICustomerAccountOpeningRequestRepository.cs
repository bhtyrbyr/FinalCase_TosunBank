using FinalCase_TosunBank.Domain.Entities;

namespace FinalCase_TosunBank.Application.Repository;

public interface ICustomerAccountOpeningRequestRepository : IGenericRepository<CustomerAccountOpeningRequest, int>
{
    Task<CustomerAccountOpeningRequest> FindByNationalityNumberAsync(string NationalityNumber);
}

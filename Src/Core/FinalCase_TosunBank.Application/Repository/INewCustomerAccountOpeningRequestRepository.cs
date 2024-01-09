using FinalCase_TosunBank.Domain.Entities;

namespace FinalCase_TosunBank.Application.Repository;

public interface INewCustomerAccountOpeningRequestRepository : IGenericRepository<NewCustomerAccountOpeningRequest, int>
{
    Task<NewCustomerAccountOpeningRequest> FindByNationalityNumberAsync(string NationalityNumber);
}

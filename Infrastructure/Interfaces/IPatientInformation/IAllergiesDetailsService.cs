using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IBase;

namespace Infrastructure.Interfaces.IPatientInformation
{
    public interface IAllergiesDetailsService : IGenericRepository<Allergy_Detail>
    {
        Task<IList<Allergy_Detail>> AllergiesList(int id);
        Task UpdateRangeAsync(int id, List<Allergy_Detail> entity);
    }
}






using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IBase;

namespace Infrastructure.Interfaces.IPatientInformation
{
    public interface INCDDetailsService : IGenericRepository<NCD_Detail>
    {
        Task<IList<NCD_Detail>> NCDIDList(int id);
        Task UpdateRangeAsync(int id, List<NCD_Detail> entity);
    }
}






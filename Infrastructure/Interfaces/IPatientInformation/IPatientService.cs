using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IBase;

namespace Infrastructure.Interfaces.IPatientInformation
{
    public interface IPatientService:IGenericRepository<Patient>
    {
        Task<Patient> GetAllList();
    }
}






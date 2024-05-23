using ApplicationCore.Base;
using ApplicationCore.DBContext;
using ApplicationCore.Entities;
using Infrastructure.Interfaces.IPatientInformation;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.PatientInformation
{
    public class NCDDetailsService : GenericRepository<NCD_Detail>, INCDDetailsService
    {
        private readonly ApplicationDbContext _context;

        public NCDDetailsService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<IList<NCD_Detail>> NCDIDList(int id)
        {

         return  _context.NCD_Details.Where(x => x.PatientId == id).ToList();
        }
        public async Task UpdateRangeAsync(int id, List<NCD_Detail> entity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var existingNcdDetails =  _context.NCD_Details.Where(x=>x.PatientId==id).ToList();
                _context.RemoveRange(existingNcdDetails);

                await _context.AddRangeAsync(entity);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


    }

}

using ApplicationCore.Base;
using ApplicationCore.DBContext;
using ApplicationCore.Entities;
using Infrastructure.Interfaces.IPatientInformation;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.PatientInformation
{
    public class AllergiesDetailsService : GenericRepository<Allergy_Detail>, IAllergiesDetailsService
    {
        private readonly ApplicationDbContext _context;

        public AllergiesDetailsService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<IList<Allergy_Detail>> AllergiesList(int id)
        {

            return _context.Allergy_Details.Where(x => x.PatientId == id).ToList();
        }
        public async Task UpdateRangeAsync(int id, List<Allergy_Detail> entity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var existingAllergiesDetails = _context.Allergy_Details.Where(x => x.PatientId == id).ToList();
                _context.RemoveRange(existingAllergiesDetails);

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

using ApplicationCore.Base;
using ApplicationCore.DBContext;
using ApplicationCore.Entities;
using Infrastructure.Interfaces.IPatientInformation;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace Infrastructure.Services.PatientInformation
{
    public class PatientService : GenericRepository<Patient>, IPatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Patient> GetAllList()
        {
            var viewModel = new Patient
            {
                Diseases = await _context.DiseaseInformations.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.DiseaseName
                }).ToListAsync(),
                NCDs = await _context.NCDs.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.NCD_Name
                }).ToListAsync(),
                Allergies = await _context.Allergies.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Allergy_Name
                }).ToListAsync()
            };
            return viewModel;
        }
    }
}

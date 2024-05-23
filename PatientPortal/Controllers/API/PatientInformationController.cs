using ApplicationCore.Entities;
using Infrastructure.Interfaces.IPatientInformation;
using Infrastructure.Services.PatientInformation;
using Microsoft.AspNetCore.Mvc;

namespace PatientPortal.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInformationController : ControllerBase
    {

        private readonly IPatientService _patientService;
        private readonly INCDDetailsService _nCDDetailsService;
        private readonly IAllergiesDetailsService _allergiesDetailsService;

        public PatientInformationController(IPatientService patientService, INCDDetailsService nCDDetailsService, IAllergiesDetailsService allergiesDetailsService)
        {
            _patientService = patientService;
            _nCDDetailsService = nCDDetailsService;
            _allergiesDetailsService = allergiesDetailsService;
        }


        [HttpGet("GetAllList")]
        public async Task<IActionResult> GetAllList()
        {
            var patients = await _patientService.GetAllList();
            return Ok(patients);
        }
        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetAllPatient()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost("AddPatient")]
        public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }
                await _patientService.AddAsync(patient);
                int newId = patient.Id;
                var ncdIdArray = patient.SelectedNCDs.Split(',');
                var allergiesIdArray = patient.SelectedAllergies.Split(',');

                List<NCD_Detail> ncdDetailsList = new List<NCD_Detail>();
                List<Allergy_Detail> allergiesDetailsList = new List<Allergy_Detail>();


                foreach (var ncdId in ncdIdArray)
                {
                    if (int.TryParse(ncdId, out int ncdIdInt))
                    {
                        var ncdDetail = new NCD_Detail
                        {
                            PatientId = newId,
                            NCDId = ncdIdInt
                        };

                        ncdDetailsList.Add(ncdDetail);
                    }

                }
                foreach (var allergiesId in allergiesIdArray)
                {
                    if (int.TryParse(allergiesId, out int allergiesIdInt))
                    {
                        var allergiesDetail = new Allergy_Detail
                        {
                            PatientId = newId,
                            AllergyId = allergiesIdInt
                        };

                        allergiesDetailsList.Add(allergiesDetail);
                    }

                }
                await _nCDDetailsService.AddRangeAsync(ncdDetailsList);
                await _allergiesDetailsService.AddRangeAsync(allergiesDetailsList);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            await _patientService.UpdateAsync(patient);
            return NoContent();
        }

        [HttpGet("EditDataById/{id}")]
        public async Task<IActionResult> EditDataById(int id)
        {
            var patients = await _patientService.GetAllList();
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            var ncdDeta = await _nCDDetailsService.NCDIDList(id);
            var allergiesDeta = await _allergiesDetailsService.AllergiesList(id);
            
            patient.SelectedNCDs = string.Join(",", ncdDeta.Select(x => x.NCDId));
            patient.SelectedAllergies = string.Join(",", allergiesDeta.Select(x => x.AllergyId));
            patient.NCDs = patients.NCDs;
            patient.Allergies = patients.Allergies;
            patient.Diseases = patients.Diseases;


            return Ok(patient);
        }

        [HttpPost("EditPatient")]
        public async Task<IActionResult> EditPatient([FromBody] Patient patient)
        {
            try
            {
                await _patientService.UpdateAsync(patient);

                var ncdIdArray = patient.SelectedNCDs.Split(',');
                var allergiesIdArray = patient.SelectedAllergies.Split(',');
                List<NCD_Detail> ncdDetailsList = new List<NCD_Detail>();
                List<Allergy_Detail> allergiesDetailsList = new List<Allergy_Detail>();
                foreach (var ncdId in ncdIdArray)
                {
                    if (int.TryParse(ncdId, out int ncdIdInt))
                    {
                        var ncdDetail = new NCD_Detail
                        {
                            PatientId = patient.Id,
                            NCDId = ncdIdInt
                        };
                        ncdDetailsList.Add(ncdDetail);
                    }
                }
                foreach (var allergiesId in allergiesIdArray)
                {
                    if (int.TryParse(allergiesId, out int allergiesIdInt))
                    {
                        var allergiesDetail = new Allergy_Detail
                        {
                            PatientId = patient.Id,
                            AllergyId = allergiesIdInt
                        };
                        allergiesDetailsList.Add(allergiesDetail);
                    }
                }
                await _nCDDetailsService.UpdateRangeAsync(patient.Id, ncdDetailsList);
                await _allergiesDetailsService.UpdateRangeAsync(patient.Id, allergiesDetailsList);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientService.DeleteAsync(id);
            return Ok(id); ;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PatientPortal.Models;
using System.Diagnostics;

namespace PatientPortal.Controllers
{
    using System;

    public abstract class Clinician
    {
        public string Name { get; set; }
        public string HospitalName { get; set; }

        public abstract bool Login(string username, string password);

        protected bool IsSessionExists(string username)
        {
            // Implementation to check if a session exists for the given username
            // For demonstration, assume session always exists
            return true;
        }

        public abstract void CreatePrescription(int patientNumber);
    }

    public class Doctor : Clinician
    {
        public string PracticeNumber { get; set; }

        public override bool Login(string username, string password)
        {
            // Implementation for Doctor's login
            if (IsSessionExists(username))
            {
                // Validate credentials
                // For demonstration, assume credentials are always valid
                return true;
            }
            return false;
        }

        public override void CreatePrescription(int patientNumber)
        {
            // Implementation for creating a prescription
            Console.WriteLine($"Doctor {Name} created a prescription for patient {patientNumber}");
        }
    }

    public class Pharmacist
    {
        public string PharmacistNumber { get; set; }

        public void DispenseMedications(int prescriptionNumber)
        {
            // Implementation for dispensing medications
            Console.WriteLine($"Pharmacist {PharmacistNumber} dispensed medications for prescription {prescriptionNumber}");
        }
    }

}
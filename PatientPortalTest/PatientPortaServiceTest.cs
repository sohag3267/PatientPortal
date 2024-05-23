using ApplicationCore.DBContext;
using ApplicationCore.Entities;
using Infrastructure.Services.PatientInformation;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;

namespace PatientPortalTest
{
    public class PatientPortaServiceTest
    {
        private Mock<ApplicationDbContext> _mockContext;

        public PatientPortaServiceTest()
        {
            _mockContext = new Mock<ApplicationDbContext>();

            // Set up in-memory data for DiseaseInformations
            var diseaseInformations = new List<DiseaseInformation>
        {
            new DiseaseInformation { Id = 1, DiseaseName = "Disease1" },
            new DiseaseInformation { Id = 2, DiseaseName = "Disease2" }
            }.AsQueryable();

            var mockDiseaseSet = new Mock<DbSet<DiseaseInformation>>();
            mockDiseaseSet.As<IQueryable<DiseaseInformation>>().Setup(m => m.Provider).Returns(diseaseInformations.Provider);
            mockDiseaseSet.As<IQueryable<DiseaseInformation>>().Setup(m => m.Expression).Returns(diseaseInformations.Expression);
            mockDiseaseSet.As<IQueryable<DiseaseInformation>>().Setup(m => m.ElementType).Returns(diseaseInformations.ElementType);
            mockDiseaseSet.As<IQueryable<DiseaseInformation>>().Setup(m => m.GetEnumerator()).Returns(diseaseInformations.GetEnumerator());

            // Set up in-memory data for NCDs
            var ncds = new List<NCD>
        {
            new NCD { Id = 1, NCD_Name = "NCD1" },
            new NCD { Id = 2, NCD_Name = "NCD2" }
            }.AsQueryable();

            var mockNCDSet = new Mock<DbSet<NCD>>();
            mockNCDSet.As<IQueryable<NCD>>().Setup(m => m.Provider).Returns(ncds.Provider);
            mockNCDSet.As<IQueryable<NCD>>().Setup(m => m.Expression).Returns(ncds.Expression);
            mockNCDSet.As<IQueryable<NCD>>().Setup(m => m.ElementType).Returns(ncds.ElementType);
            mockNCDSet.As<IQueryable<NCD>>().Setup(m => m.GetEnumerator()).Returns(ncds.GetEnumerator());

            // Set up in-memory data for Allergies
            var allergies = new List<Allergy>
        {
            new Allergy { Id = 1, Allergy_Name = "Allergy1" },
            new Allergy { Id = 2, Allergy_Name = "Allergy2" }
            }.AsQueryable();

            var mockAllergySet = new Mock<DbSet<Allergy>>();
            mockAllergySet.As<IQueryable<Allergy>>().Setup(m => m.Provider).Returns(allergies.Provider);
            mockAllergySet.As<IQueryable<Allergy>>().Setup(m => m.Expression).Returns(allergies.Expression);
            mockAllergySet.As<IQueryable<Allergy>>().Setup(m => m.ElementType).Returns(allergies.ElementType);
            mockAllergySet.As<IQueryable<Allergy>>().Setup(m => m.GetEnumerator()).Returns(allergies.GetEnumerator());

            _mockContext.Setup(c => c.DiseaseInformations).Returns(mockDiseaseSet.Object);
            _mockContext.Setup(c => c.NCDs).Returns(mockNCDSet.Object);
            _mockContext.Setup(c => c.Allergies).Returns(mockAllergySet.Object);
        }

        [Fact]
        public async Task GetAllList_ReturnsCorrectViewModel()
        {
            // Arrange
            var service = new PatientService(_mockContext.Object);

            // Act
            var result = await service.GetAllList();

            // Assert
            Assert.NotNull(result);
        }
    }
}

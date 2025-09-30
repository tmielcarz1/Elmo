using AutoMapper;
using Elmo.Application.Services.Exercise4;
using Elmo.Domain.Entities;
using Elmo.Infrastructure.Repositories.Exercise4;
using Moq;

namespace Elmo.Test.Tests.Exercise4
{
    [TestFixture]
    public class Exercise4Test
    {
        private Mock<IExercise4Repository> _repository;
        private Exercise4Service _service;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IExercise4Repository>();
            _mapperMock = new Mock<IMapper>();
            _service = new Exercise4Service(_repository.Object, _mapperMock.Object);
        }

        [Test]
        public async Task employee_can_request_vacation()
        {
            // Arrange
            var employee = CreateEmployeeWithVacationPackageCanRequest();

            _repository
                .Setup(r => r.GetEmployeeById(employee.Id))
                .ReturnsAsync(CreateEmployeeWithVacationPackageCanRequest);

            // Act
            var result = await _service.IsEmployeeCanRequestVacation(employee.Id);

            // Assert
            Assert.That(result.StateObject, Is.True);
            Assert.That(result.Errors, Is.Empty);
        }

        [Test]
        public async Task employee_cant_request_vacation()
        {
            // Arrange
            var employee = CreateEmployeeWithVacationPackageCantRequest();

            _repository
                .Setup(r => r.GetEmployeeById(employee.Id))
                .ReturnsAsync(CreateEmployeeWithVacationPackageCantRequest);

            // Act
            var result = await _service.IsEmployeeCanRequestVacation(employee.Id);

            // Assert
            Assert.That(result.StateObject, Is.False);
            Assert.That(result.Errors, Is.Empty);
        }



        #region dane przykładowe
        private Employee CreateEmployeeWithVacationPackageCanRequest()
        {
            return new Employee
            {
                Id = 1,
                Name = "Jan Kowalski ",
                VacationPackage = new VacationPackage
                {
                    Id = 1,
                    Name = "rok bieżący",
                    GrantedDays = 20,
                    Year = DateTime.Now.Year
                },
                Vacations = null
            };
        }

        private Employee CreateEmployeeWithVacationPackageCantRequest()
        {
            return new Employee
            {
                Id = 1,
                Name = "Jan Kowalski",
                VacationPackage = new VacationPackage
                {
                    Id = 1,
                    Name = "rok bieżący",
                    GrantedDays = 20,
                    Year = DateTime.Now.Year
                },
                Vacations = new List<Vacation>
             {
                 new Vacation
                 {
                     Id = 1,
                     DateSince = new DateTime(DateTime.Now.Year, 2, 1),
                     DateUntil = new DateTime(DateTime.Now.Year, 2, 20),
                     IsPartialVacation = false
                 }
             }
            };
        }
        #endregion

    }
}
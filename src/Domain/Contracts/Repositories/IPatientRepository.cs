using CrossCutting.Repositories;
using Domain.Entities.Patients;

namespace Domain.Contracts.Repositories;

public interface IPatientRepository : IRepository<Patient>; 
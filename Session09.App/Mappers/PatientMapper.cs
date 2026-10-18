using Session09.App.Dtos;
using Session09.App.Models;

namespace Session09.App.Mappers;

// Part 1 - Q4: Static mapper class that converts the Patient model into a PatientDto.
public static class PatientMapper
{
    public static PatientDto MapFromModelToDto(Patient patient)
        => new PatientDto(patient.PatientId, patient.PatientFullName, patient.PatientPhoneNumber);
}

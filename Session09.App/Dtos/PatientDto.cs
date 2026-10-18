namespace Session09.App.Dtos;

// Part 1 - Q3: Positional record that exposes ONLY Id, FullName, PhoneNumber.
// MedicalHistory is sensitive, so it is intentionally left out.
// A record gives us: properties, value-based Equals/GetHashCode, and a readable ToString for free.
public record PatientDto(int Id, string FullName, string PhoneNumber);

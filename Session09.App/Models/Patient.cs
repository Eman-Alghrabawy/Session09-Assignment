namespace Session09.App.Models;

// Part 1 - Q1: Patient class with a PRIMARY CONSTRUCTOR (C# 12).
// The parameters (Id, FullName, PhoneNumber, MedicalHistory) are declared right on the class line.
// NOTE: in a normal class, primary-constructor parameters are NOT properties; they are captured
// and can be used inside the class body (like in ToString below).
public class Patient(int Id, string FullName, string PhoneNumber, string MedicalHistory)
{
    // Expose read-only values so other classes (like PatientMapper) can read them.
    public int PatientId { get; } = Id;
    public string PatientFullName { get; } = FullName;
    public string PatientPhoneNumber { get; } = PhoneNumber;
    public string PatientMedicalHistory { get; } = MedicalHistory;

    public override string ToString()
        => $"Id: {Id} :: FullName: {FullName} :: PhoneNumber: {PhoneNumber} :: MedicalHistory: {MedicalHistory}";
}

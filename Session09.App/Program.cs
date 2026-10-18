using Session09.App.Dtos;
using Session09.App.Helpers;
using Session09.App.Logging;
using Session09.App.Mappers;
using Session09.App.Models;

namespace Session09.App;

public class Program
{
    public static void Main(string[] args)
    {
        // =====================================================================
        // PART 1 - Primary Constructor & Records
        // =====================================================================

        // ---------- Q2: Patient (class) comparisons ----------
        Console.WriteLine("===== Part 1 - Q2: Patient (class) =====");

        Patient patient01 = new Patient(1, "Ahmed Ali", "0100000000", "Diabetes");
        Patient patient02 = new Patient(1, "Ahmed Ali", "0100000000", "Diabetes");

        // 1) GetHashCode of both
        Console.WriteLine($"patient01 hash: {patient01.GetHashCode()}");
        Console.WriteLine($"patient02 hash: {patient02.GetHashCode()}");
        // ANSWER: They are NOT equal. A class uses REFERENCE equality by default, so the hash code
        // is based on the object's identity (memory reference), not on its values.
        // Two different objects = two different references = two different hash codes,
        // even though all their values are identical.

        // 2) Equals
        Console.WriteLine($"patient01.Equals(patient02): {patient01.Equals(patient02)}");
        // ANSWER: False. Equals compares REFERENCES for classes (do both variables point to the same object?).
        // They point to two different objects, so the result is false.

        // 3) Assign patient01 = patient02 then check Equals again
        patient01 = patient02;
        Console.WriteLine($"After assignment -> patient01.Equals(patient02): {patient01.Equals(patient02)}");
        Console.WriteLine($"After assignment -> hash01: {patient01.GetHashCode()} | hash02: {patient02.GetHashCode()}");
        // ANSWER: Now it is True. After the assignment, both variables point to the SAME object in memory,
        // so the references are equal (and the hash codes are equal too).

        Console.WriteLine(patient01);
        Console.WriteLine();

        // ---------- Q3: PatientDto (record) comparisons ----------
        Console.WriteLine("===== Part 1 - Q3: PatientDto (record) =====");

        PatientDto dto01 = new PatientDto(1, "Ahmed Ali", "0100000000");
        PatientDto dto02 = new PatientDto(1, "Ahmed Ali", "0100000000");

        Console.WriteLine($"dto01 hash: {dto01.GetHashCode()}");
        Console.WriteLine($"dto02 hash: {dto02.GetHashCode()}");
        Console.WriteLine($"dto01.Equals(dto02): {dto01.Equals(dto02)}");
        Console.WriteLine($"dto01 == dto02: {dto01 == dto02}");

        dto01 = dto02;
        Console.WriteLine($"After assignment -> dto01.Equals(dto02): {dto01.Equals(dto02)}");
        // EXPLANATION (class vs record):
        // - Class  -> REFERENCE equality: two objects with the same values are NOT equal
        //             (different hash codes, Equals = false) unless they are the same object.
        // - Record -> VALUE equality: two objects with the same values ARE equal
        //             (same hash codes, Equals = true, == = true), even if they are different objects.
        // After assigning dto01 = dto02 nothing changes for the record, because it was already equal by value.
        // Records also generate a readable ToString() automatically.
        Console.WriteLine();

        // ---------- Q4: PatientMapper ----------
        Console.WriteLine("===== Part 1 - Q4: PatientMapper =====");

        Patient patientToMap = new Patient(2, "Mona Hassan", "0111111111", "Asthma");
        PatientDto mappedDto = PatientMapper.MapFromModelToDto(patientToMap);
        Console.WriteLine(mappedDto); // MedicalHistory is not exposed
        Console.WriteLine();

        // =====================================================================
        // PART 2 - Singleton
        // =====================================================================
        Console.WriteLine("===== Part 2 - Q6: Singleton (AppLogger) =====");

        // Q6: call GetLogger() four times and print the hash code of each result
        AppLogger logger01 = AppLogger.GetLogger();
        AppLogger logger02 = AppLogger.GetLogger();
        AppLogger logger03 = AppLogger.GetLogger();
        AppLogger logger04 = AppLogger.GetLogger();

        Console.WriteLine($"logger01 hash: {logger01.GetHashCode()}");
        Console.WriteLine($"logger02 hash: {logger02.GetHashCode()}");
        Console.WriteLine($"logger03 hash: {logger03.GetHashCode()}");
        Console.WriteLine($"logger04 hash: {logger04.GetHashCode()}");
        // OBSERVATION: All four hash codes are IDENTICAL.
        // WHY: The constructor is private, so no one can create new instances from outside.
        // GetLogger() creates the object only on the first call (when _instance is null) and returns that
        // same stored instance on every next call. So all four variables point to ONE single object.
        Console.WriteLine();

        // =====================================================================
        // PART 3 - var & dynamic
        // =====================================================================
        Console.WriteLine("===== Part 3 - Q7: var & dynamic =====");

        // 1) Target-typed new: the type is written on the left, "new(...)" infers it from the target.
        Patient p = new(3, "Omar Khaled", "0122222222", "Hypertension");
        Console.WriteLine(p);

        // 2) var: the compiler infers the type (Patient) from the right side.
        var patientWithVar = new Patient(4, "Salma Samir", "0133333333", "None");
        Console.WriteLine(patientWithVar);

        // 3) dynamic: assign a Patient and print it.
        dynamic patientDynamic = new Patient(5, "Youssef Adel", "0144444444", "Allergy");
        Console.WriteLine(patientDynamic);

        // 4) EXPLANATION:
        // - var     -> resolved at COMPILE TIME. The compiler decides the type once (Patient) and it is
        //              fixed afterwards. You get IntelliSense and compile-time error checking.
        // - dynamic -> resolved at RUN TIME. The compiler skips type checking, and member access is
        //              checked only when the code runs. A wrong member name compiles fine
        //              but throws an exception at run time. The variable can also hold different types later.
        Console.WriteLine();

        // =====================================================================
        // PART 4 - Anonymous Types
        // =====================================================================
        Console.WriteLine("===== Part 4 - Q8: Anonymous Types =====");

        var doctor01 = new { Name = "Sara", Specialty = "Cardiology", ExperienceYears = 8, Salary = 25_000 };
        var doctor02 = new { Name = "Sara", Specialty = "Cardiology", ExperienceYears = 8, Salary = 25_000 };

        // 1) Name and Specialty
        Console.WriteLine($"Name: {doctor01.Name}, Specialty: {doctor01.Specialty}");
        // 2) Hash codes
        Console.WriteLine($"doctor01 hash: {doctor01.GetHashCode()}");
        Console.WriteLine($"doctor02 hash: {doctor02.GetHashCode()}");
        // 3) Type
        Console.WriteLine($"doctor01 type: {doctor01.GetType()}");
        // 4) Equals
        Console.WriteLine($"doctor01.Equals(doctor02): {doctor01.Equals(doctor02)}");
        // 5) ToString
        Console.WriteLine($"doctor01.ToString(): {doctor01.ToString()}");
        // COMPARISON:
        // - Anonymous type -> VALUE equality (like a record): the compiler generates Equals/GetHashCode
        //                     that compare all properties. doctor01.Equals(doctor02) = true and hashes are equal
        //                     (same property names, types, and order => same generated type).
        //                     Its properties are READ-ONLY and it cannot have methods.
        // - Class          -> REFERENCE equality by default: same values but different objects = false.
        // - Record         -> VALUE equality: same values = true (and == works too).
        Console.WriteLine();

        // =====================================================================
        // PART 5 - Extension Methods
        // =====================================================================
        Console.WriteLine("===== Part 5 - Q10: Extension Methods =====");

        bool isShorter = "Stethoscope".IsShorterThan(5);
        string repeated = "Ab".Repeat(4);

        Console.WriteLine($"\"Stethoscope\".IsShorterThan(5) => {isShorter}"); // False (length 11 is not less than 5)
        Console.WriteLine($"\"Ab\".Repeat(4) => {repeated}");                  // AbAbAbAb
    }
}

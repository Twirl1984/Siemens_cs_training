using System;
using System.Globalization;

static class Appointment
{
    // REQ-001: Schedule - Parsen von Datumsstrings (en-US Kultur)
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription, CultureInfo.GetCultureInfo("en-US"));
    }

    // REQ-002: HasPassed - zu implementieren
    public static bool HasPassed(DateTime appointmentDate)
    {
        throw new NotImplementedException();
    }

    // REQ-003: IsAfternoonAppointment - zu implementieren
    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        throw new NotImplementedException();
    }

    // REQ-004: Description - zu implementieren
    public static string Description(DateTime appointmentDate)
    {
        throw new NotImplementedException();
    }

    // REQ-005: AnniversaryDate - zu implementieren
    public static DateTime AnniversaryDate()
    {
        throw new NotImplementedException();
    }
}

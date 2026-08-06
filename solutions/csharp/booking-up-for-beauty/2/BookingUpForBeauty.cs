using System;
using System.Globalization;

static class Appointment
{
    // REQ-001: Schedule - Parsen von Datumsstrings (en-US Kultur)
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription, CultureInfo.GetCultureInfo("en-US"));
    }

    // REQ-002: HasPassed - Prüfen ob Termin in der Vergangenheit liegt
    public static bool HasPassed(DateTime appointmentDate)
    {
        return appointmentDate < DateTime.Now;
    }

    // REQ-003: IsAfternoonAppointment - Prüfen ob Termin am Nachmittag ist (12:00-17:59)
    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        return appointmentDate.Hour >= 12 && appointmentDate.Hour < 18;
    }

    // REQ-004: Description - Generieren einer Terminbeschreibung
    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate.ToString(CultureInfo.GetCultureInfo("en-US"))}.";
    }

    // REQ-005: AnniversaryDate - Jahrestag: 15. September des aktuellen Jahres
    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year, 9, 15);
    }
}

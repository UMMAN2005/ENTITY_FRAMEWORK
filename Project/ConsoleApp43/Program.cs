using System.Text;
using Service.Services;
using Service.Extensions;
using static Service.Extensions.SpecialPrints;
using static Service.Extensions.Utilities;
using Core.Models;
using System.Collections;
/*
ConsoleColor red = ConsoleColor.Red;
ConsoleColor green = ConsoleColor.Green;
ConsoleColor blue = ConsoleColor.Blue;
ConsoleColor cyan = ConsoleColor.Cyan;

AppointmentService appointmentService = new();
DoctorService doctorService = new();
PatientService patientService = new();

FilterResults filterResults = new();

Console.Clear();
PrintStart(ASCII.text);
Console.OutputEncoding = Encoding.UTF8;
Console.CursorVisible = false;

string decorator = "✅ \u001b[32m";
ConsoleKeyInfo key;
int option = 1;
int filterOption = 1;

do {
    Console.CursorVisible = false;
    Console.WriteLine("Use W/⬆️  and S/⬇️  to navigate and press \u001b[32mEnter/Return\u001b[0m to select:");
    (int left, int top) = Console.GetCursorPosition();
    option = GetSelectedOption(left, top);
    Console.Clear();
    ProcessOption();
} while (option != 13);


void ProcessOption() {
    Doctor doctor = new();
    Patient patient = new();
    Appointment appointment = new();
    Console.CursorVisible = true;
    switch (option) {
        case 1:
            patientService.Add(CreatePatient(patient));
            break;
        case 2:
            try { patientService.Delete(GetId()); }
            catch (Exception ex) { ColorPrintLine(ex.Message, red); }
            break;
        case 3:
            try { patientService.Update(GetId(), CreatePatient(patient)); }
            catch (Exception ex) { ColorPrintLine(ex.Message, red); }
            break;
        case 4:
            var patientAppointments = patientService.SpecialGetAll();
            foreach (var item in patientAppointments)
                Console.WriteLine($"\u001b[34mId: {item.Id}, " +
                    $"FullName: {item.FullName}, " +
                    $"Email: {item.Email}, " +
                    $"AppointmentCount: {item.AppointmentCount}, " +
                    $"NextAppointmentDate: {item.NextAppointmentDate}\u001B[0m");
            break;
        case 5:
            doctorService.Add(CreateDoctor(doctor));
            break;
        case 6:
            try { doctorService.Delete(GetId()); }
            catch (Exception ex) { ColorPrintLine(ex.Message, red); }
            break;
        case 7:
            try { doctorService.Update(GetId(), CreateDoctor(doctor)); }
            catch (Exception ex) { ColorPrintLine(ex.Message, red); }
            break;
        case 8:
            var doctorAppointments = doctorService.SpecialGetAll();
            foreach (var item in doctorAppointments)
                Console.WriteLine($"\u001b[34mId: {item.Id}, " +
                    $"FullName: {item.FullName}, " +
                    $"Email: {item.Email}, " +
                    $"AppointmentCount: {item.AppointmentCount}\u001B[0m");
            break;
        case 9:
            try { appointmentService.Add(CreateAppointment(appointment)); }
            catch (Exception ex) { ColorPrintLine(ex.Message, red); }
            break;
        case 10:
            try { appointmentService.Delete(GetId()); }
            catch (Exception ex) { ColorPrintLine(ex.Message, red); }
            break;
        case 11:
            appointmentService.GetAll().ForEach(x => Console.WriteLine($"\u001b[34m {x} \u001B[0m"));
            break;
        case 12:
            Console.CursorVisible = false;
            Console.WriteLine("Use W/⬆️  and S/⬇️  to navigate and press \u001b[32mEnter/Return\u001b[0m to select:");
            (int left, int top) = Console.GetCursorPosition();
            filterOption = GetSelectedFilterOption(left, top);
            Console.Clear();
            ShowFilterMenu(ref filterOption, decorator);
            FulFillFilterResults(filterOption);
            var filteredAppointments = appointmentService.FilterAppointments(filterResults);
            foreach (var item in filteredAppointments)
                Console.WriteLine($"\u001b[34m{item}\u001B[0m");
            break;
        case 13:
            ColorPrint("Goodbye!", green);
            break;
        default:
            break;
    }
}

void FulFillFilterResults(int filterOption) {
    Console.Clear();
    Console.CursorVisible = true;
    filterResults = new();
    switch(filterOption) {
        case 1:
            filterResults.StartDate = GetDate("Enter Start Date: ");
            filterResults.EndDate = GetDate("Enter End Date: ");
            break;
        case 2:
            filterResults.DoctorId = GetId("Enter doctor's Id: ");
            break;
        case 3:
            filterResults.PatientId = GetId("Enter patient's Id: ");
            break;
        case 4:
            filterResults.StartDate = GetDate("Enter Start Date: ");
            filterResults.EndDate = GetDate("Enter End Date: ");
            filterResults.DoctorId = GetId("Enter doctor's Id: ");
            break;
        case 5:
            filterResults.StartDate = GetDate("Enter Start Date: ");
            filterResults.EndDate = GetDate("Enter End Date: ");
            filterResults.PatientId = GetId("Enter patient's Id: ");
            break;
        case 6:
            filterResults.DoctorId = GetId("Enter doctor's Id: ");
            filterResults.PatientId = GetId("Enter patient's Id: ");
            break;
        case 7:
            filterResults.StartDate = GetDate("Enter Start Date: ");
            filterResults.EndDate = GetDate("Enter End Date: ");
            filterResults.DoctorId = GetId("Enter doctor's Id: ");
            filterResults.PatientId = GetId("Enter patient's Id: ");
            break;
        default:
            break;
    }
}

int GetSelectedOption(int left, int top) {
    int option = 1;
    bool isSelected = false;
    ConsoleKeyInfo key;

    while (!isSelected) {
        Console.SetCursorPosition(left, top);
        ShowMenu(ref option, decorator);
        key = Console.ReadKey(false);
        switch (key.Key) {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                option = option == 1 ? 13 : option - 1;
                break;

            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                option = option == 13 ? 1 : option + 1;
                break;

            case ConsoleKey.Enter:
                isSelected = true;
                Console.Beep();
                break;
        }
    }
    return option;
}

int GetSelectedFilterOption(int left, int top) {
    int filterOption = 1;
    bool isSelected = false;
    ConsoleKeyInfo key;

    while (!isSelected) {
        Console.SetCursorPosition(left, top);
        ShowFilterMenu(ref filterOption, decorator);
        key = Console.ReadKey(false);
        switch (key.Key) {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                filterOption = filterOption == 1 ? 7 : filterOption - 1;
                break;

            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                filterOption = filterOption == 7 ? 1 : filterOption + 1;
                break;

            case ConsoleKey.Enter:
                isSelected = true;
                Console.Beep();
                break;
        }
    }
    return filterOption;
}

static void ShowMenu(ref int option, string decorator) {
    Console.WriteLine($"{(option == 1 ? decorator : "   ")}1.1 Patient create\u001b[0m");
    Console.WriteLine($"{(option == 2 ? decorator : "   ")}1.2.Patient delete\u001b[0m");
    Console.WriteLine($"{(option == 3 ? decorator : "   ")}1.3.Patient edit\u001b[0m");
    Console.WriteLine($"{(option == 4 ? decorator : "   ")}1.4.Show all patients\u001b[0m");
    Console.WriteLine($"{(option == 5 ? decorator : "   ")}2.1.Doctor create\u001b[0m");
    Console.WriteLine($"{(option == 6 ? decorator : "   ")}2.2.Doctor delete\u001b[0m");
    Console.WriteLine($"{(option == 7 ? decorator : "   ")}2.3 Doctor edit\u001b[0m");
    Console.WriteLine($"{(option == 8 ? decorator : "   ")}2.4 Show all doctors\u001b[0m");
    Console.WriteLine($"{(option == 9 ? decorator : "   ")}3.1.Make an appointment\u001b[0m");
    Console.WriteLine($"{(option == 10 ? decorator : "   ")}3.2 Cancel an appointment\u001b[0m");
    Console.WriteLine($"{(option == 11 ? decorator : "   ")}3.3 Show all appointments\u001b[0m");
    Console.WriteLine($"{(option == 12 ? decorator : "   ")}3.4 Filter appointments\u001b[0m");
    Console.WriteLine($"{(option == 13 ? decorator : "   ")}0 Exit\u001b[0m");
}

static void ShowFilterMenu(ref int filterOption, string decorator) {
    Console.WriteLine($"{(filterOption == 1 ? decorator : "   ")}1. Filter by date\u001b[0m");
    Console.WriteLine($"{(filterOption == 2 ? decorator : "   ")}2. Filter by doctor\u001b[0m");
    Console.WriteLine($"{(filterOption == 3 ? decorator : "   ")}3. Filter by patient\u001b[0m");
    Console.WriteLine($"{(filterOption == 4 ? decorator : "   ")}4. Filter by date and doctor\u001b[0m");
    Console.WriteLine($"{(filterOption == 5 ? decorator : "   ")}5. Filter by date and patient\u001b[0m");
    Console.WriteLine($"{(filterOption == 6 ? decorator : "   ")}6. Filter by doctor and patient\u001b[0m");
    Console.WriteLine($"{(filterOption == 7 ? decorator : "   ")}7. Filter by date, doctor and patient\u001b[0m");
}

Appointment CreateAppointment(Appointment appointment) {
    doctorService.GetAll().ForEach(x => Console.WriteLine($"\u001B[32m{x}\u001B[0m"));
    appointment.DoctorId = GetId("Enter doctor's Id: ");
    patientService.GetAll().ForEach(x => Console.WriteLine($"\u001B[32m{x}\u001B[0m"));
    appointment.PatientId = GetId("Enter patient's Id: ");
    DateTime startDate;
    do {
        ColorPrint("Enter appointment's StartDate: ", ConsoleColor.Blue);
    } while (!DateTime.TryParse(Console.ReadLine(), out startDate));
    appointment.StartDate = startDate;
    return appointment;
}

*/
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

class Program {
    static void Main() {
        // Sample data
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Create an IQueryable from the data source
        IQueryable<int> queryableData = numbers.AsQueryable();

        // Call the function with a null expression
        var filteredData = FilterData(queryableData, x => x > 11);

        // Execute the query
        foreach (var item in filteredData) {
            Console.WriteLine(item);
        }
    }

    static IQueryable<int> FilterData(IQueryable<int> query, Expression<Func<int, bool>> expression = null) {
        if (expression != null) {
            // Apply the expression to filter the query
            query = query.Where(expression);
            Console.WriteLine(query is null);
        }

        return null;
    }
}

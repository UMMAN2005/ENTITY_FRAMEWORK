using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Models;
using Service.Services;
using static Service.Extensions.SpecialPrints;

namespace Service.Extensions {

    public static class Utilities {

        public static Doctor CreateDoctor(Doctor doctor) {
            do {
                ColorPrint("Enter doctor's FullName: ", ConsoleColor.Blue);
                doctor.FullName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(doctor.FullName) || !IsCorrectFullName(doctor.FullName));
            do {
                ColorPrint("Enter doctor's Email: ", ConsoleColor.Blue);
                doctor.Email = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(doctor.Email) || !IsCorrectEmail(doctor.Email));
            return doctor;
        }

        public static Patient CreatePatient(Patient patient) {
            do {
                ColorPrint("Enter patient's FullName: ", ConsoleColor.Blue);
                patient.FullName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(patient.FullName) || !IsCorrectFullName(patient.FullName));
            do {
                ColorPrint("Enter patient's Email: ", ConsoleColor.Blue);
                patient.Email = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(patient.Email) || !IsCorrectEmail(patient.Email));
            return patient;
        }

        public static int GetId(string text = null) {
            int id;
            do {
                ColorPrint(text ?? "Enter Id: ", ConsoleColor.Blue);
            } while (!int.TryParse(Console.ReadLine(), out id) && id > 0);
            return id;
        }

        public static DateTime GetDate(string text = null) {
            DateTime date;
            do {
                ColorPrint(text ?? "Enter date: ", ConsoleColor.Blue);
            } while (!DateTime.TryParse(Console.ReadLine(), out date));
            return date;
        }

        public static bool IsCorrectEmail(string email) {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }

        public static bool IsCorrectFullName(string fullName) {
            bool isFullName = Regex.IsMatch(fullName, @"^[A-Z][a-z]*(\s[A-Z][a-z]*)+$", RegexOptions.IgnoreCase);
            return isFullName;
        }
    }
}

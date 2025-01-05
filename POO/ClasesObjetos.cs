using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public class MedicalAppoiment
    {
        private string Patient { get; set; }
        private string Symptoms { get; set; }
        private DateTime Date { get; set; }
        private string Doctor { get; set; }
        private string Specialty { get; set; }
        private string Room { get; set; }

        public MedicalAppoiment(string patient, string symptoms, DateTime date, string doctor, string specialty, string room)
        {
            Patient = patient;
            Symptoms = symptoms;
            Date = date;
            Doctor = doctor;
            Specialty = specialty;
            Room = room;
        }

        public string GetInfo()
        {
            return $"The patient {Patient} with the symptoms {Symptoms}\n" +
                   $"Will be attended to {Date} with the doctor {Doctor}\n" +
                   $" specialty in {Specialty}, in the room {Room}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public class MedicalAppoiment
    {
        private string _patient { get; set; }
        private string _symptoms { get; set; }
        private DateTime _date { get; set; }
        private string _doctor { get; set; }
        private string _specialty { get; set; }
        private string _room { get; set; }

        public MedicalAppoiment(string patient, string symptoms, DateTime date, string doctor, string specialty, string room)
        {
            _patient = patient;
            _symptoms = symptoms;
            _date = date;
            _doctor = doctor;
            _specialty = specialty;
            _room = room;
        }

        public string GetInfo()
        {
            return $"The patient {_patient} with the symptoms {_symptoms}\n" +
                   $"Will be attended to {_date} with the doctor {_doctor}\n" +
                   $" specialty in {_specialty}, in the room {_room}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSystem.Model
{
    internal class Appointment
    {
        private int appointmentId;
        private int patientId;
        private int doctorId;
        private DateTime appointmentDate;
        private string description;

        // Public properties to provide access to the attributes

        public int AppointmentId
        {
            get { return appointmentId; }
            set { appointmentId = value; }
        }

        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        public int DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; }
        }

        public DateTime AppointmentDate
        {
            get { return appointmentDate; }
            set { appointmentDate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public Appointment()
        {

        }
        public Appointment(int appointmentId, DateTime appointmentDate)
        {
            this.appointmentId = appointmentId;
            this.appointmentDate = appointmentDate;
        }
        // Additional constructor for initializing attributes
        public Appointment(int appointmentId, int patientId, int doctorId, DateTime appointmentDate, string description)
        {
            this.appointmentId = appointmentId;
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.appointmentDate = appointmentDate;
            this.description = description;
        }
        public override string ToString()
        {
            return $"AppointmentID: {AppointmentId}, PatientID: {PatientId}, DoctorID: {DoctorId}, AppointmentDate: {AppointmentDate}, Description: {Description}";
        }
    }
}

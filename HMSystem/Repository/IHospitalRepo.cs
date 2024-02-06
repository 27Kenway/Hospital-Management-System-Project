using HMSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSystem.Repository
{
    internal interface IHospitalRepo
    {
        Appointment getAppointmentById(int AppointmentId);

        List<Appointment> GetAppointmentsForPatient(int patientid);

        List<Appointment> GetAppointmentsForDoctor(int doctorid);

        bool ScheduleAppointment(Appointment appointment);

        bool UpdateAppointment( Appointment appointment);

        bool CancelAppointment(int appointmentid);

    }
}

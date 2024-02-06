using HMSystem.Exception;
using HMSystem.Model;
using HMSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HMSystem.Service
{
    internal class HospitalService : IHospitalService
    {
        readonly IHospitalRepo _hospitalRepo;
        public HospitalService()
        {
            _hospitalRepo = new HospitalRepo();
        }
        public void getAppointmentById()
        {
            Console.WriteLine("Enter Appointment:: ");
            int AppointmentID = int.Parse(Console.ReadLine());

            Appointment getAppointment = _hospitalRepo.getAppointmentById(AppointmentID);
            if (getAppointment.Equals(null))
            {
                Console.WriteLine("No record found");
            }
            else
            {
                Console.WriteLine(getAppointment.ToString());
            }
        }

        public void GetAppointmentsForPatient()
        {
            Console.WriteLine("Enter PatientID::");
            int patientid = int.Parse(Console.ReadLine());
            
            List<Appointment> getPatientAppointments = _hospitalRepo.GetAppointmentsForPatient(patientid);
            try
            {

                if (getPatientAppointments.Any())
                {
                    foreach (var item in getPatientAppointments)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No record found");
                }
            }
            catch(PatientNumberNotFoundException Pnex)
            {
                Console.WriteLine(Pnex.Message);
            }
        }
        public void GetAppointmentsForDoctor()
        {
            Console.WriteLine("Enter DoctorID::");
            int doctorid = int.Parse(Console.ReadLine());

            List<Appointment> getDoctorAppointment = _hospitalRepo.GetAppointmentsForDoctor(doctorid);
            if (getDoctorAppointment.Any())
            {
                foreach(var item in getDoctorAppointment)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("No record found");
            }
        }

        public void ScheduleAppointment()
        {
            Appointment appointment = new Appointment();
            Console.WriteLine("Enter PatientID::");
            appointment.PatientId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter DoctorID::");
            appointment.DoctorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter AppointmentDate::");
            appointment.AppointmentDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Description::");
            appointment.Description = (Console.ReadLine());

            bool newSchedule = _hospitalRepo.ScheduleAppointment(appointment);
            if(newSchedule)
            {
                Console.WriteLine("New Appointment is Schedule");
            }
            else
            {
                Console.WriteLine("Failed!! No new Appointment is Schedule");
            }

        }

        public void UpdateAppointment()
        {
            Console.WriteLine("Enter AppointmentID::");
            int appointmentid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the AppointDate to Reschedule::");
            DateTime appointmentDate = DateTime.Parse(Console.ReadLine());
            Appointment appointment = new Appointment(appointmentid,appointmentDate);

            bool updateAppointmentDate = _hospitalRepo.UpdateAppointment(appointment);
            if(updateAppointmentDate)
            {
                Console.WriteLine("Reschedule AppointmentDate is successfull");
            }
            else
            {
                Console.WriteLine("Failed!! Reschedule AppointmentDate is unsuccessfull");
            }
        }

        public void CancelAppointment()
        {
            Console.WriteLine("Enter AppointmentID to Cancel the Appointment::");
            int appointmentid = int.Parse(Console.ReadLine());

            bool cancelAppointment = _hospitalRepo.CancelAppointment(appointmentid);
            if(cancelAppointment)
            {
                Console.WriteLine("Appointment Cancel Successfully");
            }
            else
            {
                Console.WriteLine("Failed!! Appointment Cancel Unsuccessfully");
            }
        }
    }
}

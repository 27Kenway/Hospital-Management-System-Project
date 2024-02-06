using HMSystem.Exception;
using HMSystem.Service;

namespace HMSystem
{
    internal class MainModule
    {
        static void Main(string[] args)
        {
            try
            {

                IHospitalService hospitalService = new HospitalService();

                string choice;
                do
                {
                    Console.WriteLine("Welcome to Hospital Management System");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1. Get Appointment by AppointmentID");
                    Console.WriteLine("2. Get Appointment by PatientID");
                    Console.WriteLine("3. Get Appointment by DoctorID");
                    Console.WriteLine("4. Schedule new Appointment");
                    Console.WriteLine("5. Reschedule new Appointment");
                    Console.WriteLine("6. Cancel Appointment");
                    Console.WriteLine("7. Exits");
                    Console.WriteLine("------------------------------------------");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            hospitalService.getAppointmentById();
                            break;

                        case "2":
                            hospitalService.GetAppointmentsForPatient();
                            break;

                        case "3":
                            hospitalService.GetAppointmentsForDoctor();
                            break;

                        case "4":
                            hospitalService.ScheduleAppointment();
                            break;

                        case "5":
                            hospitalService.UpdateAppointment();
                            break;

                        case "6":
                            hospitalService.CancelAppointment();
                            break;
                        case "7":
                            Console.WriteLine("Exiting the program.");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice. Please try again.");
                            break;
                    }
                } while (choice != "7");

            }
            catch (PatientNumberNotFoundException Pnex)
            {
                Console.WriteLine(Pnex.Message);
            }
            }
    }
}

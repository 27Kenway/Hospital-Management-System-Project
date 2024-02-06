using HMSystem.Model;
using HMSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HMSystem.Repository
{
    internal class HospitalRepo:IHospitalRepo
    {
        public string connectionString;
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;
        public HospitalRepo()
        {
            connectionString = DBConnection.GetConnectionString();
            cmd = new SqlCommand();
        }

        public Appointment getAppointmentById(int AppointmentId)
        {
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {


                cmd.CommandText = "Select * from Appointment Where Appointmentid = @appointment";
                cmd.Parameters.AddWithValue("@appointment", AppointmentId);


                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();

                    int appointmentId = reader.GetInt32(reader.GetOrdinal("AppointmentId"));
                    int patientId = reader.GetInt32(reader.GetOrdinal("PatientId"));
                    int doctorId = reader.GetInt32(reader.GetOrdinal("DoctorId"));
                    string Description = reader.GetString(reader.GetOrdinal("Description"));
                    DateTime AppointmentDate = reader.GetDateTime(reader.GetOrdinal("AppointmentDate"));


                    return new Appointment(appointmentId, patientId, doctorId, AppointmentDate, Description);
                }

            }
        }

        

        public List<Appointment> GetAppointmentsForPatient(int patientid)
        {
            List<Appointment> appointments = new List<Appointment>();
            using(SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "Select * from Appointment where patientid =@patientid";
                cmd.Parameters.AddWithValue("@patientid", patientid);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int appointmentId = reader.GetInt32(reader.GetOrdinal("AppointmentId"));
                        int patientId = reader.GetInt32(reader.GetOrdinal("PatientId"));
                        int doctorId = reader.GetInt32(reader.GetOrdinal("DoctorId"));
                        string Description = reader.GetString(reader.GetOrdinal("Description"));
                        DateTime AppointmentDate = reader.GetDateTime(reader.GetOrdinal("AppointmentDate"));

                        appointments.Add(new Appointment(appointmentId, patientId, doctorId, AppointmentDate, Description));

                    }
                }
                return appointments;
            }
        }
        public List<Appointment> GetAppointmentsForDoctor(int doctorid)
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "Select * from Appointment where doctorid =@doctorid";
                cmd.Parameters.AddWithValue("@doctorid", doctorid);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int appointmentId = reader.GetInt32(reader.GetOrdinal("AppointmentId"));
                        int patientId = reader.GetInt32(reader.GetOrdinal("PatientId"));
                        int doctorId = reader.GetInt32(reader.GetOrdinal("DoctorId"));
                        string Description = reader.GetString(reader.GetOrdinal("Description"));
                        DateTime AppointmentDate = reader.GetDateTime(reader.GetOrdinal("AppointmentDate"));

                        appointments.Add(new Appointment(appointmentId, patientId, doctorId, AppointmentDate, Description));

                    }
                }
                return appointments;
            }
        }

        public bool ScheduleAppointment(Appointment appointment)
        {
            using(SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "insert into Appointment values(@patientid,@doctorid,@appointmentDate,@description)";
                cmd.Parameters.AddWithValue("@patientid", appointment.PatientId);
                cmd.Parameters.AddWithValue("@doctorid", appointment.DoctorId);
                cmd.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate );
                cmd.Parameters.AddWithValue("@description", appointment.Description);

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                int newSchedule = cmd.ExecuteNonQuery();

                return newSchedule==0? false : true;
            }
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            using( SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "Update Appointment set AppointmentDate = @appointmentDate where appointmentid = @appointmentid";
                cmd.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate);
                cmd.Parameters.AddWithValue("@appointmentId", appointment.AppointmentId);

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                int updateAppointmentDate = cmd.ExecuteNonQuery();

                return updateAppointmentDate == 0 ? false : true;
            }
        }

        public bool CancelAppointment(int appointmentid)
        {
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "Delete from Appointment where appointmentid = @appointmentid";
                cmd.Parameters.AddWithValue("@appointmentid", appointmentid);

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                int cancelAppointment = cmd.ExecuteNonQuery();

                return cancelAppointment == 0 ? false : true;
            }
        }
    }
}

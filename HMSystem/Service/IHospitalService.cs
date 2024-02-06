using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSystem.Service
{
    internal interface IHospitalService
    {
        public void getAppointmentById();

        public void GetAppointmentsForPatient();

        public void GetAppointmentsForDoctor();

        public void ScheduleAppointment();

        public void UpdateAppointment();

        public void CancelAppointment();
    }
}

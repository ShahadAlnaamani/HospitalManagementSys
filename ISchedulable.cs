using System;
namespace HospitalManagementSys
{
	public interface ISchedulable
    {
        void ScheduleEvent(Patient patient, Doctor doctor, DateTime appointmentDate, TimeSpan appointmentTime, bool book);



        void CancelEvent(Appointment appointment);

    }
}

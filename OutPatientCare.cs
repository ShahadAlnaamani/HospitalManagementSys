using System;

namespace HospitalManagementSys
{
    public interface IOutPatientCare : IPatientCare
    {
        public void ScheduleFollowUp(DateTime day, DateOnly date, TimeSpan time, Patient patient);
    }
}
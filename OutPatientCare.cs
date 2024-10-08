using System;

namespace HospitalManagementSys
{
    public interface IOutPatientCare : IPatientCare
    {
        public void ScheduleFollowUp();
    }
}
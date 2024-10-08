using System;

namespace HospitalManagementSys
{
	public interface IInPatientCare : IPatientCare 
	{
		void AssignRoom(Patient patient);

		void Discharge(Patient patient);
    }
}
namespace DataAccess.Models
{
	public class EmployeeDto
	{
		public string staffNumber { get; set; }
		public string birthDate { get; set; }
		public string hiredDate { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string identityNumber { get; set; }
		public string workEmail { get; set; }
		public string phone { get; set; }
		public string gender { get; set; }
		public string language { get; set; }
		public string placeOfBirth { get; set; }
		public string bloodType { get; set; }
		public string militaryService { get; set; }
		public string unit { get; set; }
		public string branch { get; set; }
		public string team { get; set; }
		public string jobInfo { get; set; }
		public string collarType { get; set; }
		public string company { get; set; }
		public string manager { get; set; }
		public string role { get; set; }
		//public List<HrManager> hrManagers { get; set; }

	}
	public class HrManager
	{
		public int rank { get; set; }
		public bool editor { get; set; }
		public string manager { get; set; }
	}
}

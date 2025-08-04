namespace DemoApis.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public DateTime EmpDOB { get;set; }
        public DateTime EmpJoinDate { get;set; }
        public string EmpUserName { get;set; }
        public string EmpPassword { get; set; } 
        public string EmpEmailId { get; set; }
        public string EmpPhoneNo { get;set; }
        public int DeptId { get;set; }
        public int EmpDesignationId { get;set; }
        public string ? EmpProfileImage { get; set; }


    }
}

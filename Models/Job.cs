namespace SAKD.Models
{
    public class Job: BaseDbObject
    {
        public Employment MainJob { get; set; }
        public Employment AdditionalJob { get; set; }
        public double MainSalary { get; set; }
        public double AdditionalSalary { get; set; }
        public int WorkExperience { get; set; }
        public string SalaryBank { get; set; }
    }
}

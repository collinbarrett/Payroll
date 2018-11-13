namespace Payroll.Core.Entities
{
    public class Dependent : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public decimal BenefitsDeduction { get; set; }
    }
}
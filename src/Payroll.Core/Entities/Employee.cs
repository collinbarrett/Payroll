namespace Payroll.Core.Entities
{
    public class Employee : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public decimal Salary { get; set; } = 2000 * 26;
    }
}
using System.Collections.Generic;

namespace Payroll.Core.Entities
{
    public class Employee : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public ICollection<Dependent> Dependents { get; set; }
        public decimal Salary { get; set; }
        public decimal BenefitsDeduction { get; set; }
    }
}
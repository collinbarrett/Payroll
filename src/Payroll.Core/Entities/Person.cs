using System.ComponentModel;

namespace Payroll.Core.Entities
{
    public class Person : BaseEntity
    {
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
    }
}
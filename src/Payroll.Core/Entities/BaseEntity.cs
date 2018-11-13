using System;

namespace Payroll.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? DateCreatedUtc { get; set; }
        public DateTime? DateModifiedUtc { get; set; }
    }
}
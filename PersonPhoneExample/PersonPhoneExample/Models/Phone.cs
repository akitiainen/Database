using System;
using System.Collections.Generic;

namespace PersonPhoneExample.Models
{
    public partial class Phone
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public long? PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
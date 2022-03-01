using System;
using System.Collections.Generic;

namespace BuildingApplication.Models.Building
{
    public partial class Object
    {
        public Object()
        {
            Reading = new HashSet<Reading>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Reading> Reading { get; set; }
    }
}

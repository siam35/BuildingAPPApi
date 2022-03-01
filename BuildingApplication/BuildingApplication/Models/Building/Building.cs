using System;
using System.Collections.Generic;

namespace BuildingApplication.Models.Building
{
    public partial class Building
    {
        public Building()
        {
            Reading = new HashSet<Reading>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Reading> Reading { get; set; }
    }
}

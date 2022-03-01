using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildingApplication.Models.Building
{

    public partial class Reading
    {
        public int Id { get; set; }
        public short BuildingId { get; set; }
        public byte? ObjectId { get; set; }
        public byte DataFieldId { get; set; }
        public decimal Value { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual Building Building { get; set; }
        public virtual DataField DataField { get; set; }
        public virtual Object Object { get; set; }
    }
}

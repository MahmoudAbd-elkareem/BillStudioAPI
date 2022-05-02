using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillStudio.Domain.Entities
{
    public class Studio
    {
        public Guid Id { get; set; }
        public Guid userId { get; set; }
        public string studioType { get; set; }
        public string Adress { get; set; }
    }
}

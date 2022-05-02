using BillStudio.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillStudio.Infrastructure.Configuration
{
    internal class StudioConfiguration
    {

        public void configure(EntityTypeBuilder<Studio> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}

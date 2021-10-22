using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class HappyFridayMap : IEntityTypeConfiguration<HappyFriday>
    {
        public void Configure(EntityTypeBuilder<HappyFriday> builder)
        {
            builder.ToTable("HappyFridays");

            builder.HasKey(prop => prop.Id);

        }
    }
}

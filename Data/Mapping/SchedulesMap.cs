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
    public class SchedulesMap : IEntityTypeConfiguration<Schedules>
    {
        public void Configure(EntityTypeBuilder<Schedules> builder)
        {
            builder.ToTable("Schedules");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Entry)
            .HasConversion(prop => prop, prop => prop)
            .HasColumnName("Entry Time")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.LunchTime)
            .HasConversion(prop => prop, prop => prop)
            .HasColumnName("Lunch Time")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.ReturnLunchTime)
            .HasConversion(prop => prop, prop => prop)
            .HasColumnName("Lunch Return Time")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.DepartureTime)
            .HasConversion(prop => prop, prop => prop)
            .HasColumnName("Departure Time")
            .HasColumnType("varchar(100)");
        }
    }
}
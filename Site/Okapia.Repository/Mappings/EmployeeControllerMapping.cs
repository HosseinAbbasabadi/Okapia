using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okapia.Domain.Models;

namespace Okapia.Repository.Mappings
{
    public class EmployeeControllerMapping : IEntityTypeConfiguration<EmployeeController>
    {
        public void Configure(EntityTypeBuilder<EmployeeController> builder)
        {
            builder.ToTable("EmployeeControllers");
            builder.HasKey(x => x.Id);
        }
    }
}
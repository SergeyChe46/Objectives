using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Objectives.Models;

namespace Objectives.Repositories.Configuration
{
    public class ObjectiveConfiguration : IEntityTypeConfiguration<Objective>
    {
        public void Configure(EntityTypeBuilder<Objective> builder)
        {
            builder.HasData(
                new Objective { Title = "First title", Description = "First description" },
                new Objective { Title = "Second title", Description = "Second description" }
            );
        }
    }
}

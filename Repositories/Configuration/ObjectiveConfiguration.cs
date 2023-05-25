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
        // Данные по умолчанию.
        public void Configure(EntityTypeBuilder<Objective> builder)
        {
            builder.HasData(
                new Objective
                {
                    ObjectiveId = 1,
                    Title = "First title",
                    Description = "First description",
                    Priority = "High"
                },
                new Objective
                {
                    ObjectiveId = 2,
                    Title = "Second title",
                    Description = "Second description",
                    Priority = "Low"
                }
            );
        }
    }
}

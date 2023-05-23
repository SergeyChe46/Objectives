using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Objectives.Models;

namespace Objectives.Repositories.Configuration
{
    public class PerformerConfiguration : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> builder)
        {
            builder.HasData(
                new Performer { Email = "First@mail.ru", Name = "First Name" },
                new Performer { Email = "Second@mail.ru", Name = "Second Name" }
            );
        }
    }
}

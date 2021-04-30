using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class TemaConfiguration : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}

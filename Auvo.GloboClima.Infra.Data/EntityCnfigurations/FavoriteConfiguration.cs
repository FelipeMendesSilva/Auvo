
using Auvo.GloboClima.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BNP.CMM.Infra.EntityConfiguration
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");

            builder.HasKey(p => new { p.UserName, p.FavoriteCountry });

            builder.Property(p => p.UserName)
                   .HasColumnName("UserName")
                   .HasColumnType("varchar(256)")
                   .IsRequired();

            builder.Property(p => p.FavoriteCountry)
                   .HasColumnName("Country")
                   .HasColumnType("varchar(60)")
                   .IsRequired();
        }
    }
}

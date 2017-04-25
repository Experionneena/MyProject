using RI.SolutionOwner.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Data.Mapping
{
    public class CurrencyMap : EntityTypeConfiguration<Currency>
    {
        public CurrencyMap()
        {
            this.HasKey(t => t.Id);
            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id");
            this.Property(t => t.CurrencyName).IsRequired().HasMaxLength(50).HasColumnName("CurrencyName");
            this.Property(t => t.Abbreviation).IsRequired().HasMaxLength(10).HasColumnName("Abbreviation");
            this.Property(t => t.Value).HasColumnName("Value");
            this.ToTable("Currencies");
        }
    }
}

using MexicanBankTest.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MexicanBankTest.DAL.Configurations;

public class ValueConfiguration : IEntityTypeConfiguration<ValueEntity>
{
    public void Configure(EntityTypeBuilder<ValueEntity> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextCBS.Bank.Module.Entities;

namespace NextCBS.Bank.Data.Configurations
{
    public class DepositProductConfiguration : IEntityTypeConfiguration<DepositProducts>
    {
        public void Configure(EntityTypeBuilder<DepositProducts> builder)
        {
            builder.ToTable("deposit_products", "admin");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextCBS.Bank.Module.Entities;

namespace NextCBS.Bank.Data.Configurations
{
    public class LoanProductConfiguration : IEntityTypeConfiguration<LoanProduct>
    {
        public void Configure(EntityTypeBuilder<LoanProduct> builder)
        {
            builder.ToTable("loan_products", "admin");
        }
    }
}

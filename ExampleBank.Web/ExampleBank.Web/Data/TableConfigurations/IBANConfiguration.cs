using ExampleBank.Web.Data.Auditables;
using ExampleBank.Web.Data.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleBank.Web.Data.TableConfigurations
{
    public class IBANConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IIBANEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            var entityInterface = typeof(TEntity).GetInterface(nameof(IIBANEntity), true);
            if (entityInterface is null)
            {
                throw new Exception($"Class : '{typeof(TEntity).Name}' not inherited '{nameof(IAuditableEntity)}'.");
            }

            builder.Property(nameof(IIBANEntity.IBAN))
                .HasMaxLength(50).IsRequired();
        }
    }
}
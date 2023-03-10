using ExampleBank.Web.Data.Auditables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleBank.Web.Data.TableConfigurations
{
    public class AuditableConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IAuditableEntity
    {
        public AuditableConfiguration() : this(256) { }

        public AuditableConfiguration(int maxLength)
        {
            MaxLength = maxLength;
        }

        public int MaxLength { get; }
        
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            var entityType = typeof(TEntity);
            var entityInterface = entityType.GetInterface(nameof(IAuditableEntity), true);

            if (entityInterface is null)
            {
                throw new Exception($"Class : '{entityType.Name}' not inherited '{nameof(IAuditableEntity)}'.");
            }

            builder.Property(nameof(IAuditableEntity.CreatedBy)).HasMaxLength(MaxLength).IsRequired();
            builder.Property(nameof(IAuditableEntity.CreatedDate)).IsRequired();
            builder.Property(nameof(IAuditableEntity.ModifiedBy)).HasMaxLength(MaxLength).IsRequired();
            builder.Property(nameof(IAuditableEntity.ModifiedBy)).IsRequired();
        }
    }
}
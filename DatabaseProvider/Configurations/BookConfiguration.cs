using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseProvider.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book").HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(50);

            builder.HasOne(b => b.Author).WithMany(a => a.Books).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

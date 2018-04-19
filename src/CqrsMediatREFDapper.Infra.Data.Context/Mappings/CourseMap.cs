using CqrsMediatREFDapper.Domain.CourseContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CqrsMediatREFDapper.Infra.Data.Context.Mappings
{
    public sealed class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder
                .Property(x => x.Description)
                .HasMaxLength(1000)
                .IsRequired();
            builder
                .Property(x => x.Price)
                .IsRequired();
            builder
                .Property(x => x.Video)
                .IsRequired();
        }
    }
}

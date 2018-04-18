using CqrsMediatREFDapper.Domain.CourseContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CqrsMediatREFDapper.Infra.Data.Context.Mappings
{
    public sealed class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(x => x.Name.Value)
                .HasMaxLength(100)
                .HasField("Name")
                .IsRequired();
            builder
                .Property(x => x.Description.Value)
                .HasMaxLength(1000)
                .HasField("Description")
                .IsRequired();
            builder
                .Property(x => x.Price)
                .IsRequired();
            builder
                .Property(x => x.Video.Value)
                .HasField("Video")
                .IsRequired();
        }
    }
}

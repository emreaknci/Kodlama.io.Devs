// <auto-generated />
using Kodlama.io.Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220908143216_Mig_techAdded")]
    partial class Mig_techAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Java"
                        },
                        new
                        {
                            Id = 3,
                            Name = "JavaScript"
                        });
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LanguageId")
                        .HasColumnType("int")
                        .HasColumnName("LanguageId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Technologies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LanguageId = 1,
                            Name = "WPF"
                        },
                        new
                        {
                            Id = 2,
                            LanguageId = 1,
                            Name = "ASP.NET"
                        },
                        new
                        {
                            Id = 3,
                            LanguageId = 2,
                            Name = "Spring"
                        },
                        new
                        {
                            Id = 4,
                            LanguageId = 2,
                            Name = "JSP"
                        },
                        new
                        {
                            Id = 5,
                            LanguageId = 3,
                            Name = "React"
                        },
                        new
                        {
                            Id = 6,
                            LanguageId = 3,
                            Name = "Vue"
                        });
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.Technology", b =>
                {
                    b.HasOne("Kodlama.io.Devs.Domain.Entities.ProgrammingLanguage", "Language")
                        .WithMany("Technologies")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Navigation("Technologies");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Free_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FreeAPI.Migrations
{
    [DbContext(typeof(FreeAPIContext))]
    [Migration("20230221163818_DeleteMenuAndIncludeCategoryToDish")]
    partial class DeleteMenuAndIncludeCategoryToDish
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AllergenDish", b =>
                {
                    b.Property<int>("allergensId")
                        .HasColumnType("int");

                    b.Property<int>("dishesId")
                        .HasColumnType("int");

                    b.HasKey("allergensId", "dishesId");

                    b.HasIndex("dishesId");

                    b.ToTable("AllergenDish");
                });

            modelBuilder.Entity("Free_API.Models.DAO.Allergen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Allergens");
                });

            modelBuilder.Entity("Free_API.Models.DAO.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Free_API.Models.DAO.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("categoryId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("AllergenDish", b =>
                {
                    b.HasOne("Free_API.Models.DAO.Allergen", null)
                        .WithMany()
                        .HasForeignKey("allergensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Free_API.Models.DAO.Dish", null)
                        .WithMany()
                        .HasForeignKey("dishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Free_API.Models.DAO.Dish", b =>
                {
                    b.HasOne("Free_API.Models.DAO.Category", "category")
                        .WithMany("dishes")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("Free_API.Models.DAO.Category", b =>
                {
                    b.Navigation("dishes");
                });
#pragma warning restore 612, 618
        }
    }
}

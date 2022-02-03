﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieDB.Models;

namespace MovieDB.Migrations
{
    [DbContext(typeof(MovieSubmissionContext))]
    partial class MovieSubmissionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("MovieDB.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Action/Adventure"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Comedy"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Horror/Suspense"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Psychological Thriller"
                        },
                        new
                        {
                            CategoryID = 5,
                            CategoryName = "Sports Drama"
                        });
                });

            modelBuilder.Entity("MovieDB.Models.SubmissionResponse", b =>
                {
                    b.Property<int>("SubmissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubmissionId");

                    b.HasIndex("CategoryID");

                    b.ToTable("Submissions");

                    b.HasData(
                        new
                        {
                            SubmissionId = 1,
                            CategoryID = 5,
                            Director = "Gavin O'Connor",
                            Edited = false,
                            LentTo = "",
                            Notes = "",
                            Rating = "PG-13",
                            Title = "Warrior",
                            Year = (short)2011
                        },
                        new
                        {
                            SubmissionId = 2,
                            CategoryID = 1,
                            Director = "Christopher Nolan",
                            Edited = false,
                            LentTo = "",
                            Notes = "",
                            Rating = "PG-13",
                            Title = "Interstellar",
                            Year = (short)2014
                        },
                        new
                        {
                            SubmissionId = 3,
                            CategoryID = 5,
                            Director = "Ron Howard",
                            Edited = false,
                            LentTo = "",
                            Notes = "",
                            Rating = "PG-13",
                            Title = "Cinderella Man",
                            Year = (short)2005
                        });
                });

            modelBuilder.Entity("MovieDB.Models.SubmissionResponse", b =>
                {
                    b.HasOne("MovieDB.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

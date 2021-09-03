﻿// <auto-generated />
using System;
using CrazyBook_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrazyBook_DataAccess.Migrations
{
    [DbContext(typeof(CrazyBooksDbContext))]
    [Migration("20210903044550_AddSubject")]
    partial class AddSubject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrazyBook_Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorDetail_Id")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorDetail_Id")
                        .IsUnique()
                        .HasFilter("[AuthorDetail_Id] IS NOT NULL");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("CrazyBook_Models.AuthorBook", b =>
                {
                    b.Property<int>("Author_Id")
                        .HasColumnType("int");

                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.HasKey("Author_Id", "Book_Id");

                    b.HasIndex("Book_Id");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("CrazyBook_Models.AuthorDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Photo")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("AuthorDetail");
                });

            modelBuilder.Entity("CrazyBook_Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Publisher_Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Publisher_Id");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("CrazyBook_Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("CrazyBook_Models.Author", b =>
                {
                    b.HasOne("CrazyBook_Models.AuthorDetail", "AuthorDetail")
                        .WithOne("Author")
                        .HasForeignKey("CrazyBook_Models.Author", "AuthorDetail_Id");

                    b.Navigation("AuthorDetail");
                });

            modelBuilder.Entity("CrazyBook_Models.AuthorBook", b =>
                {
                    b.HasOne("CrazyBook_Models.Author", "Author")
                        .WithMany("AuthorsBooks")
                        .HasForeignKey("Author_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrazyBook_Models.Book", "Book")
                        .WithMany("AuthorsBooks")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("CrazyBook_Models.Book", b =>
                {
                    b.HasOne("CrazyBook_Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("Publisher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("CrazyBook_Models.Author", b =>
                {
                    b.Navigation("AuthorsBooks");
                });

            modelBuilder.Entity("CrazyBook_Models.AuthorDetail", b =>
                {
                    b.Navigation("Author");
                });

            modelBuilder.Entity("CrazyBook_Models.Book", b =>
                {
                    b.Navigation("AuthorsBooks");
                });

            modelBuilder.Entity("CrazyBook_Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}

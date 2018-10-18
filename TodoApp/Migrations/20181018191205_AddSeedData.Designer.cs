﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApp.Models;

namespace TodoApp.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20181018191205_AddSeedData")]
    partial class AddSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TodoApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, Name = "Home" },
                        new { Id = 2, Name = "Business" }
                    );
                });

            modelBuilder.Entity("TodoApp.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new { Id = 1, Description = "Learn to use this todo app", DueDate = new DateTime(2018, 10, 18, 15, 12, 4, 747, DateTimeKind.Local) }
                    );
                });

            modelBuilder.Entity("TodoApp.Models.TodoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<int>("TodoId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TodoId");

                    b.ToTable("TodoCategories");
                });

            modelBuilder.Entity("TodoApp.Models.TodoCategory", b =>
                {
                    b.HasOne("TodoApp.Models.Category", "Category")
                        .WithMany("TodoCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TodoApp.Models.Todo", "Todo")
                        .WithMany("TodoCategories")
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

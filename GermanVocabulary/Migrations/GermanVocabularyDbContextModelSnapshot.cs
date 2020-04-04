﻿// <auto-generated />
using GermanVocabulary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GermanVocabulary.Migrations
{
    [DbContext(typeof(GermanVocabularyDbContext))]
    partial class GermanVocabularyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GermanVocabulary.Data.Model.Words", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("German")
                        .IsRequired()
                        .HasColumnName("german")
                        .HasColumnType("text");

                    b.Property<string>("Serbian")
                        .IsRequired()
                        .HasColumnName("serbian")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("words","public");
                });
#pragma warning restore 612, 618
        }
    }
}
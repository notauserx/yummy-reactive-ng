﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rezept.Data.Contexts;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(RezeptDbContext))]
    [Migration("20221227042544_RenameImageUrlTable")]
    partial class RenameImageUrlTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("Rezept.Data.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Rezept.Data.Entities.Instruction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Instructions");
                });

            modelBuilder.Entity("Rezept.Data.Entities.Keyword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("Rezept.Data.Entities.NutritionInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Calories")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CarbohydrateContent")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("FatContent")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("FiberContent")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ProteinContent")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SaturatedFatContent")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SodiumContent")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SugarContent")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId")
                        .IsUnique();

                    b.ToTable("NutritionInfos");
                });

            modelBuilder.Entity("Rezept.Data.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CookTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("PrepTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("RecipeAuthorId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RecipeServings")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ReviewCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RecipeAuthorId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Rezept.Data.Entities.RecipeAuthor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Rezept.Data.Entities.RecipeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Rezept.Data.Entities.RecipeImageUrl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeImageUrls");
                });

            modelBuilder.Entity("Rezept.Data.Entities.RecipeKeywords", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("KeywordId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RecipeKeywords");
                });

            modelBuilder.Entity("Rezept.Data.Entities.Ingredient", b =>
                {
                    b.HasOne("Rezept.Data.Entities.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rezept.Data.Entities.Instruction", b =>
                {
                    b.HasOne("Rezept.Data.Entities.Recipe", null)
                        .WithMany("Instructions")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rezept.Data.Entities.NutritionInfo", b =>
                {
                    b.HasOne("Rezept.Data.Entities.Recipe", null)
                        .WithOne("NutritionInfo")
                        .HasForeignKey("Rezept.Data.Entities.NutritionInfo", "RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rezept.Data.Entities.Recipe", b =>
                {
                    b.HasOne("Rezept.Data.Entities.RecipeAuthor", null)
                        .WithMany("Recipes")
                        .HasForeignKey("RecipeAuthorId");
                });

            modelBuilder.Entity("Rezept.Data.Entities.RecipeImageUrl", b =>
                {
                    b.HasOne("Rezept.Data.Entities.Recipe", null)
                        .WithMany("AdditionalRecipeImageUrls")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rezept.Data.Entities.Recipe", b =>
                {
                    b.Navigation("AdditionalRecipeImageUrls");

                    b.Navigation("Ingredients");

                    b.Navigation("Instructions");

                    b.Navigation("NutritionInfo");
                });

            modelBuilder.Entity("Rezept.Data.Entities.RecipeAuthor", b =>
                {
                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Menu.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Menu.Infrastructure.Migrations
{
    [DbContext(typeof(MenuDbContext))]
    [Migration("20191230185404_MenuRemoveCrustType")]
    partial class MenuRemoveCrustType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Menu")
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Menu.Domain.ProductAggregate.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<bool>("IsSpicy")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegetarian")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Menu.Domain.ProductAggregate.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("Menu.Domain.ProductAggregate.PizzaIngredient", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("PizzaId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("PizzaIngredient");
                });

            modelBuilder.Entity("Menu.Domain.ProductAggregate.Ingredient", b =>
                {
                    b.OwnsOne("Menu.Domain.ProductAggregate.ProductDescription", "Description", b1 =>
                        {
                            b1.Property<int>("IngredientId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Description")
                                .HasColumnType("nvarchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("IngredientId");

                            b1.ToTable("Ingredients");

                            b1.WithOwner()
                                .HasForeignKey("IngredientId");
                        });

                    b.OwnsOne("Menu.Domain.ProductAggregate.ProductName", "Name", b1 =>
                        {
                            b1.Property<int>("IngredientId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Name")
                                .HasColumnType("nvarchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("IngredientId");

                            b1.ToTable("Ingredients");

                            b1.WithOwner()
                                .HasForeignKey("IngredientId");
                        });
                });

            modelBuilder.Entity("Menu.Domain.ProductAggregate.Pizza", b =>
                {
                    b.OwnsOne("Menu.Domain.ProductAggregate.ProductDescription", "Description", b1 =>
                        {
                            b1.Property<int>("PizzaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Description")
                                .HasColumnType("nvarchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("PizzaId");

                            b1.ToTable("Pizzas");

                            b1.WithOwner()
                                .HasForeignKey("PizzaId");
                        });

                    b.OwnsOne("Menu.Domain.ProductAggregate.ProductName", "Name", b1 =>
                        {
                            b1.Property<int>("PizzaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Name")
                                .HasColumnType("nvarchar(255)")
                                .HasMaxLength(255);

                            b1.HasKey("PizzaId");

                            b1.ToTable("Pizzas");

                            b1.WithOwner()
                                .HasForeignKey("PizzaId");
                        });
                });

            modelBuilder.Entity("Menu.Domain.ProductAggregate.PizzaIngredient", b =>
                {
                    b.HasOne("Menu.Domain.ProductAggregate.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Menu.Domain.ProductAggregate.Pizza", "Pizza")
                        .WithMany("Ingredients")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

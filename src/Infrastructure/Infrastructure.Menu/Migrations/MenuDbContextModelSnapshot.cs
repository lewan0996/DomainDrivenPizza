﻿// <auto-generated />
using Infrastructure.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Menu.Migrations
{
    [DbContext(typeof(MenuDbContext))]
    partial class MenuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Menu")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.MenuHiLoSequence", "'MenuHiLoSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:HiLoSequenceName", "MenuHiLoSequence")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

            modelBuilder.Entity("Domain.Menu.ProductAggregate.PizzaIngredient", b =>
                {
                    b.Property<int>("PizzaId");

                    b.Property<int>("IngredientId");

                    b.HasKey("PizzaId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("PizzaIngredient");
                });

            modelBuilder.Entity("Domain.Menu.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("AvailableQuantity");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<float>("UnitPrice");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("Domain.Menu.ProductAggregate.Ingredient", b =>
                {
                    b.HasBaseType("Domain.Menu.ProductAggregate.Product");

                    b.Property<bool>("IsSpicy");

                    b.Property<bool>("IsVegan");

                    b.Property<bool>("IsVegetarian");

                    b.HasDiscriminator().HasValue("Ingredient");
                });

            modelBuilder.Entity("Domain.Menu.ProductAggregate.Pizza", b =>
                {
                    b.HasBaseType("Domain.Menu.ProductAggregate.Product");

                    b.Property<string>("CrustType")
                        .IsRequired();

                    b.HasDiscriminator().HasValue("Pizza");
                });

            modelBuilder.Entity("Domain.Menu.ProductAggregate.PizzaIngredient", b =>
                {
                    b.HasOne("Domain.Menu.ProductAggregate.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId");

                    b.HasOne("Domain.Menu.ProductAggregate.Pizza", "Pizza")
                        .WithMany("Ingredients")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Menu.ProductAggregate.Product", b =>
                {
                    b.OwnsOne("Domain.Menu.ProductAggregate.ProductDescription", "Description", b1 =>
                        {
                            b1.Property<int>("ProductId");

                            b1.Property<string>("Value")
                                .HasColumnName("Description");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products","Menu");

                            b1.HasOne("Domain.Menu.ProductAggregate.Product")
                                .WithOne("Description")
                                .HasForeignKey("Domain.Menu.ProductAggregate.ProductDescription", "ProductId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Domain.Menu.ProductAggregate.ProductName", "Name", b1 =>
                        {
                            b1.Property<int>("ProductId");

                            b1.Property<string>("Value")
                                .HasColumnName("Name");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products","Menu");

                            b1.HasOne("Domain.Menu.ProductAggregate.Product")
                                .WithOne("Name")
                                .HasForeignKey("Domain.Menu.ProductAggregate.ProductName", "ProductId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

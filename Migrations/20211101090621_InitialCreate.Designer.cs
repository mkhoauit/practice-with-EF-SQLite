// <auto-generated />
using Animal.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Animal.Migrations
{
    [DbContext(typeof(AnimalContext))]
    [Migration("20211101090621_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Animal.Classes.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("AnimalId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Animal.Classes.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FoodName")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberofCans")
                        .HasColumnType("INTEGER");

                    b.HasKey("FoodId");

                    b.HasIndex("AnimalId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Animal.Classes.Food", b =>
                {
                    b.HasOne("Animal.Classes.Animal", "Animal")
                        .WithMany("Foods")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("Animal.Classes.Animal", b =>
                {
                    b.Navigation("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}

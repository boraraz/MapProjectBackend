// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ParcelBackend.Models;

#nullable disable

namespace ParcelBackend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ParcelBackend.Models.Parcel", b =>
                {
                    b.Property<int>("parcelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("parcelId"));

                    b.Property<string>("parcelCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("parcelCoordinates")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("parcelCounty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("parcelDistrict")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("parcelId");

                    b.ToTable("parcel", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

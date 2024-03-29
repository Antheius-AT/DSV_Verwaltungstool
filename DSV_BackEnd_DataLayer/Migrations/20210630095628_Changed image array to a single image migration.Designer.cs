﻿// <auto-generated />
using DSV_BackEnd_DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DSV_BackEnd_DataLayer.Migrations
{
    [DbContext(typeof(DSVDatabaseContext))]
    [Migration("20210630095628_Changed image array to a single image migration")]
    partial class Changedimagearraytoasingleimagemigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DSV_BackEnd_DataLayer.DataModel.Article", b =>
                {
                    b.Property<int>("AssetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Editor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PreviousStorageLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetID");

                    b.HasIndex("ImageName");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("DSV_BackEnd_DataLayer.DataModel.Book", b =>
                {
                    b.Property<int>("AssetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Editor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Pages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousStorageLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicationLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubLevelTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetID");

                    b.HasIndex("ImageName");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DSV_BackEnd_DataLayer.DataModel.Image", b =>
                {
                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Base64EncodedImageData")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageName");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DSV_BackEnd_DataLayer.DataModel.Article", b =>
                {
                    b.HasOne("DSV_BackEnd_DataLayer.DataModel.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageName");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("DSV_BackEnd_DataLayer.DataModel.Book", b =>
                {
                    b.HasOne("DSV_BackEnd_DataLayer.DataModel.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageName");

                    b.Navigation("Image");
                });
#pragma warning restore 612, 618
        }
    }
}

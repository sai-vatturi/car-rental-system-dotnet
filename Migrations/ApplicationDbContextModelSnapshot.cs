﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace CarRentalSystem.Migrations
{
	[DbContext(typeof(ApplicationDbContext))]
	partial class ApplicationDbContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "8.0.11")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);

			SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

			modelBuilder.Entity("CarRentalSystem.Models.User", b =>
				{
					b.Property<Guid>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("uniqueidentifier");

					b.Property<string>("Email")
						.IsRequired()
						.HasMaxLength(100)
						.HasColumnType("nvarchar(100)");

					b.Property<string>("Name")
						.IsRequired()
						.HasMaxLength(100)
						.HasColumnType("nvarchar(100)");

					b.Property<string>("Password")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.Property<string>("Role")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.HasKey("Id");

					b.ToTable("Users");
				});

			modelBuilder.Entity("CarRentalSystem.Models.Car", b =>
				{
					b.Property<Guid>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("uniqueidentifier");

					b.Property<bool>("IsAvailable")
						.HasColumnType("bit");

					b.Property<string>("Make")
						.IsRequired()
						.HasMaxLength(50)
						.HasColumnType("nvarchar(50)");

					b.Property<string>("Model")
						.IsRequired()
						.HasMaxLength(50)
						.HasColumnType("nvarchar(50)");

					b.Property<decimal>("PricePerDay")
						.HasColumnType("decimal(18,2)");

					b.Property<int>("Year")
						.HasColumnType("int");

					b.HasKey("Id");

					b.ToTable("Cars");
				});
#pragma warning restore 612, 618
		}
	}
}

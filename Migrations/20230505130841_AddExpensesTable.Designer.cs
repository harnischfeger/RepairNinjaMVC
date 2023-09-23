﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RepairNinjaMVC.Data;

#nullable disable

namespace RepairNinjaMVC.Migrations
{
    [DbContext(typeof(RepairNinjaContext))]
    [Migration("20230505130841_AddExpensesTable")]
    partial class AddExpensesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("RepairNinjaMVC.Data.Entities.Categories", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("cat_description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("cat_itemname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("cat_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RepairNinjaMVC.Data.Entities.Expenses", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("expense_date")
                        .HasColumnType("date");

                    b.Property<Guid>("expense_type")
                        .HasColumnType("uuid");

                    b.Property<string>("invoice_img")
                        .HasColumnType("text");

                    b.Property<Guid>("landlord_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("property_id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("provider_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("repair_type")
                        .HasColumnType("uuid");

                    b.HasKey("id");

                    b.ToTable("expenses");
                });

            modelBuilder.Entity("RepairNinjaMVC.Data.Entities.Properties", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("hoa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("insurance")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("intial_maint_cost")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("landlord_id")
                        .HasColumnType("uuid");

                    b.Property<string>("mortgage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("rent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("taxes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("zipcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("properties");
                });

            modelBuilder.Entity("RepairNinjaMVC.Data.Entities.Provider_Details", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool?>("is_electric")
                        .HasColumnType("boolean");

                    b.Property<bool?>("is_general")
                        .HasColumnType("boolean");

                    b.Property<bool?>("is_gutterpowerwash")
                        .HasColumnType("boolean");

                    b.Property<bool?>("is_hvac")
                        .HasColumnType("boolean");

                    b.Property<bool?>("is_plumbing")
                        .HasColumnType("boolean");

                    b.Property<bool?>("is_roofing")
                        .HasColumnType("boolean");

                    b.Property<string>("service_area")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("RepairNinjaMVC.Data.Entities.Requests", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("accepted_scheduled_date")
                        .HasColumnType("date");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("landlord_id")
                        .HasColumnType("uuid");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("provider_id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("requesteddate_1")
                        .HasColumnType("date");

                    b.Property<DateTime>("requesteddate_2")
                        .HasColumnType("date");

                    b.Property<DateTime>("requesteddate_3")
                        .HasColumnType("date");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("tenant_id")
                        .HasColumnType("uuid");

                    b.Property<string>("type_of_service")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("zipcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("RepairNinjaMVC.Data.Entities.Users", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_landlord")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_provider")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_tenant")
                        .HasColumnType("boolean");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("zipcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}

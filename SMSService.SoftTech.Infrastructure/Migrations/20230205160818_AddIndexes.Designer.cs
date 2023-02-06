﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SMSService.SoftTech.Infrastructure.Context;

namespace SMSService.SoftTech.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230205160818_AddIndexes")]
    partial class AddIndexes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SMSService.SoftTech.Data.Database.SmsMessage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("SendTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SenderName")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id");

                    b.ToTable("SmsMessages");
                });

            modelBuilder.Entity("SMSService.SoftTech.Data.Database.SmsState", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("SetDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("SmsMessageId")
                        .HasColumnType("bigint");

                    b.Property<byte>("State")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("SetDate");

                    b.HasIndex("SmsMessageId");

                    b.ToTable("SmsStates");
                });

            modelBuilder.Entity("SMSService.SoftTech.Data.Database.SmsState", b =>
                {
                    b.HasOne("SMSService.SoftTech.Data.Database.SmsMessage", "SmsMessage")
                        .WithMany("StateHistory")
                        .HasForeignKey("SmsMessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SmsMessage");
                });

            modelBuilder.Entity("SMSService.SoftTech.Data.Database.SmsMessage", b =>
                {
                    b.Navigation("StateHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TCN.Persistence;

namespace TCN.Migrations
{
    [DbContext(typeof(TcnDbContext))]
    [Migration("20180227101612_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TCN.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaxAmount");

                    b.Property<int>("MinAmount");

                    b.Property<int>("Price");

                    b.Property<int>("TransactionCoinId");

                    b.Property<int>("TransactionFxId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TransactionCoinId");

                    b.HasIndex("TransactionFxId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("TCN.Models.TransactionCoin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TransactionCoins");
                });

            modelBuilder.Entity("TCN.Models.TransactionFx", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TransactionFx");
                });

            modelBuilder.Entity("TCN.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TCN.Models.Transaction", b =>
                {
                    b.HasOne("TCN.Models.TransactionCoin", "Coin")
                        .WithMany()
                        .HasForeignKey("TransactionCoinId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TCN.Models.TransactionFx", "Fx")
                        .WithMany()
                        .HasForeignKey("TransactionFxId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TCN.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

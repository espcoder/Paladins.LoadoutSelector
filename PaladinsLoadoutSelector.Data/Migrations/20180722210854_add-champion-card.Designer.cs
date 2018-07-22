﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaladinsLoadoutSelector.Data;

namespace PaladinsLoadoutSelector.Data.Migrations
{
    [DbContext(typeof(PaladinsLoudoutSelectorContext))]
    [Migration("20180722210854_add-champion-card")]
    partial class addchampioncard
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaladinsDomain.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChampionId");

                    b.Property<int>("Level");

                    b.Property<int?>("LoadoutId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ChampionId");

                    b.HasIndex("LoadoutId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("PaladinsDomain.Champion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Champions");
                });

            modelBuilder.Entity("PaladinsDomain.Loadout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChampionId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ChampionId");

                    b.ToTable("Loadouts");
                });

            modelBuilder.Entity("PaladinsDomain.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("PaladinsDomain.Card", b =>
                {
                    b.HasOne("PaladinsDomain.Champion", "Champion")
                        .WithMany()
                        .HasForeignKey("ChampionId");

                    b.HasOne("PaladinsDomain.Loadout")
                        .WithMany("Cards")
                        .HasForeignKey("LoadoutId");
                });

            modelBuilder.Entity("PaladinsDomain.Loadout", b =>
                {
                    b.HasOne("PaladinsDomain.Champion", "Champion")
                        .WithMany("Loadouts")
                        .HasForeignKey("ChampionId");
                });
#pragma warning restore 612, 618
        }
    }
}

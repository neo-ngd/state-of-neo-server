﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StateOfNeo.Data;

namespace StateOfNeo.Data.Migrations
{
    [DbContext(typeof(StateOfNeoContext))]
    partial class StateOfNeoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StateOfNeo.Data.Models.BlockchainInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BlockCount");

                    b.Property<string>("Net");

                    b.Property<decimal>("SecondsCount")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.HasKey("Id");

                    b.ToTable("BlockchainInfos");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FlagUrl");

                    b.Property<int?>("Height");

                    b.Property<double?>("Latitude");

                    b.Property<string>("Locale");

                    b.Property<string>("Location");

                    b.Property<double?>("Longitude");

                    b.Property<int?>("MemoryPool");

                    b.Property<string>("Net");

                    b.Property<int?>("Peers");

                    b.Property<string>("Protocol");

                    b.Property<string>("SuccessUrl");

                    b.Property<int>("Type");

                    b.Property<string>("Url");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ip");

                    b.Property<int>("NodeId");

                    b.Property<long?>("Port");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("NodeAddresses");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.TimeEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("LastDownTime");

                    b.Property<int?>("NodeId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("TimeEvents");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeAddress", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Node", "Node")
                        .WithMany("NodeAddresses")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.TimeEvent", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Node")
                        .WithMany("Events")
                        .HasForeignKey("NodeId");
                });
#pragma warning restore 612, 618
        }
    }
}

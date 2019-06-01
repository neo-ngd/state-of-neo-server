﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StateOfNeo.Data;

namespace StateOfNeo.Data.Migrations
{
    [DbContext(typeof(StateOfNeoContext))]
    [Migration("20190519170516_AddCreatorAddressToAssets")]
    partial class AddCreatorAddressToAssets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StateOfNeo.Data.Models.Address", b =>
                {
                    b.Property<string>("PublicAddress")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("FirstTransactionOn");

                    b.Property<DateTime>("LastTransactionOn");

                    b.Property<long>("LastTransactionStamp");

                    b.Property<int>("TransactionsCount");

                    b.HasKey("PublicAddress");

                    b.HasIndex("LastTransactionOn");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.AddressAssetBalance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressPublicAddress");

                    b.Property<string>("AssetHash");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(36, 8)");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("TransactionsCount");

                    b.HasKey("Id");

                    b.HasIndex("AddressPublicAddress");

                    b.HasIndex("AssetHash");

                    b.ToTable("AddressBalances");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.AddressInAssetTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressPublicAddress");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(36, 8)");

                    b.Property<int>("AssetInTransactionId");

                    b.Property<DateTime>("CreatedOn");

                    b.HasKey("Id");

                    b.HasIndex("AddressPublicAddress");

                    b.HasIndex("AssetInTransactionId");

                    b.ToTable("AddressesInAssetTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.AddressInTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressPublicAddress");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(36, 8)");

                    b.Property<string>("AssetHash");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<long>("DailyStamp");

                    b.Property<long>("HourlyStamp");

                    b.Property<long>("MonthlyStamp");

                    b.Property<long>("Timestamp");

                    b.Property<string>("TransactionHash");

                    b.HasKey("Id");

                    b.HasIndex("AddressPublicAddress");

                    b.HasIndex("AssetHash");

                    b.HasIndex("TransactionHash");

                    b.ToTable("AddressesInTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Asset", b =>
                {
                    b.Property<string>("Hash")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("CreatorAddressId");

                    b.Property<long?>("CurrentSupply");

                    b.Property<int>("Decimals");

                    b.Property<byte?>("GlobalType");

                    b.Property<long?>("MaxSupply");

                    b.Property<string>("Name");

                    b.Property<string>("Symbol");

                    b.Property<int>("TransactionsCount");

                    b.Property<int>("Type");

                    b.HasKey("Hash");

                    b.HasIndex("CreatorAddressId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.AssetInTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssetHash");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<long>("Timestamp");

                    b.Property<string>("TransactionHash");

                    b.HasKey("Id");

                    b.HasIndex("AssetHash");

                    b.HasIndex("TransactionHash");

                    b.HasIndex("Timestamp", "AssetHash");

                    b.ToTable("AssetsInTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Block", b =>
                {
                    b.Property<string>("Hash")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ConsensusData")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<DateTime>("CreatedOn");

                    b.Property<long>("DailyStamp");

                    b.Property<int>("Height");

                    b.Property<long>("HourlyStamp");

                    b.Property<string>("InvocationScript");

                    b.Property<long>("MonthlyStamp");

                    b.Property<string>("NextConsensusNodeAddress");

                    b.Property<string>("PreviousBlockHash");

                    b.Property<int>("Size");

                    b.Property<double>("TimeInSeconds");

                    b.Property<long>("Timestamp");

                    b.Property<string>("Validator");

                    b.Property<string>("VerificationScript");

                    b.HasKey("Hash");

                    b.HasIndex("Height");

                    b.HasIndex("PreviousBlockHash");

                    b.HasIndex("Timestamp");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.ChartEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("AccumulatedValue");

                    b.Property<long?>("Count");

                    b.Property<long>("Timestamp");

                    b.Property<int>("Type");

                    b.Property<int>("UnitOfTime");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(36, 8)");

                    b.HasKey("Id");

                    b.ToTable("ChartEntries");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.ConsensusNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<decimal>("CollectedFees")
                        .HasColumnType("decimal(36, 8)");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.Property<string>("Organization");

                    b.Property<string>("PublicKey");

                    b.Property<string>("PublicKeyHash");

                    b.HasKey("Id");

                    b.ToTable("ConsensusNodes");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<long?>("FirstRuntime");

                    b.Property<string>("FlagUrl");

                    b.Property<int?>("Height");

                    b.Property<bool>("IsHttps");

                    b.Property<long?>("LastAudit");

                    b.Property<long?>("LatestRuntime");

                    b.Property<double?>("Latitude");

                    b.Property<string>("Locale");

                    b.Property<string>("Location");

                    b.Property<double?>("Longitude");

                    b.Property<string>("Net");

                    b.Property<string>("Protocol");

                    b.Property<long>("SecondsOnline");

                    b.Property<string>("Service");

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

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeAudit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<long>("DailyStamp");

                    b.Property<long>("HourlyStamp");

                    b.Property<int>("Latency");

                    b.Property<long>("MonthlyStamp");

                    b.Property<int>("NodeId");

                    b.Property<decimal?>("Peers");

                    b.Property<long>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.HasIndex("Timestamp");

                    b.ToTable("NodeAudits");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlockHash");

                    b.Property<int>("BlockId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsP2pTcpOnline");

                    b.Property<bool>("IsP2pWsOnline");

                    b.Property<bool>("IsRpcOnline");

                    b.Property<int>("NodeId");

                    b.HasKey("Id");

                    b.HasIndex("BlockHash");

                    b.HasIndex("NodeId");

                    b.ToTable("NodeStatusUpdates");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Peer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FlagUrl");

                    b.Property<string>("Ip");

                    b.Property<double?>("Latitude");

                    b.Property<string>("Locale");

                    b.Property<string>("Location");

                    b.Property<double?>("Longitude");

                    b.Property<int?>("NodeId");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("Peers");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.SmartContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<bool>("HasDynamicInvoke");

                    b.Property<bool>("HasStorage");

                    b.Property<string>("Hash");

                    b.Property<string>("InputParameters");

                    b.Property<string>("Name");

                    b.Property<bool>("Payable");

                    b.Property<byte>("ReturnType");

                    b.Property<long>("Timestamp");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.ToTable("SmartContracts");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.TotalStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressCount");

                    b.Property<int?>("AssetsCount");

                    b.Property<int?>("BlockCount");

                    b.Property<long?>("BlocksSizes");

                    b.Property<decimal?>("BlocksTimes");

                    b.Property<decimal?>("ClaimedGas");

                    b.Property<long?>("NeoGasTxCount");

                    b.Property<long?>("Nep5TxCount");

                    b.Property<long?>("Timestamp");

                    b.Property<long?>("TransactionsCount");

                    b.HasKey("Id");

                    b.ToTable("TotalStats");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.EnrollmentTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("PublicKey");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.ToTable("EnrollmentTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.InvocationTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContractHash");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<decimal>("Gas")
                        .HasColumnType("decimal(36, 8)");

                    b.Property<string>("ScriptAsHexString");

                    b.Property<int?>("SmartContractId");

                    b.Property<string>("TransactionHash");

                    b.HasKey("Id");

                    b.HasIndex("SmartContractId");

                    b.ToTable("InvocationTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.MinerTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<long>("Nonce");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.ToTable("MinerTransaction");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.PublishTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("CodeVersion");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<bool>("NeedStorage");

                    b.Property<string>("ParameterList");

                    b.Property<string>("ReturnType");

                    b.Property<string>("ScriptAsHexString");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.ToTable("PublishTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.RegisterTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminAddress");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(36, 8)");

                    b.Property<byte>("AssetType");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerPublicKey");

                    b.Property<byte>("Precision");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.ToTable("RegisterTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.StateDescriptor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Field");

                    b.Property<string>("KeyAsHexString");

                    b.Property<int>("TransactionId");

                    b.Property<byte>("Type");

                    b.Property<string>("ValueAsHexString");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("StateDescriptors");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.StateTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.ToTable("StateTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.TransactedAsset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(36, 8)");

                    b.Property<string>("AssetHash");

                    b.Property<int>("AssetType");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("FromAddressPublicAddress");

                    b.Property<string>("InGlobalTransactionHash");

                    b.Property<string>("OutGlobalTransactionHash");

                    b.Property<string>("ToAddressPublicAddress");

                    b.Property<string>("TransactionHash");

                    b.HasKey("Id");

                    b.HasIndex("AssetHash");

                    b.HasIndex("FromAddressPublicAddress");

                    b.HasIndex("InGlobalTransactionHash");

                    b.HasIndex("OutGlobalTransactionHash");

                    b.HasIndex("ToAddressPublicAddress");

                    b.HasIndex("TransactionHash");

                    b.ToTable("TransactedAssets");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.Transaction", b =>
                {
                    b.Property<string>("Hash")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlockId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<long>("DailyStamp");

                    b.Property<int?>("EnrollmentTransactionId");

                    b.Property<long>("HourlyStamp");

                    b.Property<int?>("InvocationTransactionId");

                    b.Property<int?>("MinerTransactionId");

                    b.Property<long>("MonthlyStamp");

                    b.Property<decimal>("NetworkFee")
                        .HasColumnType("decimal(36, 8)");

                    b.Property<int?>("PublishTransactionId");

                    b.Property<int?>("RegisterTransactionId");

                    b.Property<int>("Size");

                    b.Property<int?>("StateTransactionId");

                    b.Property<decimal>("SystemFee")
                        .HasColumnType("decimal(36, 8)");

                    b.Property<long>("Timestamp");

                    b.Property<byte>("Type");

                    b.Property<int>("Version");

                    b.HasKey("Hash");

                    b.HasIndex("BlockId");

                    b.HasIndex("EnrollmentTransactionId")
                        .IsUnique()
                        .HasFilter("[EnrollmentTransactionId] IS NOT NULL");

                    b.HasIndex("InvocationTransactionId")
                        .IsUnique()
                        .HasFilter("[InvocationTransactionId] IS NOT NULL");

                    b.HasIndex("MinerTransactionId")
                        .IsUnique()
                        .HasFilter("[MinerTransactionId] IS NOT NULL");

                    b.HasIndex("PublishTransactionId")
                        .IsUnique()
                        .HasFilter("[PublishTransactionId] IS NOT NULL");

                    b.HasIndex("RegisterTransactionId")
                        .IsUnique()
                        .HasFilter("[RegisterTransactionId] IS NOT NULL");

                    b.HasIndex("StateTransactionId")
                        .IsUnique()
                        .HasFilter("[StateTransactionId] IS NOT NULL");

                    b.HasIndex("Timestamp");

                    b.HasIndex("Timestamp", "Hash");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.TransactionAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DataAsHexString");

                    b.Property<string>("TransactionHash");

                    b.Property<int>("TransactionId");

                    b.Property<int>("Usage");

                    b.HasKey("Id");

                    b.HasIndex("TransactionHash");

                    b.ToTable("TransactionAttributes");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.TransactionWitness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("InvocationScriptAsHexString");

                    b.Property<string>("TransactionHash");

                    b.Property<int>("TransactionId");

                    b.Property<string>("VerificationScriptAsHexString");

                    b.HasKey("Id");

                    b.HasIndex("TransactionHash");

                    b.ToTable("TransactionWitnesses");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.AddressAssetBalance", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Address", "Address")
                        .WithMany("Balances")
                        .HasForeignKey("AddressPublicAddress");

                    b.HasOne("StateOfNeo.Data.Models.Asset", "Asset")
                        .WithMany("Balances")
                        .HasForeignKey("AssetHash");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.AddressInAssetTransaction", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Address", "Address")
                        .WithMany("AddressesInAssetTransactions")
                        .HasForeignKey("AddressPublicAddress");

                    b.HasOne("StateOfNeo.Data.Models.AssetInTransaction", "AssetInTransaction")
                        .WithMany("AddressesInAssetTransactions")
                        .HasForeignKey("AssetInTransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.AddressInTransaction", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Address", "Address")
                        .WithMany("AddressesInTransaction")
                        .HasForeignKey("AddressPublicAddress");

                    b.HasOne("StateOfNeo.Data.Models.Asset", "Asset")
                        .WithMany("AddressesInTransactions")
                        .HasForeignKey("AssetHash");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.Transaction", "Transaction")
                        .WithMany("AddressesInTransactions")
                        .HasForeignKey("TransactionHash");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Asset", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Address", "CreatorAddress")
                        .WithMany()
                        .HasForeignKey("CreatorAddressId");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.AssetInTransaction", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Asset", "Asset")
                        .WithMany("AssetsInTransactions")
                        .HasForeignKey("AssetHash");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.Transaction", "Transaction")
                        .WithMany("AssetsInTransactions")
                        .HasForeignKey("TransactionHash");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Block", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Block", "PreviousBlock")
                        .WithMany()
                        .HasForeignKey("PreviousBlockHash");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeAddress", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Node", "Node")
                        .WithMany("NodeAddresses")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeAudit", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Node", "Node")
                        .WithMany("Audits")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeStatus", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Block", "Block")
                        .WithMany("NodeStatusUpdates")
                        .HasForeignKey("BlockHash");

                    b.HasOne("StateOfNeo.Data.Models.Node", "Node")
                        .WithMany("NodeStatusUpdates")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Peer", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Node", "Node")
                        .WithMany("AssociatedPeers")
                        .HasForeignKey("NodeId");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.InvocationTransaction", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.SmartContract", "SmartContract")
                        .WithMany("InvocationTransactions")
                        .HasForeignKey("SmartContractId");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.StateDescriptor", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Transactions.StateTransaction", "Transaction")
                        .WithMany("Descriptors")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.TransactedAsset", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Asset", "Asset")
                        .WithMany("TransactedAssets")
                        .HasForeignKey("AssetHash");

                    b.HasOne("StateOfNeo.Data.Models.Address", "FromAddress")
                        .WithMany("OutgoingTransactions")
                        .HasForeignKey("FromAddressPublicAddress");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.Transaction", "InGlobalTransaction")
                        .WithMany("GlobalIncomingAssets")
                        .HasForeignKey("InGlobalTransactionHash");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.Transaction", "OutGlobalTransaction")
                        .WithMany("GlobalOutgoingAssets")
                        .HasForeignKey("OutGlobalTransactionHash");

                    b.HasOne("StateOfNeo.Data.Models.Address", "ToAddress")
                        .WithMany("IncomingTransactions")
                        .HasForeignKey("ToAddressPublicAddress");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.Transaction", "Transaction")
                        .WithMany("Assets")
                        .HasForeignKey("TransactionHash");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.Transaction", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Block", "Block")
                        .WithMany("Transactions")
                        .HasForeignKey("BlockId");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.EnrollmentTransaction", "EnrollmentTransaction")
                        .WithOne("Transaction")
                        .HasForeignKey("StateOfNeo.Data.Models.Transactions.Transaction", "EnrollmentTransactionId");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.InvocationTransaction", "InvocationTransaction")
                        .WithOne("Transaction")
                        .HasForeignKey("StateOfNeo.Data.Models.Transactions.Transaction", "InvocationTransactionId");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.MinerTransaction", "MinerTransaction")
                        .WithOne("Transaction")
                        .HasForeignKey("StateOfNeo.Data.Models.Transactions.Transaction", "MinerTransactionId");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.PublishTransaction", "PublishTransaction")
                        .WithOne("Transaction")
                        .HasForeignKey("StateOfNeo.Data.Models.Transactions.Transaction", "PublishTransactionId");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.RegisterTransaction", "RegisterTransaction")
                        .WithOne("Transaction")
                        .HasForeignKey("StateOfNeo.Data.Models.Transactions.Transaction", "RegisterTransactionId");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.StateTransaction", "StateTransaction")
                        .WithOne("Transaction")
                        .HasForeignKey("StateOfNeo.Data.Models.Transactions.Transaction", "StateTransactionId");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.TransactionAttribute", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Transactions.Transaction", "Transaction")
                        .WithMany("Attributes")
                        .HasForeignKey("TransactionHash");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.TransactionWitness", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Transactions.Transaction", "Transaction")
                        .WithMany("Witnesses")
                        .HasForeignKey("TransactionHash");
                });
#pragma warning restore 612, 618
        }
    }
}

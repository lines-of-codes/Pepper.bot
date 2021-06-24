﻿// <auto-generated />
using DiscordBotDataBase.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiscordBotDataBase.Dal.Migrations.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210624102146_AddedModerationData")]
    partial class AddedModerationData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Items.ItemDBData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfileId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileItems");
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Moderation.ModerationProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("DiscordId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ModerationProfiles");
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Moderation.SubData.Ban", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModerationProfileId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reason")
                        .HasColumnType("TEXT");

                    b.Property<string>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ModerationProfileId");

                    b.ToTable("ModBans");
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Moderation.SubData.Endorsement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModerationProfileId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reason")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ModerationProfileId");

                    b.ToTable("ModEndorsements");
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Moderation.SubData.Infraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModerationProfileId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reason")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ModerationProfileId");

                    b.ToTable("ModInfractions");
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Moderation.SubData.Kick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModerationProfileId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reason")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ModerationProfileId");

                    b.ToTable("ModKicks");
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Profile.Boosts.BoostData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BoostStartTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("BoostTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoostValue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BoosteName")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfileId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileBoosts");
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Profile.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Coins")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoinsBank")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoinsBankMax")
                        .HasColumnType("INTEGER");

                    b.Property<long>("DiscordUserID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Job")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("XP")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Items.ItemDBData", b =>
                {
                    b.HasOne("DiscordBotDataBase.Dal.Models.Profile.Profile", null)
                        .WithMany("Items")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Moderation.SubData.Ban", b =>
                {
                    b.HasOne("DiscordBotDataBase.Dal.Models.Moderation.ModerationProfile", null)
                        .WithMany("Bans")
                        .HasForeignKey("ModerationProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Moderation.SubData.Endorsement", b =>
                {
                    b.HasOne("DiscordBotDataBase.Dal.Models.Moderation.ModerationProfile", null)
                        .WithMany("Endorsements")
                        .HasForeignKey("ModerationProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Moderation.SubData.Infraction", b =>
                {
                    b.HasOne("DiscordBotDataBase.Dal.Models.Moderation.ModerationProfile", null)
                        .WithMany("Infractions")
                        .HasForeignKey("ModerationProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Moderation.SubData.Kick", b =>
                {
                    b.HasOne("DiscordBotDataBase.Dal.Models.Moderation.ModerationProfile", null)
                        .WithMany("Kicks")
                        .HasForeignKey("ModerationProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Profile.Boosts.BoostData", b =>
                {
                    b.HasOne("DiscordBotDataBase.Dal.Models.Profile.Profile", null)
                        .WithMany("Boosts")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Moderation.ModerationProfile", b =>
                {
                    b.Navigation("Bans");

                    b.Navigation("Endorsements");

                    b.Navigation("Infractions");

                    b.Navigation("Kicks");
                });

            modelBuilder.Entity("DiscordBotDataBase.Dal.Models.Profile.Profile", b =>
                {
                    b.Navigation("Boosts");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}

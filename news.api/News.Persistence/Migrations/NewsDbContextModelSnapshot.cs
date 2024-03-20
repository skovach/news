﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using News.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace News.Persistence.Migrations
{
    [DbContext(typeof(NewsDbContext))]
    partial class NewsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("News.Domain.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("PublishedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("Articles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "In an unprecedented event that will forever be remembered as the 'Great Bubble Burst,' all cryptocurrencies simultaneously crashed to zero value overnight. Experts are baffled, economies are in turmoil, and digital wallets everywhere now eerily resemble ghost towns. The era of digital gold has ended, leaving behind nothing but digital dust.",
                            PublishedDate = new DateTimeOffset(new DateTime(2024, 3, 10, 21, 50, 48, 623, DateTimeKind.Unspecified).AddTicks(523), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "The Great Bubble Burst: How Cryptocurrencies Crashed to Zero Overnight"
                        },
                        new
                        {
                            Id = 2,
                            Content = "In a shocking turn of events, the world's paper money has turned into literal paper overnight. Banknotes are now being used as origami supplies and kindling, as their monetary value evaporates into thin air. Economists are puzzled, suggesting that perhaps this is the universe's way of telling us we should have stuck to bartering with livestock and grains.",
                            PublishedDate = new DateTimeOffset(new DateTime(2024, 3, 11, 21, 50, 48, 623, DateTimeKind.Unspecified).AddTicks(545), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Economies Crumble as Paper Money Turns Literal Overnight"
                        },
                        new
                        {
                            Id = 3,
                            Content = "In an extraordinary leap towards the future, cryptocurrencies have replaced all global currencies, ushering in an era of unprecedented prosperity. Taxes are now considered 'optional donations,' and ATMs dispense free digital coins daily. The world has never been wealthier, and the term 'financial crisis' is now only found in history books.",
                            PublishedDate = new DateTimeOffset(new DateTime(2024, 3, 12, 21, 50, 48, 623, DateTimeKind.Unspecified).AddTicks(547), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Cryptocurrencies Replace Global Currencies: A New Era of Prosperity"
                        },
                        new
                        {
                            Id = 4,
                            Content = "Scientists have cracked quantum financial algorithms, creating a system where wealth is infinitely and equitably distributed among the planet's inhabitants. Poverty has been eradicated, and financial disparities are a thing of the past. Money grows on trees, and the trees are flourishing. Welcome to the dawn of the Quantum Financial System, where everyone is a trillionaire.",
                            PublishedDate = new DateTimeOffset(new DateTime(2024, 3, 13, 21, 50, 48, 623, DateTimeKind.Unspecified).AddTicks(548), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "The Dawn of the Quantum Financial System: Wealth For All"
                        },
                        new
                        {
                            Id = 5,
                            Content = "As traditional and digital currencies face a catastrophic collapse, the world has turned to collectible stickers as the new form of currency. Central banks are now racing to secure rare editions of vintage stickers to bolster their reserves. People everywhere are digging through their attics in hopes of finding that one sticker which could make them sticker-millionaires.",
                            PublishedDate = new DateTimeOffset(new DateTime(2024, 3, 14, 21, 50, 48, 623, DateTimeKind.Unspecified).AddTicks(549), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Global Economy Turns to Collectible Stickers as Currencies Collapse"
                        },
                        new
                        {
                            Id = 6,
                            Content = "In a somber turn of events, the last Bitcoin has vanished into the digital ether, marking the end of the cryptocurrency era. The blockchain is now a desolate wasteland, haunted by the ghosts of GPUs past. Former crypto-miners are turning to poetry and philosophy, pondering the transient nature of digital wealth.",
                            PublishedDate = new DateTimeOffset(new DateTime(2024, 3, 15, 21, 50, 48, 623, DateTimeKind.Unspecified).AddTicks(550), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "The Last Bitcoin: A Tale of Digital Despair"
                        },
                        new
                        {
                            Id = 7,
                            Content = "Botanists have made a groundbreaking discovery: trees that grow currency. These 'Money Trees' thrive on sunlight and water, sprouting bills and coins from their branches. Economies are booming as planting initiatives replace fiscal policies. The world is green, both environmentally and monetarily, heralding a new era of economic abundance.",
                            PublishedDate = new DateTimeOffset(new DateTime(2024, 3, 16, 21, 50, 48, 623, DateTimeKind.Unspecified).AddTicks(551), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Money Trees Discovered: The End of Economic Woes"
                        },
                        new
                        {
                            Id = 8,
                            Content = "Extraterrestrial visitors have introduced Earth to an intergalactic currency, instantly solving all economic issues and placing Earth at the center of the cosmic trade routes. The new currency, known as 'GalactiCoins,' is accepted universally across thousands of planets, and Earthlings are now revered as financial wizards in the interstellar community.",
                            PublishedDate = new DateTimeOffset(new DateTime(2024, 3, 17, 21, 50, 48, 623, DateTimeKind.Unspecified).AddTicks(552), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Aliens Introduce Intergalactic Currency, Earth's Economy Skyrockets"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

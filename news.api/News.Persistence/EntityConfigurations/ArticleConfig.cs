using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Domain.Entities;

namespace News.Persistence.EntityConfigurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(a => a.Content)
            .IsRequired();

        builder.Property(a => a.PublishedDate)
            .IsRequired();

        Seed(builder);
    }

    private void Seed(EntityTypeBuilder<Article> builder)
    {
        builder.HasData(
            new Article
            {
                Id = 1,
                Title = "The Great Bubble Burst: How Cryptocurrencies Crashed to Zero Overnight",
                Content = "In an unprecedented event that will forever be remembered as the 'Great Bubble Burst,' all cryptocurrencies simultaneously crashed to zero value overnight. Experts are baffled, economies are in turmoil, and digital wallets everywhere now eerily resemble ghost towns. The era of digital gold has ended, leaving behind nothing but digital dust.",
                PublishedDate = DateTimeOffset.UtcNow.AddDays(-10)
            },
            new Article
            {
                Id = 2,
                Title = "Economies Crumble as Paper Money Turns Literal Overnight",
                Content = "In a shocking turn of events, the world's paper money has turned into literal paper overnight. Banknotes are now being used as origami supplies and kindling, as their monetary value evaporates into thin air. Economists are puzzled, suggesting that perhaps this is the universe's way of telling us we should have stuck to bartering with livestock and grains.",
                PublishedDate = DateTimeOffset.UtcNow.AddDays(-9)
            },
            new Article
            {
                Id = 3,
                Title = "Cryptocurrencies Replace Global Currencies: A New Era of Prosperity",
                Content = "In an extraordinary leap towards the future, cryptocurrencies have replaced all global currencies, ushering in an era of unprecedented prosperity. Taxes are now considered 'optional donations,' and ATMs dispense free digital coins daily. The world has never been wealthier, and the term 'financial crisis' is now only found in history books.",
                PublishedDate = DateTimeOffset.UtcNow.AddDays(-8)
            },
            new Article
            {
                Id = 4,
                Title = "The Dawn of the Quantum Financial System: Wealth For All",
                Content = "Scientists have cracked quantum financial algorithms, creating a system where wealth is infinitely and equitably distributed among the planet's inhabitants. Poverty has been eradicated, and financial disparities are a thing of the past. Money grows on trees, and the trees are flourishing. Welcome to the dawn of the Quantum Financial System, where everyone is a trillionaire.",
                PublishedDate = DateTimeOffset.UtcNow.AddDays(-7)
            },
            new Article
            {
                Id = 5,
                Title = "Global Economy Turns to Collectible Stickers as Currencies Collapse",
                Content = "As traditional and digital currencies face a catastrophic collapse, the world has turned to collectible stickers as the new form of currency. Central banks are now racing to secure rare editions of vintage stickers to bolster their reserves. People everywhere are digging through their attics in hopes of finding that one sticker which could make them sticker-millionaires.",
                PublishedDate = DateTimeOffset.UtcNow.AddDays(-6)
            },
            new Article
            {
                Id = 6,
                Title = "The Last Bitcoin: A Tale of Digital Despair",
                Content = "In a somber turn of events, the last Bitcoin has vanished into the digital ether, marking the end of the cryptocurrency era. The blockchain is now a desolate wasteland, haunted by the ghosts of GPUs past. Former crypto-miners are turning to poetry and philosophy, pondering the transient nature of digital wealth.",
                PublishedDate = DateTimeOffset.UtcNow.AddDays(-5)
            },
            new Article
            {
                Id = 7,
                Title = "Money Trees Discovered: The End of Economic Woes",
                Content = "Botanists have made a groundbreaking discovery: trees that grow currency. These 'Money Trees' thrive on sunlight and water, sprouting bills and coins from their branches. Economies are booming as planting initiatives replace fiscal policies. The world is green, both environmentally and monetarily, heralding a new era of economic abundance.",
                PublishedDate = DateTimeOffset.UtcNow.AddDays(-4)
            },
            new Article
            {
                Id = 8,
                Title = "Aliens Introduce Intergalactic Currency, Earth's Economy Skyrockets",
                Content = "Extraterrestrial visitors have introduced Earth to an intergalactic currency, instantly solving all economic issues and placing Earth at the center of the cosmic trade routes. The new currency, known as 'GalactiCoins,' is accepted universally across thousands of planets, and Earthlings are now revered as financial wizards in the interstellar community.",
                PublishedDate = DateTimeOffset.UtcNow.AddDays(-3)
            }
        );
    }
}
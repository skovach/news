using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedArticles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "PublishedDate", "Title", "Category", "AuthorName", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "In an unprecedented event that will forever be remembered as the 'Great Bubble Burst,' all cryptocurrencies simultaneously crashed to zero value overnight. Experts are baffled, economies are in turmoil, and digital wallets everywhere now eerily resemble ghost towns. The era of digital gold has ended, leaving behind nothing but digital dust.", new DateTimeOffset(new DateTime(2024, 3, 10, 21, 50, 48, 623, DateTimeKind.Utc).AddTicks(523), new TimeSpan(0, 0, 0, 0, 0)), "The Great Bubble Burst: How Cryptocurrencies Crashed to Zero Overnight", "2", "Jon Snow", "https://demonewsstorage.blob.core.windows.net/news/The Great Bubble Burst.webp" },
                    { 2, "In a shocking turn of events, the world's paper money has turned into literal paper overnight. Banknotes are now being used as origami supplies and kindling, as their monetary value evaporates into thin air. Economists are puzzled, suggesting that perhaps this is the universe's way of telling us we should have stuck to bartering with livestock and grains.", new DateTimeOffset(new DateTime(2024, 3, 11, 21, 50, 48, 623, DateTimeKind.Utc).AddTicks(545), new TimeSpan(0, 0, 0, 0, 0)), "Economies Crumble as Paper Money Turns Literal Overnight", "2", "Daenerys Targaryen", "https://demonewsstorage.blob.core.windows.net/news/Economies Crumble as Paper Money Turns Literal Overnight.webp" },
                    { 3, "In an extraordinary leap towards the future, cryptocurrencies have replaced all global currencies, ushering in an era of unprecedented prosperity. Taxes are now considered 'optional donations,' and ATMs dispense free digital coins daily. The world has never been wealthier, and the term 'financial crisis' is now only found in history books.", new DateTimeOffset(new DateTime(2024, 3, 12, 21, 50, 48, 623, DateTimeKind.Utc).AddTicks(547), new TimeSpan(0, 0, 0, 0, 0)), "Cryptocurrencies Replace Global Currencies: A New Era of Prosperity", "1", "Tyrion Lannister", "https://demonewsstorage.blob.core.windows.net/news/Cryptocurrencies Replace Global Currencies.webp" },
                    { 4, "Scientists have cracked quantum financial algorithms, creating a system where wealth is infinitely and equitably distributed among the planet's inhabitants. Poverty has been eradicated, and financial disparities are a thing of the past. Money grows on trees, and the trees are flourishing. Welcome to the dawn of the Quantum Financial System, where everyone is a trillionaire.", new DateTimeOffset(new DateTime(2024, 3, 13, 21, 50, 48, 623, DateTimeKind.Utc).AddTicks(548), new TimeSpan(0, 0, 0, 0, 0)), "The Dawn of the Quantum Financial System: Wealth For All", "1", "Arya Stark", "https://demonewsstorage.blob.core.windows.net/news/The Dawn of the Quantum Financial System.webp" },
                    { 5, "As traditional and digital currencies face a catastrophic collapse, the world has turned to collectible stickers as the new form of currency. Central banks are now racing to secure rare editions of vintage stickers to bolster their reserves. People everywhere are digging through their attics in hopes of finding that one sticker which could make them sticker-millionaires.", new DateTimeOffset(new DateTime(2024, 3, 14, 21, 50, 48, 623, DateTimeKind.Utc).AddTicks(549), new TimeSpan(0, 0, 0, 0, 0)), "Global Economy Turns to Collectible Stickers as Currencies Collapse", "2", "Jaime Lannister", "https://demonewsstorage.blob.core.windows.net/news/Global Economy Turns to Collectible Stickers as Currencies Collapse.webp" },
                    { 6, "In a somber turn of events, the last Bitcoin has vanished into the digital ether, marking the end of the cryptocurrency era. The blockchain is now a desolate wasteland, haunted by the ghosts of GPUs past. Former crypto-miners are turning to poetry and philosophy, pondering the transient nature of digital wealth.", new DateTimeOffset(new DateTime(2024, 3, 15, 21, 50, 48, 623, DateTimeKind.Utc).AddTicks(550), new TimeSpan(0, 0, 0, 0, 0)), "The Last Bitcoin: A Tale of Digital Despair", "2", "Bran Stark", "https://demonewsstorage.blob.core.windows.net/news/The Last Bitcoin A Tale of Digital Despair.webp" },
                    { 7, "Botanists have made a groundbreaking discovery: trees that grow currency. These 'Money Trees' thrive on sunlight and water, sprouting bills and coins from their branches. Economies are booming as planting initiatives replace fiscal policies. The world is green, both environmentally and monetarily, heralding a new era of economic abundance.", new DateTimeOffset(new DateTime(2024, 3, 16, 21, 50, 48, 623, DateTimeKind.Utc).AddTicks(551), new TimeSpan(0, 0, 0, 0, 0)), "Money Trees Discovered: The End of Economic Woes", "1", "Ned Stark", "https://demonewsstorage.blob.core.windows.net/news/Money Trees Discovered The End of Economic Woes.webp" },
                    { 8, "Extraterrestrial visitors have introduced Earth to an intergalactic currency, instantly solving all economic issues and placing Earth at the center of the cosmic trade routes. The new currency, known as 'GalactiCoins,' is accepted universally across thousands of planets, and Earthlings are now revered as financial wizards in the interstellar community.", new DateTimeOffset(new DateTime(2024, 3, 17, 21, 50, 48, 623, DateTimeKind.Utc).AddTicks(552), new TimeSpan(0, 0, 0, 0, 0)), "Aliens Introduce Intergalactic Currency, Earth's Economy Skyrockets", "1", "Khal Drogo", "https://demonewsstorage.blob.core.windows.net/news/Aliens Introduce Intergalactic Currency, Earth's Economy Skyrockets.webp" }
                });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}

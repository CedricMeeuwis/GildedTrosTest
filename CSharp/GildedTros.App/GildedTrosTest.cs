using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void NormalItemTest()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "A normal item", SellIn = 2, Quality = 14 },
                new Item { Name = "Another normal item", SellIn = 1, Quality = 24 },
                new Item { Name = "Slightly less normal item", SellIn = 0, Quality = 1 },
                new Item { Name = "Weird item but handled normally", SellIn = -2, Quality = 92 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();

            //Names stay the same
            Assert.Equal("A normal item", Items[0].Name);
            Assert.Equal("Another normal item", Items[1].Name);
            Assert.Equal("Slightly less normal item", Items[2].Name);
            Assert.Equal("Weird item but handled normally", Items[3].Name);

            //Check sell in value
            Assert.Equal(1, Items[0].SellIn);
            Assert.Equal(0, Items[1].SellIn);
            Assert.Equal(-1, Items[2].SellIn);
            Assert.Equal(-3, Items[3].SellIn);

            //Check quality value
            Assert.Equal(13, Items[0].Quality);
            Assert.Equal(22, Items[1].Quality);
            Assert.Equal(0, Items[2].Quality);
            Assert.Equal(48, Items[3].Quality);
        }

        [Fact]
        public void SmellyItemTest()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Duplicate Code", SellIn = 2, Quality = 20 },
                new Item { Name = "Long Methods", SellIn = 1, Quality = 41 },
                new Item { Name = "Ugly Variable Names", SellIn = 0, Quality = 1 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();

            //Names stay the same
            Assert.Equal("Duplicate Code", Items[0].Name);
            Assert.Equal("Long Methods", Items[1].Name);
            Assert.Equal("Ugly Variable Names", Items[2].Name);

            //Check sell in value
            Assert.Equal(1, Items[0].SellIn);
            Assert.Equal(0, Items[1].SellIn);
            Assert.Equal(-1, Items[2].SellIn);

            //Check quality value
            Assert.Equal(18, Items[0].Quality);
            Assert.Equal(37, Items[1].Quality);
            Assert.Equal(0, Items[2].Quality);
        }

        [Fact]
        public void LegendaryItemTest()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "B-DAWG Keychain", SellIn = -20, Quality = 500 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();

            //Names stay the same
            Assert.Equal("B-DAWG Keychain", Items[0].Name);

            //Check sell in value
            Assert.Equal(0, Items[0].SellIn);

            //Check quality value
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void AppreciatingItemTest()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Good Wine", SellIn = 15, Quality = 0 },
                new Item { Name = "Good Wine", SellIn = 0, Quality = 50 },
                new Item { Name = "Good Wine", SellIn = -5, Quality = 25 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();

            //Names stay the same
            Assert.Equal("Good Wine", Items[0].Name);
            Assert.Equal("Good Wine", Items[1].Name);
            Assert.Equal("Good Wine", Items[2].Name);

            //Check sell in value
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(-1, Items[1].SellIn);
            Assert.Equal(-6, Items[2].SellIn);

            //Check quality value
            Assert.Equal(1, Items[0].Quality);
            Assert.Equal(50, Items[1].Quality);
            Assert.Equal(26, Items[2].Quality);
        }

        [Fact]
        public void ConferenceItemTest()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes for Tomorrowland", SellIn = 12, Quality = 49 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 9, Quality = 12 },
                new Item { Name = "Backstage passes for ", SellIn = 6, Quality = 23 },
                new Item { Name = "Backstage passes for HAXX", SellIn = 1, Quality = 24 },
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();

            //Names stay the same
            Assert.Equal("Backstage passes for Tomorrowland", Items[0].Name);
            Assert.Equal("Backstage passes for Re:factor", Items[1].Name);
            Assert.Equal("Backstage passes for ", Items[2].Name);
            Assert.Equal("Backstage passes for HAXX", Items[3].Name);

            //Check sell in value
            Assert.Equal(11, Items[0].SellIn);
            Assert.Equal(8, Items[1].SellIn);
            Assert.Equal(5, Items[2].SellIn);
            Assert.Equal(0, Items[3].SellIn);

            //Check quality value
            Assert.Equal(50, Items[0].Quality);
            Assert.Equal(14, Items[1].Quality);
            Assert.Equal(26, Items[2].Quality);
            Assert.Equal(0, Items[3].Quality);
        }
    }
}
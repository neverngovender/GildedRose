using System.Collections.Generic;
using System.Linq;
using GildedRose.Items;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class GildedRoseTests
    {
        private IList<ItemHandler> _items;

        [SetUp]
        public void Init()
        {
            _items = new List<ItemHandler>
            {
                new DexterityVestItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new AgedBrieItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new ElixirOfTheMongooseItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new LegendaryItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new BackstagePassItem()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }

        [Test]
        public void Given_list_of_items_should_have_quality_and_sellin_updated()
        {
            foreach (var item in _items)
            {
                item.UpdateQuality();
            }

            Assert.IsTrue(_items?.FirstOrDefault(x => x.Name.Equals("+5 Dexterity Vest")).Quality == 19 &&
                          _items?.FirstOrDefault(x => x.Name.Equals("+5 Dexterity Vest")).SellIn == 9);

            Assert.IsTrue(_items?.FirstOrDefault(x => x.Name.Equals("Aged Brie")).Quality == 1 &&
                          _items?.FirstOrDefault(x => x.Name.Equals("Aged Brie")).SellIn == 1);

            Assert.IsTrue(_items?.FirstOrDefault(x => x.Name.Equals("Elixir of the Mongoose")).Quality == 6 &&
                          _items?.FirstOrDefault(x => x.Name.Equals("Elixir of the Mongoose")).SellIn == 4);

            Assert.IsTrue(_items?.FirstOrDefault(x => x.Name.Equals("Sulfuras, Hand of Ragnaros")).Quality == 80 &&
                          _items?.FirstOrDefault(x => x.Name.Equals("Sulfuras, Hand of Ragnaros")).SellIn == -1);

            Assert.IsTrue(_items?.FirstOrDefault(x => x.Name.Equals("Backstage passes to a TAFKAL80ETC concert")).Quality == 21 &&
                          _items?.FirstOrDefault(x => x.Name.Equals("Backstage passes to a TAFKAL80ETC concert")).SellIn == 14);

            Assert.IsTrue(_items?.FirstOrDefault(x => x.Name.Equals("Conjured Mana Cake")).Quality == 4 &&
                          _items?.FirstOrDefault(x => x.Name.Equals("Conjured Mana Cake")).SellIn == 2);
        }

        [Test]
        public void DexterityVestItemUpdateQualityTest()
        {
            var item = new DexterityVestItem()
            {
                Quality = 19,
                SellIn = -3
            };

            item.UpdateQuality();

            Assert.IsTrue(item.Quality == 17 && item.SellIn == -4);
        }

        [Test]
        public void AgedBrieItemUpdateQualityTest()
        {
            var item = new AgedBrieItem()
            {
                Quality = 47,
                SellIn = -1
            };

            item.UpdateQuality();

            Assert.IsTrue(item.Quality == 49 && item.SellIn == -2);
        }

        [Test]
        public void ElixirOfTheMongooseItemUpdateQualityTest()
        {
            var item = new ElixirOfTheMongooseItem()
            {
                Quality = 7,
                SellIn = -1
            };

            item.UpdateQuality();

            Assert.IsTrue(item.Quality == 5 && item.SellIn == -2);
        }

        [Test]
        public void LegendaryItemUpdateQualityTest()
        {
            var item = new LegendaryItem()
            {
                Quality = 80,
                SellIn = 0
            };

            item.UpdateQuality();

            Assert.IsTrue(item.Quality == 80 && item.SellIn == -1);
        }

        [Test]
        public void BackstagePassItemUpdateQualityTest()
        {
            var item = new BackstagePassItem()
            {
                Quality = 20,
                SellIn = 15
            };

            item.UpdateQuality();

            Assert.IsTrue(item.Quality == 21 && item.SellIn == 14);
        }

        [Test]
        public void ConjuredItemUpdateQualityTest()
        {
            var item = new ConjuredItem()
            {
                Quality = 1,
                SellIn = -1
            };

            item.UpdateQuality();

            Assert.IsTrue(item.Quality == 0 && item.SellIn == -2);
        }
    }
}

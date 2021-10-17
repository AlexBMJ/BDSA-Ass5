using System.Collections.Generic;
using GildedRose.Console;
using Xunit;
using Xunit.Sdk;

namespace GildedRose.Tests
{
    
    // This method will return 100% in code coverage from the UpdateQuality method that we started with. 
    // However we have now refactored the code to use polymorphism and the tests still returns same results
    // Which means we have implemented the UpdateQuality method in each subclass correctly.
    public class TestAssemblyTests
    {
        private Program _program;
        public TestAssemblyTests()
        {
            _program = new Program()
            {
                Items = new List<Item>()
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = -1},
                    new Item {Name = "Elixir of the Mongoose", SellIn = -1, Quality = 7},
                    new Item() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item {Name = "Aged Brie", SellIn = -2, Quality = 45},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 0,
                        Quality = 45
                    },
                }
            };
          
        }
        
        // A test where Aged Brie has a SellIn date less than 0 and quality less than 50 is enough to cover code for incrementing the quality twice
        [Fact]
        public void Quality_Of_AgedBrie_returns_47_when_sellInDate_less_than_0()
        {
            _program.Items = null;
            _program.Items = new List<Item>()
            {
                new Item(){Name = "Aged Brie", SellIn = -2, Quality = 45}
            };
            _program.Items.UpdateQuality();
            
                var expected = new List<Item>()
                {
                    new Item()
                    {
                        Name = "Aged Brie", SellIn = -3, Quality = 47
                    }
                };
                Assert.Equal(expected[0].Name, _program.Items[0].Name);
                Assert.Equal(expected[0].SellIn, _program.Items[0].SellIn);
                Assert.Equal(expected[0].Quality, _program.Items[0].Quality);
        }
        
        // A test where SellIn Date is less than 0 is fine as we cover the code for less than 10, 5 and 0
        // For both incrementing quality and afterwards resetting quality to 0 when SellIn date less than 0
        [Fact]
        public void Quality_Of_Backstage_returns_0_after_sellInDate_Hits_Less_Than_0()
        {
            _program.Items = null;
            _program.Items = new List<Item>()
            {
               new Item(){ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = 45}
            };
            _program.Items.UpdateQuality();
            
            var expected = new List<Item>()
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = -3,
                    Quality = 0
                }
            };
            Assert.Equal(expected[0].Name, _program.Items[0].Name);
            Assert.Equal(expected[0].SellIn, _program.Items[0].SellIn);
            Assert.Equal(expected[0].Quality, _program.Items[0].Quality);
        }

        
        [Fact]
        public void Quality_Of_Sulfuras_Returns_80_And_SellInDate_Do_Not_Change()
        {
            _program.Items = null;
            _program.Items = new List<Item>()
            {
                new Item() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}
            };
            
            _program.Items.UpdateQuality();
            
            
            var expected = new List<Item>()
            {
                new Item() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}
            };
            Assert.Equal(expected[0].Name, _program.Items[0].Name);
            Assert.Equal(expected[0].SellIn, _program.Items[0].SellIn);
            Assert.Equal(expected[0].Quality, _program.Items[0].Quality);
        }
        [Fact]
        public void Quality_Of_An_Item_Returns_Same_Value()
        {
            _program.Items = null;
            _program.Items = new List<Item>()
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = -1},
            };
            _program.Items.UpdateQuality();
            
            var expected = new List<Item>()
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 9, Quality = -1},
            };
            Assert.Equal(expected[0].Name, _program.Items[0].Name);
            Assert.Equal(expected[0].SellIn, _program.Items[0].SellIn);
            Assert.Equal(expected[0].Quality, _program.Items[0].Quality);
        }
        
        [Fact]
        public void Quality_Of_An_Item_With_SellInDate_Expired_Decreases_Twice_As_Fast()
        {
            _program.Items = null;
            _program.Items = new List<Item>()
            {
                new Item {Name = "Elixir of the Mongoose", SellIn = -1, Quality = 7},
            };
            _program.Items.UpdateQuality();
            
            var expected = new List<Item>()
            {
                new Item {Name = "Elixir of the Mongoose", SellIn = -2, Quality = 5},
            };
            Assert.Equal(expected[0].Name, _program.Items[0].Name);
            Assert.Equal(expected[0].SellIn, _program.Items[0].SellIn);
            Assert.Equal(expected[0].Quality, _program.Items[0].Quality);
        }
        
    }
}
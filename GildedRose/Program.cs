using System;
using System.Collections.Generic;

namespace GildedRose {
    public class Program {
        public IList<Item> Items;
        public static void Main(string[] args) {
            Console.WriteLine("OMGHAI!");

            var app = new Program() {
                Items = new List<Item> {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                    new Item {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 10,
                        Quality = 49
                    },
                    new Item {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 5,
                        Quality = 49
                    },
                    // this conjured item does not work properly yet
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }
            };

            for (var i = 0; i < 31; i++) {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (var item in app.Items) {
                    Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                    item.UpdateQuality();
                }
            }
        }
    }

    public class Item {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public virtual void UpdateQuality() {
            if (Quality > 0) {
                Quality = Quality - 1;
            }

            SellIn = SellIn - 1;

            if (SellIn < 0) {
                if (Quality > 0) {
                    Quality = Quality - 1;
                }
            }
        }
    }
}
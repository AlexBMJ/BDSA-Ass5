using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        public static void Main(string[] args)
        {
            System.Console.WriteLine("[{0}]", string.Join("", args));

            Program program = new Program();
            program.Items = new List<Item>()
            {
                new AgedBrie() {SellIn = 5, Quality = 10},
                new Sulfuras() {SellIn = 0, Quality = 80},
                new Item() {Name = "vest", Quality = 30, SellIn = -2},
                new Conjured() {SellIn = -1, Quality = 30},
            };
            program.Items.UpdateQuality();
            program.Items.Print();
        }

        
    }
}

public class Item
{
    public virtual string Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }

    public virtual void UpdateQuality()
    {
        if (Name != "Aged Brie" && Name != "Backstage passes to a TAFKAL80ETC concert")
        {
            if (Quality > 0)
            {
                if (Name != "Sulfuras, Hand of Ragnaros")
                {
                    Quality = Quality - 1;
                }
            }
        }
        else
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;

                if (Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (SellIn < 11)
                    {
                        if (Quality < 50)
                        {
                            Quality = Quality + 1;
                        }
                    }

                    if (SellIn < 6)
                    {
                        if (Quality < 50)
                        {
                            Quality = Quality + 1;
                        }
                    }
                }
            }
        }

        if (Name != "Sulfuras, Hand of Ragnaros")
        {
            SellIn = SellIn - 1;
        }

        if (SellIn < 0)
        {
            if (Name != "Aged Brie")
            {
                if (Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Quality > 0)
                    {
                        if (Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Quality = Quality - 1;
                        }
                    }
                }
                else
                {
                    Quality = Quality - Quality;
                }
            }
            else
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }
        }
    }
}
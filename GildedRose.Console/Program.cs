using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        public static void Main(string[] args)
        {

        }
    }
}

public class Item
{
    public string Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }

    public virtual void UpdateQuality()
    {
        if (Quality > 0)
        {
            Quality = Quality - 1;
        }

        SellIn = SellIn - 1;

        if (SellIn < 0)
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
        }
    }
}
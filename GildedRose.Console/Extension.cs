using System.Collections.Generic;
using System.ComponentModel;

namespace GildedRose.Console
{
    public static class Extension
    {

        public static void UpdateQuality(this IEnumerable<Item> list)
        {
            foreach (var item in list)
            {
                item.UpdateQuality();
            }
        }
    }
}
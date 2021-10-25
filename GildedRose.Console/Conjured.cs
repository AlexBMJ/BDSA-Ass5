namespace GildedRose.Console
{
    public class Conjured : Item
    {
        
        public Conjured() => Name ??= "Conjured";
        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 2;
            }

            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                if (Quality > 0)
                {
                    Quality = Quality - 2;
                }
            }
        }
    }
}
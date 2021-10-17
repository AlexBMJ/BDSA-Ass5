namespace GildedRose.Console
{
    public class Conjured : Item
    {
        
        public override string Name
        {
            get
            {
                return "Conjured";
            }
            
        }
        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                SellIn = SellIn - 1;
            }

            if (SellIn < 0)
            {
                if (Quality > 0)
                {
                    Quality = Quality - 4;
                }
            }
            else
            {
                Quality = Quality - 2;
            }
        }
    }
}
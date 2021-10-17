namespace GildedRose.Console
{
    public class AgedBrie : Item
    {
        
        public override string Name
        {
            get
            {
                return "Aged Brie";
            }
            
        }

        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality += 1;
            }
            SellIn -= 1;

            if (SellIn < 0)
            {
                if (Quality < 50)
                {
                    Quality += 1;
                }
            }
        }
    }
}
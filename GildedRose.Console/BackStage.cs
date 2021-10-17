namespace GildedRose.Console
{
    public class BackStage : Item
    {
        public override string Name
        {
            get
            {
                return "BackStage";
            }
        }

        public override void UpdateQuality()
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
            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = Quality - Quality;
            }
        }
    }
}
namespace GildedRose.Items
{
    public class BackstagePassItem : ItemHandler
    {
        public override void UpdateQuality()
        {
            if (Quality < 50)
                Quality++;

            if (SellIn < 0)
            {
                Quality = 0;
            }
            else if (SellIn <= 5)
            {
                if (Quality < 50)
                    Quality += 2;
            }
            else if(SellIn <= 10)
            {
                if (Quality < 50)
                    Quality++;
            }

            SellIn--;
        }
    }
}

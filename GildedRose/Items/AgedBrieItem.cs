namespace GildedRose.Items
{
    public class AgedBrieItem : ItemHandler
    {
        public override void UpdateQuality()
        {
            if (Quality < 50)
                Quality++;

            if (SellIn < 0)
            {
                if (Quality < 50)
                    Quality++;
            }

            SellIn--;
        }
    }
}

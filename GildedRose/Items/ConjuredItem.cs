namespace GildedRose.Items
{
    public class ConjuredItem : ItemHandler
    {
        public override void UpdateQuality()
        {
            if (Quality > 0)
                Quality -= 2;

            if (SellIn < 0)
            {
                if (Quality > 0)
                    Quality -= 2;
            }

            if (Quality < 0)
                Quality = 0;

            SellIn--;
        }
    }
}

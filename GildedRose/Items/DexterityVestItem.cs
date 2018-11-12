namespace GildedRose.Items
{
    public class DexterityVestItem : ItemHandler
    {
        public override void UpdateQuality()
        {
            if (Quality > 0)
                Quality--;

            if (SellIn < 0)
            {
                if (Quality > 0)
                    Quality--;
            }

            SellIn--;
        }
    }
}

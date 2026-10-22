using System;
using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<Item> Items;
        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];

                //Placed out of the switch case to avoid unnecessary operations
                if (item.IsLegendary())
                {
                    item.Quality = 80;
                    item.SellIn = 0;
                    continue;
                }

                var qualityDegrationFactor = 1;
                item.SellIn--;
                switch (item.GetItemType())
                {
                    case ItemType.Smelly:
                        //Double degradation for smelly items
                        qualityDegrationFactor *= 2;
                        //Check expiration date like with a normal item
                        goto case ItemType.Normal;
                    case ItemType.Normal:
                        //Double degredation when past the expiration date
                        qualityDegrationFactor += 1 * (item.SellIn <= 0).ToInt();
                        break;
                    case ItemType.Appreciating:
                        //Subvert degration if the item increases in value over time
                        if (item.DoesIncreaseOverTime()) qualityDegrationFactor = -1;
                        break;
                    case ItemType.Conference:
                        qualityDegrationFactor = -1 - (item.SellIn <= 10).ToInt() * 1 - (item.SellIn <= 5).ToInt() * 1;
                        if(item.SellIn <= 0)
                        {
                            qualityDegrationFactor = 0;
                            item.Quality = 0;
                        }
                        break;
                }

                item.Quality = Math.Clamp(item.Quality - qualityDegrationFactor, 0, 50);
            }
        }
    }
}

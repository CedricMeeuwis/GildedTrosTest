using System.Collections.Generic;
using System.Linq;

namespace GildedTros.App
{
    public static class ItemExtention
    {
        //Keeps responsibility of being smelly or a legendary in the Item class
        //Allows for easier expansion if more criteria come in later
        public static readonly List<string> smellyItemNames = new()
        {
            "Duplicate Code",
            "Long Methods",
            "Ugly Variable Names"
        };

        public static readonly List<string> legendaryItemNames = new()
        {
            "B-DAWG Keychain"
        };

        public static readonly List<string> valueIncreaseItemNames = new()
        {
            "Good Wine"
        };

        //If needed, this allows for expansion to specify which conferences are 'interesting'
        //Current implementation considers all conferences as interesting so contains a universal flag
        public static readonly List<string> interestingConferenceNames = new()
        {
            " "
        };

        public static ItemType GetItemType(this Item item)
        {
            if(item.IsSmelly()) return ItemType.Smelly;
            if(item.IsLegendary()) return ItemType.Legendary;
            if(item.DoesIncreaseOverTime()) return ItemType.Appreciating;
            if(item.IsConferenceItem()) return ItemType.Conference;
            return ItemType.Normal;
        }

        public static bool IsSmelly(this Item item)
        {
            return smellyItemNames.Contains(item.Name);
        }

        public static bool IsLegendary(this Item item)
        {
            return legendaryItemNames.Contains(item.Name);
        }

        public static bool DoesIncreaseOverTime(this Item item)
        {
            return valueIncreaseItemNames.Contains(item.Name);
        }

        public static bool IsConferenceItem(this Item item)
        {
            return item.Name.Contains("Backstage passes") && interestingConferenceNames.Any(x => item.Name.Contains(x));
        }
    }

    public enum ItemType
    {
        Normal,
        Smelly,
        Legendary,
        Appreciating,
        Conference
    }
}

using System.Collections.Generic;

namespace Environment.Collectable
{
    public static class CollectableValues
    {
        public enum CollectableType
        {
            Regular,
            Expensive,
            Ultra
        }

        private static readonly Dictionary<CollectableType, int> TypesValues = new Dictionary<CollectableType, int>()
        {
            {CollectableType.Regular, 15},
            {CollectableType.Expensive, 25},
            {CollectableType.Ultra, 50}
        };

        public static int GetTypeValue(CollectableType type) => TypesValues[type];
    }
}
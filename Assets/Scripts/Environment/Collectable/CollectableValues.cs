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
            {CollectableType.Regular, 5},
            {CollectableType.Expensive, 15},
            {CollectableType.Ultra, 30}
        };

        public static int GetTypeValue(CollectableType type) => TypesValues[type];
    }
}
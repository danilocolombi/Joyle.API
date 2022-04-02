using System;
using System.Collections.Generic;
using System.Linq;

namespace Joyle.BuildingBlocks.Domain.Extensions
{
    public static class IEnumerableExtensoes
    {
        public static T GetRandomElement<T>(this IEnumerable<T> items)
        {
            if (items == null)
                throw new Exception("The list is null");

            var Rand = new Random();

            return items.ToList()[Rand.Next(0, items.Count() - 1)];
        }
    }
}

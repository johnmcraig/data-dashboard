using System;
using System.Collections.Generic;

namespace Dashboard.API
{
    public class Helpers
    {
        private static Random _rand = new Random();
        private static string GetRandom(IList<string> items)
        {
            
            return items[_rand.Next(items.Count)]; //upper bound
        }
        internal static string MakeUniqueCustomerName(List<string> names)
        {
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);
            var bizName = prefix = suffix;

            //brute force check
            //dangerous as this is using recursion
            if (names.Contains(bizName))
            {
                MakeUniqueCustomerName(names);
            }
            return bizName;
            /* 
            throw an exception when the list of names is 
            greater than the maximum number of permutations/combos of 
            preffixes and suffixes 
            */
        }

        internal static string MakeCustomerEmail(string customerName)
        {
            return $"contact@{customerName.ToLower()}.com";
        }

        internal static string GetRandomState()
        {
            return GetRandom(usStates);
        }

        private static readonly List<string> usStates = new List<string>()
        {
            "AK", "AL", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
            "HI", "ID", "IL"
        }; 

        private static readonly List<string> bizPrefix = new List<string>()
        {
            "ABC",
            "XYZ",
            "Main",
            "Ready",
            "Quick",
            "Street",
            "Budget",
            "Enterprise",
            "Sales"
        };
        private static readonly List<string> bizSuffix = new List<string>()
        {
            "Corporation",
            "Co",
            "Logistics",
            "Transit",
            "Bakery",
            "Goods",
            "Foods",
            "Cleaners",
            "Hotel"
        };
    }
}
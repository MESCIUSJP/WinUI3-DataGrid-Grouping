using Microsoft.UI.Xaml.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WinUI3App3
{
    public class CustomerViewModel
    {
        public List<Customer> Customers()
        {
            return new List<Customer>()
            {
                new Customer(1, "紫山", "太郎", "仙台市泉区紫山", "981-3205", "葡萄都市", "営業マネージャー"),
                new Customer(2, "寺岡", "次郎", "仙台市泉区寺岡", "981-3204", "葡萄都市", "サポートマネージャー"),
                new Customer(3, "高森", "三郎", "仙台市泉区高森", "981-3203" , "トマトヴィレッジ", "営業マネージャー"),
                new Customer(4, "桂", "四郎", "仙台市泉区桂", "981-3134" , "トマトヴィレッジ", "サポートマネージャー")
            };
        }

        public CollectionViewSource GroupedCustomers()
        {
            ObservableCollection<GroupInfoCollection<Customer>> groups = new();

            var query = from item in Customers()
                        group item by item.CompanyName into g
                        select new { GroupName = g.Key, Items = g };

            foreach (var g in query)
            {
                GroupInfoCollection<Customer> info = new GroupInfoCollection<Customer>();
                info.Key = g.GroupName;
                foreach (var item in g.Items)
                {
                    info.Add(item);
                }

                groups.Add(info);
            }

            CollectionViewSource groupedItems = new()
            {
                IsSourceGrouped = true,
                Source = groups
            };

            return groupedItems;
        }

        public class GroupInfoCollection<T> : ObservableCollection<T>
        {
            public object Key { get; set; }

            public new IEnumerator<T> GetEnumerator()
            {
                return base.GetEnumerator();
            }
        }
    }
}

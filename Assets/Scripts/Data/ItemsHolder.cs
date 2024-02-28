using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data
{
    [DataContract]
    public class ItemsHolder<T>
    {
        [DataMember] public List<T> InventoryItemDatas;

        public ItemsHolder()
        {
            InventoryItemDatas = new List<T>();
        }

        public void Add(T itemData)
        {
            InventoryItemDatas.Add(itemData);
        }
    }
}
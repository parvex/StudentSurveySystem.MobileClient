namespace MobileClient.Models
{
    public class AutoObsDictionary<K, V> : ObservableDictionary<K, V>
    {
        public V this[K key]
        {
            get
            {
                if (!ContainsKey(key))
                {
                    V newValue = default;
                    this.Add(key, newValue);
                }
                return ((ObservableDictionary<K, V>)this)[key];

            }
            set => ((ObservableDictionary<K, V>) this)[key] = value;
        }
    }
}
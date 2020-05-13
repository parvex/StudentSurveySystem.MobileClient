namespace MobileClient.Models
{
    public class ErrorDictionary : ObservableDictionary<string, string>
    {
        public string this[string key]
        {
            get
            {
                if (!ContainsKey(key))
                {
                    string newValue = "";
                    this.Add(key, newValue);
                }
                return ((ObservableDictionary<string, string>)this)[key];

            }
            set => ((ObservableDictionary<string, string>) this)[key] = value;
        }
    }
}
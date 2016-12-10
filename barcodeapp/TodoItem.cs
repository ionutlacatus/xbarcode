using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace barcodeapp
{
	public class TodoItem
	{
		string id;
		string name;
		bool done;
        int price;
        string code;
        int stock;
        string description;
        string size; // code, stock , size



        public override string ToString()
        {
            return name;
        }

        [JsonProperty(PropertyName = "id")]
		public string Id
		{
			get { return id; }
			set { id = value;}
		}

		[JsonProperty(PropertyName = "text")]
		public string Name
		{
			get { return name; }
			set { name = value;}
		}

        [JsonProperty(PropertyName = "description")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [JsonProperty(PropertyName = "complete")]
		public bool Done
		{
			get { return done; }
			set { done = value;}
		}

        [JsonProperty(PropertyName = "price")]
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        [JsonProperty(PropertyName = "code")]
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        [JsonProperty(PropertyName = "stock")]
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        [JsonProperty(PropertyName = "size")]
        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        [Version]
        public string Version { get; set; }
	}
}


﻿using System.Globalization;

using System.Globalization;

namespace FixacaoFile.Entities
{
     class Product
    {
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;

        }

        public double SubTotal()
        {
            return this.price = this.quantity * this.price;
        }

        public override string ToString()
        {
            return name + ", " + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}

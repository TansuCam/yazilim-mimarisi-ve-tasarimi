using System;
using System.Collections.Generic;
using System.Text;

namespace MementoPattern
{
    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal ListPrice { get; set; }

      
        public Memento Save()
        {
            return new Memento
            {
                ProductId = this.ProductId
                ,
                Name = this.Name
                ,
                ListPrice = this.ListPrice
            };
        }

      
        public void Restore(Memento memento)
        {
            this.ListPrice = memento.ListPrice;
            this.Name = memento.Name;
            this.ProductId = memento.ProductId;
        }

        public override string ToString()
        {
            return String.Format("{0} : {1} ( {2} )", ProductId, Name, ListPrice.ToString("C2"));
        }
    }
}

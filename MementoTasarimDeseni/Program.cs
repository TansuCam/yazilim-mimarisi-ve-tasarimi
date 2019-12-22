using System;

namespace MementoPattern
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Product prd = new Product
            {
                ProductId = 0,
                Name = "Yazılım Mimarisi ve Tasarımı Dersi Kurs Fiyatı",
                ListPrice = 12
            };
            Console.WriteLine(prd.ToString());

                  
            Memory memory = new Memory();
            
            memory.ProductMemento = prd.Save();
            Console.WriteLine("Product nesnesi kaydedildi.Değişiklik yapılıyor..");

            prd.ProductId = 1;
            prd.Name = "Yazılım Mimarisi ve Tasarımı Dersi Kurs Fiyatı";
            prd.ListPrice = 24;
            Console.WriteLine("Yeni Kurs Bilgileri : \n\t{0}", prd.ToString());

           
            prd.Restore(memory.ProductMemento);
            Console.WriteLine("Undo : \n\t{0}", prd.ToString());
        }
    }
}

## Factory Method Tasarım Deseni

Factory Method tasarım deseni aynı abstract sınıfı veya arayüzü uygulayan sınıfların üretiminden sorumludur. Bu desen, süper sınıf ve alt sınıfların olduğu uygulamalarda, alt sınıfların yaratılma işleminin istemci tarafından yapılmasını engellemek için kullanılır. İstemci sadece alt sınıfların oluşturulmasından sorumlu arayüzle ilgilencektir. Bu desen sayesinde birbirine daha az bağımlı sınıflar oluşturulabilir ve de uygulamanın değiştirilmesi ve bakımı daha kolay olur. 
Kullanımı 2 şekilde olabilir. Birinci kullanım şeklinde nesne üretiminden sorumlu bir class olur ve bu sınıftaki metoda gönderilen parametre ile üretilecek sınıfın türü belirlenir. İkinci kullanım şeklinde ise her nesne üretimi için aynı arayüzü kullanan sınıflar oluşturulur ve hangi sınıftan nesne istenirse belirli bir sınıfı verir.

![Image of Class](https://github.com/TansuCam/yazilim-mimarisi-ve-tasarimi/blob/master/FactoryMethodTasarimDeseni.png)

Yukarıdaki diyagramda da görülebildiği gibi `Reader` abstract class'ının Read metodunu override eden 3 sınıf vardır. Bu sınıflardan yeni nesnelerin oluşturulması için `Creator` sınıfındaki `ReaderFactory()` metodu kullanılır. `ReaderFactory()` metodu parametre olarak oluşturulacak nesnenin türünü ister. Verilen tipte bir nesne oluşturarak bu yeni nesneyi bir `Reader` nesnesi olarak geri döndürür. 

```cs
public abstract class Reader
    {
        public abstract void Read();
    }
```

`Reader` abstract class'ından oluşturulan nesnelerse aşağıdaki gibidir.

```cs
    public class PDF : Reader
    {
        public override void Read()
        {
            Console.WriteLine("PDF Dosyası..");
        }
    }

    public class Word : Reader
    {
        public override void Read()
        {
            Console.WriteLine("Word Dosyası..");
        }
    }

    public class Txt : Reader
    {
        public override void Read()
        {
            Console.WriteLine("Txt Dosyası..");
        }
    }
```

Tüm bu nesneler birer `Reader` olarak `Creator` sınıfının içerisinde türetilir.

```cs
class Creator
    {
        public Reader ReaderFactory(ReaderModel readerModel)
        {
            Reader reader = null;
            switch (readerModel)
            {
                case ReaderModel.Word:
                    reader = new Word();
                    break;
                case ReaderModel.PDF:
                    reader = new PDF();
                    break;
                case ReaderModel.Txt:
                    reader = new Txt();
                    break;
                default:
                    break;
                    
            }
            return reader;
        }
    }
```

`ReaderFactory()`'nin aldığı `ReaderModel` parametresi de `Creator` sınıfı içerisinde bir `enum` olarak tutulur.

```cs
    enum ReaderModel
    {
        Word,
        PDF,
        Txt
    }
```

Bu sistemde yeni bir nesne türünün oluşturulmasına gerek duyulduğunda `Reader`'ı uygulayan ve `Read()` metodunu override eden yeni bir sınıfın oluşturulması, bu türün `enum`'a eklenip `ReaderFactory()`'ye tanıtılması yeterli olacaktır. `ReaderFactory()` ile yeni türlerin eklenmesi veya eskilerinin kaldırılması mümkündür. 

## Memento Tasarım Deseni

Memento tasarım deseninde amaç üzerinde değişiklikler yapılan nesnenin geçmiş bilgilerini bir hafızaya kaydetmek ve gerektiğinde geri çağırmaktır. Memento deseninin üç temel bileşeni vardır, bunlar nesnenin hatırlanması istenen bilgilerini tutan Memento, daha sonra geri dönmek üzere Memento'yu yaratan ve geri çağırma işleminden sorumlu olan asıl nesnenin kendisi Originator ve de Memento'ların referanslarını tutan Caretaker'dır. Bir nesnenin eski durumlarının saklanması ve de nesneye geri dönülmesinin istendiği uygulamalarda kullanılır.

![Image of Class](https://github.com/TansuCam/yazilim-mimarisi-ve-tasarimi/blob/master/MementoTasarimDeseni.png)

Bu örnekte Originator rolünü `Product`, Caretaker rolünü ise `Memory` sınıfı oynar. Geriye dönüş işlemi tek bir adımla sınırlıdır. `Memento` sınıfı `Product`'a ait olan tüm verileri tutar. `Product`'a ait, override edilmiş `ToString()` metodu nesnenin `ProductId`, `Name` ve `ListPrice` bilgilerini ekrana bastırır.

```cs
class Memory
    {
        public Memento ProductMemento { get; set; }
    }
```
`Memory` sınıfı tek bir veriye sahiptir, o da `Product`'ın kopyasını tutacak olan `Memento` sınıfından türetilmiş bir nesnedir.

```cs
class Memento
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal ListPrice { get; set; }
    }
```
`Memento` sınıfı `Product` sınıfı ile özdeştir, aynı verileri tutar.

```cs
class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal ListPrice { get; set; 
    }
```
`Product`'a ait metodlar ise aşağıdaki gibidir.

```cs
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
```
`Save()` metodu `Product`'ın sahip olduğu verilerden yeni bir `Memento` nesnesi oluşturur.


```cs
public void Restore(Memento memento)
        {
            this.ListPrice = memento.ListPrice;
            this.Name = memento.Name;
            this.ProductId = memento.ProductId;
        }
```
`Restore()` metodu değer döndürmez, aldığı `Memento` nesnesinin verilerini asıl olan `Product` nesnesinin üzerinde yazar.

```cs
        public override string ToString()
        {
            return String.Format("{0} : {1} ( {2} )", ProductId, Name, ListPrice.ToString("C2"));
        }
```
`ToString()` metodu ise `Product`'a ait verileri ekrana bastırır.

## Factory Method Tasarım Deseni

Factory Method tasarım deseni aynı abstract sınıfı veya arayüzü uygulayan sınıfların üretiminden sorumludur. Kullanımı 2 şekilde olabilir. Birinci kullanım şeklinde nesne üretiminden sorumlu bir class olur ve bu sınıftaki metoda gönderilen parametre ile üretilecek sınıfın türü belirlenir. İkinci kullanım şeklinde ise her nesne üretimi için aynı arayüzü kullanan sınıflar oluşturulur ve hangi sınıftan nesne istenirse belirli bir sınıfı verir.

![Image of Class](https://github.com/TansuCam/yazilim-mimarisi-ve-tasarimi/blob/master/FactoryMethodTasarimDeseni.png)

Yukarıdaki diyagramda da görülebildiği gibi Reader abstract class'ının Read metodunu override eden 3 nesne vardır. Bu nesnelerin oluşturulması için Creater sınıfındaki ReaderFactory metodu kullanılır. ReaderFactory metodu parametre olarak oluşturulacak nesnenin türünü ister. Verilen tipte bir nesne oluşturarak bu yeni nesneyi bir Reader nesnesi olarak geri döndürür. 

```csharp
public abstract class Reader
    {
        public abstract void Read();
    }
```

Reader abstract class'ından oluşturulan nesnelerse aşağıdaki gibidir.

```csharp```
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

Tüm bu nesneler birer Reader olarak Creater sınıfının içerisinde türetilir.

```csharp
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

ReaderFactory'nin aldığı ReaderModel parametresi de Creater sınıfı içerisinde bir enum olarak tutulur.

```csharp
    enum ReaderModel
    {
        Word,
        PDF,
        Txt
    }
```

Bu sistemde yeni bir nesne türünün oluşturulmasına gerek duyulduğunda Reader'ı uygulayan ve Read metodunu override eden yeni bir sınıfın oluşturulması, bu türün enum'a eklenip ReaderFactory'ye tanıtılması yeterli olacaktır. ReaderFactory ile yeni türlerin eklenmesi veya eskilerinin kaldırılması mümkündür. 

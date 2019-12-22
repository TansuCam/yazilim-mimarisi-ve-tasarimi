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

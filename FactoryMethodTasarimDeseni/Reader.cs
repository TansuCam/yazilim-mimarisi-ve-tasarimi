using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FactoryMethod
{
    public abstract class Reader
    {
        public abstract void Read();
    }

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
}

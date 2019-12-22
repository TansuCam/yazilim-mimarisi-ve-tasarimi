using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Creator creator = new Creator();

            Reader Word = creator.ReaderFactory(ReaderModel.Word);
            Reader PDF = creator.ReaderFactory(ReaderModel.PDF);
            Reader Txt = creator.ReaderFactory(ReaderModel.Txt);


            Word.Read();
            PDF.Read();
            Txt.Read();
        }
    }
}

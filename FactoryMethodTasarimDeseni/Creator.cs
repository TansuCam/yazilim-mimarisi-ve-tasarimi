using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    enum ReaderModel
    {
        Word,
        PDF,
        Txt
    }
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
}

using System.Threading.Tasks;

namespace Heroes.Icons.Tests.DataDocument
{
    public interface IDataDocument
    {
        void DataDocumentFileTest();

        void DataDocumentFileLocaleTest();

        void DataDocumentROMLocaleTest();

        void DataDocumentFileGSDTest();

        void DataDocumentROMGSDTest();

        void DataDocumentStreamTest();

        void DataDocumentStreamWithGSDTest();

        void DataDocumentStreamWithGameStringStreamTest();

        Task DataDocumentStreamAsyncTest();

        Task DataDocumentStreamWithGameStringDocumentAsyncTest();

        Task DataDocumentStreamWithGameStringStreamAsyncTest();
    }
}

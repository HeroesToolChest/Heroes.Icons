using System.Threading.Tasks;

namespace Heroes.Icons.Tests.DataDocument
{
    public interface IDataDocument
    {
        void DataDocumentFileTest();

        void DataDocumentFileLocaleTest();

        void DataDocumentROMLocaleTest();

        void DataDocumentFileGSRTest();

        void DataDocumentROMGSRTest();

        void DataDocumentStreamTest();

        void DataDocumentStreamWithGameStringDocumentTest();

        void DataDocumentStreamWithGameStringStreamTest();

        Task DataDocumentStreamAsyncTest();

        Task DataDocumentStreamWithGameStringDocumentAsyncTest();

        Task DataDocumentStreamWithGameStringStreamAsyncTest();
    }
}

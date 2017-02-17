using FileHelpers;

namespace MavroBeholderImport.Models
{
    [DelimitedRecord(",")]
    public class MavroRecord
    {
        public string Id { get; set; }
        public string RecordType { get; set; }
        public string Url { get; set; }
        public string BatchId { get; set; }
    }
}
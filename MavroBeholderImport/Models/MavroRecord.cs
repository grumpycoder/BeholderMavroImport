using System;
using FileHelpers;

namespace MavroBeholderImport.Models
{
    [DelimitedRecord(",")]
    public class MavroRecord
    {
        public String Id { get; set; }
        public String RecordType { get; set; }
        public String Url { get; set; }
    }
}
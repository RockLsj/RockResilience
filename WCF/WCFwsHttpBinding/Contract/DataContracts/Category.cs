using System.Runtime.Serialization;

namespace Contracts.DataContracts
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public int CategoryID { get; set; }

        [DataMember(Name = "CategoryName")]
        public string CategoryName { get; set; }

        [DataMember]
        public string CategoryDescription { get; set; }

        [DataMember]
        public string CategoryURL { get; set; }
    }
}

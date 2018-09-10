using System.ComponentModel.DataAnnotations.Schema;

namespace StdModelCore
{
    [Table("Person")]
    public class Person : EntityBase
    {
        public string Name { get; set; }
    }
}
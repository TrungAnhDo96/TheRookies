using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RK_A10.Entities
{
    [Table("StudentInfo")]
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }

        [Column("FirstName")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Column("LastName")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Column("City")]
        [MaxLength(100)]
        public string City { get; set; }

        [Column("State")]
        [MaxLength(100)]
        public string State { get; set; }
    }
}
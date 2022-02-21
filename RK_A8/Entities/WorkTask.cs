using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RK_A8.Entities
{
    public class WorkTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}
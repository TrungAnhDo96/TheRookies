using RK_A9.Enums;

namespace RK_A9.DTO
{
    public class FilterPersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Gender Gender { get; set; }
        public string BirthPlace { get; set; }
    }

}
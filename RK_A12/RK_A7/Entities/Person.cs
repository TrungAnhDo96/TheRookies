using RK_A7.Enums;
using RK_A7.Models;

namespace RK_A7.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string BirthPlace { get; set; }

        public bool IsGraduated { get; set; }

        public static explicit operator PersonModel(Person entity)
        {
            PersonModel model = new PersonModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Gender = entity.Gender.ToString(),
                DateOfBirth = entity.DateOfBirth,
                PhoneNumber = entity.PhoneNumber,
                BirthPlace = entity.BirthPlace,
                IsGraduated = entity.IsGraduated == true ? "Yes" : "No"
            };
            return model;
        }
    }
}

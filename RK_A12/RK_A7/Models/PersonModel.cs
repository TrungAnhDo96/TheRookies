using RK_A7.Entities;
using RK_A7.Enums;
namespace RK_A7.Models
{
    public class PersonModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string DateOfBirth { get; set; }

        public string Age { get; set; }

        public string PhoneNumber { get; set; }

        public string BirthPlace { get; set; }

        public string IsGraduated { get; set; }

        public static explicit operator Person(PersonModel model)
        {
            Gender genderEnum = Enums.Gender.None;
            Enum.TryParse(model.Gender, out genderEnum);
            Person person = new Person()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = genderEnum,
                DateOfBirth = model.DateOfBirth,
                PhoneNumber = model.PhoneNumber,
                BirthPlace = model.BirthPlace,
                IsGraduated = model.IsGraduated == "Yes"
            };
            return person;
        }
    }
}
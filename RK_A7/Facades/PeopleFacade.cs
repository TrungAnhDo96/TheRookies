using RK_A7.Interfaces;
using RK_A7.Entities;
using RK_A7.Services;
using RK_A7.Models;
using System.Data;

namespace RK_A7.Facades
{
    public class PeopleFacade : IPeopleFacade
    {
        IPeopleService _service;

        public PeopleFacade()
        {
            _service = new PeopleService();
        }

        public List<PersonModel> GetAllPeople()
        {
            Dictionary<uint, Person> memberDic = _service.Read();
            List<PersonModel> members = new List<PersonModel>();
            foreach (var pair in memberDic)
            {
                PersonModel temp = (PersonModel)pair.Value;
                temp.Id = pair.Key;
                members.Add(temp);
            }
            return members;
        }

        public PersonModel GetPerson(uint id)
        {
            List<PersonModel> members = GetAllPeople();
            return members.Where(member => member.Id == id).FirstOrDefault();
        }

        public void AddPerson(PersonModel model)
        {
            Dictionary<uint, Person> memberDic = _service.Read();
            if (!memberDic.Keys.Contains(model.Id))
            {
                _service.Create(model);
            }
        }

        public void EditPerson(PersonModel model)
        {
            _service.Update(model.Id, model);
        }

        public void DeletePerson(PersonModel model)
        {
            _service.Delete(model.Id);
        }
    }
}
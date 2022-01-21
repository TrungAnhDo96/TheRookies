using System;
using System.Collections.Generic;
using RK_A5.Interfaces;
using RK_A5.Entities;
using RK_A5.Models;
using RK_A5.DB;

namespace RK_A5.Services
{
    public class PeopleService : IPeopleService
    {
        public void OpenCon()
        {
            PeopleDB.Instance.Connected = true;
        }

        public void CloseCon()
        {
            PeopleDB.Instance.Connected = false;
        }

        public void Create(PersonModel model)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            OpenCon();
            List<Person> result = PeopleDB.Instance.PeopleList;
            CloseCon();
            return result;
        }

        public void Update(int id, Person newPerson)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
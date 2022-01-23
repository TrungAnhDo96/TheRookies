using System.Collections.Generic;
using RK_A5.Entities;
using RK_A5.Models;

namespace RK_A5.Interfaces
{
    public interface IPeopleService
    {
        void OpenCon();

        void CloseCon();

        List<Person> Read();
    }
}
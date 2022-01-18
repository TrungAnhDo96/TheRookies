using System.Collections.Generic;
using System.Linq;

using RK_A2.Entities;

namespace RK_A2.Services
{
    class MemberService
    {
        private List<Member> _members;
        public MemberService()
        {
            InitMembers();
        }

        private void InitMembers()
        {
            _members = new List<Member>() {
                new Member("Do", "Trung Anh", Gender.Male, "12/08/1996", "0422061033"),
                new Member("Nguyen", "Van Phuc", Gender.Male, "01/01/2000", "0966416708"),
                new Member("Do", "Ngoc Anh", Gender.Male, "01/01/1994", "0962828299", "Ha Noi", true),
                new Member("Pham", "Duc Loc", Gender.Male, "01/01/1999", "0343428821"),
                new Member("Pham", "Thanh Long", Gender.Male, "01/01/2000", "0944531628", "Ha Noi"),
                new Member("Chu Ky", "Giang Son", Gender.Male, "01/01/1998", "0963164813"),
                new Member("Lai", "Quoc Long", Gender.Male, "01/01/1997", "0354505588"),
                new Member("Pham","Duc Tien",Gender.Male,"01/01/1998", "0963164813"),
                new Member("Do","Tien Thanh",Gender.Male,"01/01/2000", "0585032360"),
                new Member("Do","Hong Son",Gender.Male,"01/01/2000", "0975378309"),
                new Member("Vu","Quang Hiep",Gender.Male,"01/01/2000", "0964910360"),
                new Member("Vu","Minh Duc",Gender.Male,"01/01/2000", "0395429489"),
                new Member("Nguyen","Duc Huy",Gender.Male,"01/01/1996", "0925206686"),
                new Member("Pham","Dinh Quan",Gender.Male,"01/01/2000", "0326894875"),
                new Member("Nguyen","Tuan Nghia",Gender.Male,"01/01/2000", "0866626802"),
                new Member("Nguyen","Thanh Nam",Gender.Male,"01/01/2001", "0965510506"),
                new Member("Nguyen","Nam Phuong",Gender.Male,"01/01/2001", "0943746666"),
                new Member("Ta","Phi Hung",Gender.Male,"01/01/2000", "0368133069"),
                new Member("Dao","Tan Dung",Gender.Male,"01/01/2000", "0968442865"),
                new Member("Tran","Chi Thanh",Gender.Male,"01/01/2000", "0376959875"),
                new Member("Nguyen","Manh Cuong",Gender.Male,"01/01/1999", "0981226250"),
                new Member("Nguyen","Hung Son",Gender.Male,"01/01/1999", "0965976864"),
                new Member("Le","Duc Manh",Gender.Male,"01/01/2001", "0869269948"),
                new Member("Nguyen","Quang Huy",Gender.Male,"01/01/1992", "0842140392"),
                new Member("Leu","Duy Tan",Gender.Male,"01/01/1996", "0922110996"),
                new Member("Do","Van Thai",Gender.Male,"01/01/2001", "0989479615"),
                new Member("Bui","Chi Huong",Gender.Male,"01/01/2000", "0338559513"),
                new Member("Vu","Trung Kien",Gender.Male,"01/01/1996", "0947681357"),
                new Member("Dao","Tuan Phong",Gender.Male,"01/01/2000", "0963199204"),
                new Member("Nguyen","Thai Hoc",Gender.Male,"01/01/1999", "0862916198"),
                new Member("Dao","Quy Vuong",Gender.Male,"01/01/2000", "0335878777"),
                new Member("Pham","Tran Duy",Gender.Male,"01/01/1999", "0946301025"),
                new Member("Le","Trung Nghia",Gender.Male,"01/01/2000", "0946696302"),
                new Member("Phuong","Viet Hoang",Gender.Male,"01/01/1999", "0702028599"),
                new Member("Nguyen","Tien Truong",Gender.Male,"01/01/2000", "0968034684"),
                new Member("Nguyen","Van A",Gender.None,"01/01/")
            };
        }

        public List<Member> GetAllMembers()
        {
            return _members;
        }

        public List<Member> GetMembersByGender(Gender gender)
        {
            IEnumerable<Member> linq = from member in _members
                                       where member.Gender == Gender.Male
                                       select member;

            List<Member> result = linq.ToList();

            return result;
        }

        public Member GetOldestMember()
        {
            uint maxAge = _members.Max(member => member.Age);

            return _members.FirstOrDefault(member => member.Age == maxAge);
        }

        public List<string> GetMemberNames()
        {
            List<string> result = _members.Select(member => member.FullName).ToList();

            return result;
        }

        public List<Member> GetMembersByYear(uint year, string compareOperator = "==")
        {
            List<Member> result = new List<Member>();

            switch (compareOperator)
            {
                case "==":
                    result = _members.Where(member => member.DOB_Date.Year == year).ToList();
                    break;
                case ">":
                    result = _members.FindAll(member => member.DOB_Date.Year > year);
                    break;
                case "<":
                    result = _members.FindAll(member => member.DOB_Date.Year < year);
                    break;
                default:
                    break;
            }

            return result;
        }

        public Member GetFirstMemberByBirthPlace(string birthPlace)
        {
            Member result = _members.Find(member => member.BirthPlace == birthPlace);

            return result;
        }
    }
}
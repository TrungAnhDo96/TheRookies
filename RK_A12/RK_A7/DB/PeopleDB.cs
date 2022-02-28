using RK_A7.Entities;
using RK_A7.Enums;

namespace RK_A7.DB
{
    public class PeopleDB
    {
        private static PeopleDB _instance;
        public static PeopleDB Instance()
        {
            if (_instance == null)
            {
                _instance = new PeopleDB();
            }
            return _instance;
        }

        private List<Person> _memberList;
        private int _order;

        public PeopleDB()
        {
            _memberList = new List<Person>()
                {
                    new Person() {Id = 1, FirstName = "Do", LastName = "Trung Anh", Gender = Gender.Male, DateOfBirth = "12/08/1996", PhoneNumber = "0422061033"},
                    new Person() {Id = 2, FirstName = "Nguyen", LastName = "Van Phuc", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0966416708"},
                    new Person() {Id = 3, FirstName = "Do", LastName = "Ngoc Anh", Gender = Gender.Male, DateOfBirth = "01/01/1994",  PhoneNumber = "0962828299", BirthPlace = "Ha Noi", IsGraduated = true},
                    new Person() {Id = 4, FirstName = "Pham", LastName = "Duc Loc", Gender = Gender.Male, DateOfBirth = "01/01/1999",  PhoneNumber = "0343428821"},
                    new Person() {Id = 5, FirstName = "Pham", LastName = "Thanh Long", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0944531628", BirthPlace = "Ha Noi"},
                    new Person() {Id = 6, FirstName = "Chu Ky", LastName = "Giang Son", Gender = Gender.Male, DateOfBirth = "01/01/1998",  PhoneNumber = "0963164813"},
                    new Person() {Id = 7, FirstName = "Lai", LastName = "Quoc Long", Gender = Gender.Male, DateOfBirth = "01/01/1997",  PhoneNumber = "0354505588"},
                    new Person() {Id = 8, FirstName = "Pham", LastName = "Duc Tien", Gender = Gender.Male, DateOfBirth = "01/01/1998",  PhoneNumber = "0963164813"},
                    new Person() {Id = 9, FirstName = "Do", LastName = "Tien Thanh", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0585032360"},
                    new Person() {Id = 10, FirstName = "Do", LastName = "Hong Son", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0975378309"},
                    new Person() {Id = 11, FirstName = "Vu", LastName = "Quang Hiep", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0964910360"},
                    new Person() {Id = 12, FirstName = "Vu", LastName = "Minh Duc", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0395429489"},
                    new Person() {Id = 13, FirstName = "Nguyen", LastName = "Duc Huy", Gender = Gender.Male, DateOfBirth = "01/01/1996",  PhoneNumber = "0925206686"},
                    new Person() {Id = 14, FirstName = "Pham", LastName = "Dinh Quan", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0326894875"},
                    new Person() {Id = 15, FirstName = "Nguyen", LastName = "Tuan Nghia", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0866626802"},
                    new Person() {Id = 16, FirstName = "Nguyen", LastName = "Thanh Nam", Gender = Gender.Male, DateOfBirth = "01/01/2001",  PhoneNumber = "0965510506"},
                    new Person() {Id = 17, FirstName = "Nguyen", LastName = "Nam Phuong", Gender = Gender.Male, DateOfBirth = "01/01/2001",  PhoneNumber = "0943746666"},
                    new Person() {Id = 18, FirstName = "Ta", LastName = "Phi Hung", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0368133069"},
                    new Person() {Id = 19, FirstName = "Dao", LastName = "Tan Dung", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0968442865"},
                    new Person() {Id = 20, FirstName = "Tran", LastName = "Chi Thanh", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0376959875"},
                    new Person() {Id = 21, FirstName = "Nguyen", LastName = "Manh Cuong", Gender = Gender.Male, DateOfBirth = "01/01/1999",  PhoneNumber = "0981226250"},
                    new Person() {Id = 22, FirstName = "Nguyen", LastName = "Hung Son", Gender = Gender.Male, DateOfBirth = "01/01/1999",  PhoneNumber = "0965976864"},
                    new Person() {Id = 23, FirstName = "Le", LastName = "Duc Manh", Gender = Gender.Male, DateOfBirth = "01/01/2001",  PhoneNumber = "0869269948"},
                    new Person() {Id = 24, FirstName = "Nguyen", LastName = "Quang Huy", Gender = Gender.Male, DateOfBirth = "01/01/1992",  PhoneNumber = "0842140392"},
                    new Person() {Id = 25, FirstName = "Leu", LastName = "Duy Tan", Gender = Gender.Male, DateOfBirth = "01/01/1996",  PhoneNumber = "0922110996"},
                    new Person() {Id = 26, FirstName = "Do", LastName = "Van Thai", Gender = Gender.Male, DateOfBirth = "01/01/2001",  PhoneNumber = "0989479615"},
                    new Person() {Id = 27, FirstName = "Bui", LastName = "Chi Huong", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0338559513"},
                    new Person() {Id = 28, FirstName = "Vu", LastName = "Trung Kien", Gender = Gender.Male, DateOfBirth = "01/01/1996",  PhoneNumber = "0947681357"},
                    new Person() {Id = 29, FirstName = "Dao", LastName = "Tuan Phong", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0963199204"},
                    new Person() {Id = 30, FirstName = "Nguyen", LastName = "Thai Hoc", Gender = Gender.Male, DateOfBirth = "01/01/1999",  PhoneNumber = "0862916198"},
                    new Person() {Id = 31, FirstName = "Dao", LastName = "Quy Vuong", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0335878777"},
                    new Person() {Id = 32, FirstName = "Pham", LastName = "Tran Duy", Gender = Gender.Male, DateOfBirth = "01/01/1999",  PhoneNumber = "0946301025"},
                    new Person() {Id = 33, FirstName = "Le", LastName = "Trung Nghia", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0946696302"},
                    new Person() {Id = 34, FirstName = "Phuong", LastName = "Viet Hoang", Gender = Gender.Male, DateOfBirth = "01/01/1999",  PhoneNumber = "0702028599"},
                    new Person() {Id = 35, FirstName = "Nguyen", LastName = "Tien Truong", Gender = Gender.Male, DateOfBirth = "01/01/2000",  PhoneNumber = "0968034684"},
                    new Person() {Id = 36, FirstName = "Nguyen", LastName = "Van A", Gender = Gender.None, DateOfBirth = "01/01/"}
                };
            _order = 36;
        }

        public List<Person> MemberList { get { return _memberList; } set { _memberList = value; } }

        public int Order { get { return _order; } set { _order = value; } }
    }
}
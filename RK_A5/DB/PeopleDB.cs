using System;
using System.Collections.Generic;
using RK_A5.Entities;
using RK_A5.Enums;

namespace RK_A5.DB
{
    public class PeopleDB
    {
        // Singleton
        private static PeopleDB _instance;
        public static PeopleDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PeopleDB();
                }
                return _instance;
            }
        }

        private List<Person> _people;
        public PeopleDB()
        {
            Initialize();
        }

        private void Initialize()
        {
            Connected = false;
            _people = new List<Person>() {
                    new Person("Do", "Trung Anh", Gender.Male, "12/08/1996", "0422061033"),
                    new Person("Nguyen", "Van Phuc", Gender.Male, "01/01/2000", "0966416708"),
                    new Person("Do", "Ngoc Anh", Gender.Male, "01/01/1994", "0962828299", "Ha Noi", true),
                    new Person("Pham", "Duc Loc", Gender.Male, "01/01/1999", "0343428821"),
                    new Person("Pham", "Thanh Long", Gender.Male, "01/01/2000", "0944531628", "Ha Noi"),
                    new Person("Chu Ky", "Giang Son", Gender.Male, "01/01/1998", "0963164813"),
                    new Person("Lai", "Quoc Long", Gender.Male, "01/01/1997", "0354505588"),
                    new Person("Pham","Duc Tien",Gender.Male,"01/01/1998", "0963164813"),
                    new Person("Do","Tien Thanh",Gender.Male,"01/01/2000", "0585032360"),
                    new Person("Do","Hong Son",Gender.Male,"01/01/2000", "0975378309"),
                    new Person("Vu","Quang Hiep",Gender.Male,"01/01/2000", "0964910360"),
                    new Person("Vu","Minh Duc",Gender.Male,"01/01/2000", "0395429489"),
                    new Person("Nguyen","Duc Huy",Gender.Male,"01/01/1996", "0925206686"),
                    new Person("Pham","Dinh Quan",Gender.Male,"01/01/2000", "0326894875"),
                    new Person("Nguyen","Tuan Nghia",Gender.Male,"01/01/2000", "0866626802"),
                    new Person("Nguyen","Thanh Nam",Gender.Male,"01/01/2001", "0965510506"),
                    new Person("Nguyen","Nam Phuong",Gender.Male,"01/01/2001", "0943746666"),
                    new Person("Ta","Phi Hung",Gender.Male,"01/01/2000", "0368133069"),
                    new Person("Dao","Tan Dung",Gender.Male,"01/01/2000", "0968442865"),
                    new Person("Tran","Chi Thanh",Gender.Male,"01/01/2000", "0376959875"),
                    new Person("Nguyen","Manh Cuong",Gender.Male,"01/01/1999", "0981226250"),
                    new Person("Nguyen","Hung Son",Gender.Male,"01/01/1999", "0965976864"),
                    new Person("Le","Duc Manh",Gender.Male,"01/01/2001", "0869269948"),
                    new Person("Nguyen","Quang Huy",Gender.Male,"01/01/1992", "0842140392"),
                    new Person("Leu","Duy Tan",Gender.Male,"01/01/1996", "0922110996"),
                    new Person("Do","Van Thai",Gender.Male,"01/01/2001", "0989479615"),
                    new Person("Bui","Chi Huong",Gender.Male,"01/01/2000", "0338559513"),
                    new Person("Vu","Trung Kien",Gender.Male,"01/01/1996", "0947681357"),
                    new Person("Dao","Tuan Phong",Gender.Male,"01/01/2000", "0963199204"),
                    new Person("Nguyen","Thai Hoc",Gender.Male,"01/01/1999", "0862916198"),
                    new Person("Dao","Quy Vuong",Gender.Male,"01/01/2000", "0335878777"),
                    new Person("Pham","Tran Duy",Gender.Male,"01/01/1999", "0946301025"),
                    new Person("Le","Trung Nghia",Gender.Male,"01/01/2000", "0946696302"),
                    new Person("Phuong","Viet Hoang",Gender.Male,"01/01/1999", "0702028599"),
                    new Person("Nguyen","Tien Truong",Gender.Male,"01/01/2000", "0968034684"),
                    new Person("Nguyen","Van A",Gender.None,"01/01/")
                };
        }

        public List<Person> PeopleList
        {
            get
            {
                if (Connected)
                    return _people;
                else
                    throw new Exception("Connection not established with PeopleDB");
            }
            set
            {
                if (Connected)
                    _people = value;
                else
                    throw new Exception("Connection not established with PeopleDB");
            }
        }

        public bool Connected { get; set; }
    }
}
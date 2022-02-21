using Microsoft.EntityFrameworkCore;
using RK_A9.Entities;
using RK_A9.Enums;

namespace RK_A9.DB
{
    public class PeopleContext : DbContext
    {
        private static readonly Person[] InitData = new Person[36] {
            new Person() { Id = 1, FirstName = "Do", LastName = "Trung Anh", DateOfBirth = new DateTime(1996, 8, 12), Gender = Gender.Male, BirthPlace = "Hanoi" },
            new Person() { Id = 2, FirstName = "Nguyen", LastName = "Van Phuc", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 3, FirstName = "Do", LastName = "Ngoc Anh", DateOfBirth = new DateTime(1994,1,1), Gender = Gender.Male, BirthPlace = "Ha Noi"},
            new Person() { Id = 4, FirstName = "Pham", LastName = "Duc Loc", DateOfBirth = new DateTime(1999,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 5, FirstName = "Pham", LastName = "Thanh Long", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace ="Ha Noi"},
            new Person() { Id = 6, FirstName = "Chu Ky", LastName = "Giang Son", DateOfBirth = new DateTime(1998,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 7, FirstName ="Lai", LastName = "Quoc Long", DateOfBirth = new DateTime(1997,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 8, FirstName = "Pham", LastName = "Duc Tien", DateOfBirth = new DateTime(1998,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 9, FirstName = "Do", LastName = "Tien Thanh", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 10, FirstName = "Do", LastName =  "Hong Son", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 11, FirstName = "Vu", LastName = "Quang Hiep", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 12, FirstName = "Vu", LastName = "Minh Duc", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 13, FirstName = "Nguyen", LastName = "Duc Huy", DateOfBirth = new DateTime(1996,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 14, FirstName = "Pham", LastName = "Dinh Quan", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 15, FirstName = "Le", LastName = "Duc Manh", DateOfBirth = new DateTime(2001,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 16, FirstName = "Nguyen", LastName = "Tuan Nghia", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 17, FirstName = "Leu", LastName = "Duy Tan", DateOfBirth = new DateTime(1996,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 18, FirstName = "Nguyen", LastName = "Thanh Nam", DateOfBirth = new DateTime(2001,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 19, FirstName = "Bui", LastName = "Chi Huong", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 20, FirstName = "Nguyen", LastName = "Nam Phuong", DateOfBirth = new DateTime(2001,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 21, FirstName = "Ta", LastName = "Phi Hung", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 22, FirstName = "Dao", LastName = "Tan Dung", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 23, FirstName = "Tran", LastName = "Chi Thanh", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 24, FirstName = "Nguyen", LastName = "Manh Cuong", DateOfBirth = new DateTime(1999,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 25, FirstName = "Nguyen", LastName = "Hung Son", DateOfBirth = new DateTime(1999,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 26, FirstName = "Nguyen", LastName = "Quang Huy", DateOfBirth = new DateTime(1992,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 27, FirstName = "Do", LastName = "Van Thai", DateOfBirth = new DateTime(2001,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 28, FirstName = "Vu", LastName = "Trung Kien", DateOfBirth = new DateTime(1996,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 29, FirstName = "Dao", LastName = "Tuan Phong", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 30, FirstName = "Nguyen", LastName = "Thai Hoc", DateOfBirth = new DateTime(1999,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 31, FirstName = "Dao", LastName = "Quy Vuong", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 32, FirstName = "Pham", LastName = "Tran Duy", DateOfBirth = new DateTime(1999,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 33, FirstName = "Le", LastName = "Trung Nghia", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 34, FirstName = "Phuong", LastName = "Viet Hoang", DateOfBirth = new DateTime(1999,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 35, FirstName = "Nguyen", LastName = "Tien Truong", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Male, BirthPlace = ""},
            new Person() { Id = 36, FirstName = "Nguyen", LastName = "Van A", DateOfBirth = new DateTime(2000,1,1), Gender = Gender.Female, BirthPlace = ""}
        };

        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().HasData(InitData);
        }
    }
}
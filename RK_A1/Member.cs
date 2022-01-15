using System;

namespace RK_A1
{

    public enum Gender
    {
        None = 0,
        Male = 1,
        Female = 2,
    }

    class Member
    {
        public Member(string firstName, string lastName, Gender gender, string dob, string phoneNumber = "", string birthPlace = "", bool isGraduated = false)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DOB = dob;
            PhoneNumber = phoneNumber;
            BirthPlace = birthPlace;
            Age = CalAge();
            IsGraduated = isGraduated;
        }

        private uint CalAge()
        {
            uint result = 0;
            DateTime dobParse = getDOB_Date();
            if (DOB != null && DOB != "" && DateTime.Compare(DateTime.MinValue, dobParse) != 0)
            {
                DateTime now = DateTime.Now;
                if (dobParse.Year < now.Year)
                    result = (uint)(now.Year - dobParse.Year);
            }

            return result;
        }

        public DateTime getDOB_Date()
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(DOB, out result);
            return result;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public Gender Gender { get; set; }

        public string DOB { get; set; }

        public string PhoneNumber { get; set; }

        public string BirthPlace { get; set; }

        public uint Age { get; }

        public bool IsGraduated { get; set; }

        public string MemberSummary
        {
            get
            {
                string result =
                    "Name: " + FullName +
                    " | Gender: " + Gender.ToString() +
                    " | DOB: " + DOB +
                    " | Phone Number: " + PhoneNumber +
                    " | Birth Place: " + BirthPlace;

                result += " | Age: ";
                if (Age <= 0)
                    result += "Not specified";
                else
                    result += Age;

                result += " | Graduated: ";
                if (IsGraduated)
                    result += "Yes";
                else
                    result += "No";

                return result;
            }
        }

    }
}
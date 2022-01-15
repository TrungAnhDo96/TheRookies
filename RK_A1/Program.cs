using System;
using System.Collections.Generic;
namespace RK_A1
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassMembers classMembers = new ClassMembers();
            if (classMembers.getAllMembers().Count > 0)
            {
                // Console.WriteLine();
                // PrintMembersByGender(classMembers, Gender.Male);

                // Console.WriteLine("\n**************************************************\n");
                // PrintOldestMember(classMembers);

                // Console.WriteLine("\n**************************************************\n");
                // PrintMemberNames(classMembers);

                Console.WriteLine("\n**************************************************\n");
                PrintMembersByBirthYearEquals(classMembers, 2000);

                Console.WriteLine("\n**************************************************\n");
                PrintMembersByBirthYearGreaterThan(classMembers, 2000);

                Console.WriteLine("\n**************************************************\n");
                PrintMembersByBirthYearLessThan(classMembers, 2000);

                // Console.WriteLine("\n**************************************************\n");
                // PrintMembersByBirthPlace(classMembers, "Ha Noi");
            }
            else
            {
                Console.WriteLine("No member in class. Please add members.");
            }
        }

        static void PrintMemberSummary(Member member)
        {
            Console.WriteLine("     " + member.MemberSummary);
        }

        static void PrintMembersByGender(ClassMembers members, Gender gender)
        {
            //getMembersByGender(gender)
            List<Member> membersByGender = members.getMembersByGender(gender);
            if (membersByGender.Count > 0)
            {
                Console.WriteLine("Here is a list of members who are " + gender.ToString().ToLower() + ": ");
                foreach (var member in members.getMembersByGender(gender))
                {
                    PrintMemberSummary(member);
                }
            }
            else
            {
                Console.WriteLine("There are no members who are " + gender.ToString().ToLower());
            }
        }

        static void PrintOldestMember(ClassMembers members)
        {
            //getOldestMember()
            Console.WriteLine("Here is the detail of the oldest member:");
            PrintMemberSummary(members.getOldestMember());
        }

        static void PrintMemberNames(ClassMembers members)
        {
            //getMemberNames()
            List<string> memberNames = members.getMemberNames();
            Console.WriteLine("Here is the list of members (full name only):");
            foreach (var name in memberNames)
            {
                Console.WriteLine("     " + name);
            }
        }

        static void PrintMembersByBirthYearEquals(ClassMembers members, uint year)
        {
            //getMembersByYear(year, "equals")
            List<Member> membersWithYearEquals = members.getMembersByYear(year);
            if (membersWithYearEquals.Count > 0)
            {
                Console.WriteLine("Here is the list of members whose birth year equals " + year + ": ");
                foreach (Member member in membersWithYearEquals)
                {
                    PrintMemberSummary(member);
                }
            }
            else
            {
                Console.WriteLine("There is no members whose birth year equals " + year);
            }
        }

        static void PrintMembersByBirthYearGreaterThan(ClassMembers members, uint year)
        {
            //getMembersByYear(year, "greater");
            List<Member> membersWithYearGreater = members.getMembersByYear(year, ">");
            if (membersWithYearGreater.Count > 0)
            {
                Console.WriteLine("Here is the list of members whose birth year is greater than " + year + ": ");
                foreach (Member member in membersWithYearGreater)
                {
                    PrintMemberSummary(member);
                }
            }
            else
            {
                Console.WriteLine("There is no members whose birth year is greater than " + year);
            }
        }

        static void PrintMembersByBirthYearLessThan(ClassMembers members, uint year)
        {
            //getMembersByYear(year, "less");
            List<Member> membersWithYearLess = members.getMembersByYear(year, "<");
            if (membersWithYearLess.Count > 0)
            {
                Console.WriteLine("Here is the list of members whose birth year is less than " + year + ": ");
                foreach (Member member in membersWithYearLess)
                {
                    PrintMemberSummary(member);
                }
            }
            else
            {
                Console.WriteLine("There is no members whose birth year is less than " + year);
            }
        }
        static void PrintMembersByBirthPlace(ClassMembers members, string birthPlace)
        {
            //getFirstMemberByBirthPlace(birthPlace);
            Member firstMemberByBirthPlace = members.getFirstMemberByBirthPlace(birthPlace);
            if (firstMemberByBirthPlace != null)
            {
                Console.WriteLine("Here is the first member whose birth place is '" + birthPlace + "': ");
                PrintMemberSummary(members.getFirstMemberByBirthPlace(birthPlace));
            }
            else
            {
                Console.WriteLine("There is no members whose birth place is '" + birthPlace + "'");
            }
        }
    }
}

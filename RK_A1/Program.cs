using System;
using System.Collections.Generic;
namespace RK_A1
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassMembers classMembers = new ClassMembers();

            Console.WriteLine();
            PrintMembersByGender(classMembers, Gender.Male);

            Console.WriteLine("\n**************************************************\n");
            PrintOldestMember(classMembers);

            Console.WriteLine("\n**************************************************\n");
            PrintMemberNames(classMembers);

            Console.WriteLine("\n**************************************************\n");
            PrintMembersByBirthYearEquals(classMembers, 2000);

            Console.WriteLine("\n**************************************************\n");
            PrintMembersByBirthYearGreaterThan(classMembers, 2000);

            Console.WriteLine("\n**************************************************\n");
            PrintMembersByBirthYearLessThan(classMembers, 2000);

            Console.WriteLine("\n**************************************************\n");
            PrintMembersByBirthPlace(classMembers, "Ha Noi");
        }

        static void PrintMemberSummary(Member member)
        {
            Console.WriteLine("     " + member.MemberSummary);
        }

        static void PrintMembersByGender(ClassMembers members, Gender gender)
        {
            List<Member> membersByGender = members.GetMembersByGender(gender);
            if (membersByGender.Count > 0)
            {
                Console.WriteLine("Here is a list of members who are " + gender.ToString().ToLower() + ": ");
                foreach (var member in members.GetMembersByGender(gender))
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
            Console.WriteLine("Here is the detail of the oldest member:");
            PrintMemberSummary(members.GetOldestMember());
        }

        static void PrintMemberNames(ClassMembers members)
        {
            List<string> memberNames = members.GetMemberNames();
            Console.WriteLine("Here is the list of members (full name only):");
            foreach (var name in memberNames)
            {
                Console.WriteLine("     " + name);
            }
        }

        static void PrintMembersByBirthYearEquals(ClassMembers members, uint year)
        {
            List<Member> membersWithYearEquals = members.GetMembersByYear(year);
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
            List<Member> membersWithYearGreater = members.GetMembersByYear(year, ">");
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
            List<Member> membersWithYearLess = members.GetMembersByYear(year, "<");
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
            Member firstMemberByBirthPlace = members.GetFirstMemberByBirthPlace(birthPlace);
            if (firstMemberByBirthPlace != null)
            {
                Console.WriteLine("Here is the first member whose birth place is '" + birthPlace + "': ");
                PrintMemberSummary(members.GetFirstMemberByBirthPlace(birthPlace));
            }
            else
            {
                Console.WriteLine("There is no members whose birth place is '" + birthPlace + "'");
            }
        }
    }
}

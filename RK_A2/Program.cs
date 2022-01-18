using System;
using System.Collections.Generic;
namespace RK_A2
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberService memberService = new MemberService();
            if (memberService.GetAllMembers().Count > 0)
            {
                Console.WriteLine();
                PrintMembersByGender(memberService, Gender.Male);

                Console.WriteLine("\n**************************************************\n");
                PrintOldestMember(memberService);

                Console.WriteLine("\n**************************************************\n");
                PrintMemberNames(memberService);

                Console.WriteLine("\n**************************************************\n");
                PrintMembersByBirthYearEquals(memberService, 2000);

                Console.WriteLine("\n**************************************************\n");
                PrintMembersByBirthYearGreaterThan(memberService, 2000);

                Console.WriteLine("\n**************************************************\n");
                PrintMembersByBirthYearLessThan(memberService, 2000);

                Console.WriteLine("\n**************************************************\n");
                PrintMembersByBirthPlace(memberService, "Ha Noi");
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

        static void PrintMembersByGender(MemberService service, Gender gender)
        {
            List<Member> membersByGender = service.GetMembersByGender(gender);
            if (membersByGender.Count > 0)
            {
                Console.WriteLine("Here is a list of members who are " + gender.ToString().ToLower() + ": ");
                foreach (var member in membersByGender)
                {
                    PrintMemberSummary(member);
                }
            }
            else
            {
                Console.WriteLine("There are no members who are " + gender.ToString().ToLower());
            }
        }

        static void PrintOldestMember(MemberService service)
        {
            Console.WriteLine("Here is the detail of the oldest member:");
            PrintMemberSummary(service.GetOldestMember());
        }

        static void PrintMemberNames(MemberService service)
        {
            List<string> memberNames = service.GetMemberNames();
            Console.WriteLine("Here is the list of members (full name only):");
            foreach (var name in memberNames)
            {
                Console.WriteLine("     " + name);
            }
        }

        static void PrintMembersByBirthYearEquals(MemberService service, uint year)
        {
            List<Member> membersWithYearEquals = service.GetMembersByYear(year);
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

        static void PrintMembersByBirthYearGreaterThan(MemberService members, uint year)
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

        static void PrintMembersByBirthYearLessThan(MemberService members, uint year)
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
        static void PrintMembersByBirthPlace(MemberService members, string birthPlace)
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

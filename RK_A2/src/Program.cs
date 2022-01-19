using System;
using System.Collections.Generic;
using System.Linq;
using RK_A2.Services;
using RK_A2.Entities;

namespace RK_A2
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberService memberService = new MemberService();

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

        static void PrintMemberSummary(Member member)
        {
            Console.WriteLine("     " + member.MemberSummary);
        }

        static void PrintMembersByGender(MemberService service, Gender gender)
        {
            List<Member> membersByGender = service.GetMembersByGender(gender);
            if (membersByGender.Any())
            {
                Console.WriteLine("Here is a list of members who are " + gender.ToString().ToLower() + ": ");
                membersByGender.ForEach(member => { PrintMemberSummary(member); });
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
            memberNames.ForEach(name => { Console.WriteLine("     " + name); });
        }

        static void PrintMembersByBirthYearEquals(MemberService service, uint year)
        {
            List<Member> membersWithYearEquals = service.GetMembersByYear(year);
            if (membersWithYearEquals.Any())
            {
                Console.WriteLine("Here is the list of members whose birth year equals " + year + ": ");
                membersWithYearEquals.ForEach(member => { PrintMemberSummary(member); });
            }
            else
            {
                Console.WriteLine("There is no members whose birth year equals " + year);
            }
        }

        static void PrintMembersByBirthYearGreaterThan(MemberService members, uint year)
        {
            List<Member> membersWithYearGreater = members.GetMembersByYear(year, ">");
            if (membersWithYearGreater.Any())
            {
                Console.WriteLine("Here is the list of members whose birth year is greater than " + year + ": ");
                membersWithYearGreater.ForEach(member => { PrintMemberSummary(member); });
            }
            else
            {
                Console.WriteLine("There is no members whose birth year is greater than " + year);
            }
        }

        static void PrintMembersByBirthYearLessThan(MemberService members, uint year)
        {
            List<Member> membersWithYearLess = members.GetMembersByYear(year, "<");
            if (membersWithYearLess.Any())
            {
                Console.WriteLine("Here is the list of members whose birth year is less than " + year + ": ");
                membersWithYearLess.ForEach(member => { PrintMemberSummary(member); });
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

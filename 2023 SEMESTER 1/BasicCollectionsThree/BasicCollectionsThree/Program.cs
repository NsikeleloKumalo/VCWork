using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCollectionsThree
{
    class Program
    {
        static void Main(string[] args)
        {
            //advanced List of T's in OOP
            List<Student> students = new List<Student>()
            { 
                //new obect per student to consume the properties
                new Student { firstName = "Nsikelelo", lastName = "Kumalo", studentId = 100 },
                new Student { firstName = "Kimberly", lastName = "Kard", studentId = 203 },
                new Student { firstName = "Sue", lastName = "Smith", studentId = 300 },
                new Student { firstName = "John", lastName = "Hendricks", studentId = 400 },};

            Console.WriteLine("The list of students >>>\n");
            foreach (Student item in students)
            {
                //Console.WriteLine(item); Doesnt work
                Console.WriteLine("First name: {0},Last name: {1},studentID: {2}",item.firstName, item.lastName,
                    item.studentId);
            }
            Console.ReadLine();

        }
    }
}

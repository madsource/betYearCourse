using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc1 = new XmlDocument();
            
            XmlNode rootNode = doc1.CreateElement("students");

            doc1.AppendChild(rootNode);

            List<Student> studentsList = StudentsFactory.CreateStudentsList(30);

            foreach (var student in studentsList)
            {

                XmlNode studentNode = doc1.CreateElement("student");
                studentNode.InnerText = student.Name;
                XmlAttribute attributeAge = doc1.CreateAttribute("age");
                attributeAge.Value = student.Age.ToString();

                XmlAttribute attributeId = doc1.CreateAttribute("id");
                attributeId.Value = student.Id.ToString();

                studentNode.Attributes.Append(attributeAge);
                studentNode.Attributes.Append(attributeId);
                rootNode.AppendChild(studentNode);
            }

            doc1.Save("../../students.xml");
        }
    }
}

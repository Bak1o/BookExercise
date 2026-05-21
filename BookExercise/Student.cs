using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    public class Student
    {
        private string _fullName;
        private string? _course;
        private string? _subject;
        private string _university;
        private string _email;
        private string _phoneNumber;
        private static int _studentCounter = 0;
        public static int StudentNumber
        {
            get { return _studentCounter; }

        }
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        public string? Course
        {
            get { return _course; }
            set { _course = value; }
        }
        public string? Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        public string University
        {
            get { return _university; }
            set { _university = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public Student(string fullName, string? course, string? subject, string university, string email, string phoneNumber)
        {
            _fullName = fullName;
            _course = course;
            _subject = subject;
            _university = university;
            _email = email;
            _phoneNumber = phoneNumber;
            _studentCounter++;
           
            
        }
        public Student(string fullName, string university, string email, string phoneNumber) : this(fullName, null, null, university, email, phoneNumber)
        {

        }
        public void PrintInfo()
        {
            if (string.IsNullOrEmpty(_course) && string.IsNullOrEmpty(_subject))
            {
                Console.WriteLine($" student name : {_fullName}, university : {_university}, email : {Email}, phonenumber : {_phoneNumber} ");
            }


            else if (string.IsNullOrEmpty(_course))
            {
                Console.WriteLine($" student name : {_fullName}, subject : {_subject}, university : {_university}, email : {Email}, phonenumber : {_phoneNumber} ");
            }
            else if (string.IsNullOrEmpty(_subject))
            {
                Console.WriteLine($" student name : {_fullName}, course : {_course}, university : {_university}, email : {Email}, phonenumber : {_phoneNumber} ");
            }

            else
            {
                Console.WriteLine($" student name : {_fullName}, course {_course}, Subject  {_subject}");
                Console.WriteLine($"university {_university}, email {Email}, phonenumber {_phoneNumber} ");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSystem.Model
{
    internal class Patient
    {
        private int patientId;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private char gender;
        private string contactNumber;
        private string address;

        // Public properties to provide access to the attributes

        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        // Additional constructor for initializing attributes
        public Patient(int patientId, string firstName, string lastName, DateTime dateOfBirth, char gender, string contactNumber, string address)
        {
            this.patientId = patientId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.contactNumber = contactNumber;
            this.address = address;
        }

        // ToString method to display information
        public override string ToString()
        {
            return $"Patient ID: {patientId}\n" +
                   $"Name: {firstName} {lastName}\n" +
                   $"Date of Birth: {dateOfBirth.ToString("yyyy-MM-dd")}\n" +
                   $"Gender: {gender}\n" +
                   $"Contact Number: {contactNumber}\n" +
                   $"Address: {address}";
        }
    }
}

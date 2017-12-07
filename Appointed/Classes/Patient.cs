﻿using System;
using Appointed.Events;
using Appointed.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointed.Classes
{

	public class Patient : ObservableObject
	{
		//Constant values

		//Sex
		public enum SEX { MALE, FEMALE, OTHER};

        //Provinces (and territories)
        public enum PROVINCE { AB, BC, MB, NB, NL, NT, NS, NU, ON, PE, QC, SK, YT};

		//General info
		string _firstName;
		string _middleName;
		string _lastName;
		DateTime _birthDate;
		SEX _sex;              
		int _healthID;

        //Address
        string _street;
        string _city;
		PROVINCE _province;        
		string _postalCode;


        //Contact
        string _business;
		string _phone;
		string _cell;
		string _email;

		//Emergency Contact
		EmergencyContact _emergencyContact;

        //Notes
        string _notes;

        //Appointments
        List<int> _upcomingAppointments;
        List<int> _pastAppointments;


        public Patient()
        {
            _upcomingAppointments = new List<int>();
            _pastAppointments = new List<int>();
        }


        public Patient(Patient toCopy)
        {
            BirthDate = toCopy.BirthDate;
            Business = toCopy.Business;
            Cell = toCopy.Cell;
            City = toCopy.City;
            Email = toCopy.Email;
            FirstName = toCopy.FirstName;
            HealthID = toCopy.HealthID;
            LastName = toCopy.LastName;
            MiddleName = toCopy.MiddleName;
            Phone = toCopy.Phone;
            PostalCode = toCopy.PostalCode;
            Province = toCopy.Province;
            Sex = toCopy.Sex;
            Street = toCopy.Street;
            Notes = toCopy.Notes;
            EmergencyContact = toCopy.EmergencyContact;
        }

		//Property methods

        public void MoveAppointmentToPast(int key)
        {
            _upcomingAppointments.Remove(key);
            _pastAppointments.Add(key);
        }

        public List<int> GetPastAppointmentKeys()
        {
            return _pastAppointments;
        }

        public void AddUpcommingAppointment(int key)
        {
            if (_upcomingAppointments == null)
                _upcomingAppointments = new List<int>();

            _upcomingAppointments.Add(key);
        }

        public void RemoveUpcommingAppointmentKey(int key)
        {
            _upcomingAppointments.Remove(key);
        }

        public List<int> GetUpcomingAppointmentKeys()
        {
            return _upcomingAppointments;
        }

        public string FirstName
		{
			get { return _firstName; }
				
			set
			{
				_firstName = value;
				RaisePropertyChangedEvent("FirstName");
			}
		}

		public string MiddleName
		{
			get { return _middleName; }

			set
			{
				_middleName = value;
				RaisePropertyChangedEvent("MiddleName");
			}
		}

		public string LastName
		{
			get { return _lastName; }

			set
			{
				_lastName = value;
				RaisePropertyChangedEvent("LastName");
			}
		}

        //TODO: Add GetFullName() function er something

		public DateTime BirthDate
		{
			get { return _birthDate; }

			set
			{
				_birthDate = value;
				RaisePropertyChangedEvent("BirthDate");
			}
		}

		public SEX Sex
		{
			get { return _sex; }

			set
			{
				_sex = value;
				RaisePropertyChangedEvent("Sex");
			}
		}

        public String GetSexAsString()
        {
            switch (_sex)
            {
                case SEX.MALE:
                    return "Male";
                case SEX.FEMALE:
                    return "Female";
                case SEX.OTHER:
                    return "Other";
                default:
                    return "Undefined";
            }
        }

		public int HealthID
		{
			get { return _healthID; }

			set
			{
				_healthID = value;
				RaisePropertyChangedEvent("HealthID");
			}
		}

        public string Street
		{
			get { return _street; }

			set
			{
				_street = value;
				RaisePropertyChangedEvent("Street");
			}
		}

		public string City
		{
			get { return _city; }

			set
			{
				_city = value;
				RaisePropertyChangedEvent("City");
			}
		}

		public PROVINCE Province
		{
			get { return _province; }

			set
			{
				_province = value;
				RaisePropertyChangedEvent("Province");
			}
		}

		public string PostalCode
		{
			get { return _postalCode; }

			set
			{
				_postalCode = value;
				RaisePropertyChangedEvent("PostalCode");
			}
		}

        public string Business
        {
            get { return _business; }
            set
            {
                _business = value;
                RaisePropertyChangedEvent("Business");
            }
        }

		public string Phone
		{
			get { return _phone; }

			set
			{
				_phone = value;
				RaisePropertyChangedEvent("Phone");
			}
		}

		public string Cell
		{
			get { return _cell; }

			set
			{
				_cell = value;
				RaisePropertyChangedEvent("Cell");
			}
		}

		public string Email
		{
			get { return _email; }

			set
			{
				_email = value;
				RaisePropertyChangedEvent("Email");
			}
		}

        public string Notes
        {
            get { return _notes; }

            set
            {
                _notes = value;
                RaisePropertyChangedEvent("Notes");
            }
        }

        public static SEX SexStringToEnum(string sex)
        {
            if (sex == "Male") return SEX.MALE;
            if (sex == "Female") return SEX.FEMALE;

            return SEX.OTHER;
        }

        public static PROVINCE ProvinceStringToEnum(string prov)
        {
            if (prov == "AB") return PROVINCE.AB;
            if (prov == "BC") return PROVINCE.BC;
            if (prov == "MB") return PROVINCE.MB;
            if (prov == "NB") return PROVINCE.NB;
            if (prov == "NL") return PROVINCE.NL;
            if (prov == "NS") return PROVINCE.NS;
            if (prov == "NT") return PROVINCE.NT;
            if (prov == "NU") return PROVINCE.NU;
            if (prov == "ON") return PROVINCE.ON;
            if (prov == "PE") return PROVINCE.PE;
            if (prov == "QC") return PROVINCE.QC;
            if (prov == "SK") return PROVINCE.SK;
            if (prov == "YT") return PROVINCE.YT;

            //if all else fails, assume alberta
            return PROVINCE.AB;
        }

		public EmergencyContact EmergencyContact
		{
			get { return _emergencyContact; }

			set
			{
				_emergencyContact = value;
				RaisePropertyChangedEvent("EmergencyContact");
			}
		}
	}
}
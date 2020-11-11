using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BE;
using static BLL.BE.AuxiliaryObjects;

namespace DAL
{
    class DataToLoadWhenDBIsEmpty
    {
        DrugSystemContext DB;
        public DataToLoadWhenDBIsEmpty()
        {
            DB = new DrugSystemContext();
            if (DB.PersonsTable.Count() == 0)
            {
                AddAdmin();
                AddDoctors();
                AddOfficers();
                AddPaitents();
                AddMedicines();
            }
        }
        private void AddAdmin()
        {
            Administrator defaultAdmin = new Administrator() {
                BirthDate = new DateTime(2000, 1, 1),
                BuildingNumber = "10",
                CanAddDoctor = true,
                CanAddMedicine = true,
                CanAddPatient = true,
                CanCreatePrescriptions = true,
                City = "Netanya",
                EmailAddress = "admin@gmail.com",
                FirstName = "Yossi",
                Gender = Gender.זכר,
                ID = "311215149",
                LastName = "Zaguri",
                Password = "Admin1234",
                PhoneNumber = "0501234567",
                Street = "Yehuda Halevi"
            };
            DB.PersonsTable.Add(defaultAdmin);
            DB.SaveChanges();
        }
        private void AddDoctors()
        {
            Doctor doctor1 = new Doctor() {
                BirthDate = new DateTime(1995, 5, 12),
                BuildingNumber = "8",
                CanAddDoctor = true,
                CanAddMedicine = true,
                CanAddPatient = false,
                CanCreatePrescriptions = true,
                City = "Tel Aviv",
                EmailAddress = "moshe@gmail.com",
                FirstName = "Moshe",
                Gender = Gender.אחר,
                ID = "206322042",
                LastName = "Cohen",
                Password = "Moshe123",
                PhoneNumber = "0520520520",
                Street = "Alenby",
                LicenceNumber = "174",
                ProfileImagePath = "",
                ProfileImageSrc = "",
                Specialty = "Ears"
            };
            DB.PersonsTable.Add(doctor1);
            DB.SaveChanges();
            Doctor doctor2 = new Doctor() {
                BirthDate = new DateTime(1948, 11, 7),
                BuildingNumber = "10",
                CanAddDoctor = false,
                CanAddMedicine = true,
                CanAddPatient = true,
                CanCreatePrescriptions = true,
                City = "Jerusalem",
                EmailAddress = "Kobi@gmail.com",
                FirstName = "Kobi",
                Gender = Gender.זכר,
                ID = "344563317",
                LastName = "Yaakobi",
                Password = "Kobi1234",
                PhoneNumber = "0587778888",
                Street = "Jafo",
                LicenceNumber = "973",
                ProfileImagePath = "",
                ProfileImageSrc = "",
                Specialty = "Eyes"
            };
            DB.PersonsTable.Add(doctor2);
            DB.SaveChanges();
            Doctor doctor3 = new Doctor() {
                BirthDate = new DateTime(1975, 1, 10),
                BuildingNumber = "58",
                CanAddDoctor = true,
                CanAddMedicine = true,
                CanAddPatient = true,
                CanCreatePrescriptions = true,
                City = "Netanya",
                EmailAddress = "Yaara@gmail.com",
                FirstName = "Yaara",
                Gender = Gender.נקבה,
                ID = "060392743",
                LastName = "Menuchin",
                Password = "Yaara123",
                PhoneNumber = "0545454554",
                Street = "Yehuda Halevi",
                LicenceNumber = "64",
                ProfileImagePath = "",
                ProfileImageSrc = "",
                Specialty = "Heart"
            };
            DB.PersonsTable.Add(doctor3);
            DB.SaveChanges();
            Doctor doctor4 = new Doctor() {
                BirthDate = new DateTime(1986, 5, 6),
                BuildingNumber = "24",
                CanAddDoctor = false,
                CanAddMedicine = false,
                CanAddPatient = true,
                CanCreatePrescriptions = true,
                City = "Beer Sheva",
                EmailAddress = "Chen@gmail.com",
                FirstName = "Chen",
                Gender = Gender.זכר,
                ID = "304664535",
                LastName = "Levy",
                Password = "Chen1234",
                PhoneNumber = "0528789697",
                Street = "Vered",
                LicenceNumber = "7381",
                ProfileImagePath = "",
                ProfileImageSrc = "",
                Specialty = "All"
            };
            DB.PersonsTable.Add(doctor4);
            DB.SaveChanges();
            Doctor doctor5 = new Doctor() {
                BirthDate = new DateTime(1990, 2, 12),
                BuildingNumber = "97",
                CanAddDoctor = true,
                CanAddMedicine = false,
                CanAddPatient = false,
                CanCreatePrescriptions = true,
                City = "Hod Hasharon",
                EmailAddress = "dov@gmail.com",
                FirstName = "Dov",
                Gender = Gender.זכר,
                ID = "305637464",
                LastName = "Golan",
                Password = "Dov12345",
                PhoneNumber = "0504679315",
                Street = "Katz",
                LicenceNumber = "1411",
                ProfileImagePath = "",
                ProfileImageSrc = "",
                Specialty = "EKG"
            };
            DB.PersonsTable.Add(doctor5);
            DB.SaveChanges();
        }
        private void AddOfficers()
        {
            Officer officer1 = new Officer() {
                BirthDate = new DateTime(2002, 2, 8),
                BuildingNumber = "7",
                CanAddDoctor = true,
                CanAddMedicine = false,
                CanAddPatient = true,
                CanCreatePrescriptions = false,
                City = "Bet Shemesh",
                EmailAddress = "menashe@gmail.com",
                FirstName = "Menashe",
                Gender = Gender.זכר,
                ID = "305473001",
                LastName = "Nachmani",
                Password = "Menashe12",
                PhoneNumber = "0527147147",
                Street = "Katz",
                ProfileImagePath = "",
                ProfileImageSrc = "",
            };
            DB.PersonsTable.Add(officer1);
            DB.SaveChanges();
        }
        private void AddPaitents()
        {
            Patient patient1 = new Patient() {
                BirthDate = new DateTime(2020, 2, 8),
                BuildingNumber = "19",
                City = "Bet Shemesh",
                EmailAddress = "rut@gmail.com",
                FirstName = "Rut",
                Gender = Gender.נקבה,
                ID = "305645442",
                LastName = "Vazana",
                PhoneNumber = "0581239874",
                Street = "David Hamelec",
                FamilyDoctor = "Dr. Rozenblum",
                FatherName = "Shmuel",
                Weight = 4.6
            };
            DB.PersonsTable.Add(patient1);
            DB.SaveChanges();
            Patient patient2 = new Patient() {
                BirthDate = new DateTime(1984, 4, 5),
                BuildingNumber = "19",
                City = "Bet Shemesh",
                EmailAddress = "shmuel@gmail.com",
                FirstName = "Shmuel",
                Gender = Gender.זכר,
                ID = "305847832",
                LastName = "Vazana",
                PhoneNumber = "0581239874",
                Street = "David Hamelec",
                FamilyDoctor = "Dr. Rozenblum",
                FatherName = "Yoram",
                Weight = 99.99
            };
            DB.PersonsTable.Add(patient2);
            DB.SaveChanges();
            Patient patient3 = new Patient() {
                BirthDate = new DateTime(1993, 4, 4),
                BuildingNumber = "35",
                City = "Kochav Yaakov",
                EmailAddress = "renana@gmail.com",
                FirstName = "Renana",
                Gender = Gender.נקבה,
                ID = "308045442",
                LastName = "Reuveni",
                PhoneNumber = "0547948536",
                Street = "Dolev",
                FamilyDoctor = "Dr. Cohen",
                FatherName = "George",
                Weight = 62.41
            };
            DB.PersonsTable.Add(patient3);
            DB.SaveChanges();
            Patient patient4 = new Patient() {
                BirthDate = new DateTime(1920, 1, 1),
                BuildingNumber = "1",
                City = "Yokneam",
                EmailAddress = "lev@gmail.com",
                FirstName = "Lev",
                Gender = Gender.אחר,
                ID = "024219107",
                LastName = "Lev",
                PhoneNumber = "0588888888",
                Street = "Lev",
                FamilyDoctor = "Dr. Lev",
                FatherName = "Lev",
                Weight = 32
            };
            DB.PersonsTable.Add(patient4);
            DB.SaveChanges();
        }
        private void AddMedicines()
        {
            Medicine med1 = new Medicine() {
                CommercialName = "Promacta",
                MedicineID = "825422",
                GenericName = "Promacta",
                Manufacturer = "",
                ActiveIngredients = ""
            };
            DB.MedicinesTable.Add(med1);
            DB.SaveChanges();
            Medicine med2 = new Medicine() {
                CommercialName = "griseofulvin",
                MedicineID = "5021",
                GenericName = "Griseofulvin",
                Manufacturer = "",
                ActiveIngredients = ""
            };
            DB.MedicinesTable.Add(med2);
            DB.SaveChanges();
            Medicine med3 = new Medicine() {
                CommercialName = "Rhizopus stolonifer allergenic extract 25 MG/ML Injectable Solution",
                MedicineID = "2101077",
                GenericName = "Rhizopus",
                Manufacturer = "",
                ActiveIngredients = ""
            };
            DB.MedicinesTable.Add(med3);
            DB.SaveChanges();
            Medicine med4 = new Medicine() {
                CommercialName = "imipramine hydrochloride",
                MedicineID = "150816",
                GenericName = "Imipramine",
                Manufacturer = "",
                ActiveIngredients = ""
            };
            DB.MedicinesTable.Add(med4);
            DB.SaveChanges();
            Medicine med5 = new Medicine() {
                CommercialName = "Stemphylium solani allergenic extract",
                MedicineID = "867349",
                GenericName = "Stemphylium",
                Manufacturer = "",
                ActiveIngredients = ""
            };
            DB.MedicinesTable.Add(med5);
            DB.SaveChanges();
            Medicine med6 = new Medicine() {
                CommercialName = "rizatriptan",
                MedicineID = "88014",
                GenericName = "Rizatriptan",
                Manufacturer = "",
                ActiveIngredients = ""
            };
            DB.MedicinesTable.Add(med6);
            DB.SaveChanges();
            Medicine med7 = new Medicine() {
                CommercialName = "river birch pollen extract",
                MedicineID = "852148",
                GenericName = "River birch",
                Manufacturer = "",
                ActiveIngredients = ""
            };
            DB.MedicinesTable.Add(med7);
            DB.SaveChanges();
            Medicine med8 = new Medicine() {
                CommercialName = "phenelzine",
                MedicineID = "8123",
                GenericName = "Phenelzine",
                Manufacturer = "",
                ActiveIngredients = ""
            };
            DB.MedicinesTable.Add(med8);
            DB.SaveChanges();
            Medicine med9 = new Medicine() {
                CommercialName = "moclobemide",
                MedicineID = "30121",
                GenericName = "Moclobemide",
                Manufacturer = "",
                ActiveIngredients = ""
            };
            DB.MedicinesTable.Add(med9);
            DB.SaveChanges();
            Medicine med10 = new Medicine() {
                CommercialName = "isocarboxazid",
                MedicineID = "6011",
                GenericName = "Moclobemide",
                Manufacturer = "",
                ActiveIngredients = ""
            };
            Medicine med11 = new Medicine() {
                CommercialName = "benzoic acid",
                MedicineID = "18989",
                GenericName = "Benzoic Acid",
                Manufacturer = "",
                ActiveIngredients = ""
            };
            DB.MedicinesTable.Add(med11);
            DB.SaveChanges();
        }
    }
}
            

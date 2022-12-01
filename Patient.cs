using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdrave
{
    class Patient
    {
        private string name, adress, bloodGroup;
        private uint birthYear;
        private char bloodRezFact;
        private double lev;
        private int tromb, hemog;
        private byte age;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Adress
        {
            get { return this.adress; }
            set { this.adress = value; }
        }
        public string BloodGroup
        {
            get { return this.bloodGroup; }
            set
            {
                string[] validGroups = { "A", "B", "0", "AB" };

                if (validGroups.Contains(value))
                    this.bloodGroup = value;
                else
                    throw new ArgumentException("Nevalidna grupa!");
            }
        }
        public uint BirthYear
        {
            get { return this.birthYear; }
            set
            {
                if (value < 2022 && value > 1895)
                    this.birthYear = value;
                else
                    throw new ArgumentException("Nevalidna godina");
            }
        }
        public char BloodRezFact
        {
            get { return this.bloodRezFact; }
            set
            {
                if (value == '+' || value == '-')
                    this.bloodRezFact = value;
                else
                    throw new ArgumentException("Nevaliden faktor!");
            }
        }
        public double Lev
        {
            get { return this.lev; }
            set
            {
                if (value > 0)
                    this.lev = value;
                else
                    throw new ArgumentException("Otricatelna stoinost na levkociti");
            }
        }
        public int Tromb
        {
            get { return this.tromb; }
            set
            {
                if (value > 0)
                    this.tromb = value;
                else
                    throw new ArgumentException("Otricatelna stoinost na trombociti");
            }
        }
        public int Hemog
        {
            get { return this.hemog; }
            set
            {
                if (value > 0)
                    this.hemog = value;
                else
                    throw new ArgumentException("Otricatelna stoinost na hemoglobin");
            }
        }
        public byte Age
        {
            get {
                if (BirthYear == 0)
                    return 0;
                this.age = Convert.ToByte(2022 - BirthYear);
                return this.age;
            }
        }

        public Patient()
        {
            this.age = 0;
        }
        public Patient(string name, string adress, string bloodGroup, uint birthYear, char bloodRezFact, double lev, int hemog, int tromb)
        {
            this.Name = name;
            this.Adress = adress;
            this.BloodGroup = bloodGroup;
            this.BirthYear = birthYear;
            this.BloodRezFact = bloodRezFact;
            this.Lev = lev;
            this.Hemog = hemog;
            this.Tromb = tromb;
        }
        public Patient(Patient p)
        {
            this.Name = p.Name;
            this.Adress = p.Adress;
            this.BloodGroup = p.BloodGroup;
            this.BirthYear = p.BirthYear;
            this.BloodRezFact = p.BloodRezFact;
            this.Lev = p.Lev;
            this.Hemog = p.Hemog;
            this.Tromb = p.Tromb;
        }

        public void Print()
        {
            double levGorna = 10.5, levDolna = 3.5, trombDolna = 130, trombGorna = 360, hemDolna = 120, hemGorna = 160;
            char levInd, trombInd, hemInd;

            if (this.Lev > levGorna)
                levInd = 'H';
            else if (this.Lev < levGorna && this.Lev > levDolna)
                levInd = '-';
            else
                levInd = 'L';

            if (this.Tromb > trombGorna)
                trombInd = 'H';
            else if (this.Tromb < trombGorna && this.Tromb > trombDolna)
                trombInd = '-';
            else
                trombInd = 'L';

            if (this.Hemog > hemGorna)
                hemInd = 'H';
            else if (this.Hemog < hemGorna && this.Hemog > hemDolna)
                hemInd = '-';
            else
                hemInd = 'L';

            const int spacing = -20;

            Console.WriteLine();
            Console.WriteLine($"Ime na pacient: {this.Name}");
            Console.WriteLine($"Adres: {this.Adress}");
            Console.WriteLine($"Vazrast: {this.Age}");
            Console.WriteLine($"Kravna grupa: {this.BloodGroup}{this.BloodRezFact}");
            Console.WriteLine();
            Console.WriteLine("Rezultat ot izsledvaneto:");
            Console.WriteLine($"{"Pokazatel", spacing} {"rezultat", spacing} {"dolna granica", spacing} {"gorna granica", spacing} {"patologiq", spacing}");
            Console.WriteLine($"{"Levkociti", spacing} {this.Lev, spacing} {levDolna, spacing} {levGorna, spacing} {levInd, spacing}");
            Console.WriteLine($"{"Trombociti", spacing} {this.Tromb, spacing} {trombDolna, spacing} {trombGorna, spacing} {trombInd, spacing}");
            Console.WriteLine($"{"Levkociti", spacing} {this.Hemog, spacing} {hemDolna, spacing} {hemGorna, spacing} {hemInd, spacing}");
        }
    }
}

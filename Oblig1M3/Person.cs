﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1M3
{
    public class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public int BirthYear;
        public int DeathYear;
        public Person Father;
        public Person Mother;

        public string GetDescription()
        {
            //return string.Format("{0} {1} (Id={2}) Født: {3} Død: {4} Far: {5} (Id={6}) Mor: {7} (Id={8})", FirstName, LastName, Id, BirthYear, DeathYear, Father.FirstName, Father.Id, Mother.FirstName, Mother.Id);

            string fullString = "";
            if (FirstName != null)
            {
                fullString += FirstName + " ";
            }
            if (LastName != null)
            {
                fullString += LastName + " ";
            }
            if (Id != 0)
            {
                fullString += "(Id="+Id+") ";
            }
            if (BirthYear != 0)
            {
                fullString += "Født: "+BirthYear+" ";
            }
            if (DeathYear != 0)
            {
                fullString += "Død: "+DeathYear+" ";
            }
            if (Father != null)
            {
                if (Father.FirstName != null)
                {
                    fullString += "Far: " + Father.FirstName + " ";
                }
                if (Father.Id != 0)
                {
                    fullString += "(Id=" + Father.Id + ") ";
                }
            }
            if (Mother != null)
            {
                if (Mother.FirstName != null)
                {
                    fullString += "Mor: " + Mother.FirstName + " ";
                }
                if (Mother.Id != 0)
                {
                    fullString += "(Id=" + Mother.Id + ")";
                }
            }

            
            string fullStringTrimmed = fullString.Trim();
            return fullStringTrimmed;


        }
    }
}

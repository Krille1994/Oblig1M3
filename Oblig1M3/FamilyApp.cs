using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1M3
{
    public class FamilyApp
    {
        public string WelcomeMessage = "Hallo! ";
        public string CommandPrompt = "Skriv en kommando: ";
        public List<Person> People;
        public FamilyApp(params Person[] family)
        {
            People = new List<Person>(family);
        }
        public string HandleCommand(string input)
        {
            if (input == "hjelp")
            {
                return helpText();
            }
            else if (input == "liste")
            {
                return showList(People);
            }
            else if (input.Contains("vis "))
            {
                //Console.WriteLine(People.Count);
                return getPersonById(input, People);
            }
            else
            {
                return "Du kan skrive 'hjelp' for å se hva kommandoene er";
            }
        }

        private static string showList(List<Person> People)
        {
            string tekst = "";
            for (int i = 0; i < People.Count; i++)
            {
                tekst += People[i].GetDescription() + "\n";
            }
            return tekst;
        }

        private static string getPersonById(string input, List<Person> People)
        {
            int ID = Int32.Parse(input.Substring(input.IndexOf(" ") + 1));
            string tekst = "";
            List<string> children = new List<string>();

            for (int i = 0; i < People.Count; i++)
            {
                if (People[i].Id == ID)
                {
                    tekst += People[i].GetDescription();
                    for (int j = 0; j < People.Count; j++)
                    {
                        if (People[j].Father != null)
                        {
                            if (People[j].Father.Id == People[i].Id)
                            {
                                children.Add(People[j].FirstName + " (Id=" + People[j].Id + ") Født: " + People[j].BirthYear);
                            }
                        }
                        if (People[j].Mother != null)
                        {
                            if (People[j].Mother.Id == People[i].Id)
                            {
                                children.Add(People[j].FirstName + " (Id=" + People[j].Id + ") Født: " + People[j].BirthYear);
                            }
                        }
                    }
                }
            }
            tekst += "\n";
            if (children.Count != 0)
                tekst += "  Barn:\n    ";
            {
                for (int i = 0; i < children.Count; i++)
                {
                    if (i == children.Count - 1)
                    {
                        tekst += children[i] + "\n";
                    }
                    else
                    {
                    tekst += children[i] + "\n    ";
                    }
                }
            }
            return tekst;
        }

        private static string helpText()
        {
            return @"Kommandoer:

liste

Du kan skrive liste for å få en liste over alle personer.

vis Id

Du kan skrive denne kommandoen for å skjekke opp en person med en spesifikk id, 
eks: vis 23";
        }
    }
}

﻿
﻿  using System;
using System.Data.SqlTypes;
using System.Collections.Generic;

Pet myPet = new Pet();
List<Pet> listOfPets = new List<Pet>();

LoadFileValuesToMemory(listOfPets);

bool loopAgain = true;
while (loopAgain)
{
	try
	{
		DisplayMainMenu();
		string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
		if (mainMenuChoice == "N")
			myPet = NewPet();
		if (mainMenuChoice == "S")
			ShowPetInfo(myPet);

		if (mainMenuChoice == "A")
			AddPetToList(myPet, listOfPets);
		if (mainMenuChoice == "F")
			myPet = FindPetInList(listOfPets);
		if (mainMenuChoice == "R")
			RemovePetFromList(myPet, listOfPets);
		if (mainMenuChoice == "D")
			DisplayAllPetsInList(listOfPets);
		if (mainMenuChoice == "Q")
		{
			SaveMemoryValuesToFile(listOfPets);
			loopAgain = false;
			throw new Exception("Adios, I hope to see you again.");
		}
		if (mainMenuChoice == "E")
		{
			while (true)
			{
				DisplayEditMenu();
				string editMenuChoice = Prompt("\nEnter an Edit Menu Choice: ").ToUpper();
				if (editMenuChoice == "T")
					GetTag(myPet);
				if (editMenuChoice == "N")
					GetName(myPet);
				if (editMenuChoice == "A")
					GetAge(myPet);
				if (editMenuChoice == "W")
					GetWeight(myPet);
				if (editMenuChoice == "P")
					GetType(myPet);
				if (editMenuChoice == "R")
					throw new Exception("Returning to Main Menu");
			}
		}
	}
	catch (Exception ex)
	{
		Console.WriteLine($"{ex.Message}");
	}
}

void DisplayMainMenu()
{
	Console.WriteLine("\nMain Menu");
	Console.WriteLine("N) New Pet Part A");
	Console.WriteLine("S) Show Pet Info Part A");
	Console.WriteLine("E) Edit Pet Info Part A");
	Console.WriteLine("A) Add Pet To List Part B");
	Console.WriteLine("F) Find Pet In List Part B");
	Console.WriteLine("R) Remove Pet From List Part B");
	Console.WriteLine("D) Display all Pets in List Part B");
	Console.WriteLine("Q) Quit");
}

void DisplayEditMenu()
{
	Console.WriteLine("Edit Menu");
	Console.WriteLine("T) Tag");
	Console.WriteLine("N) Name");
	Console.WriteLine("A) Age");
	Console.WriteLine("W) Weight");
	Console.WriteLine("P) Type");
	Console.WriteLine("R) Return to Main Menu");
}

void ShowPetInfo(Pet pet)
{
	if(pet == null)
		throw new Exception($"No Pet In Memory");
	Console.WriteLine($"\n{pet.ToString()}");
	Console.WriteLine($"Acepromazine Dose Required  :\t{pet.Acepromazine:n4}");
	Console.WriteLine($"Carprofen Dose Required     :\t{pet.Carprofen:n4}");
}

string Prompt(string prompt)
{
	string myString = "";
	while (true)
	{
		try
		{
		Console.Write(prompt);
		myString = Console.ReadLine().Trim();
		if(string.IsNullOrEmpty(myString))
			throw new Exception($"Empty Input: Please enter something.");
		break;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
	return myString;
}

double PromptDoubleBetweenMinMax(String msg, double min, double max)
{
	double num = 0;
	while (true)
	{
		try
		{
			Console.Write($"{msg} between {min} and {max} inclusive: ");
			num = double.Parse(Console.ReadLine());
			if (num < min || num > max)
				throw new Exception($"Must be between {min:n2} and {max:n2}");
			break;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Invalid: {ex.Message}");
		}
	}
	return num;
}

Pet NewPet()
{
	Console.WriteLine("Not Implemented Yet PartA");
	Pet myPet = new Pet();
	GetTag(myPet);
	GetName(myPet);
	GetAge(myPet);
	GetWeight(myPet);
	GetType(myPet);
	return myPet;
}

void GetTag(Pet pet)
{
	string myString = Prompt($"Enter Tag: ");
	pet.Tag = myString;
}

void GetName(Pet pet)
{
	Console.WriteLine("Not Implemented Yet PartA");
	string myString = Prompt($"Enter Name: ");
	pet.Name = myString;
}

void GetAge(Pet pet)
{
	Console.WriteLine("Not Implemented Yet PartA");
	double myDouble = PromptDoubleBetweenMinMax("Enter Height in inches: ", 0, 25);
	pet.Age = myDouble;
}

void GetWeight(Pet pet)
{
	Console.WriteLine("Not Implemented Yet PartA");
	double myDouble = PromptDoubleBetweenMinMax("Enter Weight in pounds: ", 0, 200);
	pet.Weight = myDouble;
}

void GetType(Pet pet)
{
	Console.WriteLine("Not Implemented Yet PartA");
	while(true)
	{
		try
		{
			string myString = Prompt($"Enter Type CAT or DOG: ");
			pet.Type = myString;
			break;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{ex.Message}");
		}
	}
}

void AddPetToList(Pet myPet, List<Pet> listOfPets)
{
	Console.WriteLine("Not Implemented Yet PartB");
	if(myPet == null)
		throw new Exception($"No Pet provided to add to list");
	listOfPets.Add(myPet);
	Console.WriteLine($"Pet Added");
}

Pet FindPetInList(List<Pet> listOfPets)
{
	Console.WriteLine("Not Implemented Yet PartB");
	string myString = Prompt($"Enter Partial Pet Name: ");
	foreach(Pet pet in listOfPets)
		if(pet.Name.Contains(myString))
			return pet;
	Console.WriteLine($"No Pets Match");
	return null;
}

void RemovePetFromList(Pet myPet, List<Pet> listOfPets)
{
	Console.WriteLine("Not Implemented Yet PartB");
	if(myPet == null)
		throw new Exception($"No Pet provided to remove from list");
	listOfPets.Remove(myPet);
	Console.WriteLine($"Pet Removed");
}

void DisplayAllPetsInList(List<Pet> listOfPets)
{
	Console.WriteLine("Not Implemented Yet PartB");
	foreach(Pet pet in listOfPets)
		ShowPetInfo(pet);
}

void LoadFileValuesToMemory(List<Pet> listOfPets)
{
	while(true){
		try
		{
			string fileName = Prompt("Enter file name including .csv or .txt: ");
			string fileName = "regin.csv";
			string filePath = $"./data/{fileName}";
			if (!File.Exists(filePath))
				throw new Exception($"The file {fileName} does not exist.");
			string[] csvFileInput = File.ReadAllLines(filePath);
			for(int i = 0; i < csvFileInput.Length; i++)
			{
				Console.WriteLine($"lineIndex: {i}; line: {csvFileInput[i]}");
				string[] items = csvFileInput[i].Split(',');
				for(int j = 0; j < items.Length; j++)
				{
					Console.WriteLine($"itemIndex: {j}; item: {items[j]}");
				}
				Pet myPet = new Pet(items[0], items[1], double.Parse(items[2]), double.Parse(items[3]), items[4]);
				listOfPets.Add(myPet);
			}
			Console.WriteLine($"Load complete. {fileName} has {listOfPets.Count} data entries");
			break;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{ex.Message}");
		}
	}
}

void SaveMemoryValuesToFile(List<Pet> listOfPets)
{
	string fileName = Prompt("Enter file name including .csv or .txt: ");
	string fileName = "regout.csv";
	string filePath = $"./data/{fileName}";
	string[] csvLines = new string[listOfPets.Count];
	for (int i = 0; i < listOfPets.Count; i++)
	{
		csvLines[i] = listOfPets[i].ToString();
	}
	File.WriteAllLines(filePath, csvLines);
	Console.WriteLine($"Save complete. {fileName} has {listOfPets.Count} entries.");
}



Client myClient = new Client();
List<Client> listofClients = new List<Client>();

LoadFileValuesToMemory(listofClients);

bool loopAgain = true;
while (loopAgain)
{
    try
    {
        DisplayMenuOptions();
        string mainMenuChoice = Prompt("\nEnter main menu selection: ").ToUpper();
        if (mainMenuChoice == "N")
            myClient = NewClient();
        if (mainMenuChoice == "S")
            ShowClientBmiInfo(myClient);
        if (mainMenuChoice == "Q")
        {
            SaveMemoryValuesToFile(myClient);
            loopAgain = false;
            throw new Exception("Program ended, thank you.");
        }
        if (mainMenuChoice == "E")
        {
            while (true)
            {
                DisplayEditMenu();
                string editMenuChoice = Prompt("\nWhat would you like to edit? ");
                if (editMenuChoice == "F")
                    GetFirstName(myClient);
                if (editMenuChoice == "L")
                    GetLastName(myClient);
                if (editMenuChoice == "H")
                    GetHeight(myClient);
                if (editMenuChoice == "W")
                    GetWeight(myClient);
                if (editMenuChoice == "R")
                    throw new Exception("Returning to Main Menu");

            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void DisplayMenuOptions()
{
    Console.WriteLine("\nMain Menu");
    Console.WriteLine("============");
    Console.WriteLine("[N]ew client");
    Console.WriteLine("[S]how client BMI info");
    Console.WriteLine("[E]dit client");
    Console.WriteLine("[Q]uit");
}

void DisplayEditMenu()
{
    Console.WriteLine("Edit client");
    Console.WriteLine("============");
    Console.WriteLine("[F]irst name");
    Console.WriteLine("[L]ast name");
    Console.WriteLine("[H]eight");
    Console.WriteLine("[W]eight");
    Console.WriteLine("[R]eturn to Main Menu");
}

void ShowClientBmiInfo(Client client)
{
    if (client == null)
        throw new Exception($"No client info stored");
}

string Prompt(string prompt)
{
    string myString = "";
    while (true)
    {
        try
        {
            Console.Write(prompt);
            myString = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(myString))
                throw new Exception($"Empty Input: Please enter something.");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return myString;
}

double PromptDoubleBetweenMinMax(String msg, double min, double max)
{
    double num = 0;
    while (true)
    {
        try
        {
            Console.Write($"{msg} between {min} and {max} inclusive: ");
            num = double.Parse(Console.ReadLine());
            if (num < min || num > max)
                throw new Exception($"Must be between {min:n2} and {max:n2}");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid: {ex.Message}");
        }
    }
    return num;
}

client NewClient()
{
    Client myClient = new Client();
    GetFirstName(myClient);
    GetLastName(myClient);
    GetWeight(myClient);
    GetHeight(myClient);
    Console.WriteLine("Client info sucessfully entered");
    return myClient;
}

void GetFirstName(Client client)
{
    string myString = Prompt($"Enter client's first name: ");
    client.FirstName = myString;
}

void GetLastName(Client client)
{
    string myString = Prompt($"Enter client's last name: ");
    client.LastName = myString;
}

void GetWeight(Client client)
{
    double myDouble = PromptDoubleBetweenMinMax("Enter Weight in pounds: ", 0, double.PositiveInfinity);
    client.Weight = myDouble;
}

void GetHeight(Client client)
{
    double myDouble = PromptDoubleBetweenMinMax("Enter Height in inches: ", 0, double.PositiveInfinity);
    client.Height = myDouble;
}
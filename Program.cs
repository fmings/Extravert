using System.ComponentModel.Design;
using System.IO.Compression;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "bush",
        LightNeeds = 3,
        AskingPrice = 15.99M,
        City = "Louisville",
        ZIP = 40108,
        Sold = true
    },
    new Plant()
    {
        Species = "flower",
        LightNeeds = 3,
        AskingPrice = 18.99M,
        City = "Lexington",
        ZIP = 40258,
        Sold = true
    },
    new Plant()
    {
        Species = "bean",
        LightNeeds = 1,
        AskingPrice = 5.99M,
        City = "Brandenburg",
        ZIP = 40175,
        Sold = false
    },
    new Plant()
    {
        Species = "grass",
        LightNeeds = 3,
        AskingPrice = 10.99M,
        City = "Nashville",
        ZIP = 37208,
        Sold = false
    },
    new Plant()
    {
        Species = "tree",
        LightNeeds = 5,
        AskingPrice = 26.99M,
        City = "Brentwood",
        ZIP = 37027,
        Sold = false
    },
};

Random random = new Random();

string greeting = "Welcome to Extravert!";
Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Main Menu - Choose an option:
                            0. Exit
                            1. Display all plants
                            2. Plant of the Day!
                            3. Post a plant to be adopted
                            4. Adopt a plant
                            5. Delist a plant");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        DisplayPlants();
    }
    else if (choice == "2")
    {
        RandomPlant();
    }
    else if (choice == "3")
    {
        PostPlant();
    }
    else if (choice == "4")
    {
        AdoptPlant();
    }
    else if (choice == "5")
    {
        RemovePlant();
    }
    else
    {
        Console.WriteLine("Please enter a number between 0 and 4");
    }
};
void DisplayPlants()
{
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. A {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars");
    }
}

void PostPlant()
{
    Console.WriteLine("Enter the species of the plant:");
    string species = Console.ReadLine();

    Console.WriteLine("Enter the light needs of the plant (on a scale of 1 to 5):");
    int lightNeeds = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the asking price of the plant (use x.xx format)");
    decimal askingPrice = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Enter the city where the plant is located:");
    string city = Console.ReadLine();

    Console.WriteLine("Enter the ZIP code");
    int zip = int.Parse(Console.ReadLine());

 

    Plant newPlant = new Plant()
    {
        Species = species,
        LightNeeds = lightNeeds,
        AskingPrice = askingPrice,
        City = city,
        ZIP = zip,
        Sold = false
    };
    plants.Add(newPlant);
    Console.WriteLine("Your plant has been listed!");
};

void AdoptPlant()
{
    var availablePlants = plants.Where(p => !p.Sold).ToList();

    Console.WriteLine("Available Plants:");
    for (int i = 0; i < availablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. A {availablePlants[i].Species} in {availablePlants[i].City} {(availablePlants[i].Sold ? "was sold" : "is available")} for {availablePlants[i].AskingPrice} dollars");
    };
   
    Console.WriteLine("Please enter the number of which plant you would like to adopt:");
    int selectedPlantIndex;
    if (int.TryParse(Console.ReadLine(), out selectedPlantIndex) && selectedPlantIndex > 0 && selectedPlantIndex <= availablePlants.Count)
    {
        Plant selectedPlant = availablePlants[selectedPlantIndex - 1];
        selectedPlant.Sold = true;
        Console.WriteLine($"You have adopted the {selectedPlant.Species}.");
    }
    else
    {
        Console.WriteLine("Invalid selection. Please enter a valid number.");
    }
};

void RemovePlant()
{
    DisplayPlants();
    Console.WriteLine("Please enter the number of which plant you would like to remove:");
    int selectedPlantIndex;
    if (int.TryParse(Console.ReadLine(), out selectedPlantIndex) && selectedPlantIndex > 0 && selectedPlantIndex <= plants.Count)
    {
        plants.RemoveAt(selectedPlantIndex - 1);
    }
    else
    {
        Console.WriteLine("Invalid entry. Please enter a valid number.");
    }
    Console.WriteLine("Remaining Plants:");
    DisplayPlants();
}

void RandomPlant()
{
    int randomPlantIndex;
    Plant plantOfTheDay;

    do
    {
        randomPlantIndex = random.Next(0, plants.Count);
        plantOfTheDay = plants[randomPlantIndex];
    }
    while (plantOfTheDay.Sold);

    Console.WriteLine($@"Plant of the day:
                        Species: {plantOfTheDay.Species}
                        Location: {plantOfTheDay.City}
                        Light Needs: {plantOfTheDay.LightNeeds}
                        Price: {plantOfTheDay.AskingPrice}");
}

void SearchLightNeeds()
{
    Console.WriteLine("Please enter your maximum light needs (number between 1 & 5):");


}

Console.ReadLine();
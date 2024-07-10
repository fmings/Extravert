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
        Sold = true,
        AvailableUntil = new DateTime(2024, 7, 15)
    },
    new Plant()
    {
        Species = "flower",
        LightNeeds = 3,
        AskingPrice = 18.99M,
        City = "Lexington",
        ZIP = 40258,
        Sold = true,
        AvailableUntil = new DateTime(2024, 8, 15)
    },
    new Plant()
    {
        Species = "bean",
        LightNeeds = 1,
        AskingPrice = 5.99M,
        City = "Brandenburg",
        ZIP = 40175,
        Sold = false,
        AvailableUntil = new DateTime(2024, 6, 15)
    },
    new Plant()
    {
        Species = "grass",
        LightNeeds = 3,
        AskingPrice = 10.99M,
        City = "Nashville",
        ZIP = 37208,
        Sold = false,
        AvailableUntil = new DateTime(2024, 10, 15)
    },
    new Plant()
    {
        Species = "tree",
        LightNeeds = 5,
        AskingPrice = 26.99M,
        City = "Brentwood",
        ZIP = 37027,
        Sold = false,
        AvailableUntil = new DateTime(2024, 11, 15)
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
                            3. Search Plants by Light Needs
                            4. Post a plant to be adopted
                            5. Adopt a plant
                            6. Delist a plant
                            7. View App Statistics");
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
        SearchLightNeeds();
    }
    else if (choice == "4")
    {
        PostPlant();
    }
    else if (choice == "5")
    {
        AdoptPlant();
    }
    else if (choice == "6")
    {
        RemovePlant();
    }
    else if (choice == "7")
    {
        AppStatistics();
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
        Console.WriteLine($"{i + 1}. A {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} untlil {plants[i].AvailableUntil} for {plants[i].AskingPrice} dollars");
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

    Console.WriteLine("Enter the expiration date (yyyy-mm-dd):");
    DateTime expirationDate = DateTime.MinValue;
    bool isValidDate = false;
    while (!isValidDate)
    {
        try
        {
            isValidDate = DateTime.TryParse(Console.ReadLine(), out expirationDate);
            if (!isValidDate)
            {
                Console.WriteLine("Invalid date format. Please enter the expiration date (yyyy-mm-dd):");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Please enter the expiration date (yyyy-mm-dd):");
        }
    }


    Plant newPlant = new Plant()
    {
        Species = species,
        LightNeeds = lightNeeds,
        AskingPrice = askingPrice,
        City = city,
        ZIP = zip,
        Sold = false,
        AvailableUntil = expirationDate
    };
    plants.Add(newPlant);
    Console.WriteLine("Your plant has been listed!");
};

void AdoptPlant()
{
    var availablePlants = plants.Where(p => !p.Sold && DateTime.Now <= p.AvailableUntil).ToList();

    Console.WriteLine("Available Plants:");
    for (int i = 0; i < availablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. A {availablePlants[i].Species} in {availablePlants[i].City} {(availablePlants[i].Sold ? "was sold" : "is available")} until {availablePlants[i].AvailableUntil} for {availablePlants[i].AskingPrice} dollars");
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
    int maxLightNeeds;
    if (int.TryParse(Console.ReadLine(), out maxLightNeeds) && maxLightNeeds > 0 && maxLightNeeds <= 5)
    {
        var matchingPlants = new List<Plant>();
        foreach (var plant in plants)
        {
            if (plant.LightNeeds <= maxLightNeeds)
            {
                matchingPlants.Add(plant);
            }
        }
        
        Console.WriteLine($"Plants with light needs {maxLightNeeds} or lower:");
        foreach (var plant in matchingPlants)
        {
            Console.WriteLine(PlantDetails(plant));
        }
    }
    else
    {
        Console.WriteLine("Invalid entry. Please enter a valid number.");
    }

}

void AppStatistics()
{
    var lowestPricePlant = plants.OrderBy(p => p.AskingPrice).First();
    var numberOfPlants = plants.Count();
    var highestLightNeedsPlant = plants.OrderByDescending(p => p.LightNeeds).First();
    var averageLightNeeds = plants.Average(p => p.LightNeeds);
    double adoptionRate = (double)plants.Count(p => p.Sold)/plants.Count * 100;
    Console.WriteLine($@"Lowest price plant name: {lowestPricePlant.Species}
    Number of plants available: {numberOfPlants}
    Name of plant with highest light needs: {highestLightNeedsPlant.Species}
    Average light needs: {averageLightNeeds}
    Percentage of plants adopted: {adoptionRate}%");
}

string PlantDetails(Plant plant)
{
    string plantString = $"A {plant.Species} in {plant.City} {(plant.Sold ? "was sold" : "is available")} for {plant.AskingPrice} dollars";
    return plantString;
}
Console.ReadLine();

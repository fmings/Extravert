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

string greeting = "Welcome to Extravert!";
Console.WriteLine(greeting);
ListPlants();
void ListPlants()
{
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }
}
Console.ReadLine();
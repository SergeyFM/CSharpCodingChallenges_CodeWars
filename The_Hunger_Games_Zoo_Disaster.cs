using System.Collections.Generic;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class The_Hunger_Games_Zoo_Disaster {

    /*

    The Hunger Games - Zoo Disaster!

    Story
    A freak power outage at the zoo has caused all of the electric cage doors to malfunction and swing open...

    All the animals are out and some of them are eating each other!

    It's a Zoo Disaster!
    Here is a list of zoo animals, and what they can eat

    antelope eats grass
    big-fish eats little-fish
    bug eats leaves
    bear eats big-fish
    bear eats bug
    bear eats chicken
    bear eats cow
    bear eats leaves
    bear eats sheep
    chicken eats bug
    cow eats grass
    fox eats chicken
    fox eats sheep
    giraffe eats leaves
    lion eats antelope
    lion eats cow
    panda eats leaves
    sheep eats grass

    Kata Task
    INPUT
    A comma-separated string representing all the things at the zoo

    TASK
    Figure out who eats whom until no more eating is possible.

    OUTPUT
    A list of strings (refer to the example below) where:

    The first element is the initial zoo (same as INPUT)
    The last element is a comma-separated string of what the zoo looks like when all the eating has finished
    All other elements (2nd to last-1) are of the form X eats Y describing what happened
    Notes
    Animals can only eat things beside them

    Animals always eat to their LEFT before eating to their RIGHT

    Always the LEFTMOST animal capable of eating will eat before any others

    Any other things you may find at the zoo (which are not listed above) do not eat anything and are not edible

    Example
    Input

    "fox,bug,chicken,grass,sheep"

    Working

    1	fox can't eat bug	
    "fox,bug,chicken,grass,sheep"
    2	bug can't eat anything	
    "fox,bug,chicken,grass,sheep"
    3	chicken eats bug	
    "fox,chicken,grass,sheep"
    4	fox eats chicken	
    "fox,grass,sheep"
    5	fox can't eat grass	
    "fox,grass,sheep"
    6	grass can't eat anything	
    "fox,grass,sheep"
    7	sheep eats grass	
    "fox,sheep"
    8	fox eats sheep	
    "fox"
    Output

    ["fox,bug,chicken,grass,sheep", "chicken eats bug", "fox eats chicken", "sheep eats grass", "fox eats sheep", "fox"]

    */

    [TestMethod]
    public void Test() {
        string input = "fox,bug,chicken,grass,sheep";
        string[] expected = {
          "fox,bug,chicken,grass,sheep",
          "chicken eats bug",
          "fox eats chicken",
          "sheep eats grass",
          "fox eats sheep",
          "fox"
        };

        CollectionAssert.AreEqual(expected, WhoEatsWho(input));
    }

    public static string[] WhoEatsWho(string zoo) {
        Dictionary<string, List<string>> eaters = new() {
            {"antelope", new() {"grass" } },
            {"big-fish", new() {"little-fish" } },
            {"bug", new() {"leaves" } },
            {"bear", new() {"big-fish", "bug", "chicken", "cow", "leaves", "sheep" } },
            {"chicken", new() {"bug" } },
            {"cow", new() {"grass" } },
            {"fox", new() {"chicken", "sheep" } },
            {"giraffe", new() {"leaves" } },
            {"lion", new() {"antelope", "cow" } },
            {"panda", new() {"leaves" } },
            {"sheep", new() {"grass" } }
        };
        List<string> animals = zoo
            .Split(',')
            .Where(a => !string.IsNullOrWhiteSpace(a))
            .Select(a => a.Trim().ToLower())
            .ToList();

        List<string> carnageLog = new() { zoo };
        bool somebodysEaten = false;
        do {
            int currNumberOfAnimals = animals.Count();
            somebodysEaten = false;
            for (int i = 0; i < currNumberOfAnimals; i++) {
                string currAnimal = animals[i];
                string leftAnimal = i > 0 ? animals[i - 1] : "nobody";
                string rightAnimal = i < currNumberOfAnimals - 1 ? animals[i + 1] : "nobody";
                if (eaters.ContainsKey(currAnimal)) {
                    if (eaters[currAnimal].Contains(leftAnimal)) {
                        animals.RemoveAt(i - 1);
                        somebodysEaten = true;
                        carnageLog.Add($"{currAnimal} eats {leftAnimal}");
                        break;
                    }
                    if (eaters[currAnimal].Contains(rightAnimal)) {
                        animals.RemoveAt(i + 1);
                        somebodysEaten = true;
                        carnageLog.Add($"{currAnimal} eats {rightAnimal}");
                        break;
                    }
                }
            }
        } while (somebodysEaten == true);
        string carnageSurvivors = string.Join(',', animals);
        if (carnageSurvivors.Count() > 0) carnageLog.Add(carnageSurvivors);
        return carnageLog.ToArray();
    }
}

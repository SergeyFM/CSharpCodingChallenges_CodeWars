using System;
using System.Linq;

namespace CodingChallenges;
[TestClass]
public class Two_fighters_one_winner {
    [TestMethod]
    public void Test() {
        /*
        Create a function that returns the name of the winner in a fight between two fighters.
        Each fighter takes turns attacking the other and whoever kills the other first is victorious. Death is defined as having health <= 0.
        Each fighter will be a Fighter object/instance. See the Fighter class below in your chosen language.
        Both health and damagePerAttack (damage_per_attack for python) will be integers larger than 0. You can mutate the Fighter objects.
        Your function also receives a third argument, a string, with the name of the fighter that attacks first.

        Example:
          declare_winner(Fighter("Lew", 10, 2), Fighter("Harry", 5, 4), "Lew") => "Lew"
  
          Lew attacks Harry; Harry now has 3 health.
          Harry attacks Lew; Lew now has 6 health.
          Lew attacks Harry; Harry now has 1 health.
          Harry attacks Lew; Lew now has 2 health.
          Lew attacks Harry: Harry now has -1 health and is dead. Lew wins.

      
        */

        Assert.AreEqual("Lew", declareWinner(new Fighter("Lew", 10, 2), new Fighter("Harry", 5, 4), "Lew"));
        Assert.AreEqual("Harry", declareWinner(new Fighter("Lew", 10, 2), new Fighter("Harry", 5, 4), "Harry"));
        Assert.AreEqual("Harald", declareWinner(new Fighter("Harald", 20, 5), new Fighter("Harry", 5, 4), "Harry"));
        Assert.AreEqual("Harald", declareWinner(new Fighter("Harald", 20, 5), new Fighter("Harry", 5, 4), "Harald"));
        Assert.AreEqual("Harald", declareWinner(new Fighter("Jerry", 30, 3), new Fighter("Harald", 20, 5), "Jerry"));
        Assert.AreEqual("Harald", declareWinner(new Fighter("Jerry", 30, 3), new Fighter("Harald", 20, 5), "Harald"));


    }

    public string declareWinner(Fighter fighter1, Fighter fighter2, string firstAttacker) {

        // Who is who
        Fighter[] fighters = { fighter1, fighter2 };
        int victimIndex = Array.FindIndex(fighters, f => f.Name != firstAttacker);
        if (!new int[] { 0, 1 }.Contains(victimIndex)) return "";
        int attackerIndex = 1 - victimIndex;

        // First blow
        fighters[victimIndex].Health -= fighters[attackerIndex].DamagePerAttack;

        // Check who is stronger now
        double blowsVictimCanTake = Math.Ceiling((double)fighters[victimIndex].Health / fighters[attackerIndex].DamagePerAttack);
        double blowsAttackerCanTake = Math.Ceiling((double)fighters[attackerIndex].Health / fighters[victimIndex].DamagePerAttack);
        return blowsAttackerCanTake > blowsVictimCanTake ? fighters[attackerIndex].Name : fighters[victimIndex].Name;
    }


    public class Fighter {
        public string Name;
        public int Health, DamagePerAttack;
        public Fighter(string name, int health, int damagePerAttack) {
            this.Name = name;
            this.Health = health;
            this.DamagePerAttack = damagePerAttack;
        }
    }
}

/*
 * The game will first ask for the Player’s name. Pressing “Enter” will save that name.
 * The game will present a Main Menu. Its options will be selected by pressing an associated letter or number. The prompt will be repeated on an invalid choice. The options are:
 * Display Statistics (number of games played, number of “Fights” won, number of “Fights” lost.
 * Display Inventory
 * This will contain another option to change the Equipped Weapon, change the Equipped Armour, or exit back to the main menu.
 * On the Change Equipped Weapon and Armour screens, users can select a letter/number value to change the Hero EquippedWeapon or EquippedArmour.
 * Fight, beginning a “fight” with a randomly selected “Monster” from a list of available monsters.
 * In each Fight, the Hero and Monster have Health (a number) which they take turns reducing by “attacking” each other.
 * The “Hero” takes a “turn” by attacking the Monster.
 * The “damage” of that attack is calculated based on the Hero’s Base Strength + Equipped Weapon Power. Damage subtracts from the Current Health of the Monster.
 * The “Monster” takes a “turn” by attacking the Hero.
 * The “damage” of that attack is calculated by subtracting the Hero’s Base Defence, and Equipped Armour’s Power, from the Monster’s Strength. The result is subtracted from the Hero’s Current Health.
 * If either the Hero or the Monster is reduced to 0 Current Health from an attack, that character loses the fight and the other character wins.
 * After each Fight, the win or loss is recorded, and the user is returned to the Main Menu.
 */
Console.WriteLine("What is your name?");
Hero hero = new Hero(Console.ReadLine());

Weapon starterWeapon = new Weapon("Wooden Sword", 2);

Monster enemy1 = new Monster("Munstar", 2, 1, 5);
Monster enemy2 = new Monster("Munstar", 3, 2, 7);
Monster enemy3 = new Monster("Munstar", 4, 3, 10);
Monster enemy4 = new Monster("Munstar", 5, 4, 15);
Monster enemy5 = new Monster("Munstar", 6, 5, 20);



/*
 * Hero, which represents the user, with the following properties:
 * EquippedWeapon (An instance of Weapon used to calculate attack damage)
 * EquippedArmor (An instance of Armour used to calculate damage to the Hero)
 */
class MainMenu
{ 

}

class Hero
{
    public string Name { get; set; }
    public int BaseStrength { get; set; } = 5;
    public int BaseDefence { get; set; } = 2;
    public int OriginalHealth { get; set; } = 20;
    public int CurrentHealth { get; set; } = 20;

    public Hero(string name)
    {
        Name = name;
        BaseStrength = 5;
        BaseDefence = 2;
        OriginalHealth = 20;
        CurrentHealth = 20;
    }

    public void ShowStats()
    {
        Console.WriteLine("========================================");
        Console.WriteLine($"{Name} Stats:");
        Console.WriteLine($"Health: {CurrentHealth}/{OriginalHealth} ");
        Console.WriteLine($"Base Strength: {BaseStrength} ");
        Console.WriteLine($"Base Defence: {BaseDefence}");
        Console.WriteLine("========================================");

    }

    public void ShowInventory()
    {
        //(Returns what items the Hero is Equipped with)
    }
    public void EquipWeapon()
    {
        //EquipWeapon (Change the EquippedWeapon)

    }
    public void EquipArmour()
    {
        //EquipArmour(Change the EquippedArmour)
    }
}

class Monster
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int OriginalHealth { get; set; }
    public int CurrentHealth { get; set; }

    public Monster(string name, int strength, int defense, int originalHealth)
    {
        Name = name;
        Strength = strength;
        Defense = defense;
        OriginalHealth = originalHealth;
        CurrentHealth = originalHealth;
    }
}

/*
 * Weapon and Armour
 * Name (A predefined name for the instance – may be hard-coded).
 * Power (A number, added to the Hero’s attack damage for a Weapon, or subtracted from the Monster’s attack damage for Armour)
 */
class Weapon
{
    public string Name { get; set; }
    public int Power { get; set; }

    public Weapon(string name, int power)
    {
        Name = name;
        Power = power;
    }
}
class Armour
{
    public string Name { get; set; }
    public int Power { get; set; }
    public Armour(string name, int power)
    {
        Name = name;
        Power = power;
    }
}

/*
 * WeaponList and ArmourList
 * Static classes that collect all of the Weapon and Armour instances.
 * There should be at least three individual instances of Weapons and three individual instances of Armour stored.
 */
static class WeaponList
{

}
static class ArmourList
{

}

/*
 * 
 * Fight
 * Handles the organization of any Fight. Should be instantiated whenever a Fight is started by the player.
 * HeroTurn (calculates an handles “damage” to a monster as Hero BaseStrength + EquippedWeapon Power)
 * MonsterTurn (calculates and handles “damage” to the Hero as Monster Strength – (Hero BaseDefence­ + EquippedArmour Power)
 * Win (check and handle if the Monster CurrentHealth reaches 0. If the Hero wins, the Monster should no longer appear in the game, until the Hero Loses.)
 * Lose (check and handle if the Player CurrentHealth eaches 0. If the Hero Loses, their CurrentHealth is set to equal their OriginalHealth, and any Monsters that were previously defeated can appear again).
 */
class Fight
{
    public void HeroTurn()
    {

    }
  
    public void MonsterTurn()
    {

    }

    public void Win()
    {

    }

    public void Lose()
    {

    }
}

/*
 * Display the Main Menu
 * Select Main Menu options with user input (using a switch statement).
 * Handle the display and switching of any other menus. The User must be able to reach the main menu at any time.
 * Should be instantiated once at the start of the program, and invoke a method called Start which begins the game sequence.
 */

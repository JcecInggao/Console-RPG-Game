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

Game newGame = new Game();

Console.WriteLine("What is your name?");
Hero hero = new Hero(Console.ReadLine(), newGame);
newGame.Hero = hero;

Weapon starterWeapon = new Weapon("Wooden Club", 5);
Weapon weakWeapon = new Weapon("Dagger", 10);
Weapon midWeapon = new Weapon("Mace", 15);
Weapon strongWeapon = new Weapon("Greatsword", 20);
WeaponList.AddWeapon(starterWeapon);
WeaponList.AddWeapon(weakWeapon);
WeaponList.AddWeapon(midWeapon);
WeaponList.AddWeapon(strongWeapon);


Armour starterArmour = new Armour("No Armour", 1);
Armour weakArmour = new Armour("Leather Armour", 5);
Armour midArmour = new Armour("Chainmail Armour", 10);
Armour strongArmour = new Armour("Steel Armour", 15);
ArmourList.AddArmour(starterArmour);
ArmourList.AddArmour(weakArmour);
ArmourList.AddArmour(midArmour);
ArmourList.AddArmour(strongArmour);


Monster enemy1 = new Monster("Munstar", 3, 2, 20);
Monster enemy2 = new Monster("Munstar", 6, 3, 7);
Monster enemy3 = new Monster("Munstar", 9, 4, 10);
Monster enemy4 = new Monster("Munstar", 12, 5, 15);
Monster enemy5 = new Monster("Munstar", 15, 6, 20);

newGame.MainMenu();


/*
 * Display the Main Menu
 * Select Main Menu options with user input (using a switch statement).
 * Handle the display and switching of any other menus. The User must be able to reach the main menu at any time.
 * Should be instantiated once at the start of the program, and invoke a method called Start which begins the game sequence.
 */

class Game
{
    public Hero Hero { get; set; }

    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine($"What would you like to do {Hero.Name}?");
        Console.WriteLine();
        Console.WriteLine("Display Statictics [1]");
        Console.WriteLine("Display Inventory [2]");
        Console.WriteLine("Fight [3]");
        Console.WriteLine();
        Console.WriteLine("========================================");

        string playerInput = Console.ReadLine();
        int inputCode = 0;
        if (!int.TryParse(playerInput, out inputCode))
        {
            Console.WriteLine("Not an integer");
        }
        else
        {
            inputCode = int.Parse(playerInput);
        }

        switch (inputCode)
        {
            case 1:
                Hero.ShowStats();
                break;
            case 2:
                Hero.ShowInventory();
                break;
            case 3:

                break;
            default:
                Console.WriteLine("Invalid input, please try again: ");
                Console.ReadKey();
                MainMenu();
                break;
        }
    }
}


/*
 * Hero, which represents the user, with the following properties:
 * EquippedWeapon (An instance of Weapon used to calculate attack damage)
 * EquippedArmor (An instance of Armour used to calculate damage to the Hero)
 */
class Hero
{
    public string Name { get; set; }
    public int BaseStrength { get; set; } = 5;
    public int BaseDefence { get; set; } = 2;
    public int OriginalHealth { get; set; } = 100;
    public int CurrentHealth { get; set; }

    public Game Game = new Game();

    public Hero(string name, Game game)
    {
        Name = name;
        BaseStrength = 5;
        BaseDefence = 2;
        OriginalHealth = 20;
        CurrentHealth = OriginalHealth;
        Game = game;
    }


    public void ShowStats()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine($"{Name} Stats:");
        Console.WriteLine($"Health: {CurrentHealth}/{OriginalHealth} ");
        Console.WriteLine($"Base Strength: {BaseStrength} ");
        Console.WriteLine($"Base Defence: {BaseDefence}");
        Console.WriteLine("");
        Console.WriteLine("Press Enter/Return to go back");
        Console.WriteLine("========================================");
        Console.ReadKey();
        Game.MainMenu();
    }

    public void ShowInventory()
    {
        // returns what items the Hero is Equipped with
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine($"{Name} Inventory:");
        Console.WriteLine("");
        Console.WriteLine("Equipped:");
        Console.WriteLine("Wooden Club");
        Console.WriteLine("No Armour");
        Console.WriteLine("");
        Console.WriteLine("Weapons:");
        Console.WriteLine("Wooden Club --------- Attack: 5");
        Console.WriteLine("Dagger -------------- Attack: 10");
        Console.WriteLine("Mace ---------------- Attack: 15");
        Console.WriteLine("Greatsword ---------- Attack: 20");
        Console.WriteLine("");
        Console.WriteLine("Armours:");
        Console.WriteLine("No Armour ---------- Defence: 1");
        Console.WriteLine("Leather Armour ------ Defence: 5");
        Console.WriteLine("Chainmail Armour----- Defence: 10");
        Console.WriteLine("Steel Armour -------- Defence: 15");
        Console.WriteLine("");
        Console.WriteLine("Change Weapon [1]"); 
        Console.WriteLine("Press Enter/Return to go back");
        Console.WriteLine("========================================");
        Console.ReadKey();
        Game.MainMenu();


    }
    public void EquipWeapon()
    {
        // Change the EquippedWeapon

    }
    public void EquipArmour()
    {
        //EquipArmour(Change the EquippedArmour
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
    public static List<Weapon> Weapons { get; set; } = new List<Weapon>();
    public static void AddWeapon(Weapon weapon)
    {
        Weapons.Add(weapon);
    }
}
static class ArmourList
{
    public static List<Armour> Armours { get; set; } = new List<Armour>();
    public static void AddArmour(Armour armour)
    {
        Armours.Add(armour);
    }
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
    private int _monstersDefeated = 0;
    
    public Hero Hero { get; set; } 
    public Monster Monster { get; set; }

    public Fight(Hero hero)
    {
        Hero = hero;
    }

    public void HeroTurn()
    {
        if (Monster.CurrentHealth <= 0)
        {
            Win();
        }
    }
  
    public void MonsterTurn()
    {
        if (Hero.CurrentHealth <= 0)
        {
            Lose();
        }
    }

    public void Win()
    {
        _monstersDefeated++;
        if (_monstersDefeated >= 5)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("");
            Console.WriteLine("Congratulations");
            Console.WriteLine("You Win");
            Console.WriteLine("");
            Console.WriteLine("========================================");
        }
    }

    public void Lose()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("");
        Console.WriteLine("You Died");
        Console.WriteLine("Game Over");
        Console.WriteLine("");
        Console.WriteLine("========================================");
    }
}


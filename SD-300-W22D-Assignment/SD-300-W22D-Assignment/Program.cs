﻿/*
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

    public int ReadInput()
    {
        string playerInput = Console.ReadLine();
        int inputCode;
        if (int.TryParse(playerInput, out inputCode))
        {
            inputCode = int.Parse(playerInput);
        }
        return inputCode;
    }

    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine($"What would you like to do {Hero.Name}?");
        Console.WriteLine();
        Console.WriteLine("[1] Display Statictics");
        Console.WriteLine("[2] Display Inventory");
        Console.WriteLine("[3] Fight");
        Console.WriteLine();
        Console.WriteLine("========================================");

        switch (ReadInput())
        {
            case 1:
                Hero.ShowStats();
                break;
            case 2:
                Hero.ShowInventory();
                break;
            case 3:
                Console.WriteLine("Incomplete");
                Console.ReadKey();
                MainMenu();
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
    public int WeaponEquppied { get; set; } = 5;
    public int ArmourEquppied { get; set; } = 1;

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
        Console.WriteLine("Games Played: 0");
        Console.WriteLine("Fights Won: 0");
        Console.WriteLine("Fights Lost: 0");
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
        switch (WeaponEquppied)
        {
            case 5:
                Console.WriteLine("Wooden Club");
                break;
            case 10:
                Console.WriteLine("Dagger");
                break;
            case 15:
                Console.WriteLine("Mace");
                break;
            case 20:
                Console.WriteLine("Greatsword");
                break;
            default:
                // should never occur
                Console.WriteLine("Invalid Weapon Equipped, please change current Weapon");
                break;
        }
        switch (ArmourEquppied)
        {
            case 1:
                Console.WriteLine("No Armour");
                break;
            case 5:
                Console.WriteLine("Leather Armour");
                break;
            case 10:
                Console.WriteLine("Chainmail Armour");
                break;
            case 15:
                Console.WriteLine("Steel Armour");
                break;
            default:
                // should never occur
                Console.WriteLine("Invalid Armour Equipped, please change current Armour");
                break;
        }
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
        Console.WriteLine("[1] Change Weapon ");
        Console.WriteLine("[2] Change Armour");
        Console.WriteLine("Press Enter/Return to go back");
        Console.WriteLine("========================================");
        switch (Game.ReadInput())
        {
            case 1:
                EquipWeapon();
                break;
            case 2:
                EquipArmour();
                break;
            default:
                Game.MainMenu();
                break;
        }
    }
    public void EquipWeapon()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine($"Which Weapon would you like to equip?");
        Console.WriteLine("");
        Console.WriteLine("Weapons:");
        Console.WriteLine("[1] Wooden Club --------- Attack: 5");
        Console.WriteLine("[2] Dagger -------------- Attack: 10");
        Console.WriteLine("[3] Mace ---------------- Attack: 15");
        Console.WriteLine("[4] Greatsword ---------- Attack: 20");
        Console.WriteLine("[5] Cancel");
        Console.WriteLine("");
        Console.WriteLine("========================================");
        switch (Game.ReadInput())
        {
            case 1:
                Console.WriteLine("Equipped: Wooden Club");
                WeaponEquppied = 5;
                Console.ReadKey();
                ShowInventory();
                break;
            case 2:
                Console.WriteLine("Equipped: Dagger");
                WeaponEquppied = 10;
                Console.ReadKey();
                ShowInventory();
                break;
            case 3:
                Console.WriteLine("Equipped: Mace");
                Console.ReadKey();
                WeaponEquppied = 15;
                ShowInventory();
                break;
            case 4:
                Console.WriteLine("Equipped: Greatsword");
                Console.ReadKey();
                WeaponEquppied = 20;
                ShowInventory();
                break;
            case 5:
                ShowInventory();
                break;
            default:
                EquipWeapon();
                break;
        }
    }
    public void EquipArmour()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine($"Which Armour would you like to equip?");
        Console.WriteLine("");
        Console.WriteLine("Weapons:");
        Console.WriteLine("[1] No Armour------------ Defence: 1");
        Console.WriteLine("[2] Leather Armour ------ Defence: 5");
        Console.WriteLine("[3] Chainmail Armour----- Defence: 10");
        Console.WriteLine("[4] Steel Armour -------- Defence: 15");
        Console.WriteLine("[5] Cancel");
        Console.WriteLine("");
        Console.WriteLine("========================================");
        switch (Game.ReadInput())
        {
            case 1:
                Console.WriteLine("Equipped: No Armour");
                ArmourEquppied = 1;
                Console.ReadKey();
                ShowInventory();
                break;
            case 2:
                Console.WriteLine("Equipped: Leather Armour");
                ArmourEquppied = 5;
                Console.ReadKey();
                ShowInventory();
                break;
            case 3:
                Console.WriteLine("Equipped: Chainmail Armour");
                ArmourEquppied = 10;
                Console.ReadKey();
                ShowInventory();
                break;
            case 4:
                Console.WriteLine("Equipped: Steel Armour");
                ArmourEquppied = 15;
                Console.ReadKey();
                ShowInventory();
                break;
            case 5:
                ShowInventory();
                break;
            default:
                Console.WriteLine("Invalid input, please try again: ");
                Console.ReadKey();
                EquipArmour();
                break;
        }
    }

    public void CheckEquppied(Weapon weapon)
    {

    }
    public void CheckEquppied(Armour armour)
    {

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
    
    public Hero Player { get; set; } 
    public Monster Monster { get; set; }

    public Fight(Hero hero)
    {
        Player = hero;
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
        if (Player.CurrentHealth <= 0)
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


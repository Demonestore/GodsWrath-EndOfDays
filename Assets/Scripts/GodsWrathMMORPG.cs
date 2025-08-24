using System.Collections.Generic;
using UnityEngine;

public class GodsWrathGame : MonoBehaviour
{
    private List<Player> players = new List<Player>();
    private Enemy dragonBoss;

    void Start()
    {
        Debug.Log("⚡ Welcome to God's Wrath: End of Days ⚡");

        // Create some players
        players.Add(new Warrior("Gideon"));
        players.Add(new Mage("Ezra the Prophet"));
        players.Add(new Archer("Miriam"));

        // Create a boss
        dragonBoss = new Enemy("Apocalyptic Dragon", 500, 50);

        Debug.Log("🔥 The final battle begins! 🔥");
        Battle();
    }

    void Battle()
    {
        foreach (var player in players)
        {
            Debug.Log($"{player.Name} engages in battle against {dragonBoss.Name}!");

            // Each player takes a turn attacking
            player.Attack(dragonBoss);

            // Boss attacks back
            if (dragonBoss.Health > 0)
            {
                dragonBoss.Attack(player);
            }
        }

        if (dragonBoss.Health <= 0)
        {
            Debug.Log("🌟 Victory! The forces of light have defeated the dragon!");
        }
        else
        {
            Debug.Log("💀 The dragon still stands... the war continues!");
        }
    }
}

// =============================
// Base Player Class
// =============================
public abstract class Player
{
    public string Name { get; private set; }
    public int Health { get; protected set; }
    public int AttackPower { get; protected set; }

    public Player(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }

    public virtual void Attack(Enemy enemy)
    {
        Debug.Log($"{Name} attacks {enemy.Name} for {AttackPower} damage!");
        enemy.TakeDamage(AttackPower);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{Name} takes {damage} damage! Remaining health: {Health}");

        if (Health <= 0)
        {
            Debug.Log($"{Name} has fallen in battle!");
        }
    }
}

// =============================
// Warrior Class
// =============================
public class Warrior : Player
{
    public Warrior(string name) : base(name, 150, 25) { }

    public override void Attack(Enemy enemy)
    {
        Debug.Log($"{Name} swings a mighty sword at {enemy.Name}!");
        base.Attack(enemy);
    }
}

// =============================
// Mage Class
// =============================
public class Mage : Player
{
    public Mage(string name) : base(name, 100, 40) { }

    public override void Attack(Enemy enemy)
    {
        Debug.Log($"{Name} casts a holy fire spell on {enemy.Name}!");
        base.Attack(enemy);
    }
}

// =============================
// Archer Class
// =============================
public class Archer : Player
{
    public Archer(string name) : base(name, 120, 30) { }

    public override void Attack(Enemy enemy)
    {
        Debug.Log($"{Name} shoots a flaming arrow at {enemy.Name}!");
        base.Attack(enemy);
    }
}

// =============================
// Enemy (Boss)
// =============================
public class Enemy
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int AttackPower { get; private set; }

    public Enemy(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{Name} takes {damage} damage! Remaining health: {Health}");

        if (Health <= 0)
        {
            Debug.Log($"{Name} has been defeated!");
        }
    }

    public void Attack(Player player)
    {
        Debug.Log($"{Name} unleashes a devastating strike on {player.Name}!");
        player.TakeDamage(AttackPower);
    }
}

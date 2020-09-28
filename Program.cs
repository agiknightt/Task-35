using System;
using System.Collections.Generic;

namespace Task_35
{
    class Program
    {
        static void Main(string[] args)
        {
            Troop troopOne = new Troop();
            Troop troopTwo = new Troop();

            Console.Write("Сколько бойцов в первом взводе ? :");
            int countTroopOne = Convert.ToInt32(Console.ReadLine());
            troopOne.AddTroop(countTroopOne);

            Console.Write("Сколько бойцов во втором взводе ? :");
            int countTroopTwo = Convert.ToInt32(Console.ReadLine());
            troopTwo.AddTroop(countTroopTwo);

            while (troopOne.RemainedFighters() && troopTwo.RemainedFighters())
            {
                Fighter fighterOne = troopOne.FightingFighter();
                Fighter fighterTwo = troopTwo.FightingFighter();

                fighterOne.GetSkill();
                fighterTwo.GetSkill();

                fighterOne.TakeDamage(fighterTwo.Damage);
                fighterTwo.TakeDamage(fighterOne.Damage);

                if (fighterOne.Health <= 0)
                {
                    troopOne.DeleteFighter();
                }
                else if(fighterTwo.Health <= 0)
                {
                    troopTwo.DeleteFighter();
                }
            }
            if(troopOne.RemainedFighters() == false)
            {
                Console.WriteLine($"\nПобедил второй отряд");
            }
            else
            {
                Console.WriteLine($"\nПобедил первый отряд");
            }
        }
    }
    class Troop
    {
        private List<Fighter> _troop = new List<Fighter>();        
        public void AddTroop(int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                switch (rand.Next(1, 5))
                {
                    case 1:
                        _troop.Add(new Warrior(1000, 50, 15));
                        break;
                    case 2:
                        _troop.Add(new Barbarian(2000, 25, 0));
                        break;
                    case 3:
                        _troop.Add(new Berserker(1300, 30, 20));
                        break;
                    case 4:
                        _troop.Add(new Rogue(500, 50, 10));
                        break;
                    case 5:
                        _troop.Add(new Knight(800, 90, 20));
                        break;
                }
            }
        }
        public bool RemainedFighters()
        {
            if(_troop.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DeleteFighter()
        {
            _troop.RemoveAt(0);
        }
        public Fighter FightingFighter()
        {
            return _troop[0];
        }
    }    
    abstract class Fighter 
    {
        public int Health;
        public int Damage;
        public int Armor;       
        
        public Fighter(int health, int damage, int armor)
        {
            Health = damage;
            Damage = health;
            Armor = armor;
        }
        public void ShowStats(int countFighters)
        {
            Console.WriteLine($"Жизней {Health}, Урон {Damage}, Защиты {Armor}.\nОсталось бойцов {countFighters}");
        }

        public abstract void GetSkill();    
        
        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }        
    }    
    class Warrior : Fighter
    {
        public Warrior(int health, int damage, int armor) : base(health, damage, armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
        public override void GetSkill()
        {
            Health += Damage;
        }
    }
    class Barbarian : Fighter
    {
        public Barbarian(int health, int damage, int armor) : base(health, damage, armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
        public override void GetSkill()
        {
            Damage += 10;
        }
    }
    class Knight : Fighter
    {
        public Knight(int health, int damage, int armor) : base(health, damage, armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
        public override void GetSkill()
        {
            Armor += 3;
        }
    }
    class Rogue : Fighter
    {
        public Rogue(int health, int damage, int armor) : base(health, damage, armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
        public override void GetSkill()
        {
            Health += Damage;
        }
    }
    class Berserker : Fighter
    {
        private int _step = 0;
        public Berserker(int health, int damage, int armor) : base(health, damage, armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
        public override void GetSkill()
        {
            _step += 1;

            if (_step % 2 == 0)
            {
                Damage += 100;
            }
            if (_step % 3 == 0)
            {
                Damage -= 100;
            }
        }
    }
} 

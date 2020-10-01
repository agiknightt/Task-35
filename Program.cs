using System;
using System.Collections.Generic;

namespace Task_35
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Сколько бойцов в первом взводе ? :");
            int countTroopOne = Convert.ToInt32(Console.ReadLine());
            Troop troopOne = new Troop(countTroopOne);

            Console.Write("Сколько бойцов во втором взводе ? :");
            int countTroopTwo = Convert.ToInt32(Console.ReadLine());
            Troop troopTwo = new Troop(countTroopTwo);

            while (troopOne.RemainedFighters() && troopTwo.RemainedFighters())
            {
                Fighter fighterOne = troopOne.ReturnFirstFighter();
                Fighter fighterTwo = troopTwo.ReturnFirstFighter();

                fighterOne.UseSkill();
                fighterTwo.UseSkill();

                fighterOne.TakeDamage(fighterTwo.DamageFighter);
                fighterTwo.TakeDamage(fighterOne.DamageFighter);

                if (fighterOne.HealthFighter <= 0)
                {
                    troopOne.DeleteFirstFighter();
                }
                else if(fighterTwo.HealthFighter <= 0)
                {
                    troopTwo.DeleteFirstFighter();
                }
                fighterOne.ShowStats();
                fighterTwo.ShowStats();
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
        public Troop(int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                switch (rand.Next(1, 5))
                {
                    case 1:
                        _troop.Add(new Warrior());
                        break;
                    case 2:
                        _troop.Add(new Barbarian());
                        break;
                    case 3:
                        _troop.Add(new Berserker());
                        break;
                    case 4:
                        _troop.Add(new Rogue());
                        break;
                    case 5:
                        _troop.Add(new Knight());
                        break;
                }
            }
        }
        public bool RemainedFighters()
        {
            return _troop.Count > 0;            
        }
        public void DeleteFirstFighter()
        {
            _troop.RemoveAt(0);
        }
        public Fighter ReturnFirstFighter()
        {
            return _troop[0];
        }
    }    
    abstract class Fighter
    {
        protected int Health;
        protected int Damage;
        protected int Armor;
        public int HealthFighter
        {
            get
            {
                return Health;
            }
        }
        public int DamageFighter
        {
            get
            {
                return Damage;
            }
        }
        public Fighter(int health, int damage, int armor)
        {
            Health = damage;
            Damage = health;
            Armor = armor;
        }
        public void ShowStats()
        {
            Console.WriteLine($"Жизней {Health}, Урон {Damage}, Защиты {Armor}.");
        }

        public abstract void UseSkill();    
        
        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }        
    }    
    class Warrior : Fighter
    {
        public Warrior(int health = 1000, int damage = 50, int armor = 15) : base(health, damage, armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
        public override void UseSkill()
        {
            Health += 15;
        }
    }
    class Barbarian : Fighter
    {
        public Barbarian(int health = 2000, int damage = 25, int armor = 0) : base(health, damage, armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
        public override void UseSkill()
        {
            Damage += 10;
        }
    }
    class Knight : Fighter
    {
        public Knight(int health = 1300, int damage = 30, int armor = 20) : base(health, damage, armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
        public override void UseSkill()
        {
            Armor += 3;
        }
    }
    class Rogue : Fighter
    {
        public Rogue(int health = 500, int damage = 50, int armor = 10) : base(health, damage, armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
        public override void UseSkill()
        {
            Health += Damage;
        }
    }
    class Berserker : Fighter
    {
        private int _step = 0;
        public Berserker(int health = 800, int damage = 90, int armor = 20) : base(health, damage, armor)
        {
            Health = health;
            Damage = damage;
            Armor = armor;
        }
        public override void UseSkill()
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

using System;
using System.Collections.Generic;

namespace Task_35
{
    class Program
    {
        static void Main(string[] args)
        {
            Troop troop = new Troop();

            Console.Write("Сколько бойцов в первом взводе ? :");
            int countTroopOne = Convert.ToInt32(Console.ReadLine());
            troop.AddTroopOne(countTroopOne);

            Console.Write("Сколько бойцов во втором взводе ? :");
            int countTroopTwo = Convert.ToInt32(Console.ReadLine());
            troop.AddTroopTwo(countTroopTwo);

            while (troop.TroopOne.Count > 0 && troop.TroopTwo.Count > 0 )
            {
                Fighter fighterOne = troop.TroopOne[0];
                Fighter fighterTwo = troop.TroopTwo[0];

                Console.WriteLine();
                fighterOne.GetSkill();
                fighterTwo.GetSkill();

                fighterOne.TakeDamage(fighterTwo.Damage);
                fighterTwo.TakeDamage(fighterOne.Damage);

                if (fighterOne.Health <= 0)
                {
                    troop.TroopOne.RemoveAt(0);
                }
                else if(fighterTwo.Health <= 0)
                {
                    troop.TroopTwo.RemoveAt(0);
                }

                fighterOne.ShowStats(troop.TroopOne.Count);
                fighterTwo.ShowStats(troop.TroopTwo.Count);
            }
            if(troop.TroopOne.Count == 0)
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
        protected List<Fighter> _troopOne = new List<Fighter>();
        protected List<Fighter> _troopTwo = new List<Fighter>();
        public List<Fighter> TroopOne
        {
            get
            {
                return _troopOne;
            }
            private set
            {

            }
        }
        public List<Fighter> TroopTwo
        {
            get
            {
                return _troopTwo;
            }
            private set
            {

            }
        }
        public void AddTroopOne(int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                switch (rand.Next(1, 5))
                {
                    case 1:
                        _troopOne.Add(new Warrior(1000, 50, 15));
                        break;
                    case 2:
                        _troopOne.Add(new Barbarian(2000, 25, 0));
                        break;
                    case 3:
                        _troopOne.Add(new Berserker(1300, 30, 20));
                        break;
                    case 4:
                        _troopOne.Add(new Rogue(500, 50, 10));
                        break;
                    case 5:
                        _troopOne.Add(new Knight(800, 90, 20));
                        break;
                }
            }
        }
        public void AddTroopTwo(int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                switch (rand.Next(1, 5))
                {
                    case 1:
                        _troopTwo.Add(new Warrior(1000, 50, 15));
                        break;
                    case 2:
                        _troopTwo.Add(new Barbarian(2000, 35, 0));
                        break;
                    case 3:
                        _troopTwo.Add(new Berserker(1300, 40, 20));
                        break;
                    case 4:
                        _troopTwo.Add(new Rogue(500, 150, 10));
                        break;
                    case 5:
                        _troopTwo.Add(new Knight(800, 90, 20));
                        break;
                }
            }
        }
    }    
    abstract class Fighter : Troop
    {
        protected int _health;
        protected int _damage;
        protected int _armor;
        public int Health
        {
            get
            {
                return _health;
            }
            private set
            {

            }
        }
        public int Damage
        {
            get
            {
                return _damage;
            }
            private set
            {

            }
        }
        public Fighter(int health = 0, int damage = 0, int armor = 0)
        {
            _damage = damage;
            _health = health;
            _armor = armor;
        }
        public void ShowStats(int countFighters)
        {
            Console.WriteLine($"Жизней {_health}, Урон {_damage}, Защиты {_armor}.\nОсталось бойцов {countFighters}");
        }

        public abstract void GetSkill();    
        
        public void TakeDamage(int damage)
        {
            _health -= damage - _armor;
        }        
    }    
    class Warrior : Fighter
    {
        public Warrior(int health, int damage, int armor) : base(health, damage, armor)
        {
            _health = health;
            _damage = damage;
            _armor = armor;
        }
        public override void GetSkill()
        {
            _health += _damage;
        }
    }
    class Barbarian : Fighter
    {
        public Barbarian(int health, int damage, int armor) : base(health, damage, armor)
        {
            _health = health;
            _damage = damage;
            _armor = armor;
        }
        public override void GetSkill()
        {
            _damage += 10;
        }
    }
    class Knight : Fighter
    {
        public Knight(int health, int damage, int armor) : base(health, damage, armor)
        {
            _health = health;
            _damage = damage;
            _armor = armor;
        }
        public override void GetSkill()
        {
            _armor += 3;
        }
    }
    class Rogue : Fighter
    {
        public Rogue(int health, int damage, int armor) : base(health, damage, armor)
        {
            _health = health;
            _damage = damage;
            _armor = armor;
        }
        public override void GetSkill()
        {
            _health += _damage;
        }
    }
    class Berserker : Fighter
    {
        private int _step = 0;
        public Berserker(int health, int damage, int armor) : base(health, damage, armor)
        {
            _health = health;
            _damage = damage;
            _armor = armor;
        }
        public override void GetSkill()
        {
            _step += 1;

            if (_step % 2 == 0)
            {
                _damage += 100;
            }
            if (_step % 3 == 0)
            {
                _damage -= 100;
            }
        }
    }
} 

class Game
{
    private Character _human;
    private Character _zombie;

    public Game(IFactory humanFactory, IFactory zombieFactory)
    {
        _human = new Character("Человек", humanFactory.CreateHandWeapon(), humanFactory.CreateFootWeapon());
        _zombie = new Character("Зомби", zombieFactory.CreateHandWeapon(), zombieFactory.CreateFootWeapon());
    }

    public void Start()
    {
        Console.WriteLine("Игра начинается! Люди против Зомби.\n");

        while (_human.IsAlive() && _zombie.IsAlive())
        {
            PlayerTurn(_human, _zombie);
            if (!_zombie.IsAlive())
                break;

            PlayerTurn(_zombie, _human);
        }

        if (_human.IsAlive())
            Console.WriteLine("Человек выиграл!");
        else
            Console.WriteLine("Зомби выиграли!");
    }

    private void PlayerTurn(Character attacker, Character defender)
    {
        Console.WriteLine($"{attacker.Name} ходит!");

        bool attackWithHand;
        AttackTarget attackTarget;
        DefenseTarget defenseTarget;

        if (attacker.Name == "Человек") // ход игрока (человека)
        {
            attackWithHand = ChooseWeapon();
            attackTarget = ChooseAttackTarget();
            defenseTarget = ChooseDefenseTarget();
        }
        else // ход зомби - простой AI (рандом)
        {
            var rand = new Random();
            attackWithHand = rand.Next(2) == 0;
            attackTarget = (AttackTarget)rand.Next(3);
            defenseTarget = (DefenseTarget)rand.Next(3);
            Console.WriteLine($"Зомби выбирает атака: {(attackWithHand ? "рука" : "нога")}, цель атаки: {attackTarget}, защита: {defenseTarget}");
        }

        attacker.Fight(defender, attackWithHand, attackTarget, defenseTarget);
    }

    private bool ChooseWeapon()
    {
        while (true)
        {
            Console.Write("Выберите оружие для атаки (1 - рука, 2 - нога): ");
            string input = Console.ReadLine();
            if (input == "1") return true;
            if (input == "2") return false;

            Console.WriteLine("Некорректный ввод, попробуйте снова.");
        }
    }

    private AttackTarget ChooseAttackTarget()
    {
        while (true)
        {
            Console.Write("Куда атаковать? (1 - лицо, 2 - тело, 3 - ноги): ");
            string input = Console.ReadLine();
            if (input == "1") return AttackTarget.Face;
            if (input == "2") return AttackTarget.Body;
            if (input == "3") return AttackTarget.Legs;

            Console.WriteLine("Некорректный ввод, попробуйте снова.");
        }
    }

    private DefenseTarget ChooseDefenseTarget()
    {
        while (true)
        {
            Console.Write("Что защищать? (1 - лицо, 2 - тело, 3 - ноги): ");
            string input = Console.ReadLine();
            if (input == "1") return DefenseTarget.Face;
            if (input == "2") return DefenseTarget.Body;
            if (input == "3") return DefenseTarget.Legs;

            Console.WriteLine("Некорректный ввод, попробуйте снова.");
        }
    }
}

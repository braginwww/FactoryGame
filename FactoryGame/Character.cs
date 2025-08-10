class Character
{
    public string Name { get; }
    public int Life { get; private set; }
    public int DefenseFace { get; private set; }
    public int DefenseBody { get; private set; }
    public int DefenseLegs { get; private set; }

    private IWeapon _handWeapon;
    private IWeapon _footWeapon;

    public Character(string name, IWeapon handWeapon, IWeapon footWeapon)
    {
        Name = name;
        Life = 100; // начальная жизнь
        DefenseFace = 5;
        DefenseBody = 10;
        DefenseLegs = 7;

        _handWeapon = handWeapon;
        _footWeapon = footWeapon;
    }

    // Метод атаки 
    // attackWithHand: true - рука, false - нога
    // target - куда бьём
    // defense - что защищаем
    public void Fight(Character opponent, bool attackWithHand, AttackTarget attackTarget, DefenseTarget defenseTarget)
    {
        IWeapon weapon = attackWithHand ? _handWeapon : _footWeapon;
        weapon.Attack();

        // Рассчитаем урон
        int defenseValue = defenseTarget switch
        {
            DefenseTarget.Face => opponent.DefenseFace,
            DefenseTarget.Body => opponent.DefenseBody,
            DefenseTarget.Legs => opponent.DefenseLegs,
            _ => 0
        };

        int damage = weapon.AttackPower - defenseValue;
        if (damage < 0)
            damage = 0;

        opponent.Life -= damage;
        if (opponent.Life < 0)
            opponent.Life = 0;

        Console.WriteLine($"{Name} атакует {opponent.Name} в {attackTarget}, защищая {defenseTarget}. Нанесённый урон: {damage}.");
        Console.WriteLine($"{opponent.Name} осталось жизни: {opponent.Life}.");
        Console.WriteLine();
    }

    public bool IsAlive()
    {
        return Life > 0;
    }
}

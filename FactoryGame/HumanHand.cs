class HumanHand : IWeapon
{
    public int AttackPower => 10;
    public WeaponType WeaponType => WeaponType.Hand;
    public void Attack()
    {
        Console.WriteLine("Человек бьет рукой!");
    }
}
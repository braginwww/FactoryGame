class HumanFoot : IWeapon
{
    public int AttackPower => 15;
    public WeaponType WeaponType => WeaponType.Foot;
    public void Attack()
    {
        Console.WriteLine("Человек бьет ногой!");
    }
}

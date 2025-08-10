class ZombieFoot : IWeapon
{
    public int AttackPower => 18;
    public WeaponType WeaponType => WeaponType.Foot;
    public void Attack()
    {
        Console.WriteLine("Зомби пинает ногой!");
    }
}

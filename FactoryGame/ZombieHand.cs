class ZombieHand : IWeapon
{
    public int AttackPower => 12;
    public WeaponType WeaponType => WeaponType.Hand;
    public void Attack()
    {
        Console.WriteLine("Зомби бьет когтями (рукой)!");
    }
}

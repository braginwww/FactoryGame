class ZombieFactory : IFactory
{
    public IWeapon CreateHandWeapon() => new ZombieHand();
    public IWeapon CreateFootWeapon() => new ZombieFoot();
}

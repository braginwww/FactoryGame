class HumanFactory : IFactory
{
    public IWeapon CreateHandWeapon() => new HumanHand();
    public IWeapon CreateFootWeapon() => new HumanFoot();
}

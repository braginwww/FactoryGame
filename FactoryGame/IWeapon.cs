using System;

// Абстрактные типы для атаки и защиты
public enum AttackTarget
{
    Face,
    Body,
    Legs
}

public enum DefenseTarget
{
    Face,
    Body,
    Legs
}

public enum WeaponType
{
    Hand,
    Foot
}

// Интерфейс оружия
interface IWeapon
{
    int AttackPower { get; }
    WeaponType WeaponType { get; }
    void Attack();
}
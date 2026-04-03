using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponHolder : IComponentHolder
{
    bool IsAttacking { get; }

    bool CanShoot { get; }

    IWeaponElement SelectedWeapon { get; set; }
}

public interface IWeaponElement : IComponentHolder
{
    
}

public interface IAbility
{

}

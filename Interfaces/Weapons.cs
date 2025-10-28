using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponHolder
{
    bool IsAttacking { get; }

    IWeaponElement SelectedWeapon { get; set; }
}

public interface IWeaponElement
{
    
}

public interface IAbility
{

}

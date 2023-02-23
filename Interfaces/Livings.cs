using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILivingActor
{

}

public interface ILivingDeathHandler
{
    void OnDeath(GameObject weapon, GameObject offender);
}

public interface ILivingDamageHandler
{ 
    void OnDamage(ILivingImpact livingImpact, GameObject offender);
}

public interface ILivingImpact
{
    int HpDiff { get; }
}
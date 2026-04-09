using UnityEngine;

public interface ILivingActor : IComponentHolder
{
    bool IsAlive { get; }
}

public struct LivingImpact
{
    /// <summary>
    /// below zero - to deal damage, above zero - to heal
    /// </summary>
    public int hpDiff;
    /// <summary>
    /// Damage type (used for vulnerability calc, for example)
    /// </summary>
    public string impact;
    /// <summary>
    /// armed ammo in offender weapon
    /// </summary>
    public IItemElement ammo;
    public IWeaponHolder offender;

    public bool checkOnly;
    /// <summary>
    /// Ignore any damage processors (absorbers, like armor)
    /// </summary>
    public bool ignoreProcessors;

    public LivingImpact(int _hpDiff, IWeaponHolder _offender = null, string impactType = null)
    {
        ignoreProcessors = false;
        hpDiff = _hpDiff;
        impact = impactType;
        ammo = null;
        offender = _offender;
        checkOnly = false;
    }
}

public interface ILivingDeathHandler
{
    void OnDeath(LivingImpact livingImpact);
}

public interface ILivingDamageHandler
{
    void OnDamage(LivingImpact livingImpact);
}

/// <summary>
/// For items/equipment that absorbs damage (like armor)
/// </summary>
public interface ILivingDamageProcessor
{
    void OnDamageProcessor(LivingImpact damage);

    int Amount { get; }
}

public interface INonDestructableOnDeath
{

}

public interface ICountHolder
{
    int Count { get; }
}


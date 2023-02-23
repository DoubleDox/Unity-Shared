using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ParamModifierBase<T>
{
    protected Dictionary<Object, T> modifiers = new Dictionary<Object, T>();

    protected T _value;

    public T Value
    {
        get { return _value; }
    }

    public void AddModifier(Object script, T modifier)
    {
        if (!modifiers.ContainsKey(script))
            modifiers.Add(script, modifier);
        recalc();
    }

    public void RemoveModifier(Object script)
    {
        if (modifiers.ContainsKey(script))
            modifiers.Remove(script);
        recalc();
    }

    protected abstract void recalc();
}

public class MultParamModifier : ParamModifierBase<float>
{
    public MultParamModifier()
    {
        _value = 1.0f;
    }

    protected override void recalc()
    {
        _value = 1.0f;
        foreach (var kvp in modifiers)
            _value *= kvp.Value;
    }
}

public class SumParamModifier : ParamModifierBase<int>
{
    protected override void recalc()
    {
        _value = 0;
        foreach (var kvp in modifiers)
            _value += kvp.Value;
    }
}

public class OrParamModifier : ParamModifierBase<bool>
{
    protected override void recalc()
    {
        _value = false;
        foreach (var kvp in modifiers)
            _value |= kvp.Value;
    }
}

public class MaxParamModifier : ParamModifierBase<int>
{
    protected override void recalc()
    {
        _value = 0;
        foreach (var kvp in modifiers)
            _value = Mathf.Max(kvp.Value, _value);
    }
}

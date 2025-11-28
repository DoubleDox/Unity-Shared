using System.Collections;
using UnityEngine;

public abstract class VisualEffectSetup : ScriptableObject
{
    public abstract void Execute(GameObject initiator, VisualEffectContext context = null);
}

// for future implementations
public class VisualEffectContext
{

}
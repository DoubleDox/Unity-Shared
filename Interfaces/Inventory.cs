using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryHolder
{
    public IReadOnlyList<IItemElement> Items { get; }

    public T GetComponent<T>();
}

public interface IItemElement : IComponentHolder
{
    public int Count { get; }
}

public interface IEffectElement
{

}

// events raised ON ACTOR with item reference
public interface IInventoryHolderHandler
{
    void OnItemHolderEvent(IItemElement item, InventoryHolderEvent eventType);
}

public enum InventoryHolderEvent
{
    None,
    Add,
    Remove,
    SlotUpdate
}

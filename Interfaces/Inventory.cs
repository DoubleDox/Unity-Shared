using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryHolder
{
	List<IItemElement> Items { get; }
}

public interface IItemElement
{

}
using System.Collections.Generic;
using UnityEngine;

public interface IVisibleActor
{
	bool IsVisible { get; set; }
}

public interface IObserverActor
{
    public List<GameObject> VisibleEnemies { get; }
}

public interface IObserverGroup
{

}

public interface IVisibilityHandler
{
    void OnVisibilityChange();
}


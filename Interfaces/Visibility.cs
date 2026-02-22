public interface IVisibleActor
{
	bool IsVisible { get; set; }
}

public interface IObserverActor
{

}

public interface IObserverGroup
{

}

public interface IVisibilityHandler
{
    void OnVisibilityChange();
}


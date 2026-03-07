using UnityEngine;

public interface IModelHolder
{
    public GameObject View { get; }

    public Animator Animator { get; }
}


public interface IModelCreateHandler
{
    void OnModelCreated(GameObject view);
}
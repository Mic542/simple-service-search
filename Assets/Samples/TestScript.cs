using SimpleServiceSearch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Awake()
    {
        // This will register this instance as TestScript Singleton Instance
        ServiceLocator.RegisterSingleton<TestScript>(this);

        // This will register TestScript as Singleton without instance
        // Instance will be created automatically
        // Subsequent locate will return same object
        // ServiceLocator.RegisterSingleton<TestScript>();

        // This will register TestScript as Factory type
        // Instance will be created everytime it is located
        // ServiceLocator.Register<TestScript>();
    }

    public void Hello()
    {
        Debug.Log("Hello!");
    }
}

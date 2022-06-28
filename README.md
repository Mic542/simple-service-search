# Simple Service Search
Simple Service Search or simply SSS is a super simple Service Locator for Unity

# How to use
First, import the .unitypackage

Register the Services :

```
// This will register this instance as TestScript Singleton Instance
ServiceLocator.RegisterSingleton<TestScript>(this);

// This will register TestScript as Singleton without instance
// Instance will be created automatically
// Subsequent locate will return same object
ServiceLocator.RegisterSingleton<TestScript>();

// This will register TestScript as Factory type
// Instance will be created everytime it is located
ServiceLocator.Register<TestScript>();
```

Retrieve the Service :
```
public class TestScriptGet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var testHello = ServiceLocator.Locate<TestScript>();
        testHello.Hello();

        Debug.Log(testHello.gameObject.GetInstanceID());

    }
}
    
```


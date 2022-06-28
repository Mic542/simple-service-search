using SimpleServiceSearch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptGet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var testHello = ServiceLocator.Locate<TestScript>();
        testHello.Hello();

        var testHello2 = ServiceLocator.Locate<TestScript>();
        testHello2.Hello();

        Debug.Log(testHello.gameObject.GetInstanceID());
        Debug.Log(testHello2.gameObject.GetInstanceID());

    }
}

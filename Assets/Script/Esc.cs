using UnityEngine;
using System.Collections;

public class Esc : MonoBehaviour {

    public void __Esc()
    {
        Application.Quit();
    }
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            __Esc();
        }
    }
}

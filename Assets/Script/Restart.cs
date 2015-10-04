using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    public void LevelRestart()
    {
        Application.LoadLevel("Scene1");
    }
}

using UnityEngine;
using System.Collections;

public class PlayLight : MonoBehaviour {

    public void Play()
    {
        PlayerPrefs.SetString("PlayMod", "Light");
        Application.LoadLevel("Scene1");
    }
}

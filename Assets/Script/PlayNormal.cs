using UnityEngine;
using System.Collections;

public class PlayNormal : MonoBehaviour
{

    public void Play()
    {
        PlayerPrefs.SetString("PlayMod", "Normal");
        Application.LoadLevel("Scene1");
    }
}

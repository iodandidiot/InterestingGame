using UnityEngine;
using System.Collections;

public class PlayHard : MonoBehaviour
{

    public void Play()
    {
        PlayerPrefs.SetString("PlayMod", "Hard");
        Application.LoadLevel("Scene1");
    }
}
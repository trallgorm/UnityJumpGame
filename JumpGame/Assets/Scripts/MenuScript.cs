using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {
    public void OnStartGame()
    {
        Application.LoadLevel("JumpScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

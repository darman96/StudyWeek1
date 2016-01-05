using UnityEngine;
using System.Collections;

public class ButtonCommands : MonoBehaviour {

    public void Exit() {
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void Save() {
        PlayerPrefs.Save();
    }
}

using UnityEngine;
using System.Collections;

public class ButtonCommands : MonoBehaviour {

    public GameObject m_MainScreen;
    public GameObject m_OptionsScreen;
    public GameObject m_BindingsScreen;

    void Update() {
        //Escape-Button is used
        if(Input.GetKeyDown(KeyCode.Escape) && (m_MainScreen.activeInHierarchy)) {
            Exit();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && (m_OptionsScreen.activeInHierarchy)) {
            ToMainScreen();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && (m_BindingsScreen.activeInHierarchy)) {
            ToOptionsScreen();
        }
    }

    //For the exit-button (in the login-screen)
    public void Exit() {
        print("Closed");                            ////////////REMOVE
        Application.Quit();
    }

    public void ToMainScreen() {
        m_OptionsScreen.active = false;
        m_MainScreen.active = true;
    }

    public void ToOptionsScreen() {
        m_BindingsScreen.active = false;
        m_OptionsScreen.active = true;
    }
}

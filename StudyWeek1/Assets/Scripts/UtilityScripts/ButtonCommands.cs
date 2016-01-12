using UnityEngine;
using System.Collections;

public class ButtonCommands : MonoBehaviour {

    public GameObject m_MainScreen;
    public GameObject m_OptionsScreen;
    public GameObject m_BindingsScreen;
    public GameObject m_ExtrasScreen;
    public GameObject m_CreditsScreen;

    void Update() {
        //Escape-Button is used
        if(Input.GetKeyDown(KeyCode.Escape) && (m_MainScreen.activeInHierarchy)) {
            Exit();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && (m_OptionsScreen.activeInHierarchy)) {
            ToMainScreenFromOptions();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && (m_BindingsScreen.activeInHierarchy)) {
            ToOptionsScreenFromBinding();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && (m_ExtrasScreen.activeInHierarchy)) {
            ToMainScreenFromExtras();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && (m_CreditsScreen.activeInHierarchy)) {
            ToExtrasScreenFromCredits();
        }
    }

    //For the exit-button (in the login-screen)
    public void Exit() {
        print("Closed");                            ////////////REMOVE
        Application.Quit();
    }

    //Login <-> Options
    public void ToMainScreenFromOptions() {
        m_OptionsScreen.active = false;
        m_MainScreen.active = true;
    }

    public void ToMainScreenFromExtras() {
        m_ExtrasScreen.active = false;
        m_MainScreen.active = true;
    }

    //Options <-> Bindings
    public void ToOptionsScreenFromBinding() {
        m_BindingsScreen.active = false;
        m_OptionsScreen.active = true;
    }

    public void ToBindingsScreen() {
        m_OptionsScreen.active = false;
        m_BindingsScreen.active = true;
    }

    //Extras <-> Credits
    public void ToCreditsScreenFromExtras() {
        m_ExtrasScreen.active = false;
        m_CreditsScreen.active = true;
    }

    public void ToExtrasScreenFromCredits() {
        m_CreditsScreen.active = false;
        m_ExtrasScreen.active = true;
    }

    //Load Level
    public void LoadP1() {
        GameObject.Find("Master-Indestructable").GetComponent<Master>().m_playerCount = 1;
        print(GameObject.Find("Master-Indestructable").GetComponent<Master>().m_playerCount);
        Application.LoadLevel(1);
    }

    public void LoadP2() {
        GameObject.Find("Master-Indestructable").GetComponent<Master>().m_playerCount = 2;
        print(GameObject.Find("Master-Indestructable").GetComponent<Master>().m_playerCount);
        Application.LoadLevel(1);
    }
}

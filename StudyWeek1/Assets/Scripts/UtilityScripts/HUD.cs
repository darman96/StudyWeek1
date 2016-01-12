using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Sprite[] heartSprites;

    public Image heartUI;

    public int playerNumber = 1;

    //private PlaneCharacter ply1;
    //private PlaneCharacter ply2;

    void Start()
    {
        if(playerNumber == 1) {
            //ply1 = GameObject.Find("Lockheed-Player1").GetComponent<PlaneCharacter>();
        }
        if(playerNumber ==2) {
            //ply2 = GameObject.Find("Lockheed-Player2").GetComponent<PlaneCharacter>();
        }
    }

    void Update()
    {
        if(playerNumber == 1) {
            //heartUI.sprite = heartSprites[ply1.CurrentHP];
        }
        if(playerNumber == 2) {
            //heartUI.sprite = heartSprites[ply2.CurrentHP];
        }
    }
}

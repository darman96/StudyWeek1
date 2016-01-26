using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Sprite[] heartSprites;

    public Image heartUI;

    public int playerNumber = 1;

    private CharacterController player;

    void Start()
    {
        player = GameObject.Find("Lockheed").GetComponent<CharacterController>();
    }

    void Update()
    {
        heartUI.sprite = heartSprites[player.CurrentHP];
    }
}

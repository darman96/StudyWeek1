using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Sprite[] heartSprites;

    public Image heartUI;

    private PlaneCharacter ply;

    void Start()
    {
        ply = GameObject.Find("Lockheed").GetComponent<PlaneCharacter>();
    }

    void Update()
    {
        heartUI.sprite = heartSprites[ply.CurrentHP];
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Master : MonoBehaviour {

    public float FlightLevel = 10;

    public List<GameObject> Waves = new List<GameObject>();
    public GameObject PlayerPrefab;


    private List<GameObject> FightersInScene = new List<GameObject>();
    private List<GameObject> BombersInScene = new List<GameObject>();
    private List<GameObject> ZeppelinsInScene = new List<GameObject>();

    private List<GameObject> Players;

    private Wave currentWave;
    private int currentWaveIndex = 0;

    //Playercount
    private int playerCount = 0;
    public int m_playerCount = 0;

	// Use this for initialization
	void Start () {
        GameObject.DontDestroyOnLoad(this.gameObject);

        GameObject.Find("WaypointManager").GetComponent<WaypointManager>().SpawnFighters(10);
        GameObject.Find("WaypointManager").GetComponent<WaypointManager>().SpawnBombers(5);
        GameObject.Find("WaypointManager").GetComponent<WaypointManager>().SpawnZeppelin(1);
    }
	
	// Update is called once per frame
	void Update () {
	/*    
        if(currentWave.Finished() && currentWaveIndex != Waves.Count - 1)
        {
            currentWaveIndex++;
            currentWave = Waves[currentWaveIndex].GetComponent<Wave>();
        }

        currentWave.Spawn();
    */
	}

    public void AddFighter(GameObject fighter)
    {
        FightersInScene.Add(fighter);
    }

    public void AddBomber(GameObject bomber)
    {
        BombersInScene.Add(bomber);
    }

    public void AddZeppelin(GameObject zeppelin)
    {
        ZeppelinsInScene.Add(zeppelin);
    }

    public void RemoveFighter(GameObject fighter)
    {
        FightersInScene.Remove(fighter);
    }

    public void RemoveBomber(GameObject bomber)
    {
        BombersInScene.Remove(bomber);
    }
    
    public void RemoveZeppelin(GameObject zeppelin)
    {
        ZeppelinsInScene.Remove(zeppelin);
    }

    public int CurrentFighterCount()
    {
        return FightersInScene.Count;
    }

    public int CurrentBomberCount()
    {
        return BombersInScene.Count;
    }

    public int CurrentZeppelinCount()
    {
        return ZeppelinsInScene.Count;
    }

}

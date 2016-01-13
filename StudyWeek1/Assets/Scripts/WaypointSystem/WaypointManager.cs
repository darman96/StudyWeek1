using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointManager : MonoBehaviour {

    public float SpawnRate = 1f;

    public List<GameObject> FighterSpawnPoints = new List<GameObject>();
    public List<GameObject> BomberSpawnPoints = new List<GameObject>();
    public List<GameObject> ZeppelinSpawnPoints = new List<GameObject>();

    public GameObject FighterPrefab;
    public GameObject BomberPrefab;
    public GameObject ZeppelinPrefab;

    private float LastSpawnTime = 0;

    private int CurrentFighterSpawn = 0;
    private int CurrentBomberSpawn = 0;
    private int CurrentZeppelinSpawn = 0;

    private int FighterCount = 0;
    private int BomberCount = 0;
    private int ZeppelinCount = 0;

    private Master master;

	// Use this for initialization
	void Start () {
        master = GameObject.Find("Master").GetComponent<Master>();
	}
	
	// Update is called once per frame
	void Update () {

        float timeDiff = Time.time - LastSpawnTime;

        if(timeDiff >= SpawnRate)
        {
            
            if(FighterCount > 0 && master.CurrentFighterCount() < FighterSpawnPoints.Count)
            {
                GameObject fighter = (GameObject)Instantiate(FighterPrefab, FighterSpawnPoints[CurrentFighterSpawn].transform.position, Quaternion.identity);
                fighter.GetComponent<SimpleEnemyAI>().SetWaypoint(FighterSpawnPoints[CurrentFighterSpawn]);
                master.AddFighter(fighter);

                FighterCount--;
                LastSpawnTime = Time.time;
                return;
            }
            if(FighterCount <= 0 && BomberCount > 0 && master.CurrentBomberCount() < BomberSpawnPoints.Count)
            {
                GameObject bomber = (GameObject)Instantiate(BomberPrefab, BomberSpawnPoints[CurrentBomberSpawn].transform.position, Quaternion.identity);
                bomber.GetComponent<SimpleEnemyAI>().SetWaypoint(BomberSpawnPoints[CurrentBomberSpawn]);
                master.AddBomber(bomber);

                BomberCount--;
                LastSpawnTime = Time.time;
                return;
            }
            if(FighterCount <= 0 && BomberCount <= 0 && ZeppelinCount > 0 && master.CurrentZeppelinCount() < ZeppelinSpawnPoints.Count)
            {
                GameObject zeppelin = (GameObject)Instantiate(ZeppelinPrefab, ZeppelinSpawnPoints[CurrentZeppelinSpawn].transform.position, Quaternion.identity);
                zeppelin.GetComponent<SimpleEnemyAI>().SetWaypoint(ZeppelinSpawnPoints[CurrentZeppelinSpawn]);
                master.AddZeppelin(zeppelin);

                ZeppelinCount--;
                LastSpawnTime = Time.time;
                return;
            }

        }

	}

    public void SpawnFighters(int count)
    {
        FighterCount = count;
    }

    public void SpawnBombers(int count)
    {
        BomberCount = count;
    }

    public void SpawnZeppelin(int count)
    {
        ZeppelinCount = count;
    }


}

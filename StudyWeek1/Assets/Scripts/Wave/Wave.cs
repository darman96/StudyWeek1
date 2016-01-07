using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour {

    public List<GameObject> SpawnPoints = new List<GameObject>();

    private bool current = false;

    private SpawnPoint currentSpawnPoint;
    private int currentSpawnPointIndex = 0;

	// Use this for initialization
	void Start () {
        currentSpawnPoint = SpawnPoints[currentSpawnPointIndex].GetComponent<SpawnPoint>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spawn()
    {
        current = true;
    }

    public bool Finished()
    {
        return true;

    }

}

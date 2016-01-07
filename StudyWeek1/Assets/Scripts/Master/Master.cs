using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Master : MonoBehaviour {

    public List<GameObject> Waves = new List<GameObject>();

    private List<GameObject> enemiesInScene = new List<GameObject>();
    private GameObject Player;

    private Wave currentWave;
    private int currentWaveIndex = 0;

    //Playercount
    public int m_playerCount = 1;

	// Use this for initialization
	void Start () {
        GameObject.DontDestroyOnLoad(this.gameObject.transform);

        Player = GameObject.FindWithTag("Player");

        //currentWave = Waves[currentWaveIndex].GetComponent<Wave>();
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
}

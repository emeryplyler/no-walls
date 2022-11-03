using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [Header("SPAWN AREA")]
    public GameObject[] SpawnPoints;

    [Header("TARGETS")]
    public GameObject Player;
    public GameObject[] CoinPrefab;

    private int worldCtr = 0;
    private bool willSpawn = true;

    void Start()
    {
        worldCtr = 0;
        willSpawn = true;
        // Randomize the Room List so the order of spawn is different
        for (int i = 0; i < SpawnPoints.Length; i++) {
            GameObject temp = SpawnPoints[i];
            int rndIndex = Random.Range(i, SpawnPoints.Length);
            SpawnPoints[i] = SpawnPoints[rndIndex];
            SpawnPoints[rndIndex] = temp;
        }

        // Spawn the First key
        SpawnKey();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnKey() {
        if (!willSpawn) return;
        Instantiate(CoinPrefab[worldCtr], getVectors(SpawnPoints[worldCtr]), Quaternion.identity);
        worldCtr++;
        if (worldCtr >= CoinPrefab.Length) willSpawn = false;
    }

    private Vector3 getVectors(GameObject target) {
        Vector3 spawnCoord = target.GetComponent<RoomInfo>().center;
        return spawnCoord;
    }
}

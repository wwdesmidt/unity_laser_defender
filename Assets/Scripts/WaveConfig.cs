using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeToSpawn = 0.5f;
    [SerializeField] float spawnVaiance = 0.3f;
    [SerializeField] int enemyCount = 5;
    [SerializeField] float enemyMoveSpeed = 0.2f;

    public GameObject getEnemyPrefab() { return enemyPrefab; }

    public List<Transform> getWaypoints()
    {
        List<Transform> waveWaypoints = new List<Transform>();

        foreach(Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }


        return waveWaypoints;
    }

    public float getTimeToSpawn() { return timeToSpawn; }
    public float getSpawnVaiance() { return spawnVaiance; }
    public int getEnemyCount() { return enemyCount; }
    public float getEnemyMoveSpeed() { return enemyMoveSpeed; }
}

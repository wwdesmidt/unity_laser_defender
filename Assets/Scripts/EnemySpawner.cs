using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;


	// Use this for initialization
	void Start ()
    {
        WaveConfig currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
	}

    IEnumerator SpawnAllEnemiesInWave(WaveConfig wave)
    {
        for(int i=0;i<wave.getEnemyCount();i++)
        {
            Instantiate(wave.getEnemyPrefab(), wave.getWaypoints()[0].transform.position, Quaternion.identity);

            yield return new WaitForSeconds(wave.getTimeToSpawn());
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

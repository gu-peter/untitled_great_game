using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager: MonoBehaviour
{
    // enemy generator
    public GameObject enemyGenerator;
    GenerateEnemies generateEnemiesScript;

    // wave information
    public int waveCount = 3;
    int waveNr = 0;
    bool waveCleared = false;

    // wave cooldown
    public float timeBetweenWaves = 5.0f;
    float wave_cooldown;

    // Start is called before the first frame update
    void Start()
    {
        wave_cooldown = timeBetweenWaves;
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
    }

    // spawn enemy waves
    IEnumerator SpawnWaves()
    {
        generateEnemiesScript = enemyGenerator.GetComponent<GenerateEnemies>();
        while(waveNr < waveCount)
        {
            yield return Instantiate(enemyGenerator, transform.position, Quaternion.identity);
            while (!waveCleared)
            {
                waveCleared = GameObject.FindGameObjectsWithTag("SimpleEnemy").Length == 0;
                yield return null;
            }
            waveCleared = false;
            waveNr += 1;
            yield return new WaitForSeconds(wave_cooldown);
        }
        yield return null;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    // enemy object
    public GameObject enemy;

    // list of enemies
    List<GameObject> enemies = new List<GameObject>();

    // enemy spawn position
    Vector2 enemyPos = new Vector2();

    // enemy count
    int enemyCount = 0;
    public int maxEnemyCount = 10;

    // check if enemy are all dead
    public bool enemyAllDead = false;

    // camera
    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropEnemy());
    }

    IEnumerator DropEnemy()
    {
        //waveManagerScript = waveManager.GetComponent<WaveManager>();
        while (!enemyAllDead) { 
            while (enemyCount < maxEnemyCount)
            {
                float offset = 10.0f;
                float cameraHeight = 2.0f * cam.orthographicSize;
                float cameraWidth = cameraHeight * cam.aspect;

                float camMinHeight = cam.transform.position.y - cameraHeight / 2.0f;
                float camMaxHeight = cam.transform.position.y + cameraHeight / 2.0f;

                float camMinWidth = cam.transform.position.x - cameraWidth;
                float camMaxWidth = cam.transform.position.x + cameraWidth;

                float[] camBounds = new float[] {camMinHeight - offset, camMaxHeight + offset, 
                    camMinWidth - offset, camMaxWidth + offset};

                int determiner = Random.Range(0, 3);

                if (determiner < 2)
                {
                    enemyPos.y = camBounds[determiner];
                    enemyPos.x = Random.Range(camMinWidth, camMaxWidth);
                } else
                {
                    enemyPos.x = camBounds[determiner];
                    enemyPos.y = Random.Range(camMinHeight, camMaxHeight);
                }

                Instantiate(enemy, enemyPos, Quaternion.identity);

                enemyCount += 1;
                yield return new WaitForSeconds(1.0f);
            }
            enemies.AddRange(GameObject.FindGameObjectsWithTag("SimpleEnemy"));
            foreach (GameObject enemy in enemies)
            {
                if (enemy == null)
                {
                    enemies.Remove(enemy);
                }
            }

            if (enemies.Count == 0)
            {
                enemyAllDead = true;
            } else
            {
                enemies.Clear();
            }
            yield return null;
        }
        yield return null;
    }
}

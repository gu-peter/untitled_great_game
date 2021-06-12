using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    // enemy object
    public GameObject enemy;
    Vector2 enemyPos = new Vector2();
    public int enemyCount;

    // camera
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropEnemy());
    }

    IEnumerator DropEnemy()
    {
        while (enemyCount < 10)
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

            yield return new WaitForSeconds(1.0f);
            enemyCount += 1;
        }
    }
}

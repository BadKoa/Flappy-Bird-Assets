using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public BoxCollider2D spawnZone;

    public GameObject ghostPrefab;

    //public float minHeight = -1.0f;

    //public float maxHeight = 1.0f;


    public void Start()
    {
        StartCoroutine(SpawnGhost());
    }




    IEnumerator SpawnGhost()
        {
            while (true)
            {
                // Generate a random position within the spawn zone
                Vector3 spawnPos = new Vector3(Random.Range(spawnZone.bounds.min.x, spawnZone.bounds.max.x),
                                               Random.Range(spawnZone.bounds.min.y, spawnZone.bounds.max.y),
                                               0f);

                // Spawn the image at the random position
                Instantiate(ghostPrefab, spawnPos, Quaternion.identity);

                // Wait for a specified interval before spawning the next image
                yield return new WaitForSeconds(2f);
            }
        }
    
    

}

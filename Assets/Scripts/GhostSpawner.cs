using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] ghostPrefabs;
    private int maxNumberOfGhosts;
    [SerializeField] private float spawnTime;
    private GameObject firstWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 5f;
        firstWaypoint = GameObject.Find("Waypoint (1.0)");
        maxNumberOfGhosts = ghostPrefabs.Length;
        StartCoroutine(SpawnGhosts());
    }

    IEnumerator SpawnGhosts()
    {
        for (int i = 0; i < ghostPrefabs.Length; i++)
        {
            GameObject ghostClone;
            if (SceneManager.GetActiveScene().name == "Level 2")
            {
                ghostPrefabs[i].transform.localScale = new Vector3(2.7f, 2.7f, transform.rotation.z);
            }

            ghostClone = Instantiate(ghostPrefabs[i], firstWaypoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }

}

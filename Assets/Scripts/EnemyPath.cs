using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float speed = 2f;
    int index = 0;
    private string waypointResourceFolder;
    private List<GameObject> listObjects;

    // Start is called before the first frame update
    void Awake()
    {
    }

    void Start()
    {
        FillListWithTransformObjects();

        transform.position = waypoints[index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void FillListWithTransformObjects()
    {
        waypointResourceFolder = (SceneManager.GetActiveScene().name == "Level 1") ? "WaypointsLvl1" : "WaypointsLvl2";

        listObjects = new List<GameObject>(Resources.LoadAll<GameObject>(waypointResourceFolder));
        listObjects.ForEach(obj => waypoints.Add(obj.transform));
    }

    private void Movement()
    {
        if (index >= waypoints.Count)
        {
            if (index == waypoints.Count) index = 0; 
        };

        var targetPosition = waypoints[index].transform.position;
        targetPosition.z = 0f;

        var movementThisFrame = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

        if (transform.position == targetPosition)
        {
            index++;
        }
    }
}

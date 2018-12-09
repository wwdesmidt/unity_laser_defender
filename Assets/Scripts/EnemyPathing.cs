using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float enemyMovementSpeed = 2f;

    int currentWaypoint = 0;

    void Start()
    {
        currentWaypoint = 0;
        transform.position = waypoints[currentWaypoint].transform.position;
    }

    private void Update()
    {
        if(transform.position== waypoints[currentWaypoint].transform.position)
        {
            currentWaypoint++;
        }

        if(currentWaypoint<waypoints.Count)
        {
            Vector2 targetPosition = waypoints[currentWaypoint].transform.position;
            float positionDelta = enemyMovementSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, positionDelta);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    public Transform[] waypoints;
    private int _currentWaypoint;

    private void Start()
    {
        _currentWaypoint = 0;
    }

    public Vector2 GetNext(float posDelta)
    {
        if (Vector2.Distance(transform.position, 
                waypoints[_currentWaypoint % waypoints.Length].position) > posDelta)
            return waypoints[_currentWaypoint % waypoints.Length].position;
        return waypoints[++_currentWaypoint % waypoints.Length].position;
    }
}

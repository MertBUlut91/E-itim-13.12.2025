using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    [SerializeField] GameObject[] waypoints;
    [SerializeField] GameObject platform;

    [SerializeField] int platformSpeed;
    [SerializeField] bool isStatic;

    private int currentWaypointIndex = 0;


    private void Start()
    {
        if (isStatic) return;

        platform.transform.position = waypoints[currentWaypointIndex].transform.position;
    }

    void Update()
    {
        if(isStatic) return;

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, 
            platform.transform.position) < 0.1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        platform.transform.position = Vector2.MoveTowards(platform.transform.position,
            waypoints[currentWaypointIndex].transform.position, Time.deltaTime * platformSpeed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int i = 0; i < waypoints.Length; i++)
        {
            Gizmos.DrawSphere(waypoints[i].transform.position,0.2f);
        }        
    }
}

using UnityEngine;


public class EnemyMovement : MonoBehaviour
{

    Transform target;
    Transform trans;
    Enemy enemy;

    int waypointIndex = 0;
    Waypoints targetWaypoints;
    GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        waypointIndex = Random.Range(0, gameManager.Waypoints.Length);
        targetWaypoints = gameManager.Waypoints[waypointIndex].GetComponent<Waypoints>();
        target = targetWaypoints.points[0];
        trans = GetComponent<Transform>();
        enemy = GetComponent<Enemy>();
    }



    void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - trans.position;
        trans.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);
        Quaternion rotation = Quaternion.LookRotation(direction * Time.deltaTime);
        trans.rotation = rotation;

        if (Vector3.Distance(trans.position, target.position) <= 0.25f)
        {
            NextWaypoint();
        }
    }

    private void NextWaypoint()
    {
        if (waypointIndex >= targetWaypoints.points.Length - 1)
        {
            EndPoint();
            return;
        }
        else
        {
            waypointIndex++;
            target = targetWaypoints.points[waypointIndex];
        }

    }

    private void EndPoint()
    {
        GameManager.PlayerLife--;
        Spawner.enemiesInWave--;
        gameObject.SetActive(false);
    }
}

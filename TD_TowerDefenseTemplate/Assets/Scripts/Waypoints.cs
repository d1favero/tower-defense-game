using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField]
    public Transform[] points;

    private void Awake()
    {
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}

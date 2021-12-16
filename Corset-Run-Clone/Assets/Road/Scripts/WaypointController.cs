using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class WaypointController : MonoBehaviour
{
    public Vector3 currentDirection = new Vector3(0, 0, 0);
    public List<GameObject> waypoints;

    [BoxGroup("Waypoint Settings")]
    public GameObject pointObject;

    [BoxGroup("Waypoint Settings")]
    [Dropdown("WaypointDirection")]
    public Vector3 pointDirection;

    [BoxGroup("Waypoint Settings")]
    public float pointDistance = 5f;


    [Button("Add Waypoint")]
    public void AddWaypoint()
    {
        // Gelen directiona göre aralıklı aralıklı her basıldığında spawn edecek

        if (!(waypoints.Count == 0))
        {
            currentDirection += pointDirection * pointDistance;
        }

        GameObject waypoint = Instantiate(pointObject, currentDirection, Quaternion.identity);
        waypoint.transform.SetParent(this.gameObject.transform);
        waypoints.Add(waypoint);

    }

    [Button("Remove Waypoint")]
    public void RemoveWaypoint()
    {
        if (!(waypoints.Count == 0))
        {
            DestroyImmediate(waypoints[waypoints.Count - 1]);
            currentDirection -= pointDirection * pointDistance;
            waypoints.RemoveAt(waypoints.Count - 1);

        }
        else
        {
            Debug.Log("Waypoints is empty!!");
        }
    }

    private DropdownList<Vector3> WaypointDirection()
    {
        return new DropdownList<Vector3>()
        {
            { "X : Right",   Vector3.right },
            { "X : Left",    Vector3.left },
            { "Z : Forward", Vector3.forward },
            { "Z : Back",    Vector3.back }
        };
    }
}

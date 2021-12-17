using UnityEngine;
using NaughtyAttributes;

namespace PathCreation.Examples
{
    // Example of creating a path at runtime from a set of points.

    // [RequireComponent(typeof(PathCreator))]
    public class GeneratePathExample : MonoBehaviour
    {

        public bool closedLoop = true;
        public Transform[] waypoints;

        //Later, if you want to generate a path on run-time, copy and paste code on the below to Start function
        [Button("Generate Path")]
        public void GeneratePath()
        {
            if (waypoints.Length > 0)
            {
                // Create a new bezier path from the waypoints.

                BezierPath bezierPath = new BezierPath(waypoints, closedLoop, PathSpace.xyz);
                bezierPath.GlobalNormalsAngle = 90;
                GetComponent<PathCreator>().bezierPath = bezierPath;
            }
        }
    }
}
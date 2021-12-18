using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class PlayerController : MonoBehaviour
{
    public GameObject visual;

    // Update is called once per frame
    void Update()
    {
        // ignore first frame mouse is pressed
        if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0))
        {
            ScalePlayerWithDrag();
        }

    }

    private void ScalePlayerWithDrag()
    {
        float scaleFactor = Mathf.Pow(2f, Input.GetAxis("Mouse Y")* 1);

        float newY = Mathf.Clamp(visual.transform.localScale.y * scaleFactor, 4f, 8f);

        visual.transform.localScale = new Vector3(
                visual.transform.localScale.x,
                newY,
                visual.transform.localScale.z);
    }
}

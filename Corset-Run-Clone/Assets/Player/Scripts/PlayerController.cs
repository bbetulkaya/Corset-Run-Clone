using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public Transform visual;
    public float minY;
    public float maxY;
    public float scaleValue;

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                ScaleChange(touch.deltaPosition.y);
            }
        }

    }

    private void ScaleChange(float swipeDelta)
    {
        var tempScale = visual.transform.localScale;
        var tempPos = visual.transform.position;

        if (swipeDelta <= 0)
        {
            tempScale.y -= scaleValue;
            if (tempScale.y < minY)
            {
                tempScale.y = minY;
            }
        }
        else
        {
            tempScale.y += scaleValue;
            if (tempScale.y > maxY)
            {
                tempScale.y = maxY;
            }
        }

        tempPos.y = tempScale.y / 2;
        visual.transform.DOScale(tempScale, 0.5f);
        visual.transform.DOLocalMoveY(tempPos.y, 0.8f, false);
    }
}

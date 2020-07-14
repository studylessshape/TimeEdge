﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameCursor.HideCursor(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        if (!GameCursor.IsInView(pos))
        {
            //获取相机右上的点
            Vector2 cameraUpRightPoint = Camera.main.ViewportToWorldPoint(Vector2.one);
            //获取相机左下的点
            Vector2 cameraBottomLeftPoint = Camera.main.ViewportToWorldPoint(Vector2.zero);

            pos.x = Mathf.Clamp(pos.x, cameraBottomLeftPoint.x, cameraUpRightPoint.x);
            pos.y = Mathf.Clamp(pos.y, cameraBottomLeftPoint.y, cameraUpRightPoint.y);
        }
        transform.position = pos;
    }
}

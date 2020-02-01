using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform leftBounds;
    public Transform rightBounds;
    public float smoothDampTime=0.15f;

    private float smoothDampVelocity = 0.0f;
    private float camWidth, camHeight, levelMinX, levelMaxX;

    void Start()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;

        float leftBoundsWidth = leftBounds.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        float rightBoundsWidth = rightBounds.GetComponentInChildren<SpriteRenderer>().bounds.size.x;

        levelMinX = leftBounds.position.x + leftBoundsWidth*2.5f + (camWidth);
        levelMaxX = rightBounds.position.x + rightBoundsWidth * 1.5f - (camWidth) ;
    }

    void Update()
    {
        if (target)
        {
            float targetX = Mathf.Max(levelMinX, Mathf.Min(levelMaxX, target.position.x));
            //Debug.Log(targetX);
            float x = Mathf.SmoothDamp(transform.position.x, targetX, ref smoothDampVelocity, smoothDampTime);
            transform.position = new Vector3(x, target.position.y, transform.position.z);
        }
    }
}

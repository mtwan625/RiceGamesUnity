using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target; // target of camera
    Vector3 velocity = Vector3.zero;
    public float smoothTime = .2f; // to smooth movement of camera

    public bool enableYMax = false;
    public float yMax = 0;
    public bool enableYMin = false;
    public float yMin = 0;

    public bool enableXMax = false;
    public float xMax = 0;
    public bool enableXMin = false;
    public float xMin = 0;

    void FixedUpdate()
    {
        // get target position
        Vector3 targetPos = target.position;

        // vertical clamping
        float min = target.position.y;
        float max = target.position.y;
        if (enableYMin) min = yMin;
        else if (enableYMax) max = yMax;
        targetPos.y = Mathf.Clamp(target.position.y, min, max);

        // horizontal clamping
        min = target.position.x;
        max = target.position.x;
        if (enableXMin) min = xMin;
        else if (enableXMax) max = xMax;
        targetPos.x = Mathf.Clamp(target.position.x, min, max);

        // set camera position
        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}

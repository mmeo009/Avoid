using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MovingObjectController : MonoBehaviour
{
    public MovingData movingData = new MovingData();
    public RotatingData rotatingData = new RotatingData();

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}

[System.Serializable]
public class MovingData
{
    public Vector3 destination;
    public float time;
    public bool isLocalDestination;
    public bool hasLoop;
}
[System.Serializable]
public class RotatingData
{
    public Vector3 angle;
    public float time;
    public bool hasLoop;
}

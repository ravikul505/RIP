using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Police : MonoBehaviour
{
    public enum State  
    {
        Shooting,
        Patrolling,
        Following
    }
    public List<Transform> Waypoints = new List<Transform>();
    public State state = State.Patrolling;
    [SerializeField]private PoliceStation thana; 
    [SerializeField]private float Cycletime = 0f;

    void Start()
    {
        if (Waypoints == null || Waypoints.Count < 2)
        {
            return;
        }
        Vector3[] pathPositions = new Vector3[Waypoints.Count];
        for (int i = 0; i < Waypoints.Count; i++)
        {
            pathPositions[i] = Waypoints[i].position;
        }
        transform.DOPath(pathPositions, Cycletime, PathType.CatmullRom)
            .SetOptions(true)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear)
            .SetLookAt(0.05f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("OPYEEE MILLL GAYAAAA");
            thana.reportToThana(gameObject);
        }
    }

    private void Update()
    {
        Debug.Log(gameObject.name + " is " + state);
    }
}

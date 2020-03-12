using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Parachute : MonoBehaviour
{
    [SerializeField] float deployHeight = 2.5f;
    [SerializeField] float drag = 10f;

    Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        deployParachute();
    }

    private void deployParachute()
    {
        if(isDeployableHeight())
        {
            rb.drag = drag;
        }
    }

    private bool isDeployableHeight()
    {
        Vector3 startPos = transform.position;
        Vector3 direction = Vector3.down;
        float maxDist = deployHeight;

        Debug.DrawRay(startPos, direction*maxDist, Color.green);
        if (Physics.Raycast(startPos, direction, maxDist))
        {
            return true;
        }
        return false;
    }
}

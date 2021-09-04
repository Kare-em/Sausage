using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private GroundChecker[] groundCheckers;
    [SerializeField] public GameObject mainPart;
    [SerializeField] public float forceK;
    private Rigidbody rb;
    public float sumMass;
    public bool IsGrounded;

    private void Start()
    {
        rb = mainPart.GetComponent<Rigidbody>();
        Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();
        foreach (var item in rbs)
        {
            sumMass += item.mass;
        }
    }

    public void AddVelocity(Vector3 differenceMousePosition)
    {
        if (IsGrounded)
        {
            Vector3 velocity = forceK * differenceMousePosition * sumMass/rb.mass;
            rb.velocity += velocity;
        }

    }

    private bool IsGroundedCheck()
    {
        foreach (var item in groundCheckers)
        {
            if (item.IsGrounded)
            {
                return true;
            }
        }
        return false;
    }
    private void FixedUpdate()
    {
        IsGrounded=IsGroundedCheck();
    }
}

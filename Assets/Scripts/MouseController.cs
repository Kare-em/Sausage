using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private MoveController player;

    private Vector3 mouseStartPosition;
    private Trajectory trajectory;
    private void Awake()
    {
        mouseStartPosition = Vector3.zero;
    }
    private void Start()
    {
        trajectory = FindObjectOfType<Trajectory>();
    }
    private void OnMouseDown()
    {
        if (player.IsGrounded)
        {
            mouseStartPosition = Input.mousePosition;
            trajectory.TrajectoryEnable();
        }
    }
    private void OnMouseDrag()
    {
        if (player.IsGrounded)
            trajectory.Draw(mouseStartPosition, -CalcVector());
    }
    private void OnMouseUp()
    {
        if (mouseStartPosition != Vector3.zero)
        {
            player.AddVelocity(-CalcVector());
        }
        trajectory.TrajectoryClear();
        mouseStartPosition = Vector3.zero;
    }
    private Vector3 CalcVector()
    {
        Vector3 differenceMousePosition = Input.mousePosition - mouseStartPosition;
        return differenceMousePosition;
    }
}

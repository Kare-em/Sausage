using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Trajectory : MonoBehaviour
{
    [SerializeField] private MoveController moveController;
    [SerializeField] private int nSteps;
    [SerializeField] private GameObject point;
    [SerializeField] private GameObject[] points;
    [SerializeField] private float stepCorrect;//корректировка шага траектории
    [SerializeField] private float underLine;//нижняя граница отрисовки относительно игрока
    private Transform mainPartTransform;

    private void Start()
    {
        points = new GameObject[nSteps];
        for (int i = 0; i < nSteps; i++)
        {
            points[i] = Instantiate(point);
        }
        TrajectoryClear();
        moveController = FindObjectOfType<MoveController>();
        mainPartTransform = moveController.mainPart.transform;
    }

    public void TrajectoryEnable()
    {
        for (int i = 0; i < nSteps; i++)
        {
            points[i].SetActive(true);
        }
    }

    public void TrajectoryClear()
    {
        for (int i = 0; i < nSteps; i++)
        {
            points[i].SetActive(false);
        }
    }
    public void Draw(Vector3 mouseStartPosition, Vector3 velocity)
    {
        if (velocity != Vector3.zero)
        {
            velocity *= moveController.forceK;
            if (velocity.x == 0f)
            {
                velocity.x = 0.0001f;
            }
            float deltaX = velocity.x / stepCorrect;
            float tempX = mainPartTransform.position.x;
            float tempY = mainPartTransform.position.y;
            float velY = velocity.y;
            float stepTime = Mathf.Abs(deltaX / velocity.x);
            for (int i = 0; i < nSteps; i++)
            {
                tempX += deltaX;
                tempY += velY * stepTime + Physics.gravity.y * stepTime * stepTime / 2;
                velY += Physics.gravity.y * stepTime;
                if (!(tempX is float.NaN || tempY is float.NaN))
                {
                    points[i].transform.position = new Vector3(tempX, tempY, 0f);
                }
            }

        }
    }
}

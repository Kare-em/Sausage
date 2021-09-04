using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLineController : MonoBehaviour
{
    [SerializeField] private GameObject retryMenu;
    private MouseController mouseController;
    private void Start()
    {
        mouseController = FindObjectOfType<MouseController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        retryMenu.SetActive(true);
        Time.timeScale = 0f;
        mouseController.enabled = false;
    }
}

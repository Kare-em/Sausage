using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheck : MonoBehaviour
{
    [SerializeField] private GameObject wonMenu;
    [SerializeField] private float waitTime; //время отображения окна финиша
    private MouseController mouseController;

    private void Start()
    {
        mouseController = FindObjectOfType<MouseController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        wonMenu.SetActive(true);
        mouseController.enabled = false;
        StartCoroutine(WonMenuWait());
    }
    private IEnumerator WonMenuWait()
    {
        yield return new WaitForSeconds(waitTime);
        wonMenu.GetComponent<MainMenuController>().Won();

    }
}

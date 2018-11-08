using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineMenu : MonoBehaviour
{
    public GameObject[] go;
    public AudioSource audioData;

    public void IfClicked ()
    {
        go = GameObject.FindGameObjectsWithTag("mb");
        foreach (GameObject mb in go)
        {
            mb.GetComponent<Button>().interactable = !mb.GetComponent<Button>().interactable;
        }
    }

    public void MB1()
    {
        audioData.Play();
    }
}

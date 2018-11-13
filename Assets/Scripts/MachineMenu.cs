using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineMenu : MonoBehaviour
{
    public GameObject helpText;
    public GameObject door;
    public GameObject[] doors;
    public GameObject help;
    public GameObject[] go;
    public GameObject canvas;
    public GameObject despenserFake;
    public GameObject despenserCan;
    public AudioSource myAudio;

    public void IfClicked ()
    {
        if (!help.activeSelf)
        {
            help.SetActive(true);
        }
        else if (help.activeSelf == true)
        {
            help.SetActive(false);
        }
        
        go = GameObject.FindGameObjectsWithTag("mb");
        foreach (GameObject mb in go)
        {
            mb.GetComponent<Button>().interactable = !mb.GetComponent<Button>().interactable;
        }
    }

    public void CloseDoor()
    {
        door.transform.Rotate(0, 90, 0);
    }

    public void CloseDoors()
    {
        foreach (GameObject d in doors)
        {
            d.transform.Rotate(0, 80, 0);
        }
    }

    public void PlaySound()
    {
        myAudio.time = 13f;
        myAudio.Play();
    }

    public void JS()
    {
        StartCoroutine(JSIE());
    }

    public IEnumerator JSIE()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(2);
        canvas.SetActive(false);
    }

    public void Despenser()
    {
        despenserFake.SetActive(true);
    }

    public void UndoDespenser()
    {
        despenserFake.SetActive(false);
    }

    public void Despenser2()
    {
        despenserCan.SetActive(true);
    }

    public void UndoDespenser2()
    {
        despenserCan.SetActive(false);
    }

    public void DisplayHelp()
    {
        StartCoroutine(DisplayHelpIE());
    }

    public IEnumerator DisplayHelpIE()
    {
        helpText.SetActive(true);
        yield return new WaitForSeconds(2);
        helpText.SetActive(false);
    }
}

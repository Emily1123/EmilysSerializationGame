using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineMenu : MonoBehaviour
{
    public GameObject[] go;
    public GameObject canvas;
    public GameObject despenserFake;
    public GameObject despenserCan;
    public AudioSource myAudio;

    public void IfClicked ()
    {
        go = GameObject.FindGameObjectsWithTag("mb");
        foreach (GameObject mb in go)
        {
            mb.GetComponent<Button>().interactable = !mb.GetComponent<Button>().interactable;
        }
    }

    public void PlaySound()
    {
        myAudio.time = 13f;
        myAudio.Play();
    }

    public void JS()
    {
        StartCoroutine(IE());
    }

    public IEnumerator IE()
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
}

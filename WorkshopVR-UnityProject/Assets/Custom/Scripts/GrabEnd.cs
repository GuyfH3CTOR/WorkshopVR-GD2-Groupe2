using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GrabEnd : MonoBehaviour
{
    public TeleportationBlackout teleportationBlackout;

    public AudioSource audioSource_Pastor;
    public AudioSource audioSource_BreakingGlass;

    public void StartEnd(){
        StartCoroutine(PastorEnter());
    }

    IEnumerator PastorEnter(){
        audioSource_Pastor.Play();
        float timer = audioSource_Pastor.clip.length;
        yield return new WaitForSeconds(timer);
        teleportationBlackout.apertureOpen = false;
        StartCoroutine(WaitToBreakGlass());
    }

    IEnumerator WaitToBreakGlass(){
        float timer = 1.0f;
        yield return new WaitForSeconds(timer);
        StartCoroutine(BreakingGlass());
    }

    IEnumerator BreakingGlass(){
        audioSource_BreakingGlass.Play();
        float timer = audioSource_BreakingGlass.clip.length;
        yield return new WaitForSeconds(timer);
        Application.Quit();
    }
}

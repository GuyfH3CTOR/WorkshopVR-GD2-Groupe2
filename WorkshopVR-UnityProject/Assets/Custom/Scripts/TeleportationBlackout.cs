using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TeleportationBlackout : MonoBehaviour
{
    [Header("Settings")]
    public float vignetteApertureSpeed;
    private float vignetteAperture = 1;
    private bool apertureOpen = true;    
    private bool changeAperture;
    private bool isClosing;

    [Header("References")]
    public Renderer vignette;
    public AudioSource audioSource;
    
    [Header("Debug")]
    public bool TP;

    public void blackoutStart(){
        StartCoroutine(BlackoutCoroutine());
    }
    
    void Update(){
        if(TP){
            BlackoutCoroutine();
            TP = false;
        }

        if(apertureOpen){
            // Debug.Log("Open Aperture");
            vignetteAperture = Mathf.Clamp(vignetteAperture+vignetteApertureSpeed,0,1);
            vignette.material.SetFloat("_ApertureSize",vignetteAperture);
        }else{
            // Debug.Log("Close Aperture");
            vignetteAperture = Mathf.Clamp(vignetteAperture-vignetteApertureSpeed,0,1);
            vignette.material.SetFloat("_ApertureSize",vignetteAperture);
        }
    }

    IEnumerator BlackoutCoroutine(){
        apertureOpen = false;
        float timer = audioSource.clip.length;
        audioSource.Play();
        yield return new WaitForSeconds(timer);
        apertureOpen = true;
    }
}

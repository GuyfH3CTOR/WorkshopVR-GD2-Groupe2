using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GrabEffect : MonoBehaviour
{
    [Header("Settings")]
    public float timeToDetect = 5;
    public float time;
    private bool canBeDetected = true;
    private bool detected;
    private bool stop;

    // Event 
    [Serializable]
    public class Unlock_Event : UnityEvent {}
    [FormerlySerializedAs("onUnlock")]
    [SerializeField]
    private Unlock_Event onUnlock = new Unlock_Event();

    [Header("References")]
    // To be detected
    public GameObject Lettre;
    // Audio
    public AudioSource audioSourceVoice;
    public AudioClip audioClip;
    
    void Update(){
        if(detected && canBeDetected) time = time + Time.deltaTime;
        if(time >= timeToDetect && canBeDetected){
            canBeDetected = false;
            if(audioClip != null) audioSourceVoice.clip = audioClip;
            if(audioClip != null) audioSourceVoice.Play(0);
        }
        if(!canBeDetected && !audioSourceVoice.isPlaying && !stop) {
            // Debug.Log("voice finished");
            stop = true;
            onUnlock.Invoke();
        }
    }

    public void Grab(){
        detected = true;
    }

    public void Ungrab(){
        time = 0;
        detected = false;
    }
}

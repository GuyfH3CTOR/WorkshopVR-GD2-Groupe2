using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class MontreDetector : MonoBehaviour
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
    
    void Update(){
        if(detected && canBeDetected) time = time + Time.deltaTime;
        if(time >= timeToDetect && canBeDetected){
            canBeDetected = false;
            
            audioSourceVoice.Play(0);
        }
        if(!canBeDetected && !audioSourceVoice.isPlaying && !stop){
            stop = true;
            // Debug.Log("voice finished");
            onUnlock.Invoke();
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject == Lettre){
            // Debug.Log("letter in collider");
            detected = true;
        }
    }

    void OnTriggerExit(Collider collider){
        if(collider.gameObject == Lettre){
            time = 0;
            detected = false;
        }
    }
}

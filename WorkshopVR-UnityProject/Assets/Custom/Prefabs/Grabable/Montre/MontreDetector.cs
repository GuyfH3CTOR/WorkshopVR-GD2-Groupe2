using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[Serializable]
public class Letter
{
    public GameObject letterToDetect;
    public AudioSource audioSourceVoice;
    public bool letterCanBeDetected = true;
    public bool letterAsBeenRead;

    // Event 
    [Serializable]
    public class Unlock_Event : UnityEvent {}
    [FormerlySerializedAs("onUnlock")]
    [SerializeField]
    public Unlock_Event onUnlock = new Unlock_Event();
}

public class MontreDetector : MonoBehaviour
{
    [Header("Settings")]
    public float timeToDetectLetter = 5;
    public float time;
    public int letterDetected;

    private bool detected;

    [Header("References : Lettre To Detect")]
    public Letter[] letters;
    
    void Update(){
        if(detected && letters[letterDetected].letterCanBeDetected) time = time + Time.deltaTime;

        if(time >= timeToDetectLetter && letters[letterDetected].letterCanBeDetected){
            letters[letterDetected].letterCanBeDetected = false;
            
            letters[letterDetected].audioSourceVoice.Play(0);
            Debug.Log("play" + letters[letterDetected]);
        }

        if(!letters[letterDetected].letterCanBeDetected && !letters[letterDetected].audioSourceVoice.isPlaying && !letters[letterDetected].letterAsBeenRead){
            letters[letterDetected].letterAsBeenRead = true;
            // Debug.Log("voice finished");
            letters[letterDetected].onUnlock.Invoke();
        }
    }

    void OnTriggerEnter(Collider collider){
        for(int i = 0; i < letters.Length; i++){
            if(collider.gameObject == letters[i].letterToDetect){
                letterDetected = i;
                detected = true;
            }
        }
    }

    void OnTriggerExit(Collider collider){
        for(int i = 0; i < letters.Length; i++){
            if(collider.gameObject == letters[i].letterToDetect){
                time = 0;
                detected = false;
            }
        }
    }
}


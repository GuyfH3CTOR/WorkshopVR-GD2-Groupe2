using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class GlobePuzzle : MonoBehaviour
{
    [Header("######## GLOBE PUZZLE ########")]
    [Header("---- Variables ----")]
    // Locks
    private bool lock1;
    private bool lock2;
    private bool lock3;
    // private bool lock4;

    // Event 
    [Serializable]
    public class Unlock_Event : UnityEvent {}
    [FormerlySerializedAs("onUnlock")]
    [SerializeField]
    private Unlock_Event onUnlock = new Unlock_Event();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CheckAllLocks(){
        // Globe Unlock
        if(lock1 && lock2 && lock3){
            // Debug.Log("Globe Opened");
            onUnlock.Invoke();
        }
    }

    public void OpenLock(int lockNumber){
        if(lockNumber == 1)lock1 = true;
        if(lockNumber == 2)lock2 = true;
        if(lockNumber == 3)lock3 = true;
        // if(lockNumber == 4)lock4 = true;
        CheckAllLocks();
    }

    public void CloseLock(int lockNumber){
        if(lockNumber == 1)lock1 = false;
        if(lockNumber == 2)lock2 = false;
        if(lockNumber == 3)lock3 = false;
        // if(lockNumber == 4)lock4 = false;
        CheckAllLocks();
    }

    public void DebugLockSelectExit(){
        Debug.Log("SelectExit");
    }
    public void DebugLockSelectEnter(){
        Debug.Log("SelectEnter");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class BookPuzzle : MonoBehaviour
{
    [Header("######## BOOK PUZZLE ########")]
    [Header("---- Variables ----")]
    public string lockWord;
    private string lockWordTest;
    private string WordTest;
    // Locks
    private string bookSideLetters1;
    private string bookSideLetters2;
    private string bookSideLetters3;
    private string bookSideLetters4;
    private string bookSideLetters5;
    
    // Event 
    [Serializable]
    public class Unlock_Event : UnityEvent {}
    [FormerlySerializedAs("onUnlock")]
    [SerializeField]
    private Unlock_Event onUnlock = new Unlock_Event();

    void CheckAllLocks(){
        // write lock
        lockWordTest = bookSideLetters1+bookSideLetters2+bookSideLetters3+bookSideLetters4+bookSideLetters5;
        // Debug.Log("lockwordTest : "+ lockWordTest);
        // Puzzle Unlock
        if(lockWordTest == lockWord){
            Debug.Log("Book Opened");
            onUnlock.Invoke();
        }
    }

    public void OpenLock(int socketNumber, string bookSideLetters){
        // Debug.Log("OpenLock : "+ socketNumber +","+bookSideLetters);
        if(socketNumber == 1)bookSideLetters1 = bookSideLetters;
        if(socketNumber == 2)bookSideLetters2 = bookSideLetters;
        if(socketNumber == 3)bookSideLetters3 = bookSideLetters;
        if(socketNumber == 4)bookSideLetters4 = bookSideLetters;
        if(socketNumber == 5)bookSideLetters5 = bookSideLetters;
        CheckAllLocks();
    }

    public void CloseLock(int socketNumber){
        if(socketNumber == 1)bookSideLetters1 = new string("");
        if(socketNumber == 2)bookSideLetters2 = new string("");
        if(socketNumber == 3)bookSideLetters3 = new string("");
        if(socketNumber == 4)bookSideLetters4 = new string("");
        if(socketNumber == 5)bookSideLetters5 = new string("");
        CheckAllLocks();
    }
}

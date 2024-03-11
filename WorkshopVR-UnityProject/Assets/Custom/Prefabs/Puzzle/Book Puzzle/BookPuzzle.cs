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
        // write sentence
        lockWordTest = bookSideLetters1+bookSideLetters2+bookSideLetters3+bookSideLetters4+bookSideLetters5;
        // Globe Unlock
        if(lockWordTest == lockWord){
            Debug.Log("Book Opened");
            onUnlock.Invoke();
        }
    }
    public void SetSideLetter(string bookSideLetters){
        WordTest = bookSideLetters;
    }

    public void OpenLock(int socketNumber, string bookSideLetters){
        if(socketNumber == 1)bookSideLetters1 = WordTest;
        if(socketNumber == 2)bookSideLetters2 = WordTest;
        if(socketNumber == 3)bookSideLetters3 = WordTest;
        if(socketNumber == 3)bookSideLetters4 = WordTest;
        if(socketNumber == 3)bookSideLetters5 = WordTest;
        CheckAllLocks();
    }

    public void CloseLock(int socketNumber){
        if(socketNumber == 1)bookSideLetters1 = new string("");
        if(socketNumber == 2)bookSideLetters2 = new string("");
        if(socketNumber == 3)bookSideLetters3 = new string("");
        if(socketNumber == 3)bookSideLetters4 = new string("");
        if(socketNumber == 3)bookSideLetters5 = new string("");
        CheckAllLocks();
    }
}

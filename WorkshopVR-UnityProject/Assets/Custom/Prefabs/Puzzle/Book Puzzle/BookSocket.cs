using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSocket : MonoBehaviour
{
    [Header("######## GLOBE PUZZLE ########")]
    [Header("---- Variables ----")]
    public int socketNumber;
    public string bookSideLetters;

    [Header("---- References ----")]
    public Collider socketCollider;
    public BookPuzzle bookPuzzle;

    void OpenLock(){
        // int bookNumber = socketCollider.get;
        // string bookLetters = ;
        // bookPuzzle.OpenLock(socketNumber, bookLetters);
    }
    void CloseLock(){
        bookPuzzle.CloseLock(socketNumber);
    }
}

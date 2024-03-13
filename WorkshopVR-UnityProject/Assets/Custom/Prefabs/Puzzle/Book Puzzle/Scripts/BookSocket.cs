using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSocket : MonoBehaviour
{
    [Header("######## GLOBE PUZZLE ########")]
    [Header("---- Variables ----")]
    public int socketNumber;
    private string newBookSideLetters;
    public string bookSideLetters;

    [Header("---- References ----")]
    public BookPuzzle bookPuzzle;

    public void SetLock(){
        bookSideLetters = newBookSideLetters;
        // Debug.Log("Set Socket Lock : "+ socketNumber);
        // Debug.Log("new side letter : "+ bookSideLetters);
        bookPuzzle.OpenLock(socketNumber,bookSideLetters);
    }

    public void CloseLock(){
        // Debug.Log("Close Socket Lock : "+ socketNumber);
        bookPuzzle.CloseLock(socketNumber);
    }

    void OnTriggerEnter(Collider c){
        if(c.gameObject.GetComponent<Book>()){
            newBookSideLetters = c.gameObject.GetComponent<Book>().sideLetters;
            // Debug.Log("book in socket");
        }
    }
}

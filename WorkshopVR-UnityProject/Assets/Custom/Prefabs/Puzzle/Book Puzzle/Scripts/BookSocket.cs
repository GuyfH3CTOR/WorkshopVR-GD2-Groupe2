using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSocket : MonoBehaviour
{
    [Header("######## GLOBE PUZZLE ########")]
    [Header("---- Variables ----")]
    public int socketNumber;
    public string newBookSideLetters;
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
            // Debug.Log("triggerEnter"+ c.gameObject);
        if(c.gameObject.GetComponent<Book>()){
            // Debug.Log("book detected in enter : "+ c.gameObject);
            newBookSideLetters = c.gameObject.GetComponent<Book>().sideLetters;
        }
    }
}

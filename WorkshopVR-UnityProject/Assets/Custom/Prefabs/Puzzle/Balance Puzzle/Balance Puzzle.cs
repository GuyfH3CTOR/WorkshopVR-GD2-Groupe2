using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class BalancePuzzle : MonoBehaviour
{
    [Header("Settings")]
    public float weigth;
    private float initialWeigth;

    [Header("References")]
    public GameObject LeftArm;
    public GameObject RightArm;
    [Space]
    public GameObject sphereColliderCheck;
    public float sphereColliderSize = 0.02f;
    public GameObject correctGameObject;
    
    // Event 
    [Serializable]
    public class Unlock_Event : UnityEvent {}
    [FormerlySerializedAs("onUnlock")]
    [SerializeField]
    private Unlock_Event onUnlock = new Unlock_Event();

    [Header("Debug")]
    public bool updateArmRotation;
    public Vector3 newArmRotation;

    void Start(){
        UpdateArm();
    }

    void Update(){
        if(updateArmRotation){
            UpdateArm();
            updateArmRotation = !updateArmRotation;
        }
    }

    void UpdateArm(){
        // change balance rotation
        newArmRotation = new Vector3(weigth,0,0);
        transform.localRotation = Quaternion.Euler(newArmRotation);
        // Keep Arm Straight
        LeftArm.transform.rotation = Quaternion.Euler(new Vector3(0,LeftArm.transform.rotation.eulerAngles.y,RightArm.transform.rotation.eulerAngles.z));
        RightArm.transform.rotation = Quaternion.Euler(new Vector3(0,RightArm.transform.rotation.eulerAngles.y,RightArm.transform.rotation.eulerAngles.z));
    }

    public void AddWeigth(float _weigth){
        initialWeigth = weigth;
        weigth = weigth + _weigth;
        UpdateArm();
    }
    public void CheckGameObject(){
        Collider[] _colliders = Physics.OverlapSphere(sphereColliderCheck.transform.position, sphereColliderSize);
        foreach(var collider in _colliders) Debug.Log("incorrect : " + collider.gameObject);
        foreach(var collider in _colliders) if(collider.gameObject == correctGameObject){
            onUnlock.Invoke();
            // Debug.Log("correct");
        }else{
            // Debug.Log("incorrect : " + collider.gameObject);
        }
    }

    public void ResetWeight(){
        weigth = initialWeigth;
        UpdateArm();
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(sphereColliderCheck.transform.position, sphereColliderSize);
    }
}

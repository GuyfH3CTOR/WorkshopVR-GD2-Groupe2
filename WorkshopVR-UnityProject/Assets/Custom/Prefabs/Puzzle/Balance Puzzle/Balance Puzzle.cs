using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancePuzzle : MonoBehaviour
{
    [Header("Settings")]
    public float weigth;

    [Header("References")]
    public GameObject LeftArm;
    public GameObject RightArm;

    [Header("Debug")]
    public bool updateArmRotation;
    public Vector3 newArmRotation;

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

    void AddWeigth(float _weigth){
        weigth = weigth + _weigth;
    }
}

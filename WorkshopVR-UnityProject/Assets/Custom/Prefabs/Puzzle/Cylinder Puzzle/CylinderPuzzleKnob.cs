using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderPuzzleKnob : MonoBehaviour
{
    [Header("######## Cylinder Puzzle ########")]
    [Header("---- Settings ----")]
    public float[] ClampedRotation;

    public void StopGrab(){
        // Get Current Rotation
        Vector3 currentRotation = transform.rotation.eulerAngles;
        float currentRotationZ = currentRotation.z;
        // Get Closest Rotation
        float newZ = ClosestTo(currentRotationZ);
        Debug.Log("newZ : "+newZ);
        // Get new rotation in Vector3
        Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,newZ);
        // Set Rotation
        transform.rotation = Quaternion.Euler(newRotation);
    }

    public void PushKnob(){
        // Get new rotation in Vector3
        Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z + 60);
        // Set Rotation
        transform.rotation = Quaternion.Euler(newRotation);
    }

    float ClosestTo(float target){
        // NB Method will return int.MaxValue for a sequence containing no elements.
        // Apply any defensive coding here as necessary.
        var closest = float.MaxValue;
        var minDifference = float.MaxValue;
        foreach (var element in ClampedRotation)
        {
            var difference = Mathf.Abs((long)element - target);
            if (minDifference > difference)
            {
                minDifference = (float)difference;
                closest = element;
            }
        }

        return closest;
    }
}

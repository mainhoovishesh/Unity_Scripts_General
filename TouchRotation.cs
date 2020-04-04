using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script rotates the 3D object on the movement of the finger  
public class TouchRotation : MonoBehaviour
{
    //this public variable is for the rotation of the gameobject
    //the speed at which when the mouse is dragged with what speed will the object will move
    public float rotSpeed = 1000;
    //function for mouse drag or touch 
    void OnMouseDrag()
    {
        //initializing the variable rotX as to rotate the object on the x axis
        //we multiply the input mouse to the rotSpeed and the Mathf.Deg2Rad 
        //Mathf.Deg2Rad Degrees-to-radians conversion constant (Read Only).
        //This is equal to (PI * 2) / 360.
        
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;


        //calls transfor for rotation
        //on the X-axis and the Y-axis
        transform.Rotate(Vector3.up, -rotX);
        transform.Rotate(Vector3.right, rotY);

    }
}

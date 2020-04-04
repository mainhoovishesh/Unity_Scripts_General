using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This code is for the throwing of the Stone from a pivot point
//it make the game object roate from a wire and throw into the space
public class Rotation : MonoBehaviour
{
    //This is to call the game object pivot from unity.
    //game objects can be changed according to your requirement
    public GameObject pivot;
    //this is to call the game object stone with is attackked to the 
    //pivot body to be thrown into the unknown
    public GameObject stone;
    //this is to call the game object tangent which allows us to throw
    //the game object stone tangentially into the unknown as straight throw would not look to good 
    public GameObject tangent;
    //this is for the rotation speed of the stone 
    //with how muh speed should the stone be rotated
    public float rotSpeed;
    //this is the speed at which the stone is thrown
    public float speed;
    //button to throw the stone 
    public Button btn;
    //bool variable for true or false of the button press
    bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        //btn is the button therefore it contains the onclick function 
        //the onclick funtions contains the add listener fuction which is calling the 
        //udjaa funciton to make the stone fly away
        btn.onClick.AddListener(udjaa);
        //we have put isPressed as initally false 
        //so that it does not throw he stone without the press of the button
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //putting the condition on the button 
        //if the button is pressed..
        if(!isPressed)
        {
            //if the button is pressed the pivot gameobject's transform is called 
            //and then we change the euler angles of the pivot point
            //euler angles describe the orientation of a rigid body with respect to a fixed coordinate system.
            //the we create a new vector3 object where we take the X,Y,Z coordinates of the pivot game object with respect to it's euler angles
            //to the Y axis we add the rotation speed to rotate it with rotSpeed with respect to the Y axis
            pivot.transform.eulerAngles = new Vector3(pivot.transform.eulerAngles.x , pivot.transform.eulerAngles.y + rotSpeed, pivot.transform.eulerAngles.z);
        }
    }
    //here we have created the udjaa function which you guessed it makes the stone game object fly away
    
    public void udjaa()
    {
        //here we are caling the stone gameObject's rigid body component 
        //in the RigitBody component we have the velocity variable
        //we are equating the velocity variable to the transform right of the stone 
        //trnasform.right When a GameObject is rotated, the red arrow representing
        //the X axis of the GameObject also changes direction. Transform.right 
        //moves the GameObject in the red arrow’s axis (X).
        stone.GetComponent<Rigidbody>().velocity = stone.transform.right * speed;
        isPressed = true;
    }
}

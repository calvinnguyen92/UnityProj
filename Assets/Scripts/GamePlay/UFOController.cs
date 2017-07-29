using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour {

    //Private value
    //UFO position
    private Vector3 position;
    //UFO movement
    private bool isRising;
    //Des Location
    private Vector3 desiredLoc;
    //TopPosition when a planet is picked
    private double pickPos;
    //Stop Positions of UFO
    private Vector3 ufoPos1, ufoPos2, ufoPos3, ufoHome;
    //Top Position of a planet when it's picked up
    private double ufoHeight;
    //Planet(Disk) States
    private bool isPicked;
    private bool isDropped;
    private bool isBeingPickedUp;

    //Public value
    public double ratio;
    //highest Position of UFO Movement
    public double roof;
    //lowest Position of UFO Movement
    public double bottom;
    //velcity
    public float velocity = 4f;


    // Use this for initialization
    void Start () {
        //Initialize Default Value for Object
        isBeingPickedUp = false;
        isDropped = false;
        position = this.gameObject.transform.position; //Start Position of the UFO
        isRising = false; //Movement of the UFO
        ufoPos1 = new Vector3(-6.44f, 3.41f, -2.46f); //UFO stop at stack 1
        ufoPos2 = new Vector3(-2.05f, 3.41f, -2.46f); //UFO stop at stack 2
        ufoPos3 = new Vector3(2.25f, 3.41f, -2.46f); //UFO stop at stack 3
        ufoHome = new Vector3(-13.14f, 3.15f, -2.46f); //UFO off screen position
        desiredLoc = ufoPos1; //set default desired position is stack 1
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        ufoVerticalMovement();
        ufoHorizalMovement();
        ufoTracking();
    }

    void ufoHorizalMovement()
    {
        position = transform.position;
        if (Input.GetKey(KeyCode.Alpha1) && isBeingPickedUp == false) //Event when press num1 and UFO has no planet
        {
            desiredLoc = ufoPos1; //UFO from Home(Off screen) goes to stack 1
        }
        else if (Input.GetKey(KeyCode.Alpha2) && isBeingPickedUp == false)
        {
            desiredLoc = ufoPos2;
        }
        else if (Input.GetKey(KeyCode.Alpha3) && isBeingPickedUp == false)
        {
            desiredLoc = ufoPos3;
        }

        if (Input.GetKey(KeyCode.Alpha1) && isPicked == true) //Event when press num1 and UFO has a planet picked
        {
            isBeingPickedUp = false;
            desiredLoc = ufoPos1;
            if (isDropped) //When a planet is already dropped, UFO goes home
            {
                desiredLoc = ufoHome;
            }
        }
        else if (Input.GetKey(KeyCode.Alpha2) && isPicked == true)
        {
            isBeingPickedUp = false;
            desiredLoc = ufoPos2;
            if (isDropped) //When a planet is already dropped, UFO goes home
            {
                desiredLoc = ufoHome;
            }
        }
        else if (Input.GetKey(KeyCode.Alpha3) && isPicked == true)
        {
            isBeingPickedUp = false;
            desiredLoc = ufoPos3;
            if (isDropped) //When a planet is already dropped, UFO goes home
            {
                desiredLoc = ufoHome;
            }
        }
    } //UFO movement to stacks

    void ufoTracking()
    {
        //Track UFO Position in every frame
        if(transform.position.x <= desiredLoc.x + 2.13) //2.13 is ratio of screen depends on DPI
        {
            transform.position = new Vector3(transform.position.x + velocity, position.y, position.z);
        }
        if(transform.position.x >= desiredLoc.x + 2.13)
        {
            transform.position = new Vector3(transform.position.x - velocity, position.y, position.z);
        }
    }

    void ufoVerticalMovement() //just a UFO effect
    {
        position = transform.position;
        if (isRising)
        {
            position.y = position.y + (float)ratio; //convert double to float
            if (this.gameObject.transform.position.y >= roof)
            {
                isRising = false;
            }
            this.gameObject.transform.position = position;
        }
        else
        {
            position.y = position.y - (float)ratio;
            if (this.gameObject.transform.position.y <= bottom)
            {
                isRising = true;
            }
            this.gameObject.transform.position = position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControl : MonoBehaviour
{
    float inputX;
    float inputY; //horizontal vertical
    public Transform character;
    Animator Anim;
    Vector3 currentDirection; //Mevcut yön
    Camera mainCam;
    float maxLength=1;
    float rotationSpeed=18;
    float maxSpeed;
    void Start()
    {
        Anim = GetComponent<Animator>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate() //Karakter yönetimlerinde yumuþak hareket için
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 1;
            //inputX = Input.GetAxis("Horizontal");
            //inputY = Input.GetAxis("Vertical");
        }
        else if(Input.GetKey(KeyCode.W))
        {
            maxSpeed = 0.2f;
            inputX = 1;
           
        }
        else 
        {
            maxSpeed = 0f;
            inputX = 0;
            
        }
        if(Input.GetKeyDown(KeyCode.A)){
            Anim.SetBool("Left", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Anim.SetBool("Left", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Anim.SetBool("Right", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Anim.SetBool("Right", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Anim.SetBool("Back", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Anim.SetBool("Back", false);
        }

        currentDirection = new Vector3(inputX, 0, inputY);       
        
        inputMove();
        inputRotation();
    }
    void inputMove()
    {
        Anim.SetFloat("speed", Vector3.ClampMagnitude(currentDirection,maxSpeed).magnitude,maxLength,Time.deltaTime*10);
    }
    void inputRotation()
    {
        //Vector3 CamOfset = mainCam.transform.TransformDirection(currentDirection); //Klavyeden basmýþ olduðumuz yönü verdik
        Vector3 CamOfset = mainCam.transform.forward;
        CamOfset.y = 0;
        character.forward = Vector3.Slerp(character.forward, CamOfset, Time.deltaTime * rotationSpeed);//Karakter o yöne döner. 
    }
}

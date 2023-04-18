using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed = 10f;

    public float speed;

    public float upRotation;
    public float downRotation;

    float thisISDecimal = 3.14f;
    CharacterController CharacterControl;
    public Transform playerCam;

    Vector3 vel;

    public float lookSensitivity;

    public float castDist;

    public Camera mainCam;

    float xRotation = 0;
    public TMP_Text itemText;
    public string lookingAt = "nothing!";

    public bool hasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        CharacterControl = GetComponent<CharacterController>();
        itemText.text = lookingAt;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
        
    {

        transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -upRotation, downRotation);
        playerCam.localRotation = Quaternion.Euler(xRotation, 0, 0);

        vel.z = Input.GetAxis("Vertical") * speed;
        vel.x = Input.GetAxis("Horizontal") * speed;

        vel = transform.TransformDirection(vel);
        CharacterControl.Move(vel * Time.deltaTime);

        
        
          
    
           

           


        
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 rayStart = mainCam.ViewportToWorldPoint(Input.mousePosition);
        if (Physics.Raycast(rayStart, playerCam.forward, out hit, castDist))
        {
            Debug.Log(hit.transform.name);
        }
    }
}

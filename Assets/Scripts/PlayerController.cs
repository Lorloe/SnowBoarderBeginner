using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 10f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            RotatePlayer();
            ResponseToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
    void ResponseToBoost()
    {
        //for speed up character
        /*
        if(Input.GetKey(KeyCode.Shift))
        {
            transform.Translate(10f * boostSpeed * Time.DeltaTime, 0f, 0f);
        }
        else if(Input.GetKey(KeyCode.Ctrl))
        {
            transform.Translate(10f * -boostSpeed * Time.DeltaTime, 0f, 0f);
        }*/
        if(Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}

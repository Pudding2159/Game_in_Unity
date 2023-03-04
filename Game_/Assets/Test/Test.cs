using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Test : MonoBehaviour
{
    private Vector3 VCamera;
    public Transform Camera;
    public Transform[] test_M = new Transform[3]; 
    private float X=0;
    private float Y=1;
    private float Z=10;
    private float num = 0.01f;
    private int counter =0;

    public float jump = 0f;

    //Move
    float xmove;
    float ymove;    
    public float speed;
    public CharacterController player;

    Vector3 move_Direction;
    void Start()
    {
        //light_.intensity = 0.1f;     
        player = GetComponent<CharacterController>();
    }


    public bool Collisions(params Transform[] test_mas)
    {   
        for(int i=0;i<test_mas.Length;i++)
        {
            if(test_mas[i].position.z == Camera.position.z)
            {   
                Debug.Log("Collisions");
                return false;
            }
        }

        return true;
    } 

    public void Test_(params Transform[] test_mas)
    {     
        for(int i=0;i<test_mas.Length;i++)
        {
            
            X = test_mas[i].position.x;
            Y=test_mas[i].position.y;
            Z = test_mas[i].position.z;
            X = X+num;
            // for(int i=0;i<test_mas.Length;i++)
            //     test_mas[i].position = new Vector3(X,Y,Z);
            if(X<5 && counter == 0)
            {
                num = 0.01f;
                counter = 0;
            }      
            if(X > 5)
            {
                num = -0.01f;
                counter = 1;
            }
            if(X < -5 )
            {
                counter = 0;
            }

                    test_mas[i].position = new Vector3(X,Y,Z);
                    test_mas[i].transform.Rotate(X-0.005f,Y,Z);
        }
    }




    void Grab()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            

        }


    }



    void Move() 
    {
        xmove = Input.GetAxis("Horizontal");
        ymove = Input.GetAxis("Vertical");
        if(player.isGrounded)
        {
           
            move_Direction = new Vector3(xmove,0f,ymove);
            move_Direction = transform.TransformDirection(move_Direction);
            //player.Move(move_Direction * Time.deltaTime * speed);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                move_Direction.y += jump; 

            }
        }
        move_Direction.y -= 1;
        player.Move(move_Direction * Time.deltaTime * speed);
        

    } 

    void Update()
    {
        Move();        
        VCamera = Camera.position;
        Test_(test_M);
    }
}

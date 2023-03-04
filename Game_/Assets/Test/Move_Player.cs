using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour
{
    // Start is called before the first frame update
    private float X_Rot;
    private float Y_Rot;

    public Camera Camera;
    public GameObject Player;

    public float sensivity = 5f;

    void Start()
    {
        
    }

    void Mouse_Move()
    {
        X_Rot += Input.GetAxis("Mouse Y");
        Y_Rot -= Input.GetAxis("Mouse X");

        Camera.transform.rotation = Quaternion.Euler(X_Rot,Y_Rot,0f);
        Player.gameObject.transform.rotation = Quaternion.Euler(0f,Y_Rot,0f);

    }

    // Update is called once per frame
    void Update()
    {
        Mouse_Move();
    }
}

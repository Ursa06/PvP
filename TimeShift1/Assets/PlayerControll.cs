using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public Rigidbody rb;
    public bool Left = false;
    public bool Right = false;
    public bool Forward = false;
    public bool Back = false;
    public float x = 0;
    public float z = 0;
    public Vector3 LR;
    public Vector3 FB;
    public Rigidbody trap1;
    GameObject player;
    public bool stun = false;
    public bool TimeShift = false;
    public float[,] TimeCoordinates = new float[50, 3];
    int i;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bolt")
        {
            OnHitDestroy bolt = collision.gameObject.GetComponent<OnHitDestroy>();
            stun = true;
            
            rb.velocity = bolt.rb.velocity;
        }
        if (collision.gameObject.tag == "Wall")
        {
            if (stun == true)
            {
                stun = false;
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
    }
    void TimeCapture()
    {
        for (i = 49; i > 0; i--)
        {
            TimeCoordinates[i, 0] = TimeCoordinates[i - 1, 0];
        }
       // TimeCoordinates[0, 0] = transform.position.x;
        for (i = 49; i > 0; i--)
        {
            TimeCoordinates[i, 1] = TimeCoordinates[i - 1, 1];
        }
        //TimeCoordinates[0, 1] = transform.position.z;
        for (i = 49; i > 0; i--)
        {
            TimeCoordinates[i, 2] = TimeCoordinates[i - 1, 2];
        }
        //TimeCoordinates[0, 2] = transform.rotation.y;
        //Debug.Log("Invoked" + TimeCoordinates[49, 0] + TimeCoordinates[49, 1] + TimeCoordinates[49, 2]);


    }
    // Start is called before the first frame update
    void Start()
    {
        for (i = 0; i < 50; i++)
        {
            TimeCoordinates[i, 0] = transform.position.x;
        }
        for (i = 0; i < 50; i++)
        {
            TimeCoordinates[i, 1] = transform.position.z;
        }
        for (i = 0; i < 50; i++)
        {
            TimeCoordinates[i, 2] = transform.rotation.y;
        }
        InvokeRepeating("TimeCapture", 5f, 0.1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        TimeCoordinates[0, 0] = transform.position.x;
        TimeCoordinates[0, 1] = transform.position.z;
        TimeCoordinates[0, 2] = transform.rotation.y;
        if (stun == false)
        { 
        Left = Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow);
        Right = Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow);
        Forward = Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow);
        Back = Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow);
        if (Forward == true)
        {
            FB = Vector3.forward;
            z = 2f;
        }
        else
        {
            if (Back == true)
            {
                FB = Vector3.forward * -1f;
                z = -2f;
            }
            else
            {
                if (Forward != true && Back != true)
                {
                    //FB = new Vector3(0, 0, 0);
                    z = 0f;
                }
            }
        }
        if (Left == true)
        {
            LR = Vector3.left;
            x = -2f;
        }
        else
        {
            if (Right == true)
            {
                LR = Vector3.left * -1f;
                x = 2f;
            }
            else
            {
                if (Left != true && Right != true)
                {
                    x = 0f;
                }
            }
        }
        if (Right == true || Left == true)
        {
            if (Forward != true && Back != true)
            {
                FB = new Vector3(0, 0, 0);
            }
        }
        if (Forward == true || Back == true)
        {
            if (Left != true && Right != true)
            {
                LR = new Vector3(0, 0, 0);
            }
        }
        if (Right == true && Left == true)
        {
            x = 0f;
        }
        if (Forward == true && Back == true)
        {
            z = 0f;
        }
        rb.velocity = new Vector3(x, 0, z);
        transform.forward = LR + FB;

        if (Input.GetKeyDown(KeyCode.Mouse0) == true)
        {

            Rigidbody clone;
            clone = Instantiate(trap1, transform.position, transform.rotation);


        }
    }


        
        TimeShift = Input.GetKey("e");
        if (TimeShift == true)
        {
            transform.position = new Vector3(TimeCoordinates[49, 0], transform.position.y, TimeCoordinates[49, 1]);
            transform.rotation = Quaternion.Euler(0, TimeCoordinates[49, 2], 0);
        }


    }
}

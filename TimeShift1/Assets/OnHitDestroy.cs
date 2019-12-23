using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDestroy : MonoBehaviour
{
    public Rigidbody rb;
    GameObject projectile;
    void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Destroy", 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

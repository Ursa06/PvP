using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaAutoFire : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody projectile;
    GameObject ballista;
    Collider Collider;
    public bool activated = false;
    // Start is called before the first frame update
    void Fire()
    {
        Rigidbody clone;
        clone = Instantiate(projectile, transform.position + transform.TransformDirection(Vector3.forward) * 0.5f, transform.rotation);
        clone.velocity = transform.TransformDirection(Vector3.forward * 10);
        Destroy(gameObject);
    }
    void Activate()
    {
        activated = true;
    }
    void Ray()
    {
        
    }
    void Start()
    {
        Collider = GetComponent<Collider>();
        Collider.enabled = false;
        Invoke("Activate", 2f); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
        
        int LayerMask = 1 << 11;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, LayerMask))
        {
            if (activated == true)
            {
                Invoke("Fire", 0f);
                
            }
        }
    }
}

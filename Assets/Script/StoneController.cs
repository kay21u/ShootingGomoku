using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (this.gameObject.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(0, -10f, 0);
    }
}

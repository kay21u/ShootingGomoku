using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    public GameObject BlackStone;
    public GameObject WhiteStone;
    private Vector3 center;
    private int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        center.y += 0.35f;
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (flag == 0)
        {
            if (other.gameObject.tag == "BlackStone")
            {
                Instantiate(BlackStone, center, Quaternion.identity);
                flag = 1;
            } else if (other.gameObject.tag == "WhiteStone")
            {
                Instantiate(WhiteStone, center, Quaternion.identity);
                flag = 1;
            }
        }
        Destroy(other.gameObject);
    }
}

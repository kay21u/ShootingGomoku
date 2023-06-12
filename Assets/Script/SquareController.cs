using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    public GameObject BlackStone;
    public GameObject WhiteStone;
    private GameObject Obj;
    private Vector3 center;
    private int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        //
        center = new Vector3(0f, 0f, 0f);
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
                Obj = Instantiate(BlackStone, center, Quaternion.identity);
                Obj.transform.SetParent(transform);
                Obj.transform.localPosition = Vector3.zero;
                Vector3 stonePosition = Obj.transform.localPosition;
                stonePosition.y += 0.7f;
                Obj.transform.localPosition = stonePosition;
                flag = 1;
            }
            else if (other.gameObject.tag == "WhiteStone")
            {
                Obj = Instantiate(WhiteStone, center, Quaternion.identity);
                Obj.transform.SetParent(transform);
                Obj.transform.localPosition = Vector3.zero;
                Vector3 stonePosition = Obj.transform.localPosition;
                stonePosition.y += 0.7f;
                Obj.transform.localPosition = stonePosition;
                flag = 1;
            }
        }
        Destroy(other.gameObject);
    }
}

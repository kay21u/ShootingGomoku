using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuttingStone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Select();
    }

    void Select()
    {
        Vector3 StonePos = this.gameObject.transform.position;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.position = new Vector3(StonePos.x, StonePos.y, StonePos.z + 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.gameObject.transform.position = new Vector3(StonePos.x, StonePos.y, StonePos.z - 1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position = new Vector3(StonePos.x - 1, StonePos.y, StonePos.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.gameObject.transform.position = new Vector3(StonePos.x + 1, StonePos.y, StonePos.z); ;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuttingStone : MonoBehaviour
{
    public GameObject WhiteStone;
    public GameObject BlackStone;
    public GameObject CurrentStone;
    public GameObject ParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        WhiteStone = GameObject.Find("WhiteStone").gameObject;
        BlackStone = GameObject.Find("BlackStone").gameObject;
        CurrentStone = GameObject.Find("BlackStone").gameObject;
        ParticleSystem = GameObject.Find("Particle System").gameObject;
        CurrentStone.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Select();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(CurrentStone == BlackStone)
            {
                CurrentStone = WhiteStone;
                Vector3 StonePos = CurrentStone.transform.position;
                ParticleSystem.transform.position = new Vector3(StonePos.x, StonePos.y, StonePos.z);
                Vector3 clonePos = BlackStone.transform.position;
                BlackStone = Instantiate(BlackStone, new Vector3(clonePos.x, clonePos.y, clonePos.z), Quaternion.identity);
            }
            else
            {
                CurrentStone = BlackStone;
                Vector3 StonePos = CurrentStone.transform.position;
                ParticleSystem.transform.position = new Vector3(StonePos.x, StonePos.y, StonePos.z);
                Vector3 clonePos = WhiteStone.transform.position;
                WhiteStone = Instantiate(WhiteStone, new Vector3(clonePos.x, clonePos.y, clonePos.z), Quaternion.identity);
            }
        }
    }

    void Select()
    {
        Vector3 StonePos = CurrentStone.transform.position;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CurrentStone.transform.position = new Vector3(StonePos.x, StonePos.y, StonePos.z + 1);
            ParticleSystem.transform.position = new Vector3(StonePos.x, StonePos.y, StonePos.z + 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CurrentStone.transform.position = new Vector3(StonePos.x, StonePos.y, StonePos.z - 1);
            ParticleSystem.transform.position = new Vector3(StonePos.x, StonePos.y, StonePos.z - 1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CurrentStone.transform.position = new Vector3(StonePos.x - 1, StonePos.y, StonePos.z);
            ParticleSystem.transform.position = new Vector3(StonePos.x - 1, StonePos.y, StonePos.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CurrentStone.transform.position = new Vector3(StonePos.x + 1, StonePos.y, StonePos.z);
            ParticleSystem.transform.position = new Vector3(StonePos.x + 1, StonePos.y, StonePos.z);
        }
    }
}

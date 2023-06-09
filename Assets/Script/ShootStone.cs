using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStone : MonoBehaviour
{
    public GameObject WhiteStone;
    public GameObject BlackStone;
    public GameObject CurrentStone;
    public GameObject ParticleSystem;
    public GameObject Hanabi;
    public GameObject BigHanabi;
    public GameObject WhiteWin;
    public GameObject BlackWin;
    public GameObject PuttingError;

    public int[,] WhiteStoneLog;
    public int[,] BlackStoneLog;

    public int Winner;

    // Start is called before the first frame update
    void Start()
    {
        // get gameObject
        WhiteStone = GameObject.Find("WhiteStone").gameObject;
        BlackStone = GameObject.Find("BlackStone").gameObject;
        CurrentStone = GameObject.Find("BlackStone").gameObject;
        ParticleSystem = GameObject.Find("Particle System").gameObject;
        Hanabi = GameObject.Find("Hanabi").gameObject;
        BigHanabi = GameObject.Find("BigHanabi").gameObject;
        BlackWin = GameObject.Find("Canvas/BlackWin").gameObject;
        WhiteWin = GameObject.Find("Canvas/WhiteWin").gameObject;
        PuttingError = GameObject.Find("Canvas/PuttingError").gameObject;

        // Putting BlackStone
        CurrentStone.transform.position = new Vector3(0, 0, 0);

        // Prepare each stone array
        WhiteStoneLog = new int[9, 9];
        BlackStoneLog = new int[9, 9];

        // hide hanabi and text
        Hanabi.SetActive(false);
        BigHanabi.SetActive(false);
        WhiteWin.SetActive(false);
        BlackWin.SetActive(false);
        PuttingError.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // get current stone pos and check
            Vector3 CrrStonePos = CurrentStone.transform.position;
            if ((WhiteStoneLog[(int)CrrStonePos.x + 4, (int)CrrStonePos.z + 4] == 1) || (BlackStoneLog[(int)CrrStonePos.x + 4, (int)CrrStonePos.z + 4] == 1))
            {
                Debug.Log("error");
                PuttingError.SetActive(true);
            }
            else
            {
                // if "puttingError"==1, hide
                PuttingError.SetActive(false);

                if (CurrentStone == BlackStone)
                {
                    // next -> WhiteStone
                    CurrentStone = WhiteStone;
                    Vector3 StonePos = CurrentStone.transform.position;
                    ParticleSystem.transform.position = new Vector3(StonePos.x, StonePos.y, StonePos.z);

                    // create next turn BlackStone
                    Vector3 clonePos = BlackStone.transform.position;
                    BlackStone = Instantiate(BlackStone, new Vector3(clonePos.x, clonePos.y, clonePos.z), Quaternion.identity);
                    BlackStoneLog[(int)clonePos.x + 4, (int)clonePos.z + 4] = 1;
                    Debug.Log(((int)clonePos.x + 4) + ", " + ((int)clonePos.z + 4));

                    // check winner
                    Winner = Check();
                    if(Winner == 2)
                    {
                        Debug.Log("Black is winner");

                        // text
                        BlackWin.SetActive(true);

                        // hanabi
                        Hanabi.SetActive(true);
                        BigHanabi.SetActive(true);
                    }
                }
                else
                {
                    // next -> BlackStone
                    CurrentStone = BlackStone;
                    Vector3 StonePos = CurrentStone.transform.position;
                    ParticleSystem.transform.position = new Vector3(StonePos.x, StonePos.y, StonePos.z);

                    // create next turn WhiteStone
                    Vector3 clonePos = WhiteStone.transform.position;
                    WhiteStone = Instantiate(WhiteStone, new Vector3(clonePos.x, clonePos.y, clonePos.z), Quaternion.identity);
                    WhiteStoneLog[(int)clonePos.x + 4, (int)clonePos.z + 4] = 1;
                    Debug.Log(((int)clonePos.x + 4) + ", " + ((int)clonePos.z + 4));

                    // check winner
                    Winner = Check();
                    if (Winner == 1)
                    {
                        Debug.Log("White is winner");

                        // text
                        WhiteWin.SetActive(true);

                        // hanabi
                        Hanabi.SetActive(true);
                        BigHanabi.SetActive(true);
                    }
                }
            }
        }
    }

    int Check()
    {
        int i, j;
        int tate=0, yoko=0, Rnaname=0, Lnaname=0;
        for (i=0; i<5; i++)
        {
            for (j=8; j>3; j--)
            {
                if (WhiteStoneLog[i,j] == 1)
                {
                    tate = WhiteStoneLog[i, j] * WhiteStoneLog[i, j-1] * WhiteStoneLog[i, j-2] * WhiteStoneLog[i, j-3] * WhiteStoneLog[i, j-4];
                    yoko = WhiteStoneLog[i, j] * WhiteStoneLog[i+1, j] * WhiteStoneLog[i+2, j] * WhiteStoneLog[i+3, j] * WhiteStoneLog[i+4, j];
                    Rnaname = WhiteStoneLog[i, j] * WhiteStoneLog[i+1, j-1] * WhiteStoneLog[i+2, j-2] * WhiteStoneLog[i+3, j-3] * WhiteStoneLog[i+4, j-4];
                    if (tate==1 || yoko==1 || Rnaname == 1)
                    {
                        return 1; // white -> 1
                    }
                }
                if (BlackStoneLog[i, j] == 1)
                {
                    tate = BlackStoneLog[i, j] * BlackStoneLog[i, j-1] * BlackStoneLog[i, j-2] * BlackStoneLog[i, j-3] * BlackStoneLog[i, j-4];
                    yoko = BlackStoneLog[i, j] * BlackStoneLog[i+1, j] * BlackStoneLog[i+2, j] * BlackStoneLog[i+3, j] * BlackStoneLog[i+4, j];
                    Rnaname = BlackStoneLog[i, j] * BlackStoneLog[i+1, j-1] * BlackStoneLog[i+2, j-2] * BlackStoneLog[i+3, j-3] * BlackStoneLog[i+4, j-4];
                    if (tate == 1 || yoko == 1 || Rnaname == 1)
                    {
                        return 2; // black -> 2
                    }
                }
            }
        }
        for (i=8; i>3; i--)
        {
            for (j=8; j>3; j--)
            {
                if (WhiteStoneLog[i, j] == 1)
                {
                    tate = WhiteStoneLog[i, j] * WhiteStoneLog[i, j-1] * WhiteStoneLog[i, j-2] * WhiteStoneLog[i, j-3] * WhiteStoneLog[i, j-4];
                    Lnaname = WhiteStoneLog[i, j] * WhiteStoneLog[i-1, j-1] * WhiteStoneLog[i-2, j-2] * WhiteStoneLog[i-3, j-3] * WhiteStoneLog[i-4, j-4];
                    if (Lnaname==1 || tate==1)
                    {
                        return 1; // white -> 1
                    }
                }
                if (BlackStoneLog[i, j] == 1)
                {
                    tate = BlackStoneLog[i, j] * BlackStoneLog[i, j-1] * BlackStoneLog[i, j-2] * BlackStoneLog[i, j-3] * BlackStoneLog[i, j-4];
                    Lnaname = BlackStoneLog[i, j] * BlackStoneLog[i-1, j-1] * BlackStoneLog[i-2, j-2] * BlackStoneLog[i-3, j-3] * BlackStoneLog[i-4, j-4];
                    if (Lnaname==1 || tate==1)
                    {
                        return 2; // black -> 2
                    }
                }
            }
        }
        return 0;
    }
}

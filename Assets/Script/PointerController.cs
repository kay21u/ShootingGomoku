using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    public GameObject BlackStone;
    public GameObject WhiteStone;
    public GameObject CurrentStone;

    // Start is called before the first frame update
    void Start()
    {
        CurrentStone = BlackStone;
    }

    // Update is called once per frame
    void Update()
    {
        // カーソル位置を取得
        Vector3 mousePos = Input.mousePosition;
        // カーソル位置をワールド座標に変換
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        // GameObjectのtransform.positionにカーソル位置(ワールド座標)を代入
        transform.position = target;

        //クリックしたらStoneを出現させる
        if (Input.GetMouseButtonDown(0))
        {
            if (CurrentStone == BlackStone)
            {
                Instantiate(BlackStone, transform.position, Quaternion.identity);
                CurrentStone = WhiteStone;
            }
            else if (CurrentStone == WhiteStone)
            {
                Instantiate(WhiteStone, transform.position, Quaternion.identity);
                CurrentStone = BlackStone;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header ("ViewSetting")]
    public GameObject[ ] floors;
    public GameObject[ ] Scroll_Images;
    public GameObject Menu;

    void Start ()
    {
        Init ();
        GameManager.UIReady = true;
    }

    void Init ()
    {
        //重製座標軸
        Scroll_Images[0].transform.position += Vector3.zero;
        Scroll_Images[1].transform.position += Vector3.zero;
    }

    void Update ()
    {

    }
}

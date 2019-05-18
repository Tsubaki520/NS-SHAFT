using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreater : MonoBehaviour
{
    [Header ("Object Spawn Settings")]
    [SerializeField]
    private List<GameObject> m_blockList = new List<GameObject> ();
    [SerializeField]
    private GameObject[ ] m_blocks = null;
    private Transform m_ObjectTransform = null;
    [Range (0.1f, 2f)]
    [SerializeField]
    private float m_initY = 0;
    const int BlockNum_Normal = 5;

    //BorderLimit
    readonly float m_borderLeft = -6.8f;
    readonly float m_borderRight = 4.5f;

    void Start ()
    {
        SetObjectPool ();
    }

    void SetObjectPool ()
    {
        for (int x = 0 ; x < BlockNum_Normal ; x++)
            m_blockList.Add (m_blocks[(int) BlockType.Normal]);
        for (int y = 1 ; y < m_blocks.Length ; y++)
            m_blockList.Add (m_blocks[y]);
    }

    float NewBlockPositionX ()
    {
        return Random.Range (m_borderLeft, m_borderRight);
    }

    float NewBlockPositionY ()
    {
        return m_ObjectTransform.position.y - m_initY;
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        if (GameManager.Instance.GameStatus == Status.Play)
            StartCoroutine (CreateBlock ());
    }

    IEnumerator CreateBlock ()
    {
        int Type = Random.Range (0, m_blockList.Count);
        /*
        string m_blockType = m_blockList[Type].name;
        m_ObjectTransform = m_blockList[Type].transform;
        Transform t = ObjectPool.Instance.TakeFromPool (m_blockType);
        if (t = null) yield return null;

        float posX = Random.Range (m_borderLeft, m_borderRight);
        float posY = m_ObjectTransform.position.y - m_initHeight;
        //t.SetPositionAndRotation (new Vector2 (posX, posY), m_ObjectTransform.rotation);
        //t.rotation = m_ObjectTransform.rotation;
        */
        yield return new WaitForSeconds (1);
    }
}

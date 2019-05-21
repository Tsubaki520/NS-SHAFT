using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreater : MonoBehaviour
{
    [Header ("Object Spawn Settings")]
    [SerializeField]
    private List<GameObject> m_blockList = new List<GameObject> ();
    private List<GameObject> m_usedBlocks = new List<GameObject> ();
    [SerializeField]
    private GameObject[ ] m_blocks = null;
    private Transform m_ObjectTransform = null;

    [Range (0.1f, 2f)]
    [SerializeField]
    private float m_initY = 0;
    [Range (0.1f, 2f)]
    [SerializeField]
    private float m_initBlock = 0;
    const int BlockNum_Normal = 8;
    float Timer = 0;

    //BorderLimit
    readonly float m_borderLeft = -6.8f;
    readonly float m_borderRight = 4.5f;

    void Start ()
    {
        SetObjectPool ();
        GameManager.PoolReady = true;
    }

    void SetObjectPool ()
    {
        for (int x = 0 ; x < BlockNum_Normal ; x++)
            m_blockList.Add (Instantiate (m_blocks[(int) BlockType.Normal]));
        for (int y = 1 ; y < m_blocks.Length ; y++)
            m_blockList.Add (Instantiate (m_blocks[y]));
        for (int z = 0 ; z < m_blockList.Count ; z++)
        {
            m_blockList[z].transform.SetParent (transform);
            m_blockList[z].gameObject.SetActive (false);
        }
    }

    float NewBlockPositionX ()
    {
        if (m_usedBlocks.Count == 0)
            return -1;
        else
            return Random.Range (m_borderLeft, m_borderRight);
    }

    float NewBlockPositionY ()
    {
        if (m_usedBlocks.Count == 0)
            return -4;
        else
            return m_ObjectTransform.position.y - m_initY;
    }

    void Update ()
    {
        if (!GameManager.SceneReady) return;

        if (GameManager.Instance.GameStatus == Status.Play)
        {
            Timer += Time.deltaTime;
            if (Timer >= m_initBlock)
            {
                Timer = 0;
                StartCoroutine (CreateBlock (Timer));
            }
        }
    }

    IEnumerator CreateBlock (float time)
    {
        int Type = Random.Range (0, m_blockList.Count);
        GameObject blockClone = m_blockList[Type].gameObject;
        m_ObjectTransform = transform;

        blockClone.transform.SetPositionAndRotation (new Vector3 (NewBlockPositionX (), NewBlockPositionY (), 1), m_ObjectTransform.rotation);
        m_blockList.RemoveAt (Type);
        m_usedBlocks.Add (blockClone);
        blockClone.SetActive (true);
        yield return new WaitForSeconds (time);
    }

    public void ReturnList (GameObject obj)
    {
        m_usedBlocks.Remove (obj);
        m_blockList.Add (obj);
        obj.SetActive (false);
    }
}

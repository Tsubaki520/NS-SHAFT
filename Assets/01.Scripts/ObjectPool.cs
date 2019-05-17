using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance = null;

    [Header ("Settings")]
    public ObjPoolSetting[ ] objPool;

    // local use
    private Dictionary<string, ObjPoolInfo> poolInfo =
        new Dictionary<string, ObjPoolInfo> ();
    private Dictionary<GameObject, string> poolObjList =
        new Dictionary<GameObject, string> ();

    private void Awake ()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy (gameObject);
    }

    private void Start ()
    {
        CreatePoolObject ();
        GameManager.PoolReady = true;
    }

    private void CreatePoolObject ()
    {
        if (objPool.Length == 0) return;

        foreach (ObjPoolSetting ops in objPool)
        {
            GameObject pool = new GameObject (ops.name);
            pool.transform.SetParent (transform);
            poolInfo.Add (
                ops.name,
                new ObjPoolInfo (pool.transform, ops.prefab, ops.enableInPool)
            );
            for (int i = 0 ; i < ops.Quantity ; i++)
            {
                GameObject newObj = poolInfo[ops.name].AddNewObj ();
                poolObjList.Add (newObj, ops.name);
            }
        }
    }

    public Transform TakeFromPool (string pool)
    {
        Transform t = poolInfo[pool].Take ();
        if (poolInfo[pool].inObj < 10)
            Instance.AddMore (pool);

        return t;
    }

    private void AddMore (string pool)
    {
        if (poolInfo[pool].corou == null)
            poolInfo[pool].corou = StartCoroutine (AddMoreProcess (pool));
    }

    private IEnumerator AddMoreProcess (string pool)
    {
        poolInfo[pool].addMoreCounter++;
        int addAmt = (int) (poolInfo[pool].totalObj * 0.2f);
        if (addAmt < 10) addAmt = 10;

        for (int i = 0 ; i < addAmt ; i++)
        {
            GameObject newObj = poolInfo[pool].AddNewObj ();
            poolObjList.Add (newObj, pool);
            yield return null;
        }

        poolInfo[pool].corou = null;
    }

    public void ReturnToPool (GameObject obj)
    {
        poolInfo[poolObjList[obj]].Return (obj);
    }
}

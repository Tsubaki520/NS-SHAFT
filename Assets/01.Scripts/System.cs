using System;
using System.Collections.Generic;
using UnityEngine;

public enum Status { Play, Over }
public enum AnimationType { Idle, Left, Right }
public enum AudioClipType { normal, fake, conveyor, spring, nail, die }
public enum BlockType { Normal, Fake, Conveyor_Left, Conveyor_Right, Trampoline, Nails }

[Serializable]
public struct ObjPoolSetting
{
    public string name;
    public GameObject prefab;
    [Range (20, 100)]
    public int Quantity;
    public bool enableInPool;
}

public class ObjPoolInfo
{
    private Transform pool;
    private GameObject prefab;
    private readonly bool enableInPool;
    public int totalObj;
    public int outObj;
    public int inObj;
    public int maxOut;
    public int addMoreCounter;
    private Dictionary<GameObject, bool> objList;
    public Coroutine corou;

    public ObjPoolInfo (Transform pool, GameObject prefab, bool enableInPool)
    {
        this.pool = pool;
        this.prefab = prefab;
        this.enableInPool = enableInPool;
        totalObj = outObj = inObj = maxOut = addMoreCounter = 0;
        objList = new Dictionary<GameObject, bool> ();
    }

    public GameObject AddNewObj ()
    {
        GameObject newObj = GameObject.Instantiate (prefab, pool.transform);
        newObj.SetActive (enableInPool);
        newObj.transform.position = pool.transform.position;
        newObj.name = string.Concat (prefab.name, " (", totalObj + 1, ")");
        objList.Add (newObj, false);
        totalObj++;
        inObj++;
        return newObj;
    }

    public Transform Take ()
    {
        if (objList == null || objList.Count == 0 || inObj == 0) return null;
        Transform t = null;
        foreach (GameObject obj in objList.Keys)
            if (!objList[obj])
            {
                outObj++;
                inObj--;
                objList[obj] = true;
                obj.SetActive (true);
                t = obj.transform;
                break;
            }

        if (outObj > maxOut)
            maxOut = outObj;

        return t;
    }

    public void Return (GameObject obj)
    {
        if (!objList.ContainsKey (obj)) return;
        outObj--;
        inObj++;
        obj.SetActive (enableInPool);
        obj.transform.SetParent (pool);
        obj.transform.SetPositionAndRotation (pool.position, pool.rotation);
        objList[obj] = false;
    }
}

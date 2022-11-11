using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ObjectPooler
{
    public static Queue<GameObject> objectPool = new Queue<GameObject>();

    public static readonly string defaultLayer = "Cube";
    private static GameObject poolObject;
    private static float poolCount;
    private static Transform parent;
    private static int nameIndex = 0;
    /// <summary>
    /// Generate a certain number membered pool queue.
    /// </summary>
    /// <param name="info">Pool scriptable object that contains data.</param>
    /// <param name="holder">Parent/holder of spawned cubes.</param>
    public static void GeneratePool(PoolInfo info, Transform holder)
    {
        objectPool = new Queue<GameObject>();
        poolCount = info.poolCount;
        poolObject = info.poolObject;
        parent = holder;
        for (int i = 0; i < poolCount; i++)
        {
            InitializeObject();
        }
    }

    /// <summary>
    /// Instantiate an object and enqueue it to pool.
    /// </summary>
    public static void InitializeObject()
    {
        GameObject obj = MonoBehaviour.Instantiate(poolObject, parent);
        obj.SetActive(false);
        objectPool.Enqueue(obj);
        obj.name = nameIndex.ToString();
        nameIndex++;
    }
    /// <summary>
    /// Get an object from pool and activate it.
    /// </summary>
    /// <returns>First member of pool queue.</returns>
    public static GameObject SpawnFromQueue()
    {

        if (objectPool.Count == 0)
        {
            InitializeObject();
        }
        GameObject obj = objectPool.Dequeue();

        obj.SetActive(true);
        return obj;
    }

    /// <summary>
    /// Reset queue objects by setting them inactive and making their color as white again.
    /// </summary>
    public static void ResetQueue()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            GameObject obj = objectPool.Dequeue();
            ResetObject(obj);
        }
    }

    /// <summary>
    /// Returns object to it's default settings.
    /// </summary>
    /// <param name="queueObject">Object to reset.</param>
    public static void ResetObject(GameObject queueObject)
    {
        queueObject.SetActive(false);
        queueObject.transform.localPosition = Vector3.zero;
        queueObject.GetComponent<Renderer>().material.color = Color.white;
        queueObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
        queueObject.transform.parent = parent;
        objectPool.Enqueue(queueObject);
    }
}

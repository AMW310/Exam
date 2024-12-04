using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] 

    [Serializable]
    private struct PooledTiles
    {
        public GameObject prefab;
        public int numToSpawn;
    }

    [SerializeField] private PooledTiles[] pools;

    private static readonly Dictionary<string, Queue<GameObject>> pooledTiles =
        new Dictionary<string, Queue<GameObject>>();
    void Awake()
    {
        pooledTiles.Clear();

        foreach (PooledTiles pool in pools)
        {
            string name = pool.prefab.name;
            Transform parent = new GameObject(name).transform;
            Queue<GameObject> objectsToSpawn = new(pool.numToSpawn);
            for (int i = 0; i < pool.numToSpawn; i++)
            {
                GameObject obj = Instantiate(pool.prefab, parent);
                obj.gameObject.SetActive(false);
                objectsToSpawn.Enqueue(obj);
            }
            pooledTiles.Add(name, objectsToSpawn);
        }
    }

    public static GameObject GetTile(string name, Vector3 transformPos, Quaternion identity)
    {
        if (!pooledTiles.ContainsKey(name))
        {
            Debug.LogAssertion("Does not contain key" + name);
            return null;
        }

        GameObject obj = pooledTiles[name].Dequeue();

        obj.transform.SetLocalPositionAndRotation(transformPos, identity);
        obj.SetActive(true);

        pooledTiles[name].Enqueue(obj);
        return obj;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ObjectPooler Instance;
    private void Awake() 
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictrionary;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       poolDictrionary = new Dictionary<string, Queue<GameObject>>();
       foreach (Pool pool in pools)
       {
           Queue<GameObject> objectPool = new Queue<GameObject>();
           for (int i = 0; i < pool.size; i++)
           {
               GameObject obj = Instantiate(pool.prefab);
               obj.SetActive(false);
               objectPool.Enqueue(obj);
           }
           poolDictrionary.Add(pool.tag, objectPool);
       }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Vector3 prevPosition)
    {
        if(!poolDictrionary.ContainsKey(tag))
        {
            Debug.Log("Pool with tag" + tag + "doesn't exist.");
            return null;
        }
        GameObject objectToSpawn = poolDictrionary[tag].Dequeue();
        
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.GetComponent<Projectile>().prevPosition = prevPosition;
        objectToSpawn.GetComponent<Projectile>().position = position;
        objectToSpawn.SetActive(true);
        /* 
Debug.Log("Distance param ObjPl");
Debug.Log(Vector3.Distance(prevPosition,position));
Debug.Log("prevPos param ObjPl");
Debug.Log(prevPosition);
Debug.Log("Pos param ObjPl");
Debug.Log(position);

Debug.Log("Distance proj ObjPl");
Debug.Log(Vector3.Distance(objectToSpawn.GetComponent<Projectile>().prevPosition,objectToSpawn.GetComponent<Projectile>().position));
Debug.Log("prevPos proj ObjPl");
Debug.Log(objectToSpawn.GetComponent<Projectile>().prevPosition);
Debug.Log("Pos proj ObjPl");
Debug.Log(objectToSpawn.GetComponent<Projectile>().position);*/

        poolDictrionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}

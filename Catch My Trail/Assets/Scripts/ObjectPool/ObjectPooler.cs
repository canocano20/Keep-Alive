
/*
    Inspriation is taken from 

    https://www.raywenderlich.com/847-object-pooling-in-unity#toc-anchor-007
*/

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPooled;
    public int amountToPool;
    public bool shouldExpand;
}
public class ObjectPooler : Singleton<ObjectPooler>
{
    [SerializeField] private List<GameObject> pooledObjects;
    [SerializeField] private List<ObjectPoolItem> itemsToPool;


    private void Start() 
    {
        pooledObjects = new List<GameObject>();

        foreach(ObjectPoolItem item in itemsToPool)
        {
            for(int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = Instantiate(item.objectToPooled);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        
        for(int i = 0; i < pooledObjects.Count; i++)
        {

            if(!pooledObjects[i].activeInHierarchy && pooledObjects[i].CompareTag(tag))
            {
               
                return pooledObjects[i];
            }
        }
        
        foreach (ObjectPoolItem item in itemsToPool) 
        {
            if (item.objectToPooled.CompareTag(tag)) 
            {
                if (item.shouldExpand) 
                {
                    
                    GameObject obj = Instantiate(item.objectToPooled);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    
                    return obj;
                }
            }
        }
        return null;
    }

    public void DeactivateAllPooledObjects()
    {
        foreach(GameObject item in pooledObjects)
        {
            item.SetActive(false);
        }
    }
}

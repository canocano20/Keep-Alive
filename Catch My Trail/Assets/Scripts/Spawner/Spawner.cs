using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<string> _spawnObjectsTag = new List<string>();
    [SerializeField] private float _timer;
    [SerializeField] private float _randomMax;
    private float _cameraXBound;
    
    private void OnEnable() 
    {
        StartCoroutine(SpawnObject(_timer));

        _cameraXBound = Camera.main.orthographicSize * Screen.width / Screen.height;

        _randomMax = 2f;
    }

    IEnumerator SpawnObject(float time)
    {
        Spawn();

        yield return new WaitForSeconds(time);
        
        StartCoroutine(SpawnObject(_timer));
        
    } 

    private void Spawn()
    {
        /*Instantiate(_spawnObjects[Random.Range(0, _spawnObjects.Capacity)],
                     new Vector3(Random.Range(-cameraXBound + 1, cameraXBound - 1), Camera.main.orthographicSize + 3, 0),
                     _spawnObjects[0].transform.rotation);*/

        float randomness = Random.Range(0, _randomMax);

        GameObject pooledObject;
        if(randomness < 1f)
        {
            pooledObject = ObjectPooler.GetInstance().GetPooledObject(_spawnObjectsTag[0]);
        }
        else
        {
            pooledObject = ObjectPooler.GetInstance().GetPooledObject(_spawnObjectsTag[1]);
        }
        

        if(pooledObject != null)
        {
            pooledObject.transform.position = new Vector3(Random.Range(-_cameraXBound + 1, _cameraXBound - 1), Camera.main.orthographicSize + 3, 0);
            pooledObject.SetActive(true);
        }

        if(_timer > 0.15f)
        {
            _timer -= 0.002f;
        
        }
        if(_randomMax < 10f)
        {
            _randomMax += 0.03f;
        }
        
    }   

    private void OnDisable() 
    {
        _timer = 0.5f;
        _randomMax = 2f;
    }
}

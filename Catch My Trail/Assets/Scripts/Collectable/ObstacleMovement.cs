using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        transform.position += new Vector3(0, -(_speed * Time.deltaTime), 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float randomXAngle;

    private SpriteRenderer _mySpriteRenderer;
    private void Start()
    {
        randomXAngle = Random.Range(-0.2f, 0.2f);
        _speed = Random.Range(12f, 20f);

        _mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        float cameraXBound = Camera.main.orthographicSize * Screen.width / Screen.height;

        if(Mathf.Abs(transform.position.x)  > cameraXBound - (_mySpriteRenderer.size.x / 2))
        {
            randomXAngle *= -1;
        }

        transform.position += new Vector3(randomXAngle, -(_speed * Time.deltaTime), 0);
    }
}

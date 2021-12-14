using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private Vector3 _sizeChangeVector;
    [SerializeField] GameEvent _onGameEnded;
    private SpriteRenderer _mySpriteRendeder;
    private Animator _cameraAnimator;

    private void Start() 
    {
        _mySpriteRendeder = GetComponent<SpriteRenderer>();
        _cameraAnimator = Camera.main.GetComponent<Animator>();   
    }

    void Update()
    {
        
        if(Input.GetButton("Fire1"))
        {
            PlayerMove();
            
        }
        
        if(Input.GetButtonDown("Fire1"))
        {
            PlayerRotate();
        }
    }

    private void PlayerMove()
    {  
        Vector3 destinationPosition = new Vector3(CameraPosition(), transform.position.y, transform.position.z);
        
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, _playerSpeed * Time.deltaTime);
        
    }

    private float CameraPosition()
    {
        float cameraXBound = Camera.main.orthographicSize * Screen.width / Screen.height;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouseWorldPosition.x = Mathf.Clamp(mouseWorldPosition.x, -cameraXBound + _mySpriteRendeder.size.x / 2 , cameraXBound  -  _mySpriteRendeder.size.x / 2 );

        return mouseWorldPosition.x;
    }


    private void ChangePlayerSize(bool big)
    {
        if(big)
        {
            transform.localScale += _sizeChangeVector;
        }
        else
        {
            transform.localScale -= _sizeChangeVector;
            if(transform.localScale.x < 0.1f)

            {
                _onGameEnded.Raise();
                GameManager.GetInstance().OnGameEnded();
                CanvasManager.GetInstance().SwitchCanvas(CanvasType.EndMenu);
            }
        }
    }

    private void PlayerRotate()
    {
        if(CameraPosition() < transform.position.x)
        {
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    private void ShakeAnimation()
    {
        _cameraAnimator.SetTrigger("canShake");
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {

        if(other.CompareTag("Bad"))
        {
            AudioManager.GetInstance().Play("Hit");
            ChangePlayerSize(false);
            ShakeAnimation();
        }   
        else if(other.CompareTag("Good"))
        {
            AudioManager.GetInstance().Play("PickUp");
            ChangePlayerSize(true);  
        } 
    }
    private void OnEnable() 
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    private void OnDisable() 
    {
        transform.position = new Vector3(0f, -12f, 0f);    
    }
}

using UnityEngine;


public class PlayerMove : MonoBehaviour
{

    public CharacterController characterController;
    public Transform cam;
    private Animator _animator;
    private float Speed = 2f;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        
        #region karakterHareket
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude>=0.1f)
        {
            float TargetAngell = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            transform.rotation = Quaternion.Euler(0f, TargetAngell, 0f);
            Vector3 MoveDirection = Quaternion.Euler(0f, TargetAngell, 0f) * Vector3.forward;

     
            float moveSpeed = Speed;
            characterController.Move(MoveDirection.normalized * (moveSpeed * Time.deltaTime));
            _animator.SetBool("IsWalking", true);
            
            #region koşma
            if (Input.GetKey(KeyCode.LeftShift))
            {
                characterController.Move(MoveDirection.normalized * (moveSpeed * Time.deltaTime * 2));
                _animator.SetBool("IsRunning", true);
                _animator.SetBool("IsWalking", false);
            }
            
            else
            {
                _animator.SetBool("IsRunning", false);
            }
            #endregion
            

        }
        else
        {
            _animator.SetBool("IsWalking", false);
            _animator.SetBool("IsRunning", false);
        }
        #endregion
        
        #region yuvarlanma
        
        if (Input.GetKey(KeyCode.C))
        {
            _animator.SetBool("Rolling",true);
            _animator.SetBool("IsWalking", false);
            _animator.SetBool("IsRunning", false);
        }
        else
        {
            _animator.SetBool("Rolling",false);

        }
        
       
        #endregion
    }
}

using UnityEngine;


public class PlayerMove : MonoBehaviour
{

    public CharacterController characterController;
    public Transform cam;
    private Animator _animator;
    private float Speed = 2f;

    private Rigidbody karakterRigidbody;
    private string key = "Paleyer";
    


    void Start()
    {
        _animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        karakterRigidbody = GetComponent<Rigidbody>();
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

    #region Save
    public void Kaydet()
    {
        //************ SAVE ************
        
        Vector3 position = transform.position;
        PlayerPrefs.SetFloat(key + "_x", position.x);
        PlayerPrefs.SetFloat(key + "_y", position.y);
        PlayerPrefs.SetFloat(key + "_z", position.z);
        PlayerPrefs.Save();
        Debug.Log("Kaydedildi: " + position);
    }

    public void OyunuYukle()
    {
        //************ LOAD ************

        float x = PlayerPrefs.GetFloat(key + "_x");
        float y = PlayerPrefs.GetFloat(key + "_y");
        float z = PlayerPrefs.GetFloat(key + "_z");
        Vector3 position = new Vector3(x, y, z);
        transform.position = position;

        //Karakterin hareket etme sorununu çözen kodlar:
        characterController.enabled = false;
        characterController.enabled = true;

        Debug.Log("Yüklendi: " + position);
    }
#endregion
}

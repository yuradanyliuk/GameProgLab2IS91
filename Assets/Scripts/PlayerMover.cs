using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    #region Fields
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Transform mainCamera;

    private Rigidbody _rigidbody;
    private Vector3 _movingForce;
    private Vector3 _jumpForce;
    private Vector3 _eulerRotation;
    private bool _needToJump;
    #endregion

    #region Methods
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _jumpForce.y = jumpPower;
    }
    private void Update()
    {
        UpdateInputParameters();
        
        if (_needToJump)
            Jump(_jumpForce);
    }
    private void FixedUpdate()
    {
        if(_movingForce != Vector3.zero)
        {
            _eulerRotation.y = mainCamera.rotation.eulerAngles.y;
            Rotate(_eulerRotation);
            Move(_movingForce);
        }
    }

    private void UpdateInputParameters()
    {
        const string horizontalAxisName = "Horizontal";
        const string verticalAxisName = "Vertical";
        _movingForce.x = Input.GetAxis(horizontalAxisName);
        _movingForce.z = Input.GetAxis(verticalAxisName);
        
        _needToJump = Input.GetKeyDown(KeyCode.Space);
    }
    private void Move(Vector3 movingForce) => transform.Translate(moveSpeed * Time.fixedDeltaTime * movingForce);
    private void Rotate(Vector3 eulerRotation) => transform.rotation = Quaternion.Euler(eulerRotation);
    private void Jump(Vector3 jumpForce) => _rigidbody.AddForce(jumpForce, ForceMode.Impulse);
    #endregion
}
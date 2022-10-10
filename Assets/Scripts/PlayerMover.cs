using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    #region Fields
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;

    private Rigidbody _rigidbody;
    private Vector3 _movingForce;
    private Vector3 _jumpForce;
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
            Move(_movingForce);
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
    private void Jump(Vector3 jumpForce) => _rigidbody.AddForce(jumpForce, ForceMode.Impulse);
    #endregion
}

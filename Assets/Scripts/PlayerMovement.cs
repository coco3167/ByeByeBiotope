using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference movement;
    [SerializeField] private float speed;
    
    private Rigidbody m_rigidbody;
    private PlayerInput m_playerInput;

    private Vector2 m_rawMovement;
    
    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_playerInput = GetComponent<PlayerInput>();
        
        m_playerInput.onActionTriggered += OnActionTriggered;
    }

    private void OnActionTriggered(InputAction.CallbackContext context)
    {
        //Debug.Log(movement.action.id);
        //Debug.Log(context.action.id);
        
        if (movement.action.id == context.action.id)
        {
            m_rawMovement = context.action.ReadValue<Vector2>();
        }
    }

    private void FixedUpdate()
    {
        Vector3 realMovement = new Vector3(m_rawMovement.x, 0, m_rawMovement.y);

        m_rigidbody.AddForce(speed * Time.deltaTime * realMovement , ForceMode.Impulse);
        Debug.Log(speed * Time.deltaTime * realMovement);
    }
}

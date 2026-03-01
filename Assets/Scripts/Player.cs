using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 5f;
    private bool isWalking = false;
    private void Update()
    {
        Vector2 inputVector = Vector2.zero;
        if (Keyboard.current.wKey.isPressed)
        {
            inputVector.y += 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            inputVector.y -= 1;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            inputVector.x -= 1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            inputVector.x += 1;
        }
        inputVector.Normalize();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        isWalking = moveDir != Vector3.zero;

        transform.position += moveDir * Time.deltaTime * moveSpeed;
        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward,moveDir, Time.deltaTime * rotationSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;
    bool movementEnabled;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        movementEnabled = true;
    }

    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        if (movementEnabled) { 
            Vector2 movement = inputVector * movementSpeed;
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            isoRenderer.SetDirection(movement);
            rbody.MovePosition(newPos);
        }
    }

    public IEnumerator DisableMovement(float time)
    {
        movementEnabled = false;
        yield return new WaitForSeconds(time);
        movementEnabled = true;
    }
}

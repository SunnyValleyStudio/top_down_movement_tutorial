using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementPhysics : MonoBehaviour
{
    private float _horizontalInput = 0;
    private float _verticalInput = 0;
    public int movementSpeed;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        MovePlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        if(_horizontalInput!=0 || _verticalInput!=0)
            RotatePlayer();
    }

    private void GetPlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        Vector3 directionVector = new Vector3(_horizontalInput, _verticalInput, 0);
        rb2D.velocity = directionVector.normalized * movementSpeed;
    }

    private void RotatePlayer()
    {
        //Atan2 - Return value is the angle between the x-axis and a 2D vector starting at zero and terminating at (x,y).
        float angle = Mathf.Atan2(_verticalInput, _horizontalInput) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerTankMovement))]
public class PlayerController : MonoBehaviour
{
    private float _horizontalInput = 0;
    private float _verticalInput = 0;
    private Vector3 _mousePosition;
    PlayerTankMovement movementScript;
    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<PlayerTankMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementScript.MovePlayer(Mathf.Abs(_verticalInput));
        if (_horizontalInput != 0)
            movementScript.RotateTankBody(_horizontalInput);

    }

    void Update()
    {
        GetPlayerInput();
        movementScript.RotateTankTurret(_mousePosition);
    }

    private void GetPlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 mousePosition3d = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition = new Vector3(mousePosition3d.x, mousePosition3d.y,0);
    }
}

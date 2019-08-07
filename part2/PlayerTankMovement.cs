using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerTankMovement : MonoBehaviour
{
    
    public int movementSpeed = 0;
    public int rotationSpeedTank = 0;
    public int rotationSpeedTurret = 0;

    Transform tankBody;
    Transform tankTurret;
    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tankBody = transform.Find("Chassie");
        tankTurret = transform.Find("Turret");

    }

    public void MovePlayer(float inputValue)
    {
        rb2d.velocity = tankBody.right*inputValue * movementSpeed;
    }


    public void RotateTankTurret(Vector3 direction)
    {
        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward,direction);
        Quaternion includingThatWeAreFacingRight = Quaternion.Euler(0, 0, desiredRotation.eulerAngles.z + 90);
        tankTurret.rotation = Quaternion.RotateTowards(tankTurret.rotation, includingThatWeAreFacingRight, rotationSpeedTurret * Time.deltaTime);

    }


    public void RotateTankBody(float inputDirection)
    {
        float rotation = -inputDirection * rotationSpeedTank;
        tankBody.Rotate(Vector3.forward * rotation);

    }



}

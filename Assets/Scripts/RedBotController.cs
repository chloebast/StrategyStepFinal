using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBotController : MonoBehaviour
{
   

    public float jumpSpeed;
    public float ySpeed;
    private int redselectedNumber;
    public CharacterController characterController;

    void Start()
    {
        RedBotSelection();
    }

    private void RedBotSelection()
    {
        int randomNumber = Random.Range(0, 2);

        if (randomNumber == 0)
        {
            redselectedNumber = 1;
        }
        else if (randomNumber == 1)
        {
            redselectedNumber = 3;
        }
        else
        {
            redselectedNumber = 5;
        }

        Debug.Log("RedBot Chose: " + redselectedNumber);

        StartCoroutine(WaitAndPerformTask());
    }

    IEnumerator WaitAndPerformTask()
    {
        int randomNumber2 = Random.Range(0, 5);
        yield return new WaitForSeconds(randomNumber2);

        // Reset ySpeed before jump
        ySpeed = 0f;

        // Perform jump if grounded
        if (characterController.isGrounded)
        {
            ySpeed = jumpSpeed;
        }

    }

    void Update()
    {
        // Apply gravity and move the character controller
        ySpeed += Physics.gravity.y * Time.deltaTime;
        Vector3 verticalMovement = Vector3.up * ySpeed * Time.deltaTime;
        characterController.Move(verticalMovement);
    }

    
}

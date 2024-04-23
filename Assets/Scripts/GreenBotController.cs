using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBotController : MonoBehaviour
{


    public float jumpSpeed;
    public float ySpeed;
    private int greenselectedNumber;
    public CharacterController characterController;

    void Start()
    {
        GreenBotSelection();
    }

    private void GreenBotSelection()
    {
        int randomNumber = Random.Range(0, 2);

        if (randomNumber == 0)
        {
            greenselectedNumber = 1;
        }
        else if (randomNumber == 1)
        {
            greenselectedNumber = 3;
        }
        else
        {
            greenselectedNumber = 5;
        }

        Debug.Log("GreenBot Chose: " + greenselectedNumber);

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

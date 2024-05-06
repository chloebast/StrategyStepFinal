using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBotController : MonoBehaviour
{


    public int yellowselectedNumber;
    
    public float jumpSpeed;
    public float ySpeed;
    public CharacterController characterController;
    public bool yBotJumped;
    

    void Start()
    {

        YellowGO();
       
    }

    public void YellowGO()
    {
        StartCoroutine(WaitAndPerformTask());
        YellowBotSelection();
    }

    private void YellowBotSelection()
    {
        int randomNumberY = Random.Range(0, 3);

        if (randomNumberY == 0)
        {
            yellowselectedNumber = 1;
        }
        else if (randomNumberY == 1)
        {
            yellowselectedNumber = 3;
        }
        else if (randomNumberY == 2)
        {
            yellowselectedNumber = 5;
        }

        Debug.Log("YellowBot Chose: " + yellowselectedNumber);

    }



    public IEnumerator WaitAndLogY(int stairsNumberY)
    {
        yield return new WaitForSecondsRealtime(5f);
       // Debug.Log($"Yellow is jumping {stairsNumberY} stairs");
        
       

        Vector3 targetPosition = Vector3.zero;
        switch (yellowselectedNumber)
        {
            case 1:
                targetPosition = new Vector3(0f, 1f, 2f);
                break;
            case 3:
                targetPosition = new Vector3(0f, 3f, 5.5f);
                break;
            case 5:
                targetPosition = new Vector3(0f, 2.7f, 8.7f);
                break;
            default:
                Debug.LogError("Invalid yellowselectedNumber.");
                break;
        }

        characterController.Move(targetPosition - transform.position);


    }

    IEnumerator WaitAndPerformTask()
    {
        float randomNumber2 = Random.Range(1f, 5f);
        yield return new WaitForSeconds(randomNumber2);
        //Debug.Log("Yellow is waiting " + randomNumber2 + " before jump");

        ySpeed = 0f;
        

        if (characterController.isGrounded)
        {
            ySpeed = jumpSpeed;
            //ySpeed = Mathf.Clamp(ySpeed, -jumpSpeed, jumpSpeed);
        }
        yBotJumped = true;


    }

    void FixedUpdate()
    {

        ySpeed += Physics.gravity.y * Time.deltaTime;
        Vector3 verticalMovement = Vector3.up * ySpeed * Time.deltaTime;
        characterController.Move(verticalMovement);
    }

}

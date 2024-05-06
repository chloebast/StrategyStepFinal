using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBotController : MonoBehaviour
{
    
    public int redselectedNumber;
    public float jumpSpeed;
    public float ySpeed;
    public CharacterController characterControllerR;
    public bool rBotJumped;

    void Start()
    {
        RedGO();
    }

   public void RedGO()
    {
        //do these each time cams turn off
        RedBotSelection();
        StartCoroutine(WaitAndPerformTaskR());
    }

    IEnumerator WaitAndPerformTaskR()
    {
        float randomNumber2 = Random.Range(1f, 5f);
        yield return new WaitForSeconds(randomNumber2);
        //Debug.Log("Red is waiting " + randomNumber2 + " before jump");
        ySpeed = 0f;

        if (characterControllerR.isGrounded)
        {
            ySpeed = jumpSpeed;
        }
        rBotJumped= true;
}

    void RedBotSelection()
    {
        int randomNumberR = Random.Range(0, 3);

        if (randomNumberR == 0)
        {
            redselectedNumber = 1;
        }
        else if (randomNumberR == 1)
        {
            redselectedNumber = 3;
        }
        else if (randomNumberR == 2)
        {
            redselectedNumber = 5;
        }

        Debug.Log("RedBot Chose: " + redselectedNumber);


    }
    public IEnumerator WaitAndLogR(int redselectedNumber)
    {
        yield return new WaitForSecondsRealtime(5f);
        Debug.Log($"Red is jumping {redselectedNumber} stairs");



        Vector3 targetPosition = Vector3.zero;
        switch (redselectedNumber)
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
                Debug.LogError("Invalid redselectedNumber.");
                break;
        }

        characterControllerR.Move(targetPosition - transform.position);


    }

    void Update()
    {
        
        ySpeed += Physics.gravity.y * Time.deltaTime;
        Vector3 verticalMovement = Vector3.up * ySpeed * Time.deltaTime;
        characterControllerR.Move(verticalMovement);
    }
    

}



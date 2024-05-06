using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenBotController : MonoBehaviour
{


    public float jumpSpeed;
    public float ySpeed = 0;
    public CharacterController characterController;
    public bool gBotJumped;
    public int greenselectedNumber;

    
   void Start()
   {

        GreenGO();
   }

   public void GreenGO()
    {
        StartCoroutine(WaitAndPerformTask());
        GreenBotSelection();
    }

   IEnumerator WaitAndPerformTask()
   {
       float randomNumber2 = Random.Range(1f, 5f);
       yield return new WaitForSeconds(randomNumber2);
       //Debug.Log("Green is waiting " + randomNumber2 + " before jump");
       ySpeed = 0f;

       if (characterController.isGrounded)
       {
           ySpeed = jumpSpeed;
       }
       gBotJumped = true;

   }
    

  void GreenBotSelection()
  {
      int randomNumberG = Random.Range(0, 3);

      if (randomNumberG == 0)
      {
          greenselectedNumber = 1;
      }
      else if (randomNumberG == 1)
      {
          greenselectedNumber = 3;
      }
      else if (randomNumberG == 2)
      {
          greenselectedNumber = 5;
      }

      Debug.Log("GreenBot Chose: " + greenselectedNumber);


  }

   public IEnumerator WaitAndLogG(int stairsNumberG)
  {
      yield return new WaitForSecondsRealtime(5f);
     // Debug.Log($"Green is jumping {stairsNumberG} stairs");



      Vector3 targetPosition = Vector3.zero;
      switch (greenselectedNumber)
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
              Debug.LogError("Invalid greenselectedNumber.");
              break;
      }

      characterController.Move(targetPosition - transform.position);


  }

    
    void Update()
  {

      ySpeed += Physics.gravity.y * Time.deltaTime;
      Vector3 verticalMovement = Vector3.up * ySpeed * Time.deltaTime;
      characterController.Move(verticalMovement);
  }
  

}

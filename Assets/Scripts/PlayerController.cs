using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class PlayerController : MonoBehaviour
{

    public Camera mainCamera;
    //public GameObject Player;
    public GameObject RedBot;
    public GameObject GreenBot;
    public GameObject YellowBot;

    public int playerselection;
   

    //for jumping
    public float jumpSpeed;
    public float ySpeed;
    public CharacterController characterController;
    public bool pJumped;


    //for timer
    private float timer;
    public float TimeLeft;
    public bool TimerOn = false;
    public TextMeshProUGUI TimerTxt;

    private bool hasSelectedNumber;
    //for camera cut scene
    
    public RawImage rawImagebackground;

    public RawImage rawImagePlayerCam;
    public RawImage rawImageRedCam;
    public RawImage rawImageGreenCam;
    public RawImage rawImageYellowCam;
    public RawImage instructionPic;
    public TextMeshProUGUI PlayerPick;
    public TextMeshProUGUI RedPick;
    public TextMeshProUGUI GreenPick;
    public TextMeshProUGUI YellowPick;
    public int yellowselectedNumber;
    public int redselectedNumber;
    public int greenselectedNumber;
    private int playerautoselectedNumber;

    //for player faces
    public TextMeshProUGUI PlayerFace;
    public TextMeshProUGUI RedFace;
    public TextMeshProUGUI GreenFace;
    public TextMeshProUGUI YellowFace;

    
    

    //public float moveSpeed = 5f;
    //public int gameround;
    public GreenBotController Gbc;
   public YellowBotController Ybc;
    public RedBotController Rbc;

    private bool camerasVisible = false;

    private void Start()
    {
        hasSelectedNumber = false;
        TimeLeft = 10f;
        TimerOn = true;
        mainCamera.gameObject.SetActive(true);
        HideCameras();


      


    }
  

    void Update()
    {
        PlayerJump();

        ySpeed += Physics.gravity.y * Time.deltaTime;
        Vector3 verticalMovement = Vector3.up * ySpeed * Time.deltaTime;
        characterController.Move(verticalMovement);




        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                TimerTxt.text = Mathf.RoundToInt(TimeLeft).ToString();
            }
            else if (TimeLeft <= 0)
            {
                TimeLeft = 0;
                TimerOn = false;
                Debug.Log("Times Up!");

                if (hasSelectedNumber == false)
                {
                    //PlayerAutoSelection();
                }

                StartCoroutine(WaitthenSwitchScene());


            }

            if (Ybc.yBotJumped && Rbc.rBotJumped && Gbc.gBotJumped && pJumped)
            {
                StartCoroutine(WaitthenSwitchScene());
                
            }
        }


       



    }
    void PlayerJump()
    {

  
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ySpeed = 0f;
                if (characterController.isGrounded && !pJumped)
                {
                    ySpeed = jumpSpeed;
                playerselection = 3;
                Debug.Log("Player Selected 3");
                pJumped = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ySpeed = 0f;
                if (characterController.isGrounded && !pJumped)
                {
                    ySpeed = jumpSpeed;
                pJumped = true;
                playerselection = 5;
                Debug.Log("Player Selected 5");
            }
        }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ySpeed = 0f;
                if (characterController.isGrounded && !pJumped)
                {
                    ySpeed = jumpSpeed;
                pJumped = true;
                playerselection = 1;
                Debug.Log("Player Selected 1");
            }
        }
        
       
    }


    IEnumerator WaitthenSwitchScene()
    {
        TimerOn = false;
        yield return new WaitForSecondsRealtime(1f);
        camerasVisible = true;
        UnhideCameras();
        yield return new WaitForSecondsRealtime(5f); 
        camerasVisible = false;
        HideCameras();

    }




    

    IEnumerator WaitAndLogP(int stairsNumber)
    {
        yield return new WaitForSecondsRealtime(5f);
        Debug.Log($"Player is jumping {stairsNumber} stairs");

        Vector3 newPosition = characterController.transform.position;

        if (playerselection == 1)
        {
            newPosition += new Vector3(0f, 0.5f, 2.5f);
        }
        if (playerselection == 3)
        {
            newPosition += new Vector3(0f, 1.5f, 5.5f);
        }
        if (playerselection == 5)
        {
            newPosition += new Vector3(0f, 2.5f, 8.5f);
        }

        characterController.transform.position = newPosition;

    }

   


    public void HideCameras()
    {
        if (camerasVisible == false)
        {

            
            rawImagebackground.enabled = false;
            rawImagePlayerCam.enabled = false;
            rawImageRedCam.enabled = false;
            rawImageGreenCam.enabled = false;
            rawImageYellowCam.enabled = false;
            PlayerPick.text = ("");
            RedPick.text = ("");
            GreenPick.text = ("");
            YellowPick.text = ("");
            PlayerFace.text = ("");
            RedFace.text = ("");
            GreenFace.text = ("");
            YellowFace.text = ("");
            TimerTxt.text = ("");
            pJumped = false;
            Rbc.rBotJumped = false;
            Gbc.gBotJumped = false;
            Ybc.yBotJumped = false;
            TimeLeft = 10f;
            TimerOn = true;
            
            Rbc.RedGO();
            Gbc.GreenGO();
            Ybc.YellowGO();

        }
    }


    
        void UnhideCameras()
        {
        if (camerasVisible == true)
        {
            Debug.Log("yescameras");
            camerasVisible = true;
            instructionPic.enabled = false;
            rawImagebackground.enabled = true;
            rawImagePlayerCam.enabled = true;
            rawImageRedCam.enabled = true;
            rawImageGreenCam.enabled = true;
            rawImageYellowCam.enabled = true;

            PlayerPick.text = playerselection.ToString();
            RedPick.text = Rbc.redselectedNumber.ToString();
            GreenPick.text = Gbc.greenselectedNumber.ToString();
            YellowPick.text = Ybc.yellowselectedNumber.ToString();


            CompareNumbersFaceChange();
        }
        }

    

    void CompareNumbersFaceChange()
    {

        if (playerselection != Rbc.redselectedNumber &&
        playerselection != Gbc.greenselectedNumber &&
        playerselection != Ybc.yellowselectedNumber)
        {
            PlayerFace.text = ":)";
            StartCoroutine(WaitAndLogP(playerselection));
        }
        else
        {
            PlayerFace.text = ":(";
        }

        if (Rbc.redselectedNumber != playerselection &&
        Rbc.redselectedNumber != Gbc.greenselectedNumber &&
        Rbc.redselectedNumber != Ybc.yellowselectedNumber)
        {
            RedFace.text = ":)";
            StartCoroutine(Rbc.WaitAndLogR(Rbc.redselectedNumber));
        }
        else
        {
            RedFace.text = ":(";
        }

        if (Gbc.greenselectedNumber != playerselection &&
        Gbc.greenselectedNumber != Rbc.redselectedNumber &&
        Gbc.greenselectedNumber != Ybc.yellowselectedNumber)
        {
            GreenFace.text = ":)";
            StartCoroutine(Gbc.WaitAndLogG(Gbc.greenselectedNumber));
        }
        else
        {
            GreenFace.text = ":(";
        }

        if (Ybc.yellowselectedNumber != playerselection &&
        Ybc.yellowselectedNumber != Gbc.greenselectedNumber &&
        Ybc.yellowselectedNumber != Rbc.redselectedNumber)
        {
            YellowFace.text = ":)";
            StartCoroutine(Ybc.WaitAndLogY(Ybc.yellowselectedNumber));
        }
        else
        {
            YellowFace.text = ":(";
        }

    }

    


}

  
    /*
         void PlayerAutoSelection()
        {
            int randomNumberP = Random.Range(0, 3);

            if (randomNumberP == 0)
            {
                playerselection = selection1;
            }
            else if (randomNumberP == 1)
            {
                playerselection = selection3;
            }
            else if (randomNumberP == 2)
            {
                playerselection = selection5;
            }

            Debug.Log("Player didnt pick, so they have: " + playerselection);

        }

        



    */







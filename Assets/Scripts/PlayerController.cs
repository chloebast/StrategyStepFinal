using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    private float timer;
    public GameObject Player;
    public GameObject RedBot;
    public GameObject GreenBot;
    public GameObject YellowBot;
    private int selection1 = 1;
    private int selection3 = 3;
    private int selection5 = 5;
    private int playerselection;


    //for jumping
    public float jumpSpeed;
    public float ySpeed;
    public CharacterController characterController;

    //for timer
    public float TimeLeft;
    public bool TimerOn = false;

    public TextMeshProUGUI TimerTxt;
    private void Start()
    {
        TimeLeft = 10f;
        TimerOn = true;
        mainCamera.gameObject.SetActive(true);
    }

    public void Update()
    {
     
        PlayerJump();

        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                //TimerTxt.text = TimeLeft.ToString(""+TimeLeft);
                TimerTxt.text = Mathf.RoundToInt(TimeLeft).ToString();
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
            }
        }

    }

   
  
    private void PlayerJump()
    {

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            ySpeed = jumpSpeed;
            playerselection = selection3;
            Debug.Log("Player selected 3");
        }
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.RightArrow))
        {
            ySpeed = jumpSpeed;
            playerselection = selection5;
            Debug.Log("Player selected 5");

        }
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ySpeed = jumpSpeed;
            playerselection = selection1;
            Debug.Log("Player selected 1");
        }

        Vector3 verticalMovement = Vector3.up * ySpeed * Time.deltaTime;
        characterController.Move(verticalMovement);

    }





}

  



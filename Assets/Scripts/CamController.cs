using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamController : MonoBehaviour
{
    public float moveSpeed = 30f;

    // The target position where the image should move
    public Vector3 targetPosition = new Vector3(-300, 0, 0);


    public void CamMoveIn()
    {
        Vector3 newPosition = transform.position + targetPosition;

        Debug.Log("camslidein");
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }
       
    
}

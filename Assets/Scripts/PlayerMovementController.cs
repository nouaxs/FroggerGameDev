using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField] private float stepsInterval = 0.2f;  // time interval in seconds between each step when holding a key down
    private Rigidbody2D rb;
    private bool isMoving;
    private Vector3 curPosi, nextPosi;

    
    /// Awake is called when the script instance is being loaded.
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    private void MovePlayer() {
        Vector3 moveDirection = Vector3.zero;
        Quaternion charRotation = transform.rotation;
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !isMoving) {   
            moveDirection += Vector3.up;
            charRotation = Quaternion.Euler(0f,0f,0f);

        }
        
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !isMoving) {  
            moveDirection += Vector3.left;
            //charRotation = Quaternion.Euler(0f,0f,90f);
            rb.SetRotation(90);
            

        } 
        
        if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !isMoving) {  
            moveDirection += Vector3.right;
            charRotation = Quaternion.Euler(0f,0f,-90f);
            

        } 
        
        if((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !isMoving) {
            moveDirection += Vector3.down;
            charRotation = Quaternion.Euler(0f,0f,180f);
        }

        if (moveDirection != Vector3.zero)
        {
            transform.rotation = charRotation;
            StartCoroutine(UpdatePosition(moveDirection));
        }
    }

    private IEnumerator UpdatePosition(Vector3 target)
    {
        isMoving = true;
        float elapsedTime = 0f;
        curPosi = transform.position;
        nextPosi = curPosi + target; //the final location we want to reach
        float journeyLength = Vector3.Distance(curPosi, nextPosi);

        while(elapsedTime < stepsInterval) {
            float completedFrac = elapsedTime/stepsInterval;
            transform.position = Vector3.Lerp(curPosi, nextPosi, completedFrac);
            // Gives a non smooth transition
            // Vector3 newPosi = Vector3.Lerp(curPosi, nextPosi, completedFrac);
            // transform.position = new Vector3(Mathf.RoundToInt(newPosi.x), Mathf.RoundToInt(newPosi.y), Mathf.RoundToInt(newPosi.z));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = nextPosi;
        isMoving = false;

    }
}

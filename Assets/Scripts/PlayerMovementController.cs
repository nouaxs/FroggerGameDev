using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField] private float stepsInterval = 0.2f;
    //private const float STEP_SIZE = 2f;
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
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !isMoving) {   
            //StartCoroutine(UpdatePosition(Vector3.up));
            moveDirection += Vector3.up;
            transform.rotation = Quaternion.Euler(0f,0f,0f);

        }
        
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !isMoving) {  
            //StartCoroutine(UpdatePosition(Vector3.left));
            moveDirection += Vector3.left;
            transform.rotation = Quaternion.Euler(0f,0f,90f);
            

        } 
        
        if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !isMoving) {  
            //StartCoroutine(UpdatePosition(Vector3.right));
            moveDirection += Vector3.right;
            transform.rotation = Quaternion.Euler(0f,0f,-90f);
            

        } 
        
        if((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !isMoving) {  
            //StartCoroutine(UpdatePosition(Vector3.down));
            moveDirection += Vector3.down;
            transform.rotation = Quaternion.Euler(0f,0f,180f);
        }

        if (moveDirection != Vector3.zero)
        {
            
            StartCoroutine(UpdatePosition(moveDirection));
        }
    }

    private IEnumerator UpdatePosition(Vector3 target)
    {
        isMoving = true;
        float elapsedTime = 0f;
        curPosi = transform.position;
        nextPosi = curPosi + target;
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

    // private void MovePlayer()
    // {
    //     float horizontalInput = Input.GetAxisRaw("Horizontal");
    //     float verticalInput = Input.GetAxisRaw("Vertical");

        
    //     // Calculate the direction vector based on the input axes
    //     //Vector3 direction = new Vector3(horizontalInput, verticalInput, 0f );
    //    // direction = direction.normalized * stepsInterval * Time.deltaTime;
    //     //rb.MovePosition(rb.transform.position + direction);

    //     // // Normalize the direction vector to ensure consistent movement speed
    //     // if (direction.magnitude > 1f)
    //     // {
    //     //     direction.Normalize();
    //     // }

    //     // // Move the player based on the direction vector and speed
    //     // transform.Translate(direction * stepsInterval * Time.deltaTime);

    //     // if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
    //     //     UpdatePosition(Vector3.up);
    //     // }

    //     // transform.position = Vector3.MoveTowards(transform.position, middlePoint.position, stepsInterval * Time.deltaTime);

    //     // if (Mathf.Abs(horizontalInput) == 1f) 
    //     // {
    //     //     middlePoint.position += new Vector3(horizontalInput, 0f, 0f );
    //     // }

    //     // if (Mathf.Abs(verticalInput) == 1f) 
    //     // {
    //     //     middlePoint.position += new Vector3(0f, verticalInput, 0f );
    //     // }

    //     // Set movement direction
    //     posi.x = Mathf.Round(horizontalInput);
    //     posi.z = Mathf.Round(verticalInput);

    //     // Normalize movement direction
    //     posi = posi.normalized;

    //     // Move player by stepSize in movement direction
    //     transform.position += posi * STEP_SIZE * stepsInterval * Time.deltaTime;

    // }

    // private void UpdatePosition(Vector3 direction) 
    // {
    //     Vector3 position = rb.position;
    // }

    //  private void Move(Vector3 direction) {
    //     rb = GetComponent<Rigidbody2D>();
    //     Vector3 position = rb.position;
    //     Vector3 nextStep =  transform.position + direction;

    //     Collider2D barrier = Physics2D.OverlapBox(nextStep, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));


    //     if (barrier != null) {
    //          transform.position = transform.position;
    //     } else {
    //         transform.position += direction;
    //     }
    // }


}

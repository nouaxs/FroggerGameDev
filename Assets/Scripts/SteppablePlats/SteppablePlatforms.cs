//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UIElements;

//[RequireComponent(typeof(Rigidbody2D))]
//public abstract class SteppablePlatforms : MonoBehaviour
//{
//    [SerializeField] private float speed = 1f;
//    [SerializeField] private float minSubmergeTime = 1.2f;
//    [SerializeField] private float minAfloatTime = 1.5f;
//    [SerializeField] private float maxSubmergeTime = 1.8f;
//    [SerializeField] private float maxAfloatTime = 4f;
//    [SerializeField] private Rigidbody2D rb;
//    protected float submergeTime;
//    protected float afloatTime;
//    protected bool doesSink = false;
//    protected bool isSubmerged = false;
//    protected float changeCountdown;
//    protected float lastChangeTime;
//    protected float nextChangeTime;
//    //protected Vector2 size = Vector2.one;

//    protected virtual void Awake()
//    {
//        if (doesSink)
//        {
//            submergeTime = Random.Range(minSubmergeTime, maxSubmergeTime);
//            afloatTime = Random.Range(minAfloatTime, maxAfloatTime);
//            nextChangeTime = Random.Range(minSubmergeTime, maxSubmergeTime);

//            isSubmerged = Random.value < 0.5f;
//        }
//        else
//        {
//            doesSink = false;
//        }

//        rb = GetComponent<Rigidbody2D>();
//    }

//    protected virtual void FixedUpdate()
//    {
//        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
//        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);

//        if (doesSink)
//        {
//            lastChangeTime += Time.fixedDeltaTime;

//            // Checking if it is time to change the state
//            if (lastChangeTime >= nextChangeTime)
//            {
//                ToggleSubmerge();

//                // Resetting the countdown and the time till next state change
//                if (isSubmerged)
//                {
//                    nextChangeTime = submergeTime;
//                } else
//                {
//                    nextChangeTime = afloatTime;
//                }
//                lastChangeTime = 0f;
//            }
//        }
//    }

//    protected abstract void ToggleSubmerge();
//}

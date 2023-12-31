using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerSpeed = 3f;
    public Transform targetTransform;
    bool isHitting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.H))
        {
            isHitting = true;
        }else if (Input.GetKeyUp(KeyCode.H))
        {
            isHitting= false;
        }
        if (isHitting)
        {
            //set hitting target
            targetTransform.Translate(new Vector3 (horizontalMove, 0,0) * playerSpeed * Time.deltaTime);
        }
        //move player based on arrow keys
        if ((horizontalMove != 0 || verticalMove != 0) && !isHitting)
        {
            transform.Translate(new Vector3 (horizontalMove,0 ,verticalMove) * playerSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            //ball direction
            Vector3 direction = targetTransform.position - transform.position;
            //hit the ball
            other.GetComponent<Rigidbody>().velocity = direction.normalized * 15 + new Vector3(0,6,0);
            
        }
    }
}

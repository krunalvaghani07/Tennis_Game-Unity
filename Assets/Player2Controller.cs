using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    float botSpeed = 50;
    public Transform targetTransform;
    public Transform ballTransform;
    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //move second player as per ball position
        targetPosition.x = ballTransform.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, botSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 direction = targetTransform.position - transform.position;
            //hit the ball 15 is force
            other.GetComponent<Rigidbody>().velocity = direction.normalized * 15 + new Vector3(0, 6, 0);

        }
    }
}

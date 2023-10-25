using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        if (horizontalMove != 0 || verticalMove != 0)
        {
            transform.Translate(new Vector3 (horizontalMove,0 ,verticalMove) * playerSpeed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    float buffer = 0.25f;
    float maxXPos;
    float minXPos;
    float jumpHeight = 7.5f;
    float maxYPos;
    float minYPos;
    // Start is called before the first frame update
    void Start()
    {
        Camera gameCamera = Camera.main;
        maxXPos = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - buffer;
        minXPos = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + buffer;
        maxYPos = gameCamera.ViewportToWorldPoint(new Vector3(1, 1, 0)).y - buffer;
        minYPos = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + buffer;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jump();
    }
    private void HorizontalMovement()
    {
        var currXPosition = gameObject.transform.position.x;
        var currYPosition = gameObject.transform.position.y;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        gameObject.transform.position = new Vector2(Mathf.Clamp(currXPosition + deltaX, minXPos, maxXPos), Mathf.Clamp(gameObject.transform.position.y, minYPos, maxYPos));
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
        }
    }
}

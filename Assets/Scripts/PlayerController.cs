using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float objectWidth, objectHeight;
    private float leftBound, rightBound, upBound, downBound;

    private Vector2 screenBounds;

    [SerializeField]
    private float speed = 2f;

    
    // Start is called before the first frame update

    void Start()
    {

        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        CalculateObjectBounds();
    }

    void CalculateObjectBounds() {

        leftBound = -screenBounds.x + objectWidth;
        rightBound = screenBounds.x - objectWidth;
        upBound = -screenBounds.y + objectHeight;
        downBound = screenBounds.y - objectHeight;
    }

    // Update is called once per frame
    void Update()
    {

        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
        
    }

    private void LateUpdate()
    {
        clampOnScreenBoundaries();
    }

    void clampOnScreenBoundaries()
    {
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBound, rightBound),
            Mathf.Clamp(transform.position.y, upBound, downBound), transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tea"))
        {
            gameObject.GetComponent<ShinyBehaviourScript>().StartBlinking();
            GameManager.gameManager.DecreaseHP();
            
        }
        
        if(collision.CompareTag("Bean"))
            {
                GameManager.gameManager.IncreasePower();
                Destroy(collision.gameObject);
               
            }  
    }

   
}

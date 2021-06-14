using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaBehaviour : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float moveSpeed;

    public Transform target;

    private Vector2 screenBounds;

    private float objectWidth, objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();

        float x = Random.Range(-10,10)/10f;
        float y = 1 - Mathf.Abs(x);

        if (Random.value > 0.5f)
        {
            y = y * -1;
        }

        rigidBody.velocity = new Vector3(x, y, 0) * moveSpeed;

        transform.position = new Vector3(Random.RandomRange(-screenBounds.x + objectWidth, screenBounds.x - objectWidth), 
            Random.RandomRange(-screenBounds.y + objectHeight, screenBounds.y - objectHeight), 0);

    }

    // Update is called once per frame
    void Update()
    {
        ChangeMovementDirection();
        
    }

    private void ChangeMovementDirection()
    {
      if ((transform.position.x - objectWidth <= screenBounds.x * -1) || (transform.position.x + objectWidth >= screenBounds.x)){
            rigidBody.velocity = new Vector3(-rigidBody.velocity.x, rigidBody.velocity.y, 0);
        }

        if ((transform.position.y - objectHeight <= screenBounds.y * -1) || (transform.position.y + objectHeight >= screenBounds.y))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, -rigidBody.velocity.y, 0);
        }
    }

}

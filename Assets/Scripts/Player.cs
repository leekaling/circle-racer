using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D playerRigidbody;

    float xAxis;
    float yAxis;
    int ch;
    float speed;
    float timer;
    SpriteRenderer spRender;
    private AudioSource sound;

    #region Editor Variables
    [SerializeField]
    [Tooltip("Freeze time")]
    private float freeze;

    [SerializeField]
    [Tooltip("Check the box if this player is on the right")]
    private bool right;

    [SerializeField]
    [Tooltip("defaultSpeed")]
    private float defaultSpeed;

    [SerializeField]
    [Tooltip("Freeze Strength")]
    private float freezePenalty;
    #endregion

    // Use this for initialization
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        sound = gameObject.GetComponent<AudioSource>();
        speed = defaultSpeed;
        timer = 0;
        ch = right ? Character2.Singleton.getCharacterInt() : Character.Singleton.getCharacterInt();
        if (ch == 0)
        {
            spRender = gameObject.GetComponent<SpriteRenderer>();
            spRender.color = new Vector4(204, 204, 204, 255);

        }
        else if (ch == 1)
        {
            spRender = gameObject.GetComponent<SpriteRenderer>();
            spRender.color = new Vector4(135.0f/255, 69.0f/255, 0, 1);
        }
        else if (ch == 2)
        {
            spRender = gameObject.GetComponent<SpriteRenderer>();
            spRender.color = new Vector4(13.0f / 255, 91.0f / 255, 0, 1);
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        xAxis = right ? Input.GetAxisRaw("Horizontal2") : Input.GetAxisRaw("Horizontal");
        yAxis = right ? Input.GetAxisRaw("Vertical2") : Input.GetAxisRaw("Vertical");
        move();
    }

    void move()
    {

        if (timer < 0)
        {
            timer = 0;
            speed = defaultSpeed;

            Color newColor = gameObject.GetComponent<SpriteRenderer>().color;
            newColor.a = 1.0f;
            gameObject.GetComponent<SpriteRenderer>().color = newColor;

        } else timer -= Time.deltaTime;

        Vector2 movementVector = new Vector2(xAxis, yAxis);
        movementVector = movementVector * speed;
        playerRigidbody.AddForce(movementVector);

        //Vector2 movementVector = new Vector2(xAxis, yAxis);
        //movementVector = movementVector * speed;
        //playerRigidbody.velocity = movementVector;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            timer = freeze;
            speed = defaultSpeed / freezePenalty;
            sound.Play();

            Color newColor = gameObject.GetComponent<SpriteRenderer>().color;
            newColor.a = 0.25f;
            gameObject.GetComponent<SpriteRenderer>().color = newColor;
        }
    }
}

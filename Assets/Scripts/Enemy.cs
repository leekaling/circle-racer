using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    #region Non-Editor Variables
    private float angle;
    #endregion

    #region Constant Variables
    private const float speed = .1f;
    #endregion

    #region First Time Initialization and Set Up
    private void Awake()
    {
        angle = Random.Range(-Mathf.PI, Mathf.PI);
        
    }
    #endregion

    #region Main Updates
    private void FixedUpdate()
    {
        float dx = Mathf.Cos(angle);
        float dy = Mathf.Sin(angle);
        transform.position -= new Vector3(speed*dx, speed*dy, 0);
        if (Mathf.Abs(transform.position.x) >= 30f || Mathf.Abs(transform.position.y) >= 30f)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Click Methods
    //private void OnMouseDown()
    //{
    //    if (gameObject.CompareTag("Good")) Score.Singleton.AddScore(1);
    //    if (gameObject.CompareTag("Bad")) Miss.Singleton.AddMiss();

    //    Destroy(gameObject);
    //}
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Scene")
        {
            Destroy(gameObject);
        }
    }


}

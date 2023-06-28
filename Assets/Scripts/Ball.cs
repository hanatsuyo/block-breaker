using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
  public GameObject Board;
  bool isLaunched = false;
  public float m_Thrust = 30f;
  Vector2 force;
  Rigidbody2D m_Rigidbody;
  Rigidbody2D m_BoardRigid;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_BoardRigid = Board.GetComponent<Rigidbody2D>();
        force = new Vector2(0.0f, m_Thrust);
    }

    // Update is called once per frame
    void Update()
    {
      if(!isLaunched) {
        Vector3 boardPosition = Board.transform.position;
        Vector3 ballPosition = this.transform.position;
        ballPosition.x = boardPosition.x;
        ballPosition.y = boardPosition.y + 0.1f;
        this.transform.Translate(ballPosition - this.transform.position);
      }

      if((Input.GetKey(KeyCode.Space) || Input.touchCount > 0) && !isLaunched) {
        isLaunched = true;
        m_Rigidbody.AddForce(force * 5);
      }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
      {
        foreach (ContactPoint2D contact in collision.contacts)
        {
          float hitPoint = Math.Abs(contact.point.x);
          float boardPosition = Board.transform.position.x;
          float hitarea = hitPoint - Math.Abs(boardPosition);
          if(boardPosition < 0) {
           hitarea *= -1; 
          }
          Debug.Log(hitarea);
          if(hitarea <= 0.6 && hitarea >= 0.3) {
            m_Rigidbody.velocity = new Vector2(6f, m_Rigidbody.velocity.y);
          }else if (hitarea < 3 && hitarea > 0) {
            m_Rigidbody.velocity = new Vector2(3f, m_Rigidbody.velocity.y);
          }else if(hitarea == 0) {
            m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y);
          }else if (hitarea < 0 && hitarea >= -0.3) {
            m_Rigidbody.velocity = new Vector2(-3f, m_Rigidbody.velocity.y);
          }else {
            m_Rigidbody.velocity = new Vector2(-6f, m_Rigidbody.velocity.y);
          }
        }
      }
    }
}

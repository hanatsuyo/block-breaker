using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectBoard : MonoBehaviour
{
    Vector3 m_mousePosition;
    Transform m_boardTransform;

    // Start is called before the first frame update
    void Start()
    {
        m_boardTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        m_mousePosition = Input.mousePosition;
        m_mousePosition.x = Mathf.Clamp( m_mousePosition.x, 0.0f, Screen.width );
        Camera gameCamera = Camera.main;
        Vector3 touchWorldPosition = gameCamera.ScreenToWorldPoint(m_mousePosition);
        Vector3 boardPosition = m_boardTransform.position;
        boardPosition.x = touchWorldPosition.x;
        m_boardTransform.position = boardPosition;
    }
}
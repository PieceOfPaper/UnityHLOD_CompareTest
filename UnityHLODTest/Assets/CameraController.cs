using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float m_MoveSpeed = 1.0f;
    [SerializeField] float m_RotateSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDir.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir.z -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x += 1;
        }
        if (Input.GetKey(KeyCode.R))
        {
            moveDir.y += 1;
        }
        if (Input.GetKey(KeyCode.F))
        {
            moveDir.y -= 1;
        }

        float rotateDir = 0f;
        if (Input.GetKey(KeyCode.T))
        {
            rotateDir -= 1f;
        }
        if (Input.GetKey(KeyCode.G))
        {
            rotateDir += 1f;
        }

        transform.Rotate(Vector3.right * rotateDir * m_RotateSpeed);
        transform.Translate(moveDir.normalized * m_MoveSpeed * Time.deltaTime);
    }
}

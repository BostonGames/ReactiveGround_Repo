using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Direction Player/Object is Moving")]
    [SerializeField] Vector3 _direction = new Vector3(1, 0, 0);
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = -Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector3.right;
        }
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            0.0f,
            Mathf.Round(this.transform.position.z) + _direction.z 
            );
    }


}

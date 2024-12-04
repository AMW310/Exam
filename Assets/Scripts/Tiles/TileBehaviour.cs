using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float speed;
    public bool canMove = true;
    private float z;
    void Start()
    {
        rb.linearVelocity = new Vector2(0, -speed);
        z = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.linearVelocity.y);

        if(rb.linearVelocity.y == 0f)
        {
            canMove = false;
            rb.freezeRotation = true;
            rb.constraints = (rb.constraints & RigidbodyConstraints2D.FreezePositionY);

        }
    }

    public void RotateLeft()
    {
        z += 90f;
        rb.MoveRotation(z);
    }

    public void RotateRight()
    {
        z -= 90f;
        rb.MoveRotation(z);
    }
    public void IncreaseSpeed()
    {
        ++speed;
    }
}

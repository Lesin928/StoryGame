using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    [SerializeField]
    private float moveSpeed = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMove(InputValue inputValue)
    {
        float input = inputValue.Get<Vector2>().x;

        //Debug.Log("Key : " + input);

        if (Mathf.Abs(input) > 0)
        {
            rigidbody2D.linearVelocity = input * Vector2.right * moveSpeed;
        }
        else
        {
            rigidbody2D.linearVelocity = Vector2.zero;
        }
    }
}

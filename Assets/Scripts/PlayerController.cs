using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >=12)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup_1"))
        {
            count++;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Pickup_5"))
        {
            count += 5;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Pickup_15"))
        {
            count += 15;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Respawn"))
        {
            rb.velocity = Vector3.zero;
            count--;
            if (count < 0)
            {
                count = 0;
            }
            SetCountText();
        }


    }
}

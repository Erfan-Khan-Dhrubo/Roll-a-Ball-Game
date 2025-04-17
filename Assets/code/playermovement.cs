using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playermovement : MonoBehaviour
{
    
    public float speed;
    public TMP_Text countText;
    public TMP_Text winText;
    
    private Rigidbody _rb;
    private int _count;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        countText.text = "Count: " + _count.ToString();
        winText.text = "";
    }

    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rb.AddForce(movement * speed);
    }

    
    //This function activated when the ball triggered any box 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            _count++;
            countText.text = "Count: " + _count.ToString();
            if (_count >= 12)
            {
                winText.text = "You Win!";
            }
        }
    }
}

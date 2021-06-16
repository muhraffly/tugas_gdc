using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float kecepatan, scaleX, lompat;
    public int jumpCount, jumpValue;

    public bool isGrounded = true;
    void Start()
    {
        scaleX = transform.localScale.x;
    }

    public void jalan_kiri()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            GetComponent<Animator>().SetTrigger("isWalking");
        }
        transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
        transform.Translate(Vector3.left * kecepatan * Time.fixedDeltaTime, Space.Self);
    }

    public void jalan_kanan()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            GetComponent<Animator>().SetTrigger("isWalking");
        }
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        transform.Translate(Vector3.right * kecepatan * Time.fixedDeltaTime, Space.Self);
    }

    public void melompat()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * lompat;
        isGrounded = false;
        jumpCount--;
    }

    void berhenti()
    {
        GetComponent<Animator>().SetTrigger("stop");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            jalan_kiri();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            jalan_kanan();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount > 0)
        {
            melompat();
        }
        if(isGrounded)
        {
            jumpCount = jumpValue;
        }
        if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)){
            berhenti();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrounded)
        {
            isGrounded = true;

        }
    }
}

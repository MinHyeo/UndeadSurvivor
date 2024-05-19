using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 inputVec;
    public Scanner scanner;
    public Hand[] hands;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>(true);
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        rb.velocity = inputVec * speed;
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        anim.SetFloat("Speed", inputVec.magnitude);

        if(inputVec.x != 0){
            sr.flipX = inputVec.x < 0;
        }
    }
}

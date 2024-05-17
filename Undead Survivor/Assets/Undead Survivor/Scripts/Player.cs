using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;
    public Vector2 inputVec;
    public Scanner scanner;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    private void FixedUpdate()
    {
        rb.velocity = inputVec * speed;
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if(inputVec.x != 0){
            sr.flipX = inputVec.x < 0;
        }
    }
}

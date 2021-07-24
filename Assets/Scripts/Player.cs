using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Player : MonoBehaviour
{
    
    
    private BoxCollider2D _boxCollider;

    private Vector3 _moveDelta;
    
    private RaycastHit2D hit;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        
        // Reset MoveDelta
        _moveDelta = new Vector3(x,y,0);

        if (_moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (_moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        
        //make u no ghost thru wall
        hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, _moveDelta.y),
            Mathf.Abs(_moveDelta.y * Time.deltaTime), LayerMask.GetMask("Dude", "Blocking"));
        if (hit.collider == null)
        
        transform.Translate(0,_moveDelta.y * Time.deltaTime, 0);
        
        hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0),
            Mathf.Abs(_moveDelta.x * Time.deltaTime), LayerMask.GetMask("Dude", "Blocking"));
        if (hit.collider == null)
        
        transform.Translate(_moveDelta.x * Time.deltaTime, 0, 0);






    }
}
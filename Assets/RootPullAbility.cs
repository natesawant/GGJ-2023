using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPullAbility : MonoBehaviour
{
    Collider2D coll;
    public float radius, maxDistance;
    public float pullForce;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 playerPosition = (Vector2)transform.position + coll.offset;



        //Debug.DrawRay(playerPosition, 100 * (worldPosition - playerPosition).normalized, Color.red);

        Vector2 dir = (worldPosition - playerPosition).normalized;

        RaycastHit2D hit = Physics2D.CircleCast(playerPosition, radius, dir, maxDistance);
        Debug.Log("HIT: " + hit.collider.gameObject.name);
        Debug.DrawLine(playerPosition, hit.point, Color.white);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (hit.collider.gameObject.tag)
            {
                case "Pullable":
                    Debug.Log("Pullable object hit");
                    Rigidbody2D rb = hit.rigidbody;
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    rb.gravityScale = 0f;
                    rb.AddForce(-dir * pullForce);

                    break;
                case "Solid":
                    Debug.Log("Solid object hit");
                    break;
                case "Breakable":
                    Debug.Log("Breakable object hit");
                    break;
                default:
                    Debug.Log("Unknown type hit");
                    break;
            }
        }
    }
}

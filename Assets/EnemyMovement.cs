using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
     private float startingPosition;
     private int dir = 1;
     public float range = 0.1f;
     public float speed = 0.8f;

     private void Start()
     {
          startingPosition = transform.position.y;
     }

     private void Update()
     {
          Start();
     }

     void FixedUpdate()
     {
          transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
          if(transform.position.y < startingPosition || transform.position.y > startingPosition+range)
          {
               dir *= -1;
          }
     }
}

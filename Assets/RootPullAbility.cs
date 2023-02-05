using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RootPullAbility : MonoBehaviour
{
    Collider2D coll;
    public float radius, maxDistance;
    public float pullForce, grabForce;
    IsometricPlayerMovement movementScript;
    IsometricCharacterRenderer isoRenderer;
    AudioSource audioSrc;
    public List<AudioClip> whipNoises;
    public GameObject rootWhip;
    Animator animator;
    bool invulnerable = false;


    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        movementScript = GetComponent<IsometricPlayerMovement>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        audioSrc = GetComponent<AudioSource>();
        animator = rootWhip.GetComponent<Animator>();
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
        if (hit.collider != null)
        {
            // Debug.Log("HIT: " + hit.collider.gameObject.name);
            Debug.DrawLine(playerPosition, hit.point, Color.white);

            Rigidbody2D rb;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerPosition = (Vector2)transform.position + coll.offset;
                dir = (worldPosition - playerPosition).normalized;

                //Quaternion rotation = Quaternion.LookRotation(dir);
                float zRotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion rotation =  Quaternion.Euler(new Vector3(0, 0, zRotation));
                rootWhip.transform.rotation = rotation;

                switch (hit.collider.gameObject.tag)
                {
                    case "Pullable":
                        Debug.Log("Pullable object hit");
                        rb = hit.rigidbody;
                        rb.bodyType = RigidbodyType2D.Dynamic;
                        rb.gravityScale = 0f;
                        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                        rb.drag = 3;
                        rb.AddForce(-dir * grabForce);
                        StartCoroutine(LockInPlace(0.5f, rb));
                        StartCoroutine(movementScript.DisableMovement(0.5f));
                        isoRenderer.SetDirection(dir, optional: "Pull");
                        audioSrc.clip = whipNoises[Random.Range(0, whipNoises.Count)];
                        audioSrc.Play();
                        hit.rigidbody.gameObject.GetComponent<AudioSource>().Play();
                        animator.Play("RootWhip");
                        break;
                    case "Solid":
                        Debug.Log("Solid object hit");
                        rb = GetComponent<Rigidbody2D>();
                        rb.AddForce(dir * pullForce);
                        StartCoroutine(movementScript.DisableMovement(0.4f));
                        StartCoroutine(Invulnerable(1f));
                        isoRenderer.SetDirection(dir, optional: "Pull");
                        audioSrc.clip = whipNoises[Random.Range(0, whipNoises.Count)];
                        audioSrc.Play();
                        animator.Play("RootWhip");
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

    IEnumerator Invulnerable(float time) {
        Debug.Log("SETTING TO INVULNERABLE");
        invulnerable = true;
        yield return new WaitForSeconds(time);
        invulnerable = false;
    }

    public bool isInvulnerable() {
        return invulnerable;
    }
    IEnumerator LockInPlace(float time, Rigidbody2D rb)
    {
        yield return new WaitForSeconds(time);
        //rb.bodyType = RigidbodyType2D.Static;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}

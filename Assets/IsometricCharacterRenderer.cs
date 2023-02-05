using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCharacterRenderer : MonoBehaviour
{
    public static readonly string[] staticDirections = { "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE", "Static N" };
    public static readonly string[] runDirections = { "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE", "Run N" };
    public static readonly string[] pullDirections = { "Pull NW", "Pull W", "Pull SW", "Pull S", "Pull SE", "Pull E", "Pull NE", "Pull N" };

    Animator animator;
    int lastDirection;
    AudioSource audioSrc;
    public AudioClip runNoise;
    public List<AudioClip> gruntNoises;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
    }

    public void SetDirection(Vector2 direction, string optional = "None")
    {
        string[] directionArray = null;

        if (optional == "None") {
            if (direction.magnitude < 0.01f)
            {
                directionArray = staticDirections;
                audioSrc.Stop();
            } else
            {
                directionArray = runDirections;
                lastDirection = DirectionToIndex(direction, 8);
                audioSrc.clip = runNoise;
                if (!audioSrc.isPlaying)
                {
                    audioSrc.Play();
                }

            }
            } else if (optional == "Pull") 
        {
            directionArray = pullDirections;
            lastDirection = DirectionToIndex(direction, 8);
            audioSrc.clip = gruntNoises[Random.Range(0, gruntNoises.Count)];
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
        }
        

        animator.Play(directionArray[lastDirection]);
    }

    public static int DirectionToIndex(Vector2 dir, int sliceCount) {
        Vector2 normDir = dir.normalized;
        float step = 360f / sliceCount;
        float halfstep = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        angle += halfstep;

        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}

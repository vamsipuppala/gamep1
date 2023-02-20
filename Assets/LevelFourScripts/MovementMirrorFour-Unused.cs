using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MovementMirrorFour : MonoBehaviour
{
    //Adjustable value for checkpoints - sidebeams move between 2 checkpoints
    [SerializeField] private GameObject[] MirrorEdge;

    //Starting point
    private int currentIndex = 0;

    //Moving speed
    [SerializeField] private float speed = 2f;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //If the sidebeam is close enough to one point, it will move to another
        if (UnityEngine.Vector2.Distance(MirrorEdge[currentIndex].transform.position, transform.position) < .1f)
        {
            currentIndex++;

            if (currentIndex >= MirrorEdge.Length)
            {
                currentIndex = 0;
            }

        }
        transform.position = UnityEngine.Vector2.MoveTowards(transform.position, MirrorEdge[currentIndex].transform.position, Time.deltaTime * speed);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMirrorLevel4 : MonoBehaviour
{
    //Adjustable value for checkpoints - sidebeams move between 2 checkpoints
    [SerializeField] private GameObject[] MirrorEdge;

    //Starting point
    private int currentIndex = 0;

    //Moving speed
    [SerializeField] private float speed = 2f;

    public Vector2 originalPos;

    // Start is called before the first frame update
    public bool move = true;

    private void Start()
    {
        originalPos = transform.position;
        Debug.Log("Original Pos: " + originalPos);
    }


    // Update is called once per frame
    void Update()
    {
        //If the sidebeam is close enough to one point, it will move to another
        if (Vector2.Distance(MirrorEdge[currentIndex].transform.position, transform.position) < .1f)
        {
            currentIndex++;

            if (currentIndex >= MirrorEdge.Length)
            {
                currentIndex = 0;
            }

        }
        if(move)
            transform.position = Vector2.MoveTowards(transform.position, MirrorEdge[currentIndex].transform.position, Time.deltaTime * speed);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using Unity.VisualScripting;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator amin;
    private Ray ray;
    private RaycastHit hit;

    private float x;
    private float z;
    private float velocitySpeed;

    private CinemachineTransposer ct;
    public CinemachineVirtualCamera playerCamera;
    private Vector3 pos;
    private Vector3 curPos;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        amin = GetComponent<Animator>();
        ct = playerCamera.GetCinemachineComponent<CinemachineTransposer>();
        curPos = ct.m_FollowOffset;
    }

    // Update is called once per frame
    void Update()
    {
        (x, z) = (nav.velocity.x, nav.velocity.z);
        velocitySpeed = x + z;

        pos = Input.mousePosition;
        ct.m_FollowOffset = curPos;

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                nav.destination = hit.point;    
            }
        }
        if (velocitySpeed != 0)
        {
            amin.SetBool("Sprint", true);
        }
        else
        {
            amin.SetBool("Sprint", false);
        }
        if (Input.GetMouseButton(1))
        {
            if (pos.x != 0 || pos.y != 0)
            {
                curPos = pos / 200;
            }
        }
    }
}

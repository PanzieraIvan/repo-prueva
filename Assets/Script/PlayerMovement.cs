using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    public LayerMask cape;
    private Ray myRay;
    private NavMeshAgent myAgent;
    private RaycastHit informationRay;
    //Start is called before the first frame update
    void Start()
    {
        myAgent = this.GetComponent<NavMeshAgent>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myRay, out informationRay, 100, cape))
            {
                myAgent.SetDestination(informationRay.point);
            }
        }


    }
}

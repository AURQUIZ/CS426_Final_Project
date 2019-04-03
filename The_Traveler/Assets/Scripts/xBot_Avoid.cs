using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xBot_Avoid : MonoBehaviour
{
   UnityEngine.AI.NavMeshAgent agent;
   public Transform target = null;
    
    void Start ()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    
    void Update () 
    {
        agent.SetDestination (-(target.position));
    }
}

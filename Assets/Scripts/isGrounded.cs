using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    [SerializeField] Collider boxCollider;
    RaycastHit hit;
    [SerializeField] LayerMask mask;
    //[SerializeField] float maxDistance = 1.0f;
    [SerializeField] Vector3 offset;
    public bool checkGrounded;
    void Start()
    {
        
    }

    void Update()
    {
        Grounded();
        Debug.Log("value" + checkGrounded);
    }


    void Grounded()
    {
        checkGrounded= Physics.Raycast(boxCollider.bounds.center - offset, new Vector3(0, -1, 0), out hit, boxCollider.bounds.size.y/2, mask, QueryTriggerInteraction.UseGlobal);
        
    }


    private void OnDrawGizmos()
    {
        if (checkGrounded)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(boxCollider.bounds.center - offset, Vector3.down * boxCollider.bounds.size.y / 2);
            Gizmos.DrawWireCube(boxCollider.bounds.center - offset, boxCollider.bounds.size * 0.5f);
        }



        else if (!checkGrounded)
        {
            Gizmos.color= Color.red;
            Gizmos.DrawRay(boxCollider.bounds.center - offset, Vector3.down * boxCollider.bounds.size.y / 2);
            Gizmos.DrawWireCube(boxCollider.bounds.center - offset, boxCollider.bounds.size * 0.5f);

        }
    }

}

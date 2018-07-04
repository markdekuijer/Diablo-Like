using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTeleportSkill : AbbilitySkill
{
    /* TODO teleport didnt work, try again later
    [SerializeField] private float maxRange;
    [SerializeField] private LayerMask groundMask;

    public override void Init(Vector3 position = default(Vector3))
    {
        print(position);
        RaycastHit hit;
        if (Physics.Raycast(new Ray(position, Vector3.down), out hit, Mathf.Infinity, groundMask))
            print("Hit | " + hit.point);

        float distance = Vector2.Distance(new Vector2(transform.position.x,transform.position.z), new Vector2(hit.point.x,hit.point.z));
        print(distance);
        if (true)//distance <= maxRange)
        {
            Teleport(hit.point);
            //print("inRange");
        }
        else
        {
            Vector3 newPos = transform.position - hit.point;
            newPos.Normalize();
            newPos*= maxRange;

            RaycastHit hit2;
            Physics.Raycast(new Ray(newPos + Vector3.up * 100, Vector3.down * Mathf.Infinity), out hit2, groundMask);
            newPos.y = hit.point.y;
            Teleport(newPos);
            //print("setBack");
        }
    }

    public void Teleport(Vector3 position)
    {
        gameObject.GetComponent<CharacterMovement>().SetMoveTarget(position);
        transform.position = position;
    }
    */
}

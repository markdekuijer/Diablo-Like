using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private Transform m_Player;
    [SerializeField] private Vector3 m_CameraOffset;
    [SerializeField] private float speed = 1f;
	
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, m_Player.position + m_CameraOffset, Time.deltaTime * speed);	
	}
}

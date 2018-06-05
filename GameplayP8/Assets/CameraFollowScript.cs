using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private Transform m_Player;
    [SerializeField] private Vector3 m_CameraOffset;
	
	void Update ()
    {
        transform.position = m_Player.position + m_CameraOffset;	
	}
}

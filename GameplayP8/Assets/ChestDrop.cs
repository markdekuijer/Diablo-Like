using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDrop : MonoBehaviour
{
    [SerializeField] private List<Drops> drops = new List<Drops>();
    [SerializeField] private Animator anim;
    private bool used;

	void Start ()
    {
		
	}

    private void OnMouseDown()
    {

    }

    private void OnMouseUp()
    {
        if (used || Vector3.Distance(transform.position, CharacterBehaviour.currentPosition) > 2.5f)
            return;

        anim.SetTrigger("Open");
        used = true;
        DroppedItem item = ObjectPooler.SharedInstance.GetPooledObject(3).GetComponent<DroppedItem>();
        item.gameObject.SetActive(true);
        item.transform.position = transform.position;
        item.transform.rotation = transform.rotation;
        item.Init(drops[Random.Range(0, drops.Count)]);
    }
}

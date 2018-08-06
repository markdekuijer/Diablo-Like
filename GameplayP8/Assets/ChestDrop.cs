using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDrop : MonoBehaviour
{
    [SerializeField] private List<Drops> drops = new List<Drops>();
    private bool used;

	void Start ()
    {
		
	}

    private void OnMouseDown()
    {
        if (used || Vector3.Distance(transform.position , CharacterBehaviour.currentPosition) > 2)
            return;

        DroppedItem item = ObjectPooler.SharedInstance.GetPooledObject(3).GetComponent<DroppedItem>();
        item.gameObject.SetActive(true);
        item.transform.position = transform.position;
        item.transform.rotation = Quaternion.Euler(0, 0, 0);
        item.Init(drops[Random.Range(0, drops.Count)]);
        used = true;
    }
}

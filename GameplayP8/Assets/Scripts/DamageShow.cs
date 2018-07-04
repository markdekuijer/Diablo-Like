using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageShow : MonoBehaviour
{
    public float lifeTime = 4f;
    [SerializeField] private Text text;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator Anim;
    private float colorAlpha = 255;

    public void Init(int i)
    {
        //alpha fade
        Anim.SetTrigger("Fade");
        //TODO render before everything else
        rb.velocity = Vector3.zero;
        text.text = i.ToString();
        int r = Random.Range(0, 2);
        if (r == 0)
            rb.velocity = new Vector3(0, 1, 0.75f);
        else
            rb.velocity = new Vector3(0, 1, -0.75f);
        print(rb.velocity);

    }

    private void Update()
    {
        colorAlpha -= 200f * Time.deltaTime;
    }

    void OnEnable()
    {
        StartCoroutine(Disabler());
    }

    private IEnumerator Disabler()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
}

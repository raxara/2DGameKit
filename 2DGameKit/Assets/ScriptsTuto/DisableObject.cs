using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{

    public Collider2D[] objToDisable;

    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.root.CompareTag("Player")) return;
        foreach(Collider2D c in objToDisable)
        {
            c.enabled = false;
        }
        StartCoroutine(FadeAway());
    }

    IEnumerator FadeAway()
    {
        float t = 0;
        Color color = Color.white;
        while (t < 1.1f)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, t);
            rend.material.color = color;
            yield return null;
        }
    }
}

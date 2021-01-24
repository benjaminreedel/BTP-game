using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
       if (other.gameObject.tag == "Enemy") {
            Destroy(gameObject);
       }
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * 10f * Time.deltaTime;
    }
}

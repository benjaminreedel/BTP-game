using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBullet : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}

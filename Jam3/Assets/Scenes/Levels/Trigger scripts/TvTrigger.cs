using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvTrigger : MonoBehaviour
{

    public Light tvLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tvLight.intensity = Random.Range(5f, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tvLight.GetComponent<AudioSource>().Stop();
            Destroy(tvLight);
        }
    }
}

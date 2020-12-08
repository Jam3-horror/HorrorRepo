using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvTrigger : MonoBehaviour
{
    bool light_destoyed = false;
    public Light tvLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!light_destoyed)
        {
            tvLight.intensity = Random.Range(5f, 3f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !light_destoyed)
        {
            tvLight.GetComponent<AudioSource>().Stop();
            Destroy(tvLight);
            light_destoyed = true;
        }
    }
}

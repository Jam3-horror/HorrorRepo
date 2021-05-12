using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Monster : MonoBehaviour
{
    AudioSource audioSource;
    Animator mainCamAnimator;

    private void Start()
    {
        mainCamAnimator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();

        StartCoroutine("MonsterBehaviour");
    }

    IEnumerator MonsterBehaviour()
    {
        mainCamAnimator.SetBool("Shaking", true);

        yield return new WaitForSeconds(audioSource.clip.length);

        mainCamAnimator.SetBool("Shaking", false);

        this.gameObject.SetActive(false);
    }
}

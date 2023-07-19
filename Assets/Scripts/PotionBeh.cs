using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBeh : MonoBehaviour {
    [SerializeField]
    private float potionEffectValue;

    [SerializeField]
    private float potionEffectDurancy;

    [SerializeField]
    private AudioClip potionDrunkSound;

    private AudioSource _audio;

    // Start is called before the first frame update
    void Start() {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }



    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject income = collision.gameObject;
        if ( income.tag == "Player" ) {
            MainPlayerBehaviour player = income.GetComponent<MainPlayerBehaviour>();
            if ( player != null ) {
                Debug.Log("start potion");
                player.StartCoroutine(EffectCoroutine(player));
            }
        }

    }

    private IEnumerator EffectCoroutine(MainPlayerBehaviour player) {
        player.IncreaseSpeed(this.potionEffectValue);
        player.EnableParticles();
        _audio.clip = potionDrunkSound;
        _audio.Play();
        yield return HideAndDestroyAfter(this.potionEffectDurancy);
        player.DecreaseSpeed(this.potionEffectValue);
        player.DisableParticles();
    }
    private IEnumerator HideAndDestroyAfter(float seconds) {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}

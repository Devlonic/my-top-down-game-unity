using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseBehaviour : MonoBehaviour {
    protected event EventHandler onOpen;
    protected event EventHandler onClose;

    protected Animator animator;
    protected AudioSource audioSource;

    [SerializeField]
    private AudioClip closeSound;
    [SerializeField]
    private AudioClip openSound;

    [SerializeField]
    private bool canOpen = false;
    [SerializeField]
    private bool isOpened = false;

    // Start is called before the first frame update
    protected virtual void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        onOpen += (d, e) => {
            isOpened = true;
            Debug.Log(isOpened);

            animator.StopPlayback();
            animator.Play("opening");

            audioSource.Stop();
            audioSource.clip = openSound;
            audioSource.PlayDelayed(0.2f);
        };
        onClose += (d, e) => {
            isOpened = false;
            Debug.Log(isOpened);

            animator.StopPlayback();
            animator.Play("closing");

            audioSource.Stop();
            audioSource.clip = closeSound;
            audioSource.PlayDelayed(0.2f);
        };
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        canOpen = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        canOpen = false;
    }

    // Update is called once per frame
    void Update() {
        if ( canOpen ) {
            if ( Input.GetKeyDown(KeyCode.E) && !isOpened ) {
                onOpen?.Invoke(null, null);
            }
            else if ( Input.GetKeyDown(KeyCode.E) && isOpened ) {
                onClose?.Invoke(null, null);
            }
        }
    }

    private void FixedUpdate() {

    }
}

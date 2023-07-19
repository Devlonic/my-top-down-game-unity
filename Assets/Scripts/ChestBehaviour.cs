using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestBehaviour : OpenCloseBehaviour {
    [SerializeField]
    ParticleSystem particle;

    [SerializeField]
    float fuse;

    [SerializeField]
    Vector2 startVelocity;

    private IEnumerator OpenCoroutine() {
        yield return new WaitForSeconds(fuse);

        particle.Play();
    }

    protected override void Start() {
        base.Start();

        onOpen += (d, e) => {
            Debug.Log("start particle");

            StartCoroutine(OpenCoroutine());
        };
    }
}

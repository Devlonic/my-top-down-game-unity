using System.Linq;
using UnityEngine;

public class RemoveCollisionWhenOpenedBehaviour : OpenCloseBehaviour {
    private BoxCollider2D collision;
    protected override void Start() {
        base.Start();

        //get only one NON-TRIGGER collider that has real collision

        var colliders = GetComponents<BoxCollider2D>().ToList();
        collision = colliders.First((c) => c.isTrigger == false);

        base.onOpen += (o, e) => {
            collision.enabled = false;
            Debug.Log($"open collision: {collision.enabled}");
        };
        base.onClose += (o, e) => {
            collision.enabled = true;
            Debug.Log($"close collision: {collision.enabled}");
        };
    }
}
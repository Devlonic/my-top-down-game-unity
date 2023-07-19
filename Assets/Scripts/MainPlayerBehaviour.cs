using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainPlayerBehaviour : MonoBehaviour {
    private const float DEFAULT_SPEED = 4f;

    [SerializeField]
    private float _speed = DEFAULT_SPEED;

    [SerializeField]
    private Vector2 direction = Vector2.zero;

    private Rigidbody2D _rb;
    private AudioSource _audioSource;
    private Animator _animator;
    private ParticleSystem _particles;


    private float GetAnimationSpeed() {
        return _speed / DEFAULT_SPEED;
    }
    public void IncreaseSpeed(float speed) {
        this._speed += speed;
        this._animator.speed = GetAnimationSpeed();
        this._audioSource.pitch = GetAnimationSpeed();
    }
    public void DecreaseSpeed(float speed) {
        this._speed -= speed;
        this._animator.speed = GetAnimationSpeed();
        this._audioSource.pitch = GetAnimationSpeed();
    }
    public void EnableParticles() {
        _particles.Play();
    }
    public void DisableParticles() {
        if ( _speed == DEFAULT_SPEED ) // todo remake this
            _particles.Stop();
    }

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update() {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    private Vector2 prevDirection = Vector2.zero;
    private void FixedUpdate() {
        _rb.MovePosition(_rb.position + direction * _speed * Time.fixedDeltaTime);

        _animator.SetBool("IsWalking", direction != Vector2.zero);

        const string FRONT = "DirectionFront";
        const string BACK = "DirectionBack";
        const string LEFT = "DirectionLeft";
        const string RIGHT = "DirectionRight";
        const string UNKNOWN = "DirectionUnknown";

        if ( direction != Vector2.zero && prevDirection != direction ) {
            prevDirection = direction;
            string direct = "";

            if ( direction == Vector2.down )
                direct = FRONT;
            else if ( direction == Vector2.up )
                direct = BACK;
            else if ( direction == Vector2.left )
                direct = LEFT;
            else if ( direction == Vector2.right )
                direct = RIGHT;
            else
                direct = UNKNOWN;

            _animator.ResetTrigger(FRONT);
            _animator.ResetTrigger(BACK);
            _animator.ResetTrigger(LEFT);
            _animator.ResetTrigger(RIGHT);

            _animator.SetTrigger(direct);
        }

        if ( direction != Vector2.zero && !_audioSource.isPlaying ) {
            _audioSource.Play();
        }
        else if ( direction == Vector2.zero ) {
            _audioSource.Pause();
        }
    }
}

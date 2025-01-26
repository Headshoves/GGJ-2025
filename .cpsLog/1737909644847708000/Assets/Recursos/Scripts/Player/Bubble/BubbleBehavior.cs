using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class BubbleBehavior : MonoBehaviour
{
    [SerializeField] private float initialForce = 10f;
    [SerializeField] private float scaleDuration = 2f;
    [SerializeField] private float verticalFloat = 0.5f;
    [SerializeField] private float drag = 0.1f;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private float topContactHeight = 0.5f; // Altura da bolha considerada para ser estourada
    [FormerlySerializedAs("playerImpulseOnContact")] [SerializeField] private float impulseForce = 10f;
    [SerializeField] private float sineAmplitude = 1f;
    [SerializeField] private float sineFrequency = 2f;
    [SerializeField] private Ease spawnEase = Ease.OutBack;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask scenarioLayer;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private float _startTime;
    private PlayerController _shooter;
    private PlayerController _trappedPlayer;
    private bool _playerTrapped;
    private int _escapeAttempts;

    public PlayerController SetShooter { set => _shooter = value; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody2D não encontrado");
        }
    }

    private void Start()
    {
        _rigidbody.drag = drag;
        _startTime = Time.time;

        transform.DOScale(1f, scaleDuration).From(0).SetEase(spawnEase);

        if (!_playerTrapped)
        {
            //Destroy(gameObject, lifetime);
        }
    }

    private void FixedUpdate()
    {
        if (!_playerTrapped)
        {
            // Movimento padrão da bolha
            _rigidbody.AddForce(Vector2.up * verticalFloat);

            float sineOffset = Mathf.Sin((Time.time - _startTime) * sineFrequency) * sineAmplitude;
            Vector2 perpendicular = new Vector2(-_direction.y, _direction.x);
            _rigidbody.AddForce(perpendicular * sineOffset);
        }
        else if (_trappedPlayer != null)
        {
            // Move o jogador preso junto com a bolha
            _trappedPlayer.transform.position = transform.position;
            Debug.Log(_trappedPlayer.transform.position);
        }
    }

    public void Movement(Vector2 direction)
    {
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody2D está nulo");
            return;
        }

        _direction = direction.normalized;
        _rigidbody.AddForce(_direction * initialForce, ForceMode2D.Impulse);
    }

    //tenta usar pra chegar por tag em vez de layer, parece que náo est[a reconhecendo por layer
    
    //em ultimo caso, vamos fazer algo simples, se o inimigo colidir com a bolha, ele e empurrado
    //tem muita logica de bolha e nao aplicamos nada disso ainda na build final, assim nao vamos ter o que entregar
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("COLIDIU COM O CENÁRIO");
            // Destroi a bolha se tocar no cenário e não estiver com um jogador preso
            if (!_playerTrapped)
                gameObject.SetActive(false);
        }
        else if (collision.gameObject.layer == enemyLayer)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                if (!_playerTrapped && player != _shooter)
                {
                    Debug.Log("COLIDIU COM O INIMIGO");
                    // Prende o jogador inimigo
                    TrapPlayer(player);
                }
                else if (_playerTrapped && player == _shooter)
                {
                    // Verifica se o jogador que disparou a bolha pulou na parte superior dela
                    Vector2 collisionPoint = collision.contacts[0].point;
                    if (collisionPoint.y > transform.position.y + topContactHeight) // Apenas parte superior da bolha
                    {
                        Debug.Log("DERROTOU O INIMIGO");
                        // Mata o jogador preso
                        KillTrappedPlayer();
                    }
                }
                else if (player == _shooter)
                {
                    // Detecta se o jogador que disparou pulou na bolha para aplicar impulso
                    Vector2 collisionPoint = collision.contacts[0].point;
                    if (collisionPoint.y > transform.position.y + topContactHeight) // Apenas parte superior da bolha
                    {
                        Debug.Log("IMPULSIONOU O JOGADOR");
                        // Aplica um impulso no jogador
                        Vector2 forceDirection = (collision.transform.position - transform.position).normalized;
                        player.GetComponent<Rigidbody2D>().AddForce(forceDirection * impulseForce, ForceMode2D.Impulse);

                        // Estoura a bolha
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }


    private void TrapPlayer(PlayerController player)
    {
        _playerTrapped = true;
        _trappedPlayer = player;
        _trappedPlayer.enabled = false; // Desativa os controles do jogador preso
        _trappedPlayer.GetComponent<CapsuleCollider>().enabled = false; // Desativa a colisão do jogador preso
        _escapeAttempts = 0;

        //CancelInvoke(nameof(DestroyBubble));
        //Invoke(nameof(DestroyBubble), lifetime + 2f); // Extende o tempo de vida da bolha
    }

    public void AttemptEscape()
    {
        if (_playerTrapped)
        {
            _escapeAttempts++;
            if (_escapeAttempts >= 10)
            {
                ReleasePlayer();
            }
        }
    }

    private void ReleasePlayer()
    {
        if (_trappedPlayer != null)
        {
            // Restaura os controles do jogador preso
            _trappedPlayer.enabled = true;
            _trappedPlayer.GetComponent<CapsuleCollider>().enabled = true;

            // Restaura a posição do jogador para evitar comportamentos estranhos
            _trappedPlayer.transform.position = transform.position;

            // Libera a referência ao jogador preso
            _trappedPlayer = null;
        }

        _playerTrapped = false;

        // Destroi a bolha
        gameObject.SetActive(false);
    }


    private void DestroyBubble()
    {
        if (_playerTrapped)
        {
            ReleasePlayer();
        }

        gameObject.SetActive(false);
    }

    private void KillTrappedPlayer()
    {
        if (_trappedPlayer != null)
        {
            _trappedPlayer.gameObject.SetActive(false); // Remove o jogador preso
        }

        _playerTrapped = false;
        gameObject.SetActive(false);
    }
}

using System;
using DG.Tweening;
using UnityEngine;

public class BubbleBehavior : MonoBehaviour
{
    [SerializeField] private float initialForce = 10f;
    [SerializeField] private float scaleDuration = 2f;
    [SerializeField] private float verticalFloat = 0.5f;
    [SerializeField] private float drag = 0.1f;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private float sineAmplitude = 1f;
    [SerializeField] private float sineFrequency = 2f; 
    [SerializeField] private Ease spawnEase = Ease.OutBack;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction; // Direção inicial
    private float _startTime;
    private PlayerController _shooter;

    // Define o jogador responsável por atirar a bolha
    public PlayerController SetShooter {set => _shooter = value; }

    private void Awake()
    {
        // Inicializa o Rigidbody2D no Awake para garantir que ele esteja configurado
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody2D não encontrado! Verifique se o componente está anexado ao objeto.");
        }
    }

    private void Start()
    {
        _rigidbody.drag = drag;
        _startTime = Time.time;

        // Escala de surgimento da bolha
        transform.DOScale(1f, scaleDuration).From(0).SetEase(spawnEase);

        // Após o tempo determinado, a bolha estoura
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        // Adiciona flutuação vertical
        if (_rigidbody != null)
        {
            _rigidbody.AddForce(Vector2.up * verticalFloat);

            // Calcula o deslocamento senoidal
            float sineOffset = Mathf.Sin((Time.time - _startTime) * sineFrequency) * sineAmplitude;

            // Cria o vetor de deslocamento senoidal perpendicular à direção inicial
            Vector2 perpendicular = new Vector2(-_direction.y, _direction.x);

            // Aplica o deslocamento senoidal como força adicional (preserva a física)
            _rigidbody.AddForce(perpendicular * sineOffset);
        }
    }

    public void Movement(Vector2 direction)
    {
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody2D está nulo. Verifique se o objeto foi inicializado corretamente.");
            return;
        }

        // Armazena a direção inicial e aplica força para movimentação
        _direction = direction.normalized;
        _rigidbody.AddForce(_direction * initialForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Scenario"))
        {
            Destroy(gameObject); // Estoura a bolha ao encostar no cenário
        }
        else if (collision.gameObject.CompareTag("Bubble"))
        {
            var otherBubble = collision.gameObject.GetComponent<BubbleBehavior>();
            if (otherBubble != null && otherBubble._shooter != _shooter)
            {
                Pop(); // Estoura a bolha somente se for de outro jogador
            }
        }
    }

    private async void Pop()
    {
        Debug.Log("Pop");
        Destroy(gameObject);
    }
}

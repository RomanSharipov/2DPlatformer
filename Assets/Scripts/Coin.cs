using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Coin : MonoBehaviour
{
    [SerializeField] private float _secondsBetweenSpawn;

    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_secondsBetweenSpawn);
        _spriteRenderer.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            if (_spriteRenderer.enabled == true)
            {
                player.AddCoin();
                _spriteRenderer.enabled = false;
                StartCoroutine(Spawn());
            }
        }
    }
}

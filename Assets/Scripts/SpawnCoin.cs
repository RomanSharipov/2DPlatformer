using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private GameObject _templateCoin;

    private GameObject _coin;

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_secondsBetweenSpawn);
        var newCoin = Instantiate(_templateCoin, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        newCoin.transform.parent = gameObject.transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerOptions>(out PlayerOptions player))
        {
            if (gameObject.transform.childCount != 0)
            {
                _coin = gameObject.transform.GetChild(0).gameObject;
                Destroy(_coin);
                StartCoroutine(Spawn());
                player.AddCoin();
            }
        }
    }
}

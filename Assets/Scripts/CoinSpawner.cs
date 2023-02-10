using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private GameObject _coinSpawners;

    private WaitForSeconds _delay = new WaitForSeconds(10f);

    private void Start()
    {
        StartCoroutine(SpawningCoins());
    }

    private IEnumerator SpawningCoins()
    {
        while (true)
        {
            if (!_coin.gameObject.activeSelf)
                _coin.gameObject.SetActive(true);

            yield return _delay;
        }
    }
}
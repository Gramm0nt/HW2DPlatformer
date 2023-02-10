using UnityEngine;

public class CoinTaker : MonoBehaviour
{
    public delegate void CoinTake();

    public event CoinTake CoinTook;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            CoinTook?.Invoke();
            collision.gameObject.SetActive(false);
        }
    }
}
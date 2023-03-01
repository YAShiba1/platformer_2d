using UnityEngine;

public class Gem : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            gameObject.SetActive(false);
        }
    }
}

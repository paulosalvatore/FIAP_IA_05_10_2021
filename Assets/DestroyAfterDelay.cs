using UnityEngine;
public class DestroyAfterDelay : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private float delay;

    private void Awake()
    {
        Destroy(gameObject, delay);
    }
}

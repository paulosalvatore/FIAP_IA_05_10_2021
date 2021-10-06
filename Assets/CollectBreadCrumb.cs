using UnityEngine;
public class CollectBreadCrumb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("BreadCrumbAgent"))
        {
            return;
        }

        Destroy(gameObject);
    }
}

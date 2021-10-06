using UnityEngine;
public class GenerateCrumbs : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private GameObject breadCrumbPrefab;

    [Header("Config")]
    [Tooltip("The minimum distance to generate a bread crumb.")]
    [SerializeField]
    private float minDistanceToGenerateBreadCrumb = 3f;

    private Vector3 _lastBreadCrumbPosition;

    private void Start()
    {
        _lastBreadCrumbPosition = transform.position;
    }

    private void Update()
    {
        var distance = Vector3.Distance(_lastBreadCrumbPosition, transform.position);

        if (distance >= minDistanceToGenerateBreadCrumb)
        {
            GenerateCrumb();
        }
    }
    private void GenerateCrumb()
    {
        Instantiate(breadCrumbPrefab, transform.position, Quaternion.identity);

        _lastBreadCrumbPosition = transform.position;
    }
}

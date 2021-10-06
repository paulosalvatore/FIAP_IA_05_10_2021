using System.Linq;
using UnityEngine;
using UnityEngine.AI;
public class FollowBreadCrumbs : MonoBehaviour
{
    [Header("Config")]
    [Range(0, 50)]
    [SerializeField]
    private float fieldOfView = 5f;

    [Header("Components")]
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    private void Update()
    {
        // Obtemos todas as breadcrumbs que estão no jogo (pela tag)
        var breadCrumbs = GameObject.FindGameObjectsWithTag("BreadCrumb");

        // Filtramos apenas as bread crumbs que estão próximas (de acordo com nosso campo de visão)
        var breadCrumbsOnFieldOfView = breadCrumbs.Where(breadCrumb =>
        {
            var distance = Vector3.Distance(breadCrumb.transform.position, transform.position);

            var isOnFieldOfView = distance <= fieldOfView;

            return isOnFieldOfView;
        }).ToArray();

        // Checamos se a quantidade de breadcrumbs próximas é igual a zero
        if (breadCrumbsOnFieldOfView.Length == 0)
        {
            // Se for, retornamos o método
            // Retornar em um método, significa que ele encerrará a sua execução
            return;
        }

        // Pegar uma das migalhas
        // var breadCrumb = breadCrumbsOnFieldOfView[0];

        // Pega a migalha mais próxima
        var closestBreadCrumb = GetClosestBreadCrumb(breadCrumbsOnFieldOfView);

        if (closestBreadCrumb == null)
        {
            return;
        }

        // Definimos a posição destino do NavMeshAgent como sendo a posição da migalha
        navMeshAgent.destination = closestBreadCrumb.transform.position;
    }
    private GameObject GetClosestBreadCrumb(GameObject[] breadCrumbs)
    {
        // Bônus
        return breadCrumbs.Aggregate((checkBreadCrumb, closestBreadCrumb) =>
        {
            var closestDistance = Vector3.Distance(closestBreadCrumb.transform.position, transform.position);

            var checkDistance = Vector3.Distance(checkBreadCrumb.transform.position, transform.position);

            return checkDistance < closestDistance ? checkBreadCrumb : closestBreadCrumb;
        });

        // GameObject closestBreadCrumb = null;
        //
        // foreach (var checkBreadCrumb in breadCrumbs)
        // {
        //     if (closestBreadCrumb == null)
        //     {
        //         closestBreadCrumb = checkBreadCrumb;
        //     }
        //     else
        //     {
        //         var closestDistance = Vector3.Distance(closestBreadCrumb.transform.position, transform.position);
        //
        //         var checkDistance = Vector3.Distance(checkBreadCrumb.transform.position, transform.position);
        //
        //         if (checkDistance < closestDistance)
        //         {
        //             closestBreadCrumb = checkBreadCrumb;
        //         }
        //     }
        // }
        //
        // return closestBreadCrumb;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, fieldOfView);
    }
}

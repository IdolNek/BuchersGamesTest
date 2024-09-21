using System.Collections.Generic;
using CodeBase.GamePlay.Levels;
using UnityEngine;

namespace ButchersGames
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private List<PivotPoint> pivotPoints; // <PivotPoint>

        public Transform PlayerSpawnPoint => playerSpawnPoint;

        public List<PivotPoint> PivotPoints => pivotPoints;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (PlayerSpawnPoint != null)
        {
            Gizmos.color = Color.magenta;
            var m = Gizmos.matrix;
            Gizmos.matrix = PlayerSpawnPoint.localToWorldMatrix;
            Gizmos.DrawSphere(Vector3.up * 0.5f + Vector3.forward, 0.5f);
            Gizmos.DrawCube(Vector3.up * 0.5f, Vector3.one);
            Gizmos.matrix = m;
        }
    }
#endif
    }
}
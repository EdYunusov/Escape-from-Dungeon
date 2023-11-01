using UnityEngine;


namespace Maze2Dgame
{
    public class LevelBoundaryLimited : MonoBehaviour
    {


        void Update()
        {
            if (LevelBoundary.Instance == null) return;

            var lb = LevelBoundary.Instance;
            var radius = LevelBoundary.Instance.Radius;

            if (transform.position.magnitude > radius)
            {
                if(lb.LimitMode == LevelBoundary.Mode.Limit)
                {
                    transform.position = transform.position.normalized * radius;
                }

                if (lb.LimitMode == LevelBoundary.Mode.Teleport)
                {
                    transform.position = - transform.position.normalized * radius;
                }
            }
        }
    }
}


using UnityEngine;

namespace MirzaBeig
{
    namespace ParticleSystems
    {
        public class Billboard : MonoBehaviour
        {
            void LateUpdate()
            {
                transform.LookAt(Camera.main.transform.position);
            }
        }
    }

}


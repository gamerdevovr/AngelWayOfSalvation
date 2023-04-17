using AngelWayOfSalvation.Core.Input;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Character
{
    public class CharacterController : MonoBehaviour
    {
        private Character _character;

        private void Start()
        {
            _character = GetComponent<Character>();
        }

        private void Update()
        {

        }
    }
}

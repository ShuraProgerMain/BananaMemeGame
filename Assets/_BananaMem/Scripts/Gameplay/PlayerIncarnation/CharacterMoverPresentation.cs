using ShuraGames.BananaMeme.Gameplay.CharacterComponents;
using ShuraGames.BananaMeme.Gameplay.CharactersData;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShuraGames.BananaMeme.Gameplay.PlayerIncarnation
{
    internal sealed class CharacterMoverPresentation
    {

        private Vector2 _moveDirection;
        
        private readonly MoveCalculator _moveCalculator;
        private readonly CharacterPresentationData _presentationData;

        public CharacterMoverPresentation(MoveCalculator moveCalculator, CharacterPresentationData presentationData)
        {
            _moveCalculator = moveCalculator;
            _presentationData = presentationData;
        }
        
        public void Move(float speed)
        {
            _presentationData.transform.position += _moveCalculator.Move(_moveDirection, _presentationData.transform, 
                speed, Time.deltaTime);           
        }
        
        internal void OnVelocityOnPerformed(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }

        internal void OnVelocityOnCanceled(InputAction.CallbackContext _)
        {
            _moveDirection = Vector2.zero;
        }

        public void UpdatePresentationPosition(Vector3 position)
        {
            _presentationData.transform.position = position;
        }
    }
}
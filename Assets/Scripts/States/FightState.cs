using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CrossFates
{
    public class FightState : BaseState
    {
        private float _retreatDistance;
        private float _offensiveDistance;
        private Action _shoot;
        private FieldOfView _fieldOfView;

        public FightState(Enemy stateMachine, Action shoot) : base(stateMachine)
        {
            _retreatDistance = stateMachine.RetreatDistance;
            _offensiveDistance = stateMachine.OffensiveDistance;
            _fieldOfView = stateMachine.FieldOfView;
            _shoot = shoot;
        }

        public override void Enter()
        {
            Debug.Log("Another Test Subject");
        }

        public override void UpdateLogic()
        {
            _stateMachine.Facing.CheckDirection(_targetTransform.position - _transform.position);

            if (DistanceToCharacter >= _offensiveDistance)
            {
                _stateMachine.SwitchState<OffensiveState>();
            }
            else if (DistanceToCharacter <= _retreatDistance)
            {
                _stateMachine.SwitchState<RetreatState>();
            }
            else if (!_fieldOfView.VisibleTargets.Contains(_targetTransform))
            {
                _stateMachine.LastTargetPosition = _targetTransform.position;
                _stateMachine.SwitchState<SearchState>();
            }
            _shoot.Invoke();

        }

    }

}
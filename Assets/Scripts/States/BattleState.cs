using System.Linq;

namespace CrossFates
{
    public class BattleState : BaseState
    {
        private FieldOfView _fieldOfView;
        public BattleState(Enemy stateMachine) : base(stateMachine)
        {
            _fieldOfView = stateMachine.FieldOfView;
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            if (!_fieldOfView.VisibleTargets.Contains(_targetTransform))
            {
                _stateMachine.LastTargetPosition = _targetTransform.position;
                _stateMachine.SwitchState<SearchState>();
            }
        }
    }
}

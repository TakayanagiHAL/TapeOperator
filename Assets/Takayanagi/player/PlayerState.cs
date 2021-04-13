using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

namespace Player.State{
    public class Running: Framework.State.StateBase<playercontroller>
    {
        public override void OnEnter(playercontroller obj)
        {
            base.OnEnter(obj);

            obj.animator.SetInteger("NowState", 2);

            Debug.Log("is run");
        }

        public override void OnExit(playercontroller obj)
        {
            base.OnExit(obj);
        }

        public override Framework.State.StateBase<playercontroller> OnUpdate(playercontroller obj) {
            if (obj.isJump)
            {
                return new Jumping();
            }
            if (obj.isClimb)
            {
                return new Climbing();
            }
            if (obj.Direction < 0.001f && obj.Direction > -0.001f)
            {
                return new Idle();
            }
            else
            {
                return this;
            }
        }
    }

    public class Idle : Framework.State.StateBase<playercontroller>
    {
        public override void OnEnter(playercontroller obj)
        {
            base.OnEnter(obj);
            //obj.animator.SetInteger("NowState", 0);
            Debug.Log("is idle");
        }

        public override void OnExit(playercontroller obj)
        {
            base.OnExit(obj);
        }

        public override Framework.State.StateBase<playercontroller> OnUpdate(playercontroller obj)
        {
            if (obj.isJump)
            {
                return new Jumping();
            }
            if (obj.isClimb)
            {
                return new Climbing();
            }
            if (obj.Direction < 0.001f && obj.Direction > -0.001f)
            {
                return this;
            }
            else
            {
                return new Running();
            }
        }
    }

    public class Climbing : Framework.State.StateBase<playercontroller>
    {
        public override void OnEnter(playercontroller obj)
        {
            base.OnEnter(obj);
            obj.animator.SetInteger("NowState", 3);
            Debug.Log("is climb");
        }

        public override void OnExit(playercontroller obj)
        {
            base.OnExit(obj);
        }

        public override Framework.State.StateBase<playercontroller> OnUpdate(playercontroller obj)
        {
            if (obj.isJump)
            {
                return new Jumping();
            }
            if (obj.isClimb)
            {
                return this;
            }
            if (obj.Direction < 0.001f && obj.Direction > -0.001f)
            {
                return new Idle();
            }
            else
            {
                return new Running();
            }
        }
    }

    public class Jumping : Framework.State.StateBase<playercontroller>
    {
        public override void OnEnter(playercontroller obj)
        {
            base.OnEnter(obj);
            obj.animator.SetInteger("NowState", 1);

            Debug.Log("is jump");
        }

        public override void OnExit(playercontroller obj)
        {
            base.OnExit(obj);
        }

        public override Framework.State.StateBase<playercontroller> OnUpdate(playercontroller obj)
        {
            if (obj.isJump)
            {
                return this;
            }
            if (obj.isClimb)
            {
                return new Climbing();
            }
            if (obj.Direction < 0.001f && obj.Direction > -0.001f)
            {
                return new Idle();
            }
            else
            {
                return new Running();
            }
        }
    }

  
}
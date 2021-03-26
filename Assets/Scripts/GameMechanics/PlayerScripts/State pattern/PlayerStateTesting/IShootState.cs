using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootState
{
    void Tick();
    void Enter();
    void Exit();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    IPlayerState Tick(Player player, Input input);
    void Enter(Player player);
    void Exit(Player player);
}

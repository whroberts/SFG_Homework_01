using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase
{
    [SerializeField] float _speedAmount = .25f;
    [SerializeField] float _duration = 2f;

    float _originalSpeed;

    protected override void Collect(Player player)
    {
        // pull motor controller from the player at increase speed for limited time
        StartCoroutine(SpeedUp(player, _duration));
        
    }

    private IEnumerator SpeedUp(Player player, float speedUpLength)
    {
        TankController controller = player.GetComponent<TankController>();

        if (controller != null)
        {
            _originalSpeed = controller.MaxSpeed;
            controller.MaxSpeed += _speedAmount;
        }

        yield return new WaitForSeconds(speedUpLength);

        controller.MaxSpeed = _originalSpeed;
    }
}

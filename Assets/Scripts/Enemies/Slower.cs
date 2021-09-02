using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : Enemy
{
    [SerializeField] float _slowAmount = 0.125f;

    //added global variable to retain original speed of tank
    float originalSpeed;

    protected override void PlayerImpact(Player player)
    {
        //calls the coroutine
        StartCoroutine(Slow(player, 2f));
    }
    private IEnumerator Slow(Player player, float slowDownLength)
    {
        TankController controller = player.GetComponent<TankController>();

        //checks for null
        if (controller != null)
        {
            //stores original speed
            originalSpeed = controller.MaxSpeed;
            //lowers the MaxSpeed of the tank
            controller.MaxSpeed -= _slowAmount;
        }

        //waits for a defined time
        yield return new WaitForSeconds(slowDownLength);

        //sets the MaxSpeed back to original value
        controller.MaxSpeed = originalSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowersUp/SpeedDownBuff")]
public class SpeedDownBuff : PowerUpEffect
{
    public float amount;
    public float duration;

    public override void Apply(GameObject target)
    {
        PlayerController playerController = target.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.StartCoroutine(ApplySpeedBuff(playerController));
        }
        else
        {
            Debug.LogError("No PlayerController component found on target.");
        }
    }

    private IEnumerator ApplySpeedBuff(PlayerController playerController)
    {
        playerController.speed -= amount;
        playerController.GetComponent<SpriteRenderer>().color = Color.yellow;

        yield return new WaitForSeconds(duration);

        playerController.speed += amount;
        playerController.GetComponent<SpriteRenderer>().color = Color.white;
    }
}

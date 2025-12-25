using System.Collections;
using UnityEngine;

public class AddShieldEffect : ICardEffect
{
    private int value;

    public AddShieldEffect(int value)
    {
        this.value = value;
    }

    public IEnumerator Execute(GameManager gameController)
    {
        gameController.AddPlayerShield(value);
        yield return null;
    }
}

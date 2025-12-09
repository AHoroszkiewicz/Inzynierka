public class EnemyHPManager : HPManager
{
    public override void Register()
    {
        GameController.Instance.RegisterEnemyHP(this);
    }
}

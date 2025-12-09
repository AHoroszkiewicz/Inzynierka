public class PlayerHPManager : HPManager
{
    public override void Register()
    {
        GameController.Instance.RegisterPlayerHP(this);
    }
}

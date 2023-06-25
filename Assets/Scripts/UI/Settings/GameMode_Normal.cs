namespace TDShooter.UI
{
    public class GameMode_Normal : GameMode
    {
        public override void SetParams()
        {
            RatioGameMode = 1.2f;
            base.SetParams();
        }
    }
}
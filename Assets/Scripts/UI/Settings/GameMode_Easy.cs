namespace TDShooter.UI
{
    public class GameMode_Easy : GameMode
    {
        public override void SetParams()
        {
            RatioGameMode = 1f;
            base.SetParams();
        }
    }
}